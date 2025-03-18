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
using System.Windows.Forms.VisualStyles;

namespace Kindergarten
{
    public partial class FormScheduleAdd : Form
    {
        private List<Group> _groups;
        private readonly string connectionString;

        // Событие, которое будет срабатывать после успешного сохранения данных
        public event EventHandler DataSaved;
        public FormScheduleAdd()
        {
           
            
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["KindergartenDB"].ConnectionString;
            LoadGroupsIntoComboBox();
            InitializeWeekdayComboBox(); // Инициализируем ComboBox с днями недели

            // Устанавливаем значения по умолчанию для времени
            textBoxStartTime.Text = "08:30";
            textBoxEndTime.Text = "19:30";
        }

        private void LoadGroupsIntoComboBox()
        {
            try
            {
                _groups = GetGroupsFromDatabase();
                comboBoxGroup.DataSource = _groups;
                comboBoxGroup.DisplayMember = "Name"; // Отображаем только название группы
                comboBoxGroup.ValueMember = "Id";     // Значение — это Id группы
                comboBoxGroup.SelectedIndexChanged += comboBoxGroup_SelectedIndexChanged;
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
                        groups.Add(new Group
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
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
            // Добавляем дни недели в ComboBox
            comboBoxWeekday.Items.AddRange(new string[] { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница" });

            // Получаем текущий день недели
            DayOfWeek today = DateTime.Now.DayOfWeek;

            // Сопоставляем DayOfWeek с названиями дней
            switch (today)
            {
                case DayOfWeek.Monday:
                    comboBoxWeekday.SelectedIndex = 0; // Понедельник
                    break;
                case DayOfWeek.Tuesday:
                    comboBoxWeekday.SelectedIndex = 1; // Вторник
                    break;
                case DayOfWeek.Wednesday:
                    comboBoxWeekday.SelectedIndex = 2; // Среда
                    break;
                case DayOfWeek.Thursday:
                    comboBoxWeekday.SelectedIndex = 3; // Четверг
                    break;
                case DayOfWeek.Friday:
                    comboBoxWeekday.SelectedIndex = 4; // Пятница
                    break;
                default:
                    // Если сегодня выходной (суббота или воскресенье)
                    comboBoxWeekday.Items.Add("Выходной"); // Добавляем пункт "Выходной"
                    comboBoxWeekday.SelectedIndex = comboBoxWeekday.Items.Count - 1; // Выбираем его
                    break;
            }
        }

        private bool ValidateTime(string startTime, string endTime)
        {
            // Преобразуем строки в TimeSpan
            if (!TimeSpan.TryParse(startTime, out TimeSpan start) || !TimeSpan.TryParse(endTime, out TimeSpan end))
            {
                MessageBox.Show("Некорректный формат времени. Используйте формат HH:mm.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Проверяем, что время начала не раньше 08:30
            if (start < TimeSpan.Parse("08:30"))
            {
                MessageBox.Show("Время начала не может быть раньше 08:30.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Проверяем, что время окончания не позже 19:30
            if (end > TimeSpan.Parse("19:30"))
            {
                MessageBox.Show("Время окончания не может быть позже 19:30.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Проверяем, что время окончания больше времени начала
            if (end <= start)
            {
                MessageBox.Show("Время окончания должно быть больше времени начала.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем выбранную группу
                if (comboBoxGroup.SelectedItem == null)
                {
                    MessageBox.Show("Выберите группу.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int groupId = (int)comboBoxGroup.SelectedValue; // Id выбранной группы

                // Получаем данные из текстовых полей
                string startTime = textBoxStartTime.Text;
                string endTime = textBoxEndTime.Text;
                string weekday = comboBoxWeekday.SelectedItem?.ToString(); // День недели
                string subject = textBoxSubject.Text;

                // Проверяем, что все поля заполнены
                if (string.IsNullOrEmpty(startTime) || string.IsNullOrEmpty(endTime) || string.IsNullOrEmpty(weekday) || string.IsNullOrEmpty(subject))
                {
                    MessageBox.Show("Заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Проверяем корректность времени
                if (!ValidateTime(startTime, endTime))
                {
                    return; // Если время некорректно, выходим
                }

                // Сохраняем данные в базу данных
                SaveScheduleToDatabase(groupId, weekday, startTime, endTime, subject);

                // Вызываем событие после успешного сохранения
                OnDataSaved();

                MessageBox.Show("Данные успешно сохранены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод для вызова события
        protected virtual void OnDataSaved()
        {
            DataSaved?.Invoke(this, EventArgs.Empty);
        }

        private void SaveScheduleToDatabase(int groupId, string weekday, string startTime, string endTime, string subject)
        {
            string query = @"
            INSERT INTO schedule (group_id, weekday, start_time, end_time, subject)
            VALUES (@groupId, @weekday, @startTime, @endTime, @subject)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@groupId", groupId);
                command.Parameters.AddWithValue("@weekday", weekday);
                command.Parameters.AddWithValue("@startTime", startTime);
                command.Parameters.AddWithValue("@endTime", endTime);
                command.Parameters.AddWithValue("@subject", subject);

                connection.Open();
                command.ExecuteNonQuery();
            }
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

        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxWeekday_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

