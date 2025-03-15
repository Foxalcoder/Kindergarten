namespace Kindergarten
{
    partial class GroupControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.UpPanel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.checkBoxDateEnd = new System.Windows.Forms.CheckBox();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.checkBoxChild = new System.Windows.Forms.CheckBox();
            this.checkBoxDateStart = new System.Windows.Forms.CheckBox();
            this.checkBoxStatus = new System.Windows.Forms.CheckBox();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.comboBoxChildName = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonEditTeacher = new System.Windows.Forms.Button();
            this.buttonSaveStatus = new System.Windows.Forms.Button();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.labelAssistantId = new System.Windows.Forms.Label();
            this.labelTeacher2Id = new System.Windows.Forms.Label();
            this.labelAge = new System.Windows.Forms.Label();
            this.labelTeacher1Id = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewChildren = new System.Windows.Forms.DataGridView();
            this.childrenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kindergardenDataSet = new Kindergarten.kindergardenDataSet();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.childrenTableAdapter = new Kindergarten.kindergardenDataSetTableAdapters.childrenTableAdapter();
            this.UpPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChildren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childrenBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergardenDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // UpPanel
            // 
            this.UpPanel.BackColor = System.Drawing.Color.Beige;
            this.UpPanel.Controls.Add(this.groupBox2);
            this.UpPanel.Controls.Add(this.groupBox1);
            this.UpPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.UpPanel.Location = new System.Drawing.Point(0, 0);
            this.UpPanel.Name = "UpPanel";
            this.UpPanel.Size = new System.Drawing.Size(1337, 335);
            this.UpPanel.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Beige;
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.dateTimePickerEnd);
            this.groupBox2.Controls.Add(this.checkBoxDateEnd);
            this.groupBox2.Controls.Add(this.dateTimePickerStart);
            this.groupBox2.Controls.Add(this.checkBoxChild);
            this.groupBox2.Controls.Add(this.checkBoxDateStart);
            this.groupBox2.Controls.Add(this.checkBoxStatus);
            this.groupBox2.Controls.Add(this.comboBoxStatus);
            this.groupBox2.Controls.Add(this.comboBoxChildName);
            this.groupBox2.Font = new System.Drawing.Font("Comic Sans MS", 14.8F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.Green;
            this.groupBox2.Location = new System.Drawing.Point(923, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(720, 349);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Фильтр";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button1.Location = new System.Drawing.Point(387, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(275, 49);
            this.button1.TabIndex = 17;
            this.button1.Text = "Сформировать отчет";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 35);
            this.label1.TabIndex = 14;
            this.label1.Text = "Выберите отчет";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Cambria", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox1.Location = new System.Drawing.Point(225, 232);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(438, 34);
            this.comboBox1.TabIndex = 13;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(226)))), ((int)(((byte)(168)))));
            this.dateTimePickerEnd.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dateTimePickerEnd.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(226)))), ((int)(((byte)(168)))));
            this.dateTimePickerEnd.Font = new System.Drawing.Font("Comic Sans MS", 10.8F);
            this.dateTimePickerEnd.Location = new System.Drawing.Point(460, 46);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(197, 33);
            this.dateTimePickerEnd.TabIndex = 12;
            this.dateTimePickerEnd.ValueChanged += new System.EventHandler(this.dateTimePickerEnd_ValueChanged);
            // 
            // checkBoxDateEnd
            // 
            this.checkBoxDateEnd.AutoSize = true;
            this.checkBoxDateEnd.ForeColor = System.Drawing.Color.MidnightBlue;
            this.checkBoxDateEnd.Location = new System.Drawing.Point(375, 43);
            this.checkBoxDateEnd.Name = "checkBoxDateEnd";
            this.checkBoxDateEnd.Size = new System.Drawing.Size(79, 39);
            this.checkBoxDateEnd.TabIndex = 11;
            this.checkBoxDateEnd.Text = "по:";
            this.checkBoxDateEnd.UseVisualStyleBackColor = true;
            this.checkBoxDateEnd.CheckedChanged += new System.EventHandler(this.checkBoxDateEnd_CheckedChanged);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.AllowDrop = true;
            this.dateTimePickerStart.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(226)))), ((int)(((byte)(168)))));
            this.dateTimePickerStart.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dateTimePickerStart.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(226)))), ((int)(((byte)(168)))));
            this.dateTimePickerStart.Font = new System.Drawing.Font("Comic Sans MS", 10.8F);
            this.dateTimePickerStart.Location = new System.Drawing.Point(158, 46);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(197, 33);
            this.dateTimePickerStart.TabIndex = 10;
            this.dateTimePickerStart.Value = new System.DateTime(2025, 3, 1, 0, 0, 0, 0);
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.dateTimePickerStart_ValueChanged);
            // 
            // checkBoxChild
            // 
            this.checkBoxChild.AutoSize = true;
            this.checkBoxChild.ForeColor = System.Drawing.Color.MidnightBlue;
            this.checkBoxChild.Location = new System.Drawing.Point(12, 93);
            this.checkBoxChild.Name = "checkBoxChild";
            this.checkBoxChild.Size = new System.Drawing.Size(195, 39);
            this.checkBoxChild.TabIndex = 9;
            this.checkBoxChild.Text = "Воспитанник";
            this.checkBoxChild.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxChild.UseVisualStyleBackColor = true;
            this.checkBoxChild.CheckedChanged += new System.EventHandler(this.checkBoxChild_CheckedChanged);
            // 
            // checkBoxDateStart
            // 
            this.checkBoxDateStart.AutoSize = true;
            this.checkBoxDateStart.ForeColor = System.Drawing.Color.MidnightBlue;
            this.checkBoxDateStart.Location = new System.Drawing.Point(12, 43);
            this.checkBoxDateStart.Name = "checkBoxDateStart";
            this.checkBoxDateStart.Size = new System.Drawing.Size(131, 39);
            this.checkBoxDateStart.TabIndex = 8;
            this.checkBoxDateStart.Text = "Дата: с";
            this.checkBoxDateStart.UseVisualStyleBackColor = true;
            this.checkBoxDateStart.CheckedChanged += new System.EventHandler(this.checkBoxDateStart_CheckedChanged);
            // 
            // checkBoxStatus
            // 
            this.checkBoxStatus.AutoSize = true;
            this.checkBoxStatus.ForeColor = System.Drawing.Color.MidnightBlue;
            this.checkBoxStatus.Location = new System.Drawing.Point(12, 153);
            this.checkBoxStatus.Name = "checkBoxStatus";
            this.checkBoxStatus.Size = new System.Drawing.Size(145, 39);
            this.checkBoxStatus.TabIndex = 4;
            this.checkBoxStatus.Text = "Наличие";
            this.checkBoxStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxStatus.UseVisualStyleBackColor = true;
            this.checkBoxStatus.CheckedChanged += new System.EventHandler(this.checkBoxStatus_CheckedChanged);
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxStatus.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxStatus.ForeColor = System.Drawing.Color.MidnightBlue;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(225, 153);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(432, 35);
            this.comboBoxStatus.TabIndex = 3;
            this.comboBoxStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxStatus_SelectedIndexChanged);
            // 
            // comboBoxChildName
            // 
            this.comboBoxChildName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxChildName.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxChildName.FormattingEnabled = true;
            this.comboBoxChildName.Location = new System.Drawing.Point(225, 93);
            this.comboBoxChildName.Name = "comboBoxChildName";
            this.comboBoxChildName.Size = new System.Drawing.Size(432, 35);
            this.comboBoxChildName.TabIndex = 2;
            this.comboBoxChildName.SelectedIndexChanged += new System.EventHandler(this.comboBoxChildName_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Beige;
            this.groupBox1.Controls.Add(this.buttonEditTeacher);
            this.groupBox1.Controls.Add(this.buttonSaveStatus);
            this.groupBox1.Controls.Add(this.comboBoxGroup);
            this.groupBox1.Controls.Add(this.labelAssistantId);
            this.groupBox1.Controls.Add(this.labelTeacher2Id);
            this.groupBox1.Controls.Add(this.labelAge);
            this.groupBox1.Controls.Add(this.labelTeacher1Id);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Comic Sans MS", 14.8F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(913, 349);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // buttonEditTeacher
            // 
            this.buttonEditTeacher.FlatAppearance.BorderSize = 0;
            this.buttonEditTeacher.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEditTeacher.ForeColor = System.Drawing.Color.Red;
            this.buttonEditTeacher.Location = new System.Drawing.Point(12, 280);
            this.buttonEditTeacher.Name = "buttonEditTeacher";
            this.buttonEditTeacher.Size = new System.Drawing.Size(430, 49);
            this.buttonEditTeacher.TabIndex = 16;
            this.buttonEditTeacher.Text = "Изменить воспитателя";
            this.buttonEditTeacher.UseVisualStyleBackColor = true;
            this.buttonEditTeacher.Click += new System.EventHandler(this.buttonEditTeacher_Click);
            // 
            // buttonSaveStatus
            // 
            this.buttonSaveStatus.FlatAppearance.BorderSize = 0;
            this.buttonSaveStatus.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold);
            this.buttonSaveStatus.ForeColor = System.Drawing.Color.MidnightBlue;
            this.buttonSaveStatus.Location = new System.Drawing.Point(477, 280);
            this.buttonSaveStatus.Name = "buttonSaveStatus";
            this.buttonSaveStatus.Size = new System.Drawing.Size(430, 49);
            this.buttonSaveStatus.TabIndex = 13;
            this.buttonSaveStatus.Text = "Сохранить посещаемость";
            this.buttonSaveStatus.UseVisualStyleBackColor = true;
            this.buttonSaveStatus.Click += new System.EventHandler(this.buttonSaveStatus_Click);
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxGroup.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxGroup.ForeColor = System.Drawing.Color.MidnightBlue;
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBoxGroup.Location = new System.Drawing.Point(1, 21);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(696, 42);
            this.comboBoxGroup.TabIndex = 0;
            this.comboBoxGroup.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroup_SelectedIndexChanged_1);
            // 
            // labelAssistantId
            // 
            this.labelAssistantId.AutoSize = true;
            this.labelAssistantId.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAssistantId.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelAssistantId.Location = new System.Drawing.Point(6, 220);
            this.labelAssistantId.Name = "labelAssistantId";
            this.labelAssistantId.Size = new System.Drawing.Size(148, 34);
            this.labelAssistantId.TabIndex = 2;
            this.labelAssistantId.Text = "Помощник";
            // 
            // labelTeacher2Id
            // 
            this.labelTeacher2Id.AutoSize = true;
            this.labelTeacher2Id.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTeacher2Id.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelTeacher2Id.Location = new System.Drawing.Point(6, 170);
            this.labelTeacher2Id.Name = "labelTeacher2Id";
            this.labelTeacher2Id.Size = new System.Drawing.Size(192, 34);
            this.labelTeacher2Id.TabIndex = 4;
            this.labelTeacher2Id.Text = "Воспитатель 2";
            // 
            // labelAge
            // 
            this.labelAge.AutoSize = true;
            this.labelAge.ForeColor = System.Drawing.Color.Green;
            this.labelAge.Location = new System.Drawing.Point(6, 70);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(109, 35);
            this.labelAge.TabIndex = 6;
            this.labelAge.Text = "Возраст";
            // 
            // labelTeacher1Id
            // 
            this.labelTeacher1Id.AutoSize = true;
            this.labelTeacher1Id.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTeacher1Id.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelTeacher1Id.Location = new System.Drawing.Point(6, 120);
            this.labelTeacher1Id.Name = "labelTeacher1Id";
            this.labelTeacher1Id.Size = new System.Drawing.Size(188, 34);
            this.labelTeacher1Id.TabIndex = 3;
            this.labelTeacher1Id.Text = "Воспитатель 1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewChildren);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 335);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1337, 720);
            this.panel1.TabIndex = 1;
            // 
            // dataGridViewChildren
            // 
            this.dataGridViewChildren.AutoGenerateColumns = false;
            this.dataGridViewChildren.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewChildren.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridViewChildren.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dataGridViewChildren.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewChildren.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewChildren.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewChildren.ColumnHeadersHeight = 40;
            this.dataGridViewChildren.DataSource = this.childrenBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewChildren.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewChildren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewChildren.GridColor = System.Drawing.Color.Gray;
            this.dataGridViewChildren.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewChildren.Name = "dataGridViewChildren";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(226)))), ((int)(((byte)(168)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewChildren.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewChildren.RowHeadersWidth = 51;
            this.dataGridViewChildren.RowTemplate.Height = 24;
            this.dataGridViewChildren.Size = new System.Drawing.Size(1337, 720);
            this.dataGridViewChildren.TabIndex = 0;
            this.dataGridViewChildren.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // childrenBindingSource
            // 
            this.childrenBindingSource.DataMember = "children";
            this.childrenBindingSource.DataSource = this.kindergardenDataSet;
            // 
            // kindergardenDataSet
            // 
            this.kindergardenDataSet.DataSetName = "kindergardenDataSet";
            this.kindergardenDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // childrenTableAdapter
            // 
            this.childrenTableAdapter.ClearBeforeFill = true;
            // 
            // GroupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.UpPanel);
            this.Name = "GroupControl";
            this.Size = new System.Drawing.Size(1337, 1055);
            this.UpPanel.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChildren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childrenBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindergardenDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel UpPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.Label labelTeacher2Id;
        private System.Windows.Forms.Label labelTeacher1Id;
        private System.Windows.Forms.Label labelAssistantId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.BindingSource childrenBindingSource;
        private kindergardenDataSet kindergardenDataSet;
        private kindergardenDataSetTableAdapters.childrenTableAdapter childrenTableAdapter;
        private System.Windows.Forms.DataGridView dataGridViewChildren;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.ComboBox comboBoxChildName;
        private System.Windows.Forms.CheckBox checkBoxStatus;
        private System.Windows.Forms.CheckBox checkBoxDateEnd;
        private System.Windows.Forms.CheckBox checkBoxChild;
        private System.Windows.Forms.CheckBox checkBoxDateStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Button buttonSaveStatus;
        private System.Windows.Forms.Button buttonEditTeacher;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}
