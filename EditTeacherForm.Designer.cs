namespace Kindergarten
{
    partial class EditTeacherForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTeacher1Id = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelAssistantId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTeacher1Id
            // 
            this.labelTeacher1Id.AutoSize = true;
            this.labelTeacher1Id.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTeacher1Id.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelTeacher1Id.Location = new System.Drawing.Point(-3, 152);
            this.labelTeacher1Id.Name = "labelTeacher1Id";
            this.labelTeacher1Id.Size = new System.Drawing.Size(199, 34);
            this.labelTeacher1Id.TabIndex = 4;
            this.labelTeacher1Id.Text = "Воспитатель 2:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(-3, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 34);
            this.label1.TabIndex = 5;
            this.label1.Text = "Воспитатель 1:";
            // 
            // labelAssistantId
            // 
            this.labelAssistantId.AutoSize = true;
            this.labelAssistantId.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAssistantId.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelAssistantId.Location = new System.Drawing.Point(-3, 208);
            this.labelAssistantId.Name = "labelAssistantId";
            this.labelAssistantId.Size = new System.Drawing.Size(155, 34);
            this.labelAssistantId.TabIndex = 6;
            this.labelAssistantId.Text = "Помощник:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(-3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 34);
            this.label2.TabIndex = 7;
            this.label2.Text = "Выберите группу:";
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxGroup.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Location = new System.Drawing.Point(277, 49);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(323, 35);
            this.comboBoxGroup.TabIndex = 8;
            this.comboBoxGroup.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroup_SelectedIndexChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.ForeColor = System.Drawing.Color.MidnightBlue;
            this.buttonSave.Location = new System.Drawing.Point(12, 298);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(229, 49);
            this.buttonSave.TabIndex = 17;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonExit
            // 
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.ForeColor = System.Drawing.Color.MidnightBlue;
            this.buttonExit.Location = new System.Drawing.Point(371, 298);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(229, 49);
            this.buttonExit.TabIndex = 18;
            this.buttonExit.Text = "Отмена";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // EditTeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(612, 359);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxGroup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelAssistantId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTeacher1Id);
            this.Name = "EditTeacherForm";
            this.Text = "Редактирование воспитателя";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTeacher1Id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelAssistantId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonExit;
    }
}