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

namespace Kindergarten
{
    public partial class ScheduleControl : UserControl
    {
        private readonly string connectionString;

        public ScheduleControl()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["KindergartenDB"].ConnectionString;
            LoadGroups();
            ConfigureDataGridView();
        }

        private void LoadGroups()
        {
            try
            {
                string query = "SELECT id, name FROM groups";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    comboBoxGroup.DataSource = dataTable;
                    comboBoxGroup.DisplayMember = "name";
                    comboBoxGroup.ValueMember = "id";
                    comboBoxGroup.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке групп: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSchedule(int groupId)
        {
            try
            {
                dataGridViewSchedule.DataSource = null; // Очищаем перед загрузкой

                string query = @"
            SELECT 
                s.weekday, 
                s.start_time, 
                s.end_time, 
                s.subject 
            FROM schedule s
            WHERE s.group_id = @groupId
            ORDER BY s.start_time";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@groupId", groupId);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count == 0)
                        return; // Если данных нет, DataGridView уже очищен

                    // Форматируем данные
                    DataTable formattedTable = FormatSchedule(dataTable);
                    dataGridViewSchedule.DataSource = formattedTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке расписания: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ConfigureDataGridView()
        {
            // Настраиваем внешний вид DataGridView
            dataGridViewSchedule.AutoGenerateColumns = false;
            //dataGridViewSchedule.AllowUserToAddRows = false;
            dataGridViewSchedule.AllowUserToDeleteRows = false;
            dataGridViewSchedule.ReadOnly = true;

            // Очищаем существующие колонки
            dataGridViewSchedule.Columns.Clear();

            // Добавляем колонку для времени
            dataGridViewSchedule.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Время",
                DataPropertyName = "Время",
                ReadOnly = true
            });

            // Добавляем колонки для каждого дня недели
            string[] weekdays = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница" };
            foreach (string day in weekdays)
            {
                dataGridViewSchedule.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = day,
                    DataPropertyName = day,
                    ReadOnly = true
                });
            }

            // Подписываемся на событие CellFormatting
            dataGridViewSchedule.CellFormatting += DataGridViewSchedule_CellFormatting;
        }

        private void DataGridViewSchedule_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Получаем текущий день недели
            string today = DateTime.Now.DayOfWeek switch
            {
                DayOfWeek.Monday => "Понедельник",
                DayOfWeek.Tuesday => "Вторник",
                DayOfWeek.Wednesday => "Среда",
                DayOfWeek.Thursday => "Четверг",
                DayOfWeek.Friday => "Пятница",
                _ => null // Для выходных дней ничего не делаем
            };

            // Если сегодняшний день не определен (выходные), выходим
            if (today == null)
                return;

            // Проверяем, что это не заголовок строки и не заголовок столбца
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Получаем заголовок столбца
                string columnHeader = dataGridViewSchedule.Columns[e.ColumnIndex].HeaderText as string;

                // Если заголовок столбца совпадает с сегодняшним днем
                if (columnHeader != null && columnHeader == today)
                {
                    // Изменяем цвет фона ячейки
                    e.CellStyle.BackColor = Color.LightGreen; // Можно выбрать любой цвет
                    e.CellStyle.SelectionBackColor = Color.LightGreen; // Цвет при выделении
                }
            }
        }

        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Проверяем, что группа выбрана
            if (comboBoxGroup.SelectedIndex == -1 || comboBoxGroup.SelectedItem == null)
            {
                // Очищаем DataGridView, если группа не выбрана
                dataGridViewSchedule.DataSource = null;
                return;
            }

            // Получаем выбранную группу
            if (comboBoxGroup.SelectedItem is DataRowView rowView && rowView["id"] != DBNull.Value)
            {
                int groupId = Convert.ToInt32(rowView["id"]);
                LoadSchedule(groupId); // Загружаем расписание для выбранной группы
            }

            // Обновляем DataGridView
            dataGridViewSchedule.Invalidate();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Логика добавления записи
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // Логика редактирования записи
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Логика удаления записи
        }

        private void dataGridViewSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewSchedule.Rows.Count || dataGridViewSchedule.Rows[e.RowIndex].IsNewRow)
                return; // Предотвращаем выход за границы массива
        }
    }
}

