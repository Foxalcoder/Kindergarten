using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Kindergarten
{
    public partial class EditScheduleForm : Form
    {
        private readonly string connectionString;
        private int scheduleId; // ID записи расписания
        private int groupId;    // ID группы
        private List<Group> _groups;

        // Событие, которое будет срабатывать после успешного сохранения данных
        public event EventHandler DataSaved;



        public EditScheduleForm(int scheduleId, int groupId, string weekday = null, string subject = null, string startTime = null, string endTime = null)
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["KindergartenDB"].ConnectionString;

            this.scheduleId = scheduleId; // Правильно инициализируем scheduleId
            this.groupId = groupId;       // Инициализируем groupId

            LoadGroupsIntoComboBox();
            InitializeWeekdayComboBox();

            // Устанавливаем значения по умолчанию для времени
            textBoxStartTime.Text = startTime ?? "08:30";
            textBoxEndTime.Text = endTime ?? "19:30";

            // Заполняем поля переданными данными
            comboBoxGroup.SelectedValue = groupId;
            if (weekday != null)
            {
                comboBoxWeekday.SelectedItem = weekday;
            }
            if (subject != null)
            {
                textBoxSubject.Text = subject;
            }
        }

        private DataTable FormatSchedule(DataTable sourceTable)
        {
            // Создаем новую таблицу для отформатированных данных
            DataTable formattedTable = new DataTable();

            // Добавляем колонку для времени
            formattedTable.Columns.Add("Время", typeof(string));

            // Добавляем колонки для каждого дня недели
            string[] weekdays = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница" };
            foreach (string day in weekdays)
            {
                formattedTable.Columns.Add(day, typeof(string));
            }

            // Группируем данные по времени
            var timeSlots = sourceTable.AsEnumerable()
                .Select(row => new
                {
                    StartTime = row.Field<TimeSpan>("start_time"),
                    EndTime = row.Field<TimeSpan>("end_time")
                })
                .Distinct()
                .OrderBy(slot => slot.StartTime);

            // Заполняем таблицу
            foreach (var slot in timeSlots)
            {
                // Создаем новую строку
                DataRow newRow = formattedTable.NewRow();
                newRow["Время"] = $"{slot.StartTime:hh\\:mm} - {slot.EndTime:hh\\:mm}";

                // Заполняем данные для каждого дня недели
                foreach (string day in weekdays)
                {
                    var subject = sourceTable.AsEnumerable()
                        .FirstOrDefault(row => row.Field<string>("weekday") == day &&
                                               row.Field<TimeSpan>("start_time") == slot.StartTime &&
                                               row.Field<TimeSpan>("end_time") == slot.EndTime)?
                        .Field<string>("subject");

                    newRow[day] = subject ?? string.Empty; // Если данных нет, оставляем пустую строку
                }

                formattedTable.Rows.Add(newRow);
            }

            return formattedTable;
        }

        private void LoadGroupsIntoComboBox()
        {
            try
            {
                _groups = GetGroupsFromDatabase();
                comboBoxGroup.DataSource = _groups;
                comboBoxGroup.DisplayMember = "Name";
                comboBoxGroup.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Group> GetGroupsFromDatabase()
        {
            List<Group> groups = new List<Group>();
            try
            {
                string query = "SELECT id, name FROM groups";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        groups.Add(new Group { Id = reader.GetInt32(0), Name = reader.GetString(1) });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке групп: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return groups;
        }

        private void InitializeWeekdayComboBox()
        {
            comboBoxWeekday.Items.AddRange(new string[] { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница" });
        }

        private bool ValidateTime(string startTime, string endTime)
        {
            if (!TimeSpan.TryParse(startTime, out TimeSpan start) || !TimeSpan.TryParse(endTime, out TimeSpan end))
            {
                MessageBox.Show("Некорректный формат времени.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (start < TimeSpan.Parse("08:30") || end > TimeSpan.Parse("19:30") || end <= start)
            {
                MessageBox.Show("Некорректное время.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSubject_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxStartTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxEndTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxWeekday_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем данные из формы
                int groupId = (int)comboBoxGroup.SelectedValue;
                string weekday = comboBoxWeekday.SelectedItem?.ToString() ?? "";
                string subject = textBoxSubject.Text;
                string startTime = textBoxStartTime.Text;
                string endTime = textBoxEndTime.Text;

                // Проверяем, что все поля заполнены
                if (string.IsNullOrEmpty(weekday) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(startTime) || string.IsNullOrEmpty(endTime))
                {
                    MessageBox.Show("Заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Проверяем корректность времени
                if (!ValidateTime(startTime, endTime))
                {
                    return;
                }

                // Обновляем данные в базе данных
                UpdateScheduleInDatabase(scheduleId, groupId, weekday, startTime, endTime, subject);

                // Вызываем событие после успешного сохранения
                OnDataSaved();

                MessageBox.Show("Данные успешно обновлены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateScheduleInDatabase(int scheduleId, int groupId, string weekday, string startTime, string endTime, string subject)
        {
            string query = @"
    UPDATE schedule 
    SET group_id = @groupId, 
        weekday = @weekday, 
        start_time = @startTime, 
        end_time = @endTime, 
        subject = @subject
    WHERE id = @scheduleId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@groupId", groupId);
                command.Parameters.AddWithValue("@weekday", weekday);
                command.Parameters.AddWithValue("@startTime", startTime);
                command.Parameters.AddWithValue("@endTime", endTime);
                command.Parameters.AddWithValue("@subject", subject);
                command.Parameters.AddWithValue("@scheduleId", scheduleId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    MessageBox.Show("Запись не найдена или не обновлена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        protected virtual void OnDataSaved()
        {
            DataSaved?.Invoke(this, EventArgs.Empty);
        }

        public class Group
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}