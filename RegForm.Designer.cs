namespace Vilnius_University_Advisor
{
    partial class RegForm
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
            this.MainMenu = new System.Windows.Forms.Panel();
            this.ListLect = new System.Windows.Forms.Button();
            this.SubjReg = new System.Windows.Forms.Button();
            this.ListSubj = new System.Windows.Forms.Button();
            this.LecReg = new System.Windows.Forms.Button();
            this.LecturerPanel = new System.Windows.Forms.Panel();
            this.SaveNextLecReg = new System.Windows.Forms.Button();
            this.NameTextBoxLect = new System.Windows.Forms.TextBox();
            this.NameLabelLect = new System.Windows.Forms.Label();
            this.FacultySelectLect = new System.Windows.Forms.ListBox();
            this.FacultyLabelLect = new System.Windows.Forms.Label();
            this.SaveBackLecReg = new System.Windows.Forms.Button();
            this.BackLecReg = new System.Windows.Forms.Button();
            this.SubjectPanel = new System.Windows.Forms.Panel();
            this.IsBUS = new System.Windows.Forms.RadioButton();
            this.IsOptional = new System.Windows.Forms.RadioButton();
            this.IsMandatory = new System.Windows.Forms.RadioButton();
            this.SaveNextSubjReg = new System.Windows.Forms.Button();
            this.BackSubjReg = new System.Windows.Forms.Button();
            this.SaveBackSubjReg = new System.Windows.Forms.Button();
            this.FacultyLabelSubj = new System.Windows.Forms.Label();
            this.FacultySelectSubj = new System.Windows.Forms.ListBox();
            this.NameLabelSubj = new System.Windows.Forms.Label();
            this.NameTextBoxSubj = new System.Windows.Forms.TextBox();
            this.AllLecturers = new System.Windows.Forms.Panel();
            this.ListLectLabel = new System.Windows.Forms.Label();
            this.ListLectTable = new System.Windows.Forms.DataGridView();
            this.ListLectBack = new System.Windows.Forms.Button();
            this.ListSubjLabel = new System.Windows.Forms.Label();
            this.ListSubjTable = new System.Windows.Forms.DataGridView();
            this.AllSubjects = new System.Windows.Forms.Panel();
            this.ListSubjBack = new System.Windows.Forms.Button();
            this.MainMenu.SuspendLayout();
            this.LecturerPanel.SuspendLayout();
            this.SubjectPanel.SuspendLayout();
            this.AllLecturers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListLectTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListSubjTable)).BeginInit();
            this.AllSubjects.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Controls.Add(this.ListLect);
            this.MainMenu.Controls.Add(this.SubjReg);
            this.MainMenu.Controls.Add(this.ListSubj);
            this.MainMenu.Controls.Add(this.LecReg);
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1056, 348);
            this.MainMenu.TabIndex = 0;
            // 
            // ListLect
            // 
            this.ListLect.Location = new System.Drawing.Point(313, 83);
            this.ListLect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListLect.Name = "ListLect";
            this.ListLect.Size = new System.Drawing.Size(244, 82);
            this.ListLect.TabIndex = 3;
            this.ListLect.Text = "Rodyti dėstytojus";
            this.ListLect.UseVisualStyleBackColor = true;
            this.ListLect.Click += new System.EventHandler(this.ListLect_Click);
            // 
            // SubjReg
            // 
            this.SubjReg.Location = new System.Drawing.Point(45, 179);
            this.SubjReg.Name = "SubjReg";
            this.SubjReg.Size = new System.Drawing.Size(244, 82);
            this.SubjReg.TabIndex = 2;
            this.SubjReg.Text = "Registruoti dalyką";
            this.SubjReg.UseVisualStyleBackColor = true;
            this.SubjReg.Click += new System.EventHandler(this.SubjReg_Click);
            // 
            // ListSubj
            // 
            this.ListSubj.Location = new System.Drawing.Point(45, 84);
            this.ListSubj.Name = "ListSubj";
            this.ListSubj.Size = new System.Drawing.Size(244, 81);
            this.ListSubj.TabIndex = 0;
            this.ListSubj.Text = "Rodyti dalykus";
            this.ListSubj.UseVisualStyleBackColor = true;
            this.ListSubj.Click += new System.EventHandler(this.ListSubj_Click);
            // 
            // LecReg
            // 
            this.LecReg.Location = new System.Drawing.Point(313, 179);
            this.LecReg.Name = "LecReg";
            this.LecReg.Size = new System.Drawing.Size(244, 82);
            this.LecReg.TabIndex = 1;
            this.LecReg.Text = "Registruoti dėstytoją";
            this.LecReg.UseVisualStyleBackColor = true;
            this.LecReg.Click += new System.EventHandler(this.LecReg_Click);
            // 
            // LecturerPanel
            // 
            this.LecturerPanel.Controls.Add(this.SaveNextLecReg);
            this.LecturerPanel.Controls.Add(this.NameTextBoxLect);
            this.LecturerPanel.Controls.Add(this.NameLabelLect);
            this.LecturerPanel.Controls.Add(this.FacultySelectLect);
            this.LecturerPanel.Controls.Add(this.FacultyLabelLect);
            this.LecturerPanel.Controls.Add(this.SaveBackLecReg);
            this.LecturerPanel.Controls.Add(this.BackLecReg);
            this.LecturerPanel.Location = new System.Drawing.Point(0, 0);
            this.LecturerPanel.Name = "LecturerPanel";
            this.LecturerPanel.Size = new System.Drawing.Size(1056, 348);
            this.LecturerPanel.TabIndex = 3;
            this.LecturerPanel.Visible = false;
            // 
            // SaveNextLecReg
            // 
            this.SaveNextLecReg.Location = new System.Drawing.Point(353, 199);
            this.SaveNextLecReg.Name = "SaveNextLecReg";
            this.SaveNextLecReg.Size = new System.Drawing.Size(184, 41);
            this.SaveNextLecReg.TabIndex = 8;
            this.SaveNextLecReg.Text = "Išsaugoti ir registruoti kitą";
            this.SaveNextLecReg.UseVisualStyleBackColor = true;
            this.SaveNextLecReg.Click += new System.EventHandler(this.SaveNextLecReg_Click);
            // 
            // NameTextBoxLect
            // 
            this.NameTextBoxLect.Location = new System.Drawing.Point(63, 40);
            this.NameTextBoxLect.Name = "NameTextBoxLect";
            this.NameTextBoxLect.Size = new System.Drawing.Size(566, 22);
            this.NameTextBoxLect.TabIndex = 3;
            // 
            // NameLabelLect
            // 
            this.NameLabelLect.AutoSize = true;
            this.NameLabelLect.Location = new System.Drawing.Point(60, 20);
            this.NameLabelLect.Name = "NameLabelLect";
            this.NameLabelLect.Size = new System.Drawing.Size(114, 17);
            this.NameLabelLect.TabIndex = 4;
            this.NameLabelLect.Text = "Vardas Pavardė:";
            // 
            // FacultySelectLect
            // 
            this.FacultySelectLect.FormattingEnabled = true;
            this.FacultySelectLect.ItemHeight = 16;
            this.FacultySelectLect.Items.AddRange(new object[] {
            "Chemijos ir geomokslų",
            "Ekonomikos ir verslo administravimo",
            "Filologijos",
            "Filosofijos",
            "Fizikos",
            "Gyvybės mokslų",
            "Istorijos",
            "Kauno",
            "Komunikacijos",
            "Matematikos ir informatikos",
            "Medicinos",
            "Tarptautinių santykių ir politikos mokslų",
            "Teisės",
            "Verslo"});
            this.FacultySelectLect.Location = new System.Drawing.Point(63, 103);
            this.FacultySelectLect.Name = "FacultySelectLect";
            this.FacultySelectLect.Size = new System.Drawing.Size(257, 228);
            this.FacultySelectLect.TabIndex = 5;
            // 
            // FacultyLabelLect
            // 
            this.FacultyLabelLect.AutoSize = true;
            this.FacultyLabelLect.Location = new System.Drawing.Point(60, 84);
            this.FacultyLabelLect.Name = "FacultyLabelLect";
            this.FacultyLabelLect.Size = new System.Drawing.Size(77, 17);
            this.FacultyLabelLect.TabIndex = 6;
            this.FacultyLabelLect.Text = "Fakultetas:";
            // 
            // SaveBackLecReg
            // 
            this.SaveBackLecReg.Location = new System.Drawing.Point(353, 152);
            this.SaveBackLecReg.Name = "SaveBackLecReg";
            this.SaveBackLecReg.Size = new System.Drawing.Size(184, 41);
            this.SaveBackLecReg.TabIndex = 7;
            this.SaveBackLecReg.Text = "Išsaugoti ir grįžti";
            this.SaveBackLecReg.UseVisualStyleBackColor = true;
            this.SaveBackLecReg.Click += new System.EventHandler(this.SaveBackLecReg_Click);
            // 
            // BackLecReg
            // 
            this.BackLecReg.Location = new System.Drawing.Point(353, 103);
            this.BackLecReg.Name = "BackLecReg";
            this.BackLecReg.Size = new System.Drawing.Size(184, 42);
            this.BackLecReg.TabIndex = 9;
            this.BackLecReg.Text = "Grįžti";
            this.BackLecReg.UseVisualStyleBackColor = true;
            this.BackLecReg.Click += new System.EventHandler(this.BackLecReg_Click);
            // 
            // SubjectPanel
            // 
            this.SubjectPanel.Controls.Add(this.IsMandatory);
            this.SubjectPanel.Controls.Add(this.IsOptional);
            this.SubjectPanel.Controls.Add(this.IsBUS);
            this.SubjectPanel.Controls.Add(this.SaveNextSubjReg);
            this.SubjectPanel.Controls.Add(this.BackSubjReg);
            this.SubjectPanel.Controls.Add(this.SaveBackSubjReg);
            this.SubjectPanel.Controls.Add(this.FacultyLabelSubj);
            this.SubjectPanel.Controls.Add(this.FacultySelectSubj);
            this.SubjectPanel.Controls.Add(this.NameLabelSubj);
            this.SubjectPanel.Controls.Add(this.NameTextBoxSubj);
            this.SubjectPanel.Location = new System.Drawing.Point(0, 0);
            this.SubjectPanel.Name = "SubjectPanel";
            this.SubjectPanel.Size = new System.Drawing.Size(1056, 348);
            this.SubjectPanel.TabIndex = 10;
            this.SubjectPanel.Visible = false;
            // 
            // IsBUS
            // 
            this.IsBUS.AutoSize = true;
            this.IsBUS.Location = new System.Drawing.Point(336, 166);
            this.IsBUS.Name = "IsBUS";
            this.IsBUS.Size = new System.Drawing.Size(57, 21);
            this.IsBUS.TabIndex = 17;
            this.IsBUS.Text = "BUS";
            this.IsBUS.UseVisualStyleBackColor = true;
            // 
            // IsOptional
            // 
            this.IsOptional.AutoSize = true;
            this.IsOptional.Checked = true;
            this.IsOptional.Location = new System.Drawing.Point(336, 138);
            this.IsOptional.Name = "IsOptional";
            this.IsOptional.Size = new System.Drawing.Size(128, 21);
            this.IsOptional.TabIndex = 16;
            this.IsOptional.TabStop = true;
            this.IsOptional.Text = "Pasirenkamasis";
            this.IsOptional.UseVisualStyleBackColor = true;
            // 
            // IsMandatory
            // 
            this.IsMandatory.AutoSize = true;
            this.IsMandatory.Location = new System.Drawing.Point(336, 110);
            this.IsMandatory.Name = "IsMandatory";
            this.IsMandatory.Size = new System.Drawing.Size(108, 21);
            this.IsMandatory.TabIndex = 15;
            this.IsMandatory.TabStop = true;
            this.IsMandatory.Text = "Privalomasis";
            this.IsMandatory.UseVisualStyleBackColor = true;
            // 
            // SaveNextSubjReg
            // 
            this.SaveNextSubjReg.Location = new System.Drawing.Point(336, 296);
            this.SaveNextSubjReg.Name = "SaveNextSubjReg";
            this.SaveNextSubjReg.Size = new System.Drawing.Size(184, 42);
            this.SaveNextSubjReg.TabIndex = 14;
            this.SaveNextSubjReg.Text = "Išsaugoti ir registruoti kitą";
            this.SaveNextSubjReg.UseVisualStyleBackColor = true;
            this.SaveNextSubjReg.Click += new System.EventHandler(this.SaveNextSubjReg_Click);
            // 
            // BackSubjReg
            // 
            this.BackSubjReg.Location = new System.Drawing.Point(336, 198);
            this.BackSubjReg.Name = "BackSubjReg";
            this.BackSubjReg.Size = new System.Drawing.Size(184, 42);
            this.BackSubjReg.TabIndex = 13;
            this.BackSubjReg.Text = "Grįžti";
            this.BackSubjReg.UseVisualStyleBackColor = true;
            this.BackSubjReg.Click += new System.EventHandler(this.BackSubjReg_Click);
            // 
            // SaveBackSubjReg
            // 
            this.SaveBackSubjReg.Location = new System.Drawing.Point(336, 246);
            this.SaveBackSubjReg.Name = "SaveBackSubjReg";
            this.SaveBackSubjReg.Size = new System.Drawing.Size(184, 42);
            this.SaveBackSubjReg.TabIndex = 12;
            this.SaveBackSubjReg.Text = "Išsaugoti ir grįžti";
            this.SaveBackSubjReg.UseVisualStyleBackColor = true;
            this.SaveBackSubjReg.Click += new System.EventHandler(this.SaveBackSubjReg_Click);
            // 
            // FacultyLabelSubj
            // 
            this.FacultyLabelSubj.AutoSize = true;
            this.FacultyLabelSubj.Location = new System.Drawing.Point(60, 91);
            this.FacultyLabelSubj.Name = "FacultyLabelSubj";
            this.FacultyLabelSubj.Size = new System.Drawing.Size(77, 17);
            this.FacultyLabelSubj.TabIndex = 11;
            this.FacultyLabelSubj.Text = "Fakultetas:";
            // 
            // FacultySelectSubj
            // 
            this.FacultySelectSubj.FormattingEnabled = true;
            this.FacultySelectSubj.ItemHeight = 16;
            this.FacultySelectSubj.Items.AddRange(new object[] {
            "Chemijos ir geomokslų",
            "Ekonomikos ir verslo administravimo",
            "Filologijos",
            "Filosofijos",
            "Fizikos",
            "Gyvybės mokslų",
            "Istorijos",
            "Kauno",
            "Komunikacijos",
            "Matematikos ir informatikos",
            "Medicinos",
            "Tarptaunių santykių ir politikos mokslų",
            "Teisės",
            "Verslo"});
            this.FacultySelectSubj.Location = new System.Drawing.Point(64, 110);
            this.FacultySelectSubj.Name = "FacultySelectSubj";
            this.FacultySelectSubj.Size = new System.Drawing.Size(244, 228);
            this.FacultySelectSubj.TabIndex = 6;
            // 
            // NameLabelSubj
            // 
            this.NameLabelSubj.AutoSize = true;
            this.NameLabelSubj.Location = new System.Drawing.Point(60, 37);
            this.NameLabelSubj.Name = "NameLabelSubj";
            this.NameLabelSubj.Size = new System.Drawing.Size(92, 17);
            this.NameLabelSubj.TabIndex = 1;
            this.NameLabelSubj.Text = "Pavadinimas:";
            // 
            // NameTextBoxSubj
            // 
            this.NameTextBoxSubj.Location = new System.Drawing.Point(63, 57);
            this.NameTextBoxSubj.Name = "NameTextBoxSubj";
            this.NameTextBoxSubj.Size = new System.Drawing.Size(536, 22);
            this.NameTextBoxSubj.TabIndex = 0;
            // 
            // AllLecturers
            // 
            this.AllLecturers.Controls.Add(this.ListLectLabel);
            this.AllLecturers.Controls.Add(this.ListLectTable);
            this.AllLecturers.Controls.Add(this.ListLectBack);
            this.AllLecturers.Location = new System.Drawing.Point(0, 0);
            this.AllLecturers.Name = "AllLecturers";
            this.AllLecturers.Size = new System.Drawing.Size(1056, 348);
            this.AllLecturers.TabIndex = 3;
            this.AllLecturers.Visible = false;
            // 
            // ListLectLabel
            // 
            this.ListLectLabel.AutoSize = true;
            this.ListLectLabel.Location = new System.Drawing.Point(3, 9);
            this.ListLectLabel.Name = "ListLectLabel";
            this.ListLectLabel.Size = new System.Drawing.Size(74, 17);
            this.ListLectLabel.TabIndex = 3;
            this.ListLectLabel.Text = "Dėstytojai:";
            // 
            // ListLectTable
            // 
            this.ListLectTable.AllowUserToAddRows = false;
            this.ListLectTable.AllowUserToDeleteRows = false;
            this.ListLectTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListLectTable.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ListLectTable.Location = new System.Drawing.Point(3, 28);
            this.ListLectTable.Name = "ListLectTable";
            this.ListLectTable.ReadOnly = true;
            this.ListLectTable.RowHeadersWidth = 51;
            this.ListLectTable.RowTemplate.Height = 24;
            this.ListLectTable.Size = new System.Drawing.Size(1053, 274);
            this.ListLectTable.TabIndex = 1;
            // 
            // ListLectBack
            // 
            this.ListLectBack.Location = new System.Drawing.Point(479, 308);
            this.ListLectBack.Name = "ListLectBack";
            this.ListLectBack.Size = new System.Drawing.Size(120, 30);
            this.ListLectBack.TabIndex = 0;
            this.ListLectBack.Text = "Grįžti";
            this.ListLectBack.UseVisualStyleBackColor = true;
            this.ListLectBack.Click += new System.EventHandler(this.ListLectBack_Click);
            // 
            // ListSubjLabel
            // 
            this.ListSubjLabel.AutoSize = true;
            this.ListSubjLabel.Location = new System.Drawing.Point(3, 9);
            this.ListSubjLabel.Name = "ListSubjLabel";
            this.ListSubjLabel.Size = new System.Drawing.Size(58, 17);
            this.ListSubjLabel.TabIndex = 4;
            this.ListSubjLabel.Text = "Dalykai:";
            // 
            // ListSubjTable
            // 
            this.ListSubjTable.AllowUserToAddRows = false;
            this.ListSubjTable.AllowUserToDeleteRows = false;
            this.ListSubjTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListSubjTable.Location = new System.Drawing.Point(0, 28);
            this.ListSubjTable.Name = "ListSubjTable";
            this.ListSubjTable.ReadOnly = true;
            this.ListSubjTable.RowHeadersWidth = 51;
            this.ListSubjTable.RowTemplate.Height = 24;
            this.ListSubjTable.Size = new System.Drawing.Size(1053, 275);
            this.ListSubjTable.TabIndex = 2;
            // 
            // AllSubjects
            // 
            this.AllSubjects.Controls.Add(this.ListSubjBack);
            this.AllSubjects.Controls.Add(this.ListSubjLabel);
            this.AllSubjects.Controls.Add(this.ListSubjTable);
            this.AllSubjects.Location = new System.Drawing.Point(0, 0);
            this.AllSubjects.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AllSubjects.Name = "AllSubjects";
            this.AllSubjects.Size = new System.Drawing.Size(1056, 348);
            this.AllSubjects.TabIndex = 4;
            this.AllSubjects.Visible = false;
            // 
            // ListSubjBack
            // 
            this.ListSubjBack.Location = new System.Drawing.Point(431, 309);
            this.ListSubjBack.Name = "ListSubjBack";
            this.ListSubjBack.Size = new System.Drawing.Size(209, 36);
            this.ListSubjBack.TabIndex = 5;
            this.ListSubjBack.Text = "Grįžti";
            this.ListSubjBack.UseVisualStyleBackColor = true;
            this.ListSubjBack.Click += new System.EventHandler(this.ListSubjBack_Click);
            // 
            // RegForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 350);
            this.Controls.Add(this.SubjectPanel);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.LecturerPanel);
            this.Controls.Add(this.AllLecturers);
            this.Controls.Add(this.AllSubjects);
            this.Name = "RegForm";
            this.Text = "VU_Advisor";
            this.MainMenu.ResumeLayout(false);
            this.LecturerPanel.ResumeLayout(false);
            this.LecturerPanel.PerformLayout();
            this.SubjectPanel.ResumeLayout(false);
            this.SubjectPanel.PerformLayout();
            this.AllLecturers.ResumeLayout(false);
            this.AllLecturers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListLectTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListSubjTable)).EndInit();
            this.AllSubjects.ResumeLayout(false);
            this.AllSubjects.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainMenu;
        private System.Windows.Forms.Button ListSubj;
        private System.Windows.Forms.Button SubjReg;
        private System.Windows.Forms.Button LecReg;
        private System.Windows.Forms.Panel LecturerPanel;
        private System.Windows.Forms.TextBox NameTextBoxLect;
        private System.Windows.Forms.Label NameLabelLect;
        private System.Windows.Forms.ListBox FacultySelectLect;
        private System.Windows.Forms.Label FacultyLabelLect;
        private System.Windows.Forms.Button BackLecReg;
        private System.Windows.Forms.Button SaveNextLecReg;
        private System.Windows.Forms.Button SaveBackLecReg;
        private System.Windows.Forms.Panel SubjectPanel;
        private System.Windows.Forms.TextBox NameTextBoxSubj;
        private System.Windows.Forms.Label FacultyLabelSubj;
        private System.Windows.Forms.ListBox FacultySelectSubj;
        private System.Windows.Forms.Label NameLabelSubj;
        private System.Windows.Forms.Button SaveNextSubjReg;
        private System.Windows.Forms.Button BackSubjReg;
        private System.Windows.Forms.Button SaveBackSubjReg;
        private System.Windows.Forms.Panel AllLecturers;
        private System.Windows.Forms.Button ListLectBack;
        private System.Windows.Forms.DataGridView ListLectTable;
        private System.Windows.Forms.Label ListSubjLabel;
        private System.Windows.Forms.Label ListLectLabel;
        private System.Windows.Forms.DataGridView ListSubjTable;
        private System.Windows.Forms.Button ListLect;
        private System.Windows.Forms.Panel AllSubjects;
        private System.Windows.Forms.Button ListSubjBack;
        private System.Windows.Forms.RadioButton IsBUS;
        private System.Windows.Forms.RadioButton IsOptional;
        private System.Windows.Forms.RadioButton IsMandatory;
    }
}

