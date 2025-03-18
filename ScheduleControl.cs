using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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
            
        }

        private void ConfigureDataGridView(bool isWeeklyView)
        {

            // Очищаем существующие колонки
            dataGridViewSchedule.Columns.Clear();

            if (isWeeklyView)
            {
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

                // Добавляем скрытую колонку для ID
                dataGridViewSchedule.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "ID",
                    DataPropertyName = "id",
                    ReadOnly = true,
                    Visible = false // Скрываем колонку, чтобы она не отображалась в интерфейсе
                });
            }
            else
            {
                // Добавляем колонки для всех полей таблицы
                dataGridViewSchedule.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "ID",
                    DataPropertyName = "ID",
                    ReadOnly = true
                });

                
                dataGridViewSchedule.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "День недели",
                    DataPropertyName = "День недели",
                    ReadOnly = true
                });

                dataGridViewSchedule.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Начало",
                    DataPropertyName = "Начало",
                    ReadOnly = true
                });

                dataGridViewSchedule.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Окончание",
                    DataPropertyName = "Окончание",
                    ReadOnly = true
                });

                dataGridViewSchedule.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Предмет",
                    DataPropertyName = "Предмет",
                    ReadOnly = true
                });
            }

            // Подписываемся на событие CellFormatting
            dataGridViewSchedule.CellFormatting += DataGridViewSchedule_CellFormatting;

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

        private void LoadSchedule(int groupId, string dayOfWeek = null)
        {
            try
            {
                dataGridViewSchedule.DataSource = null; // Очищаем перед загрузкой

                string query = @"
            SELECT 
                s.id, 
                s.weekday, 
                s.start_time, 
                s.end_time, 
                s.subject 
            FROM schedule s
            WHERE s.group_id = @groupId
            AND (@dayOfWeek IS NULL OR s.weekday = @dayOfWeek)
            ORDER BY s.start_time";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@groupId", groupId);
                    adapter.SelectCommand.Parameters.AddWithValue("@dayOfWeek", (object)dayOfWeek ?? DBNull.Value);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count == 0)
                        return; // Если данных нет, DataGridView уже очищен

                    // Форматируем данные
                    DataTable formattedTable = FormatSchedule(dataTable, dayOfWeek);
                    dataGridViewSchedule.DataSource = formattedTable;

                    // Настраиваем DataGridView в зависимости от выбранного режима
                    ConfigureDataGridView(dayOfWeek == null); // Передаем true, если dayOfWeek == null (неделя), иначе false
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке расписания: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable FormatSchedule(DataTable sourceTable, string dayOfWeek = null)
        {
            DataTable formattedTable = new DataTable();

            if (dayOfWeek == null)
            {
                // Форматирование для недели (оставляем без изменений)
                formattedTable.Columns.Add("Время", typeof(string));
                string[] weekdays = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница" };
                foreach (string day in weekdays)
                {
                    formattedTable.Columns.Add(day, typeof(string));
                }
                formattedTable.Columns.Add("id", typeof(int)); // Добавляем столбец "id"

                var timeSlots = sourceTable.AsEnumerable()
                    .Select(row => new
                    {
                        StartTime = row.Field<TimeSpan>("start_time"),
                        EndTime = row.Field<TimeSpan>("end_time")
                    })
                    .Distinct()
                    .OrderBy(slot => slot.StartTime);

                foreach (var slot in timeSlots)
                {
                    DataRow newRow = formattedTable.NewRow();
                    newRow["Время"] = $"{slot.StartTime:hh\\:mm} - {slot.EndTime:hh\\:mm}";

                    foreach (string day in weekdays)
                    {
                        var subject = sourceTable.AsEnumerable()
                            .FirstOrDefault(row => row.Field<string>("weekday") == day &&
                                                   row.Field<TimeSpan>("start_time") == slot.StartTime &&
                                                   row.Field<TimeSpan>("end_time") == slot.EndTime)?
                            .Field<string>("subject");

                        newRow[day] = subject ?? string.Empty;
                    }

                    var id = sourceTable.AsEnumerable()
                        .FirstOrDefault(row => row.Field<TimeSpan>("start_time") == slot.StartTime &&
                                               row.Field<TimeSpan>("end_time") == slot.EndTime)?
                        .Field<int>("id");

                    newRow["id"] = id ?? 0; // Заполняем столбец "id"
                    formattedTable.Rows.Add(newRow);
                }
            }
            else
            {
                // Форматирование для одного дня
                formattedTable.Columns.Add("ID", typeof(int)); // Столбец для id
                
                formattedTable.Columns.Add("День недели", typeof(string)); // Столбец для weekday
                formattedTable.Columns.Add("Начало", typeof(string)); // Столбец для start_time
                formattedTable.Columns.Add("Окончание", typeof(string)); // Столбец для end_time
                formattedTable.Columns.Add("Предмет", typeof(string)); // Столбец для subject

                var timeSlots = sourceTable.AsEnumerable()
                    .Select(row => new
                    {
                        Id = row.Field<int>("id"),
                        
                        Weekday = row.Field<string>("weekday"),
                        StartTime = row.Field<TimeSpan>("start_time"),
                        EndTime = row.Field<TimeSpan>("end_time"),
                        Subject = row.Field<string>("subject")
                    })
                    .OrderBy(slot => slot.StartTime);

                foreach (var slot in timeSlots)
                {
                    DataRow newRow = formattedTable.NewRow();
                    newRow["ID"] = slot.Id; // Заполняем столбец "ID"
                   
                    newRow["День недели"] = slot.Weekday; // Заполняем столбец "День недели"
                    newRow["Начало"] = slot.StartTime.ToString(@"hh\:mm"); // Форматируем время начала
                    newRow["Окончание"] = slot.EndTime.ToString(@"hh\:mm"); // Форматируем время окончания
                    newRow["Предмет"] = slot.Subject; // Заполняем столбец "Предмет"
                    formattedTable.Rows.Add(newRow);
                }
            }

            return formattedTable;
        }

        
        private void DataGridViewSchedule_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string today = GetDayOfWeekInRussian(DateTime.Now.DayOfWeek);

            if (today == null)
                return;

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnHeader = dataGridViewSchedule.Columns[e.ColumnIndex].HeaderText as string;

                if (columnHeader != null && columnHeader == today)
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.SelectionBackColor = Color.LightGreen;
                }
            }
        }

        private string GetDayOfWeekInRussian(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "Понедельник";
                case DayOfWeek.Tuesday:
                    return "Вторник";
                case DayOfWeek.Wednesday:
                    return "Среда";
                case DayOfWeek.Thursday:
                    return "Четверг";
                case DayOfWeek.Friday:
                    return "Пятница";
                default:
                    return null; // Для выходных дней
            }
        }

        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxGroup.SelectedIndex == -1 || comboBoxGroup.SelectedItem == null)
            {
                dataGridViewSchedule.DataSource = null;
                return;
            }

            if (comboBoxGroup.SelectedItem is DataRowView rowView && rowView["id"] != DBNull.Value)
            {
                int groupId = Convert.ToInt32(rowView["id"]);

                // Получаем текущий день недели
                string today = GetDayOfWeekInRussian(DateTime.Now.DayOfWeek);

                if (today == null)
                {
                    // Если сегодня выходной, выводим сообщение и очищаем DataGridView
                    MessageBox.Show("Сегодня выходной день. Расписание отсутствует.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewSchedule.DataSource = null;
                }
                else
                {
                    // Загружаем расписание на текущий день
                    LoadSchedule(groupId, today);
                }
            }

            dataGridViewSchedule.Invalidate();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["FormScheduleAdd"] == null)
            {
                FormScheduleAdd form = new FormScheduleAdd();

                form.DataSaved += (s, ev) =>
                {
                    if (comboBoxGroup.SelectedItem != null)
                    {
                        int groupId = (int)(comboBoxGroup.SelectedItem as DataRowView)["id"];
                        LoadSchedule(groupId);
                    }
                };

                form.Show();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {


            if (dataGridViewSchedule.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запись для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем выбранную строку
            DataGridViewRow selectedRow = dataGridViewSchedule.SelectedRows[0];

            // Проверяем, что значение в ячейке "Id" не равно null
            if (selectedRow.Cells["Id"].Value == null || selectedRow.Cells["Id"].Value == DBNull.Value)
            {
                MessageBox.Show("Не удалось получить ID записи.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Безопасно преобразуем значение в int
            if (!int.TryParse(selectedRow.Cells["Id"].Value?.ToString(), out int scheduleId))
            {
                MessageBox.Show("Некорректный ID записи.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Получаем остальные данные
            int groupId = (int)(comboBoxGroup.SelectedItem as DataRowView)["Id"];
            string weekday = selectedRow.Cells["День недели"].Value?.ToString();
            string subject = selectedRow.Cells["Предмет"].Value?.ToString();
            string startTime = selectedRow.Cells["Начало"].Value?.ToString();
            string endTime = selectedRow.Cells["Окончание"].Value?.ToString();

            // Открываем форму редактирования
            EditScheduleForm editForm = new EditScheduleForm(scheduleId, groupId, weekday, subject, startTime, endTime);
            editForm.DataSaved += (s, ev) =>
            {
                // Обновляем данные в DataGridView после сохранения
                LoadSchedule(groupId, weekday);
            };
            editForm.ShowDialog();

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewSchedule.Rows.Count || dataGridViewSchedule.Rows[e.RowIndex].IsNewRow)
                return;
        }

        private void pictureBoxUpdate_Click(object sender, EventArgs e)
        {
            if (comboBoxGroup.SelectedItem is DataRowView rowView && rowView["id"] != DBNull.Value)
            {
                int groupId = Convert.ToInt32(rowView["id"]);
                LoadSchedule(groupId);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (comboBoxGroup.SelectedItem is DataRowView rowView && rowView["id"] != DBNull.Value)
            {
                int groupId = Convert.ToInt32(rowView["id"]);
                string dayOfWeek = GetDayOfWeekInRussian(dateTimePicker1.Value.DayOfWeek);

                if (dayOfWeek != null)
                {
                    LoadSchedule(groupId, dayOfWeek); // Загружаем расписание на выбранный день
                }
                else
                {
                    MessageBox.Show("Выбранный день является выходным.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttonWeek_Click(object sender, EventArgs e)
        {
            if (comboBoxGroup.SelectedItem is DataRowView rowView && rowView["id"] != DBNull.Value)
            {
                int groupId = Convert.ToInt32(rowView["id"]);
                LoadSchedule(groupId); // Загружаем расписание на всю неделю
            }
        }
    }
}