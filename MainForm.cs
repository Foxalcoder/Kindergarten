using System;
using System.Configuration;
using System.Data.SqlClient; // Для работы с SQL Server
using System.Windows.Forms;

namespace Kindergarten
{
    public partial class MainForm : Form
    {
        private bool isPanelCollapsed = true; // Состояние панели (свёрнута/развёрнута)
        private Timer timer1; // Таймер для анимации
        private const int panelWidth = 357; // Ширина панели в развёрнутом состоянии
        private const int animationStep = 10; // Шаг анимации
        private const int panelMinWidth = 70; // Минимальная ширина панели при закрытии

        // Строка подключения к базе данных
        private readonly string connectionString;

        public MainForm()
        {
            InitializeComponent();

            // Инициализация строки подключения из app.config
            connectionString = ConfigurationManager.ConnectionStrings["KindergartenDB"].ConnectionString;

            // Инициализация Timer
            timer1 = new Timer();
            timer1.Interval = 10; // Интервал в миллисекундах
            timer1.Tick += Timer1_Tick; // Подписываемся на событие Tick

            // Обработчик клика по PictureBox
            CloseOpenPicture.Click += CloseOpenPicture_Click; // Подписываемся на событие Click
        }

       
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (isPanelCollapsed)
            {
                // Закрываем панель (уменьшаем ширину)
                if (MainPanel.Width > panelMinWidth)
                {
                    MainPanel.Width -= animationStep;
                }
                else
                {
                    timer1.Stop(); // Останавливаем таймер, когда панель полностью закрыта
                    MainPanel.Width = panelMinWidth;
                }
            }
            else
            {
                // Открываем панель (увеличиваем ширину)
                if (MainPanel.Width < panelWidth)
                {
                    MainPanel.Width += animationStep;
                }
                else
                {
                    timer1.Stop(); // Останавливаем таймер, когда панель полностью открыта
                    MainPanel.Width = panelWidth;
                }
            }
        }

        private void CloseOpenPicture_Click(object sender, EventArgs e)
        {
            // Запуск анимации, только если таймер не активен
            if (!timer1.Enabled)
            {
                timer1.Start();
                isPanelCollapsed = !isPanelCollapsed; // Меняем состояние панели
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Проверка подключения к базе данных при загрузке формы
            try
            {
                var connectionStringSettings = ConfigurationManager.ConnectionStrings["KindergartenDB"];
                if (connectionStringSettings == null)
                {
                    MessageBox.Show("Строка подключения 'KindergartenDB' не найдена в app.config.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string connectionString = connectionStringSettings.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Подключение к базе данных успешно установлено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        private void ScheduleButton_Click_1(object sender, EventArgs e)
        {
            // Создание экземпляра UserControl для групп
            ScheduleControl groupControl = new ScheduleControl();

            // Добавление UserControl в MainPanel2
            AddUserControlToMainPanel2(groupControl);
        }

        private void AddUserControlToMainPanel2(UserControl userControl)
        {
            // Очистка MainPanel2 перед добавлением нового UserControl
            MainPanel2.Controls.Clear();

            // Настройка UserControl
            userControl.Dock = DockStyle.Fill; // Растягиваем UserControl на всю область MainPanel2

            // Добавление UserControl в MainPanel2
            MainPanel2.Controls.Add(userControl);
        }
        private void GroupButton_Click(object sender, EventArgs e)
        {

            // Создание экземпляра UserControl для групп
            GroupControl groupControl = new GroupControl();

            // Добавление UserControl в MainPanel2
            AddUserControlToMainPanel2(groupControl);
        }

        private void EventsButton_Click(object sender, EventArgs e)
        {

        }

        private void LessonButton_Click(object sender, EventArgs e)
        {

        }

        private void DirectoryButton_Click(object sender, EventArgs e)
        {

        }

        private void AdministrationButton_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}