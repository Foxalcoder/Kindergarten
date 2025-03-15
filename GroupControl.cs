using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class GroupControl : UserControl
    {
        private List<Group> _groups;
        private readonly string connectionString;

        public GroupControl()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["KindergartenDB"].ConnectionString;
            LoadGroupsIntoComboBox();
            LoadStatusesIntoComboBox(); // Загружаем статусы

            //Делаем dateTimePicker неактивными по умолчанию
            dateTimePickerStart.Enabled = false;
            dateTimePickerEnd.Enabled = false;

            // Делаем ComboBox неактивными по умолчанию
            comboBoxChildName.Enabled = false;
            comboBoxStatus.Enabled = false;

            // Подключаем обработчик события к кнопке
            buttonEditTeacher.Click += buttonEditTeacher_Click;
        }

        private void LoadGroupsIntoComboBox()
        {
            try
            {
                _groups = GetGroupsFromDatabase();
                comboBoxGroup.DataSource = _groups;
                comboBoxGroup.DisplayMember = "Name";
                comboBoxGroup.ValueMember = "Id";
                comboBoxGroup.SelectedIndexChanged += comboBoxGroup_SelectedIndexChanged_1;
                comboBoxGroup.SelectedIndexChanged -= comboBoxGroup_SelectedIndexChanged_1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Group> GetGroupsFromDatabase()
        {
            var groups = new List<Group>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(@"
                    SELECT 
                        g.id, 
                        g.name, 
                        g.age_range, 
                        g.assistant_id, 
                        g.teacher1_id, 
                        g.teacher2_id,
                        a.full_name AS assistant_name,
                        t1.full_name AS teacher1_name,
                        t2.full_name AS teacher2_name
                    FROM groups g
                    LEFT JOIN employees a ON g.assistant_id = a.id
                    LEFT JOIN employees t1 ON g.teacher1_id = t1.id
                    LEFT JOIN employees t2 ON g.teacher2_id = t2.id", connection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    groups.Add(new Group
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Age_range = reader.GetString(2),
                        AssistantId = reader.GetInt32(3),
                        Teacher1Id = reader.GetInt32(4),
                        Teacher2Id = reader.GetInt32(5),
                        AssistantName = reader.IsDBNull(6) ? "Неизвестно" : reader.GetString(6),
                        Teacher1Name = reader.IsDBNull(7) ? "Неизвестно" : reader.GetString(7),
                        Teacher2Name = reader.IsDBNull(8) ? "Неизвестно" : reader.GetString(8)
                    });
                }
            }

            return groups;
        }

        private void comboBoxGroup_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBoxGroup.SelectedItem is Group selectedGroup)
            {
                // Отображаем информацию о группе
                DisplayGroupInfo(selectedGroup);

                // Загружаем и отображаем детей выбранной группы
                LoadChildrenIntoDataGridView(selectedGroup.Id);

                // Загружаем список детей в ComboBox
                LoadChildrenIntoComboBox(selectedGroup.Id);
            }
        }

        private void DisplayGroupInfo(Group group)
        {
            ClearGroupInfo();
            labelAge.Text = $"Возраст: {group.Age_range}";
            labelAssistantId.Text = $"Помощник: {group.AssistantName}";
            labelTeacher1Id.Text = $"Первый воспитатель: {group.Teacher1Name}";
            labelTeacher2Id.Text = $"Второй воспитатель: {group.Teacher2Name}";
        }

        private void ClearGroupInfo()
        {
            labelAge.Text = "Возраст: ";
            labelAssistantId.Text = "Помощник: ";
            labelTeacher1Id.Text = "Первый воспитатель: ";
            labelTeacher2Id.Text = "Второй воспитатель: ";
        }

        private void LoadChildrenIntoDataGridView(int groupId)
        {
            try
            {
                string query = @"
            WITH AttendanceData AS (
                SELECT 
                    c.id AS ChildId,
                    c.full_name AS FullName,
                    a.date AS Date,
                    a.status AS Status
                FROM children c
                LEFT JOIN attendance a 
                    ON c.id = a.child_id 
                    AND (
                        (@useFilters = 1 AND @dateStart IS NOT NULL AND a.date >= @dateStart)
                        OR 
                        (@useFilters = 1 AND @dateEnd IS NOT NULL AND a.date <= @dateEnd)
                        OR 
                        (@useFilters = 0 AND a.date = @today)
                    )
                WHERE c.group_id = @groupId
            )
            SELECT 
                ChildId,
                FullName,
                ISNULL(Date, @today) AS Date, 
                ISNULL(Status, '') AS Status
            FROM AttendanceData";

                // Получаем даты из фильтров
                DateTime? dateStart = checkBoxDateStart.Checked ? (DateTime?)dateTimePickerStart.Value.Date : null;
                DateTime? dateEnd = checkBoxDateEnd.Checked ? (DateTime?)dateTimePickerEnd.Value.Date : null;
                DateTime today = DateTime.Today;

                DataTable dataTable = new DataTable();

                bool useFilters = checkBoxDateStart.Checked || checkBoxDateEnd.Checked;

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@groupId", groupId);
                    adapter.SelectCommand.Parameters.AddWithValue("@dateStart", (object)dateStart ?? DBNull.Value);
                    adapter.SelectCommand.Parameters.AddWithValue("@dateEnd", (object)dateEnd ?? DBNull.Value);
                    adapter.SelectCommand.Parameters.AddWithValue("@today", today);
                    adapter.SelectCommand.Parameters.AddWithValue("@useFilters", useFilters ? 1 : 0);

                    connection.Open();
                    adapter.Fill(dataTable);
                }

                dataGridViewChildren.DataSource = dataTable;
                dataGridViewChildren.AutoGenerateColumns = true;
                dataGridViewChildren.Columns["ChildId"].Visible = false;
                dataGridViewChildren.Columns["FullName"].HeaderText = "ФИО ребенка";
                dataGridViewChildren.Columns["Date"].HeaderText = "Дата";
                dataGridViewChildren.Columns["Status"].HeaderText = "Статус";
                dataGridViewChildren.Columns["Date"].DefaultCellStyle.Format = "dd.MM.yyyy";

                ConfigureStatusColumn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureStatusColumn()
        {
            // Удаляем старый столбец "Status", если он существует
            if (dataGridViewChildren.Columns.Contains("Status"))
            {
                dataGridViewChildren.Columns.Remove("Status");
            }

            // Создаем выпадающий список для статусов
            DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
            statusColumn.HeaderText = "Статус";
            statusColumn.Name = "Status";
            statusColumn.DataPropertyName = "Status"; // Связываем с колонкой "Status" в DataTable
            statusColumn.Items.AddRange("Присутствует", "Отсутствует", "Болеет", "Неизвестно");

            // Добавляем новый столбец
            dataGridViewChildren.Columns.Add(statusColumn);
        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Обработка событий в DataGridView (если нужно)
        }
        private void UpdateDataGridView()
        {
            if (comboBoxGroup.SelectedItem is Group selectedGroup)
            {
                LoadChildrenIntoDataGridView(selectedGroup.Id);
            }
        }
        private void checkBoxDateStart_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerStart.Enabled = checkBoxDateStart.Checked;
            if (comboBoxGroup.SelectedItem is Group selectedGroup)
            {
                LoadChildrenIntoDataGridView(selectedGroup.Id);
            }
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            if (comboBoxGroup.SelectedItem is Group selectedGroup)
            {
                LoadChildrenIntoDataGridView(selectedGroup.Id);
            }
        }

        private void checkBoxDateEnd_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerEnd.Enabled = checkBoxDateEnd.Checked;
            if (comboBoxGroup.SelectedItem is Group selectedGroup)
            {
                LoadChildrenIntoDataGridView(selectedGroup.Id);
            }
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            if (comboBoxGroup.SelectedItem is Group selectedGroup)
            {
                LoadChildrenIntoDataGridView(selectedGroup.Id);
            }
        }

        private void checkBoxChild_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxChildName.Enabled = checkBoxChild.Checked;
            if (comboBoxGroup.SelectedItem is Group selectedGroup)
            {
                LoadChildrenIntoDataGridView(selectedGroup.Id);
            }
        }
        private void LoadChildrenIntoComboBox(int groupId)
        {
            try
            {
                string query = @"
            SELECT 
                c.id, 
                c.full_name AS FullName
            FROM children c
            WHERE c.group_id = @groupId
            ORDER BY c.full_name";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@groupId", groupId);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    comboBoxChildName.Items.Clear();

                    while (reader.Read())
                    {
                        comboBoxChildName.Items.Add(new
                        {
                            Id = reader.GetInt32(0),
                            FullName = reader.GetString(1)
                        });
                    }

                    comboBoxChildName.DisplayMember = "FullName";
                    comboBoxChildName.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке списка детей: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBoxChildName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxGroup.SelectedItem is Group selectedGroup)
            {
                LoadChildrenIntoDataGridView(selectedGroup.Id);
            }

        }

        private void checkBoxStatus_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxStatus.Enabled = checkBoxStatus.Checked;
            if (comboBoxGroup.SelectedItem is Group selectedGroup)
            {
                LoadChildrenIntoDataGridView(selectedGroup.Id);
            }
        }

        private void LoadStatusesIntoComboBox()
        {
            comboBoxStatus.Items.Clear();
            comboBoxStatus.Items.Add("Присутствует");
            comboBoxStatus.Items.Add("Отсутствует");
            comboBoxStatus.Items.Add("Болеет");
            comboBoxStatus.Items.Add("Неизвестно");

            comboBoxStatus.DisplayMember = "ToString"; // Отображаем текст статуса
        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxGroup.SelectedItem is Group selectedGroup)
            {
                LoadChildrenIntoDataGridView(selectedGroup.Id);
            }
        }

        private void buttonEditTeacher_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["EditTeacherForm"] == null)  // Проверка, открыта ли уже форма
            {
                EditTeacherForm form = new EditTeacherForm();
                form.Show();
            }
        }

        private void buttonSaveStatus_Click(object sender, EventArgs e)
        {
            try
            {
                var today = DateTime.Today;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            foreach (DataGridViewRow row in dataGridViewChildren.Rows)
                            {
                                if (row.Cells["ChildId"].Value != null && row.Cells["Status"].Value != null)
                                {
                                    int childId = Convert.ToInt32(row.Cells["ChildId"].Value);
                                    string status = row.Cells["Status"].Value.ToString();

                                    string query = @"
                                IF EXISTS (SELECT 1 FROM attendance WHERE child_id = @childId AND date = @date)
                                BEGIN
                                    UPDATE attendance 
                                    SET status = @status 
                                    WHERE child_id = @childId AND date = @date;
                                END
                                ELSE
                                BEGIN
                                    INSERT INTO attendance (child_id, date, status)
                                    VALUES (@childId, @date, @status);
                                END";

                                    using (SqlCommand command = new SqlCommand(query, connection, transaction))
                                    {
                                        command.Parameters.AddWithValue("@childId", childId);
                                        command.Parameters.AddWithValue("@date", today);
                                        command.Parameters.AddWithValue("@status", status);
                                        command.ExecuteNonQuery();
                                    }
                                }
                            }

                            transaction.Commit();
                            MessageBox.Show("Изменения сохранены успешно.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Ошибка при сохранении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                // Обновляем DataGridView
                if (comboBoxGroup.SelectedItem is Group selectedGroup)
                {
                    LoadChildrenIntoDataGridView(selectedGroup.Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class Group
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Age_range { get; set; }
            public int AssistantId { get; set; }
            public int Teacher1Id { get; set; }
            public int Teacher2Id { get; set; }
            public string AssistantName { get; set; }
            public string Teacher1Name { get; set; }
            public string Teacher2Name { get; set; }
        }
    }
}