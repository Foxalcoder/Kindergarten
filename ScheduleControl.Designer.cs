namespace Kindergarten
{
    partial class ScheduleControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.scheduleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kindergardenDataS = new Kindergarten.kindergardenDataS();
            this.scheduleTableAdapter = new Kindergarten.kindergardenDataSTableAdapters.scheduleTableAdapter();
            this.pictureBoxUpdate = new System.Windows.Forms.PictureBox();
            this.kindergardenDataSet2 = new Kindergarten.kindergardenDataSet2();
            this.scheduleBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.scheduleTableAdapter1 = new Kindergarten.kindergardenDataSet2TableAdapters.scheduleTableAdapter();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.buttonWeek = new System.Windows.Forms.Button();
            this.kindergardenDataSetSchedule1 = new Kindergarten.kindergardenDataSetSchedule();
            this.dataGridViewSchedule = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergardenDataS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergardenDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergardenDataSetSchedule1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxGroup.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxGroup.ForeColor = System.Drawing.Color.MidnightBlue;
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBoxGroup.Location = new System.Drawing.Point(4, 17);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(634, 42);
            this.comboBoxGroup.TabIndex = 1;
            this.comboBoxGroup.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroup_SelectedIndexChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold);
            this.buttonAdd.ForeColor = System.Drawing.Color.MidnightBlue;
            this.buttonAdd.Location = new System.Drawing.Point(3, 682);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(375, 49);
            this.buttonAdd.TabIndex = 14;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold);
            this.buttonDelete.ForeColor = System.Drawing.Color.MidnightBlue;
            this.buttonDelete.Location = new System.Drawing.Point(795, 682);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(374, 49);
            this.buttonDelete.TabIndex = 15;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.FlatAppearance.BorderSize = 0;
            this.buttonEdit.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold);
            this.buttonEdit.ForeColor = System.Drawing.Color.MidnightBlue;
            this.buttonEdit.Location = new System.Drawing.Point(402, 682);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(374, 49);
            this.buttonEdit.TabIndex = 16;
            this.buttonEdit.Text = "Изменить";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // scheduleBindingSource
            // 
            this.scheduleBindingSource.DataMember = "schedule";
            this.scheduleBindingSource.DataSource = this.kindergardenDataS;
            // 
            // kindergardenDataS
            // 
            this.kindergardenDataS.DataSetName = "kindergardenDataS";
            this.kindergardenDataS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // scheduleTableAdapter
            // 
            this.scheduleTableAdapter.ClearBeforeFill = true;
            // 
            // pictureBoxUpdate
            // 
            this.pictureBoxUpdate.Image = global::Kindergarten.Properties.Resources.free_icon_switch_arrows_9497023;
            this.pictureBoxUpdate.Location = new System.Drawing.Point(644, 17);
            this.pictureBoxUpdate.Name = "pictureBoxUpdate";
            this.pictureBoxUpdate.Size = new System.Drawing.Size(79, 42);
            this.pictureBoxUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxUpdate.TabIndex = 18;
            this.pictureBoxUpdate.TabStop = false;
            this.pictureBoxUpdate.Click += new System.EventHandler(this.pictureBoxUpdate_Click);
            // 
            // kindergardenDataSet2
            // 
            this.kindergardenDataSet2.DataSetName = "kindergardenDataSet2";
            this.kindergardenDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // scheduleBindingSource1
            // 
            this.scheduleBindingSource1.DataMember = "schedule";
            this.scheduleBindingSource1.DataSource = this.kindergardenDataSet2;
            // 
            // scheduleTableAdapter1
            // 
            this.scheduleTableAdapter1.ClearBeforeFill = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.LightBlue;
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.Color.Beige;
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.Color.LightBlue;
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.MidnightBlue;
            this.dateTimePicker1.CalendarTrailingForeColor = System.Drawing.Color.MidnightBlue;
            this.dateTimePicker1.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(785, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(337, 40);
            this.dateTimePicker1.TabIndex = 19;
            this.dateTimePicker1.Value = new System.DateTime(2025, 3, 18, 14, 42, 49, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // buttonWeek
            // 
            this.buttonWeek.FlatAppearance.BorderSize = 0;
            this.buttonWeek.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold);
            this.buttonWeek.ForeColor = System.Drawing.Color.MidnightBlue;
            this.buttonWeek.Location = new System.Drawing.Point(785, 65);
            this.buttonWeek.Name = "buttonWeek";
            this.buttonWeek.Size = new System.Drawing.Size(337, 39);
            this.buttonWeek.TabIndex = 20;
            this.buttonWeek.Text = "Расписание на неделю";
            this.buttonWeek.UseVisualStyleBackColor = true;
            this.buttonWeek.Click += new System.EventHandler(this.buttonWeek_Click);
            // 
            // kindergardenDataSetSchedule1
            // 
            this.kindergardenDataSetSchedule1.DataSetName = "kindergardenDataSetSchedule";
            this.kindergardenDataSetSchedule1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewSchedule
            // 
            this.dataGridViewSchedule.AutoGenerateColumns = false;
            this.dataGridViewSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSchedule.DataSource = this.kindergardenDataS;
            this.dataGridViewSchedule.Location = new System.Drawing.Point(4, 110);
            this.dataGridViewSchedule.Name = "dataGridViewSchedule";
            this.dataGridViewSchedule.RowHeadersWidth = 51;
            this.dataGridViewSchedule.RowTemplate.Height = 24;
            this.dataGridViewSchedule.Size = new System.Drawing.Size(1118, 348);
            this.dataGridViewSchedule.TabIndex = 21;
            // 
            // ScheduleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.Controls.Add(this.dataGridViewSchedule);
            this.Controls.Add(this.buttonWeek);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.pictureBoxUpdate);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.comboBoxGroup);
            this.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ScheduleControl";
            this.Size = new System.Drawing.Size(1488, 734);
            ((System.ComponentModel.ISupportInitialize)(this.scheduleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergardenDataS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergardenDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergardenDataSetSchedule1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSchedule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.BindingSource scheduleBindingSource;
        private kindergardenDataS kindergardenDataS;
        private kindergardenDataSTableAdapters.scheduleTableAdapter scheduleTableAdapter;
        private System.Windows.Forms.PictureBox pictureBoxUpdate;
        private System.Windows.Forms.BindingSource scheduleBindingSource1;
        private kindergardenDataSet2 kindergardenDataSet2;
        private kindergardenDataSet2TableAdapters.scheduleTableAdapter scheduleTableAdapter1;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button buttonWeek;
        private kindergardenDataSetSchedule kindergardenDataSetSchedule1;
        private System.Windows.Forms.DataGridView dataGridViewSchedule;
    }
}
