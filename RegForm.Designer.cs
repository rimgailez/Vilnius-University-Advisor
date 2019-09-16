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
            this.Menu = new System.Windows.Forms.Panel();
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
            this.ListBack = new System.Windows.Forms.Button();
            this.ListSubjLabel = new System.Windows.Forms.Label();
            this.ListSubjTable = new System.Windows.Forms.DataGridView();
            this.AllSubjects = new System.Windows.Forms.Panel();
            this.ListBack1 = new System.Windows.Forms.Button();
            this.Menu.SuspendLayout();
            this.LecturerPanel.SuspendLayout();
            this.SubjectPanel.SuspendLayout();
            this.AllLecturers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListLectTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListSubjTable)).BeginInit();
            this.AllSubjects.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Controls.Add(this.ListLect);
            this.Menu.Controls.Add(this.SubjReg);
            this.Menu.Controls.Add(this.ListSubj);
            this.Menu.Controls.Add(this.LecReg);
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(737, 435);
            this.Menu.TabIndex = 0;
            // 
            // ListLect
            // 
            this.ListLect.Location = new System.Drawing.Point(352, 104);
            this.ListLect.Name = "ListLect";
            this.ListLect.Size = new System.Drawing.Size(275, 102);
            this.ListLect.TabIndex = 3;
            this.ListLect.Text = "Rodyti dėstytojus";
            this.ListLect.UseVisualStyleBackColor = true;
            this.ListLect.Click += new System.EventHandler(this.ListLect_Click);
            // 
            // SubjReg
            // 
            this.SubjReg.Location = new System.Drawing.Point(51, 224);
            this.SubjReg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SubjReg.Name = "SubjReg";
            this.SubjReg.Size = new System.Drawing.Size(275, 102);
            this.SubjReg.TabIndex = 2;
            this.SubjReg.Text = "Registruoti dalyką";
            this.SubjReg.UseVisualStyleBackColor = true;
            this.SubjReg.Click += new System.EventHandler(this.SubjReg_Click);
            // 
            // ListSubj
            // 
            this.ListSubj.Location = new System.Drawing.Point(51, 105);
            this.ListSubj.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ListSubj.Name = "ListSubj";
            this.ListSubj.Size = new System.Drawing.Size(275, 101);
            this.ListSubj.TabIndex = 0;
            this.ListSubj.Text = "Rodyti dalykus";
            this.ListSubj.UseVisualStyleBackColor = true;
            this.ListSubj.Click += new System.EventHandler(this.ListSubj_Click);
            // 
            // LecReg
            // 
            this.LecReg.Location = new System.Drawing.Point(352, 224);
            this.LecReg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LecReg.Name = "LecReg";
            this.LecReg.Size = new System.Drawing.Size(275, 102);
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
            this.LecturerPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LecturerPanel.Name = "LecturerPanel";
            this.LecturerPanel.Size = new System.Drawing.Size(737, 435);
            this.LecturerPanel.TabIndex = 3;
            this.LecturerPanel.Visible = false;
            // 
            // SaveNextLecReg
            // 
            this.SaveNextLecReg.Location = new System.Drawing.Point(397, 249);
            this.SaveNextLecReg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SaveNextLecReg.Name = "SaveNextLecReg";
            this.SaveNextLecReg.Size = new System.Drawing.Size(207, 51);
            this.SaveNextLecReg.TabIndex = 8;
            this.SaveNextLecReg.Text = "Išsaugoti ir registruoti kitą";
            this.SaveNextLecReg.UseVisualStyleBackColor = true;
            this.SaveNextLecReg.Click += new System.EventHandler(this.SaveNextLecReg_Click);
            // 
            // NameTextBoxLect
            // 
            this.NameTextBoxLect.Location = new System.Drawing.Point(71, 50);
            this.NameTextBoxLect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NameTextBoxLect.Name = "NameTextBoxLect";
            this.NameTextBoxLect.Size = new System.Drawing.Size(636, 26);
            this.NameTextBoxLect.TabIndex = 3;
            // 
            // NameLabelLect
            // 
            this.NameLabelLect.AutoSize = true;
            this.NameLabelLect.Location = new System.Drawing.Point(68, 25);
            this.NameLabelLect.Name = "NameLabelLect";
            this.NameLabelLect.Size = new System.Drawing.Size(126, 20);
            this.NameLabelLect.TabIndex = 4;
            this.NameLabelLect.Text = "Vardas Pavardė:";
            // 
            // FacultySelectLect
            // 
            this.FacultySelectLect.FormattingEnabled = true;
            this.FacultySelectLect.ItemHeight = 20;
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
            this.FacultySelectLect.Location = new System.Drawing.Point(71, 129);
            this.FacultySelectLect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FacultySelectLect.Name = "FacultySelectLect";
            this.FacultySelectLect.Size = new System.Drawing.Size(289, 284);
            this.FacultySelectLect.TabIndex = 5;
            // 
            // FacultyLabelLect
            // 
            this.FacultyLabelLect.AutoSize = true;
            this.FacultyLabelLect.Location = new System.Drawing.Point(68, 105);
            this.FacultyLabelLect.Name = "FacultyLabelLect";
            this.FacultyLabelLect.Size = new System.Drawing.Size(88, 20);
            this.FacultyLabelLect.TabIndex = 6;
            this.FacultyLabelLect.Text = "Fakultetas:";
            this.FacultyLabelLect.Click += new System.EventHandler(this.FacultyLabelLect_Click);
            // 
            // SaveBackLecReg
            // 
            this.SaveBackLecReg.Location = new System.Drawing.Point(397, 190);
            this.SaveBackLecReg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SaveBackLecReg.Name = "SaveBackLecReg";
            this.SaveBackLecReg.Size = new System.Drawing.Size(207, 51);
            this.SaveBackLecReg.TabIndex = 7;
            this.SaveBackLecReg.Text = "Išsaugoti ir grįžti";
            this.SaveBackLecReg.UseVisualStyleBackColor = true;
            this.SaveBackLecReg.Click += new System.EventHandler(this.SaveBackLecReg_Click);
            // 
            // BackLecReg
            // 
            this.BackLecReg.Location = new System.Drawing.Point(397, 129);
            this.BackLecReg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BackLecReg.Name = "BackLecReg";
            this.BackLecReg.Size = new System.Drawing.Size(207, 53);
            this.BackLecReg.TabIndex = 9;
            this.BackLecReg.Text = "Grįžti";
            this.BackLecReg.UseVisualStyleBackColor = true;
            this.BackLecReg.Click += new System.EventHandler(this.BackLecReg_Click);
            // 
            // SubjectPanel
            // 
            this.SubjectPanel.Controls.Add(this.SaveNextSubjReg);
            this.SubjectPanel.Controls.Add(this.BackSubjReg);
            this.SubjectPanel.Controls.Add(this.SaveBackSubjReg);
            this.SubjectPanel.Controls.Add(this.FacultyLabelSubj);
            this.SubjectPanel.Controls.Add(this.FacultySelectSubj);
            this.SubjectPanel.Controls.Add(this.NameLabelSubj);
            this.SubjectPanel.Controls.Add(this.NameTextBoxSubj);
            this.SubjectPanel.Location = new System.Drawing.Point(0, 0);
            this.SubjectPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SubjectPanel.Name = "SubjectPanel";
            this.SubjectPanel.Size = new System.Drawing.Size(737, 435);
            this.SubjectPanel.TabIndex = 10;
            this.SubjectPanel.Visible = false;
            // 
            // SaveNextSubjReg
            // 
            this.SaveNextSubjReg.Location = new System.Drawing.Point(378, 260);
            this.SaveNextSubjReg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SaveNextSubjReg.Name = "SaveNextSubjReg";
            this.SaveNextSubjReg.Size = new System.Drawing.Size(207, 53);
            this.SaveNextSubjReg.TabIndex = 14;
            this.SaveNextSubjReg.Text = "Išsaugoti ir registruoti kitą";
            this.SaveNextSubjReg.UseVisualStyleBackColor = true;
            this.SaveNextSubjReg.Click += new System.EventHandler(this.SaveNextSubjReg_Click);
            // 
            // BackSubjReg
            // 
            this.BackSubjReg.Location = new System.Drawing.Point(378, 138);
            this.BackSubjReg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BackSubjReg.Name = "BackSubjReg";
            this.BackSubjReg.Size = new System.Drawing.Size(207, 53);
            this.BackSubjReg.TabIndex = 13;
            this.BackSubjReg.Text = "Grįžti";
            this.BackSubjReg.UseVisualStyleBackColor = true;
            this.BackSubjReg.Click += new System.EventHandler(this.BackSubjReg_Click);
            // 
            // SaveBackSubjReg
            // 
            this.SaveBackSubjReg.Location = new System.Drawing.Point(378, 199);
            this.SaveBackSubjReg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SaveBackSubjReg.Name = "SaveBackSubjReg";
            this.SaveBackSubjReg.Size = new System.Drawing.Size(207, 53);
            this.SaveBackSubjReg.TabIndex = 12;
            this.SaveBackSubjReg.Text = "Išsaugoti ir grįžti";
            this.SaveBackSubjReg.UseVisualStyleBackColor = true;
            this.SaveBackSubjReg.Click += new System.EventHandler(this.SaveBackSubjReg_Click);
            // 
            // FacultyLabelSubj
            // 
            this.FacultyLabelSubj.AutoSize = true;
            this.FacultyLabelSubj.Location = new System.Drawing.Point(68, 114);
            this.FacultyLabelSubj.Name = "FacultyLabelSubj";
            this.FacultyLabelSubj.Size = new System.Drawing.Size(88, 20);
            this.FacultyLabelSubj.TabIndex = 11;
            this.FacultyLabelSubj.Text = "Fakultetas:";
            // 
            // FacultySelectSubj
            // 
            this.FacultySelectSubj.FormattingEnabled = true;
            this.FacultySelectSubj.ItemHeight = 20;
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
            this.FacultySelectSubj.Location = new System.Drawing.Point(72, 138);
            this.FacultySelectSubj.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FacultySelectSubj.Name = "FacultySelectSubj";
            this.FacultySelectSubj.Size = new System.Drawing.Size(274, 284);
            this.FacultySelectSubj.TabIndex = 6;
            this.FacultySelectSubj.SelectedIndexChanged += new System.EventHandler(this.FacultySelectSubj_SelectedIndexChanged);
            // 
            // NameLabelSubj
            // 
            this.NameLabelSubj.AutoSize = true;
            this.NameLabelSubj.Location = new System.Drawing.Point(68, 46);
            this.NameLabelSubj.Name = "NameLabelSubj";
            this.NameLabelSubj.Size = new System.Drawing.Size(102, 20);
            this.NameLabelSubj.TabIndex = 1;
            this.NameLabelSubj.Text = "Pavadinimas:";
            // 
            // NameTextBoxSubj
            // 
            this.NameTextBoxSubj.Location = new System.Drawing.Point(71, 71);
            this.NameTextBoxSubj.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NameTextBoxSubj.Name = "NameTextBoxSubj";
            this.NameTextBoxSubj.Size = new System.Drawing.Size(602, 26);
            this.NameTextBoxSubj.TabIndex = 0;
            // 
            // AllLecturers
            // 
            this.AllLecturers.Controls.Add(this.ListLectLabel);
            this.AllLecturers.Controls.Add(this.ListLectTable);
            this.AllLecturers.Controls.Add(this.ListBack);
            this.AllLecturers.Location = new System.Drawing.Point(0, 0);
            this.AllLecturers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AllLecturers.Name = "AllLecturers";
            this.AllLecturers.Size = new System.Drawing.Size(737, 435);
            this.AllLecturers.TabIndex = 3;
            this.AllLecturers.Visible = false;
            // 
            // ListLectLabel
            // 
            this.ListLectLabel.AutoSize = true;
            this.ListLectLabel.Location = new System.Drawing.Point(3, 11);
            this.ListLectLabel.Name = "ListLectLabel";
            this.ListLectLabel.Size = new System.Drawing.Size(83, 20);
            this.ListLectLabel.TabIndex = 3;
            this.ListLectLabel.Text = "Dėstytojai:";
            // 
            // ListLectTable
            // 
            this.ListLectTable.AllowUserToAddRows = false;
            this.ListLectTable.AllowUserToDeleteRows = false;
            this.ListLectTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListLectTable.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ListLectTable.Location = new System.Drawing.Point(0, 36);
            this.ListLectTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ListLectTable.Name = "ListLectTable";
            this.ListLectTable.ReadOnly = true;
            this.ListLectTable.RowHeadersWidth = 51;
            this.ListLectTable.RowTemplate.Height = 24;
            this.ListLectTable.Size = new System.Drawing.Size(734, 342);
            this.ListLectTable.TabIndex = 1;
            // 
            // ListBack
            // 
            this.ListBack.Location = new System.Drawing.Point(301, 386);
            this.ListBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ListBack.Name = "ListBack";
            this.ListBack.Size = new System.Drawing.Size(135, 38);
            this.ListBack.TabIndex = 0;
            this.ListBack.Text = "Grįžti";
            this.ListBack.UseVisualStyleBackColor = true;
            this.ListBack.Click += new System.EventHandler(this.ListBack_Click);
            // 
            // ListSubjLabel
            // 
            this.ListSubjLabel.AutoSize = true;
            this.ListSubjLabel.Location = new System.Drawing.Point(3, 11);
            this.ListSubjLabel.Name = "ListSubjLabel";
            this.ListSubjLabel.Size = new System.Drawing.Size(64, 20);
            this.ListSubjLabel.TabIndex = 4;
            this.ListSubjLabel.Text = "Dalykai:";
            // 
            // ListSubjTable
            // 
            this.ListSubjTable.AllowUserToAddRows = false;
            this.ListSubjTable.AllowUserToDeleteRows = false;
            this.ListSubjTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListSubjTable.Location = new System.Drawing.Point(0, 35);
            this.ListSubjTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ListSubjTable.Name = "ListSubjTable";
            this.ListSubjTable.ReadOnly = true;
            this.ListSubjTable.RowHeadersWidth = 51;
            this.ListSubjTable.RowTemplate.Height = 24;
            this.ListSubjTable.Size = new System.Drawing.Size(734, 343);
            this.ListSubjTable.TabIndex = 2;
            // 
            // AllSubjects
            // 
            this.AllSubjects.Controls.Add(this.ListBack1);
            this.AllSubjects.Controls.Add(this.ListSubjLabel);
            this.AllSubjects.Controls.Add(this.ListSubjTable);
            this.AllSubjects.Location = new System.Drawing.Point(0, 0);
            this.AllSubjects.Name = "AllSubjects";
            this.AllSubjects.Size = new System.Drawing.Size(737, 432);
            this.AllSubjects.TabIndex = 4;
            // 
            // ListBack1
            // 
            this.ListBack1.Location = new System.Drawing.Point(301, 386);
            this.ListBack1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ListBack1.Name = "ListBack1";
            this.ListBack1.Size = new System.Drawing.Size(135, 38);
            this.ListBack1.TabIndex = 5;
            this.ListBack1.Text = "Grįžti";
            this.ListBack1.UseVisualStyleBackColor = true;
            this.ListBack1.Click += new System.EventHandler(this.ListBack_Click);
            // 
            // RegForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 432);
            this.Controls.Add(this.LecturerPanel);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.SubjectPanel);
            this.Controls.Add(this.AllLecturers);
            this.Controls.Add(this.AllSubjects);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RegForm";
            this.Text = "Vilnius_University_Advisor";
            this.Menu.ResumeLayout(false);
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

        private System.Windows.Forms.Panel Menu;
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
        private System.Windows.Forms.Button ListBack;
        private System.Windows.Forms.DataGridView ListLectTable;
        private System.Windows.Forms.Label ListSubjLabel;
        private System.Windows.Forms.Label ListLectLabel;
        private System.Windows.Forms.DataGridView ListSubjTable;
        private System.Windows.Forms.Button ListLect;
        private System.Windows.Forms.Panel AllSubjects;
        private System.Windows.Forms.Button ListBack1;
    }
}

