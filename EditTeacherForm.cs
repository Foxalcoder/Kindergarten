using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class EditTeacherForm : Form
    {
        private readonly string connectionString;

        public EditTeacherForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["KindergartenDB"].ConnectionString;
            LoadGroups();
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

        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxGroup.SelectedValue != null && comboBoxGroup.SelectedValue != DBNull.Value)
            {
                int groupId = Convert.ToInt32(comboBoxGroup.SelectedValue); // Получаем ID выбранной группы

                LoadTeachers(groupId); // Загружаем воспитателей для выбранной группы
            }
        }

        private void LoadTeachers(int groupId)
        {
           
        }

        private void comboBoxTeacher1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Обработка изменения выбора воспитателя (если нужно)
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}