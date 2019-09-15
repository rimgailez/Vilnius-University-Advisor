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
            this.SubjReg = new System.Windows.Forms.Button();
            this.ListAll = new System.Windows.Forms.Button();
            this.LecReg = new System.Windows.Forms.Button();
            this.LecturerPanel = new System.Windows.Forms.Panel();
            this.SaveNextSubjReg = new System.Windows.Forms.Button();
            this.SaveNextLecReg = new System.Windows.Forms.Button();
            this.NameTextBoxLect = new System.Windows.Forms.TextBox();
            this.NameLabelLect = new System.Windows.Forms.Label();
            this.FacultySelectLect = new System.Windows.Forms.ListBox();
            this.FacultyLabelLect = new System.Windows.Forms.Label();
            this.SaveBackLecReg = new System.Windows.Forms.Button();
            this.BackLecReg = new System.Windows.Forms.Button();
            this.SubjectPanel = new System.Windows.Forms.Panel();
            this.BackSubjReg = new System.Windows.Forms.Button();
            this.SaveBackSubjReg = new System.Windows.Forms.Button();
            this.FacultyLabelSubj = new System.Windows.Forms.Label();
            this.FacultySelectSubj = new System.Windows.Forms.ListBox();
            this.NameLabelSubj = new System.Windows.Forms.Label();
            this.NameTextBoxSubj = new System.Windows.Forms.TextBox();
            this.ListAllPanel = new System.Windows.Forms.Panel();
            this.ListSubjLabel = new System.Windows.Forms.Label();
            this.ListLectLabel = new System.Windows.Forms.Label();
            this.ListSubjTable = new System.Windows.Forms.DataGridView();
            this.ListLectTable = new System.Windows.Forms.DataGridView();
            this.ListBack = new System.Windows.Forms.Button();
            this.Menu.SuspendLayout();
            this.LecturerPanel.SuspendLayout();
            this.SubjectPanel.SuspendLayout();
            this.ListAllPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListSubjTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListLectTable)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Controls.Add(this.SubjReg);
            this.Menu.Controls.Add(this.ListAll);
            this.Menu.Controls.Add(this.LecReg);
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(801, 452);
            this.Menu.TabIndex = 0;
            // 
            // SubjReg
            // 
            this.SubjReg.Location = new System.Drawing.Point(418, 227);
            this.SubjReg.Name = "SubjReg";
            this.SubjReg.Size = new System.Drawing.Size(315, 110);
            this.SubjReg.TabIndex = 2;
            this.SubjReg.Text = "Registruoti Dalyką";
            this.SubjReg.UseVisualStyleBackColor = true;
            this.SubjReg.Click += new System.EventHandler(this.SubjReg_Click);
            // 
            // ListAll
            // 
            this.ListAll.Location = new System.Drawing.Point(63, 37);
            this.ListAll.Name = "ListAll";
            this.ListAll.Size = new System.Drawing.Size(670, 110);
            this.ListAll.TabIndex = 0;
            this.ListAll.Text = "Rodyti dėstytojus ir dalykus";
            this.ListAll.UseVisualStyleBackColor = true;
            this.ListAll.Click += new System.EventHandler(this.ListAll_Click);
            // 
            // LecReg
            // 
            this.LecReg.Location = new System.Drawing.Point(63, 227);
            this.LecReg.Name = "LecReg";
            this.LecReg.Size = new System.Drawing.Size(315, 110);
            this.LecReg.TabIndex = 1;
            this.LecReg.Text = "Registruoti Dėstytoją";
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
            this.LecturerPanel.Size = new System.Drawing.Size(797, 448);
            this.LecturerPanel.TabIndex = 3;
            this.LecturerPanel.Visible = false;
            // 
            // SaveNextSubjReg
            // 
            this.SaveNextSubjReg.Location = new System.Drawing.Point(529, 346);
            this.SaveNextSubjReg.Name = "SaveNextSubjReg";
            this.SaveNextSubjReg.Size = new System.Drawing.Size(207, 76);
            this.SaveNextSubjReg.TabIndex = 14;
            this.SaveNextSubjReg.Text = "Išsaugoti ir registruoti kitą";
            this.SaveNextSubjReg.UseVisualStyleBackColor = true;
            this.SaveNextSubjReg.Click += new System.EventHandler(this.SaveNextSubjReg_Click);
            // 
            // SaveNextLecReg
            // 
            this.SaveNextLecReg.Location = new System.Drawing.Point(526, 346);
            this.SaveNextLecReg.Name = "SaveNextLecReg";
            this.SaveNextLecReg.Size = new System.Drawing.Size(207, 76);
            this.SaveNextLecReg.TabIndex = 8;
            this.SaveNextLecReg.Text = "Išsaugoti ir registruoti kitą";
            this.SaveNextLecReg.UseVisualStyleBackColor = true;
            this.SaveNextLecReg.Click += new System.EventHandler(this.SaveNextLecReg_Click);
            // 
            // NameTextBoxLect
            // 
            this.NameTextBoxLect.Location = new System.Drawing.Point(63, 29);
            this.NameTextBoxLect.Name = "NameTextBoxLect";
            this.NameTextBoxLect.Size = new System.Drawing.Size(670, 22);
            this.NameTextBoxLect.TabIndex = 3;
            // 
            // NameLabelLect
            // 
            this.NameLabelLect.AutoSize = true;
            this.NameLabelLect.Location = new System.Drawing.Point(60, 9);
            this.NameLabelLect.Name = "NameLabelLect";
            this.NameLabelLect.Size = new System.Drawing.Size(110, 17);
            this.NameLabelLect.TabIndex = 4;
            this.NameLabelLect.Text = "Vardas Pavardė";
            // 
            // FacultySelectLect
            // 
            this.FacultySelectLect.FormattingEnabled = true;
            this.FacultySelectLect.ItemHeight = 16;
            this.FacultySelectLect.Items.AddRange(new object[] {
            "Chemijos ir geomokslų",
            "Ekonomokos ir verslo administravimo",
            "Filologijos",
            "Filosofijos",
            "Fizikos",
            "Gyvybės mokslų centras",
            "Istorijos",
            "Kauno",
            "Komunikacijos",
            "Matematikos ir informatikos",
            "Medicinos",
            "Tarptautinių santykių ir politikos mokslų institutas",
            "Teisės",
            "Verslo mokykla"});
            this.FacultySelectLect.Location = new System.Drawing.Point(63, 85);
            this.FacultySelectLect.Name = "FacultySelectLect";
            this.FacultySelectLect.Size = new System.Drawing.Size(320, 228);
            this.FacultySelectLect.TabIndex = 5;
            // 
            // FacultyLabelLect
            // 
            this.FacultyLabelLect.AutoSize = true;
            this.FacultyLabelLect.Location = new System.Drawing.Point(60, 65);
            this.FacultyLabelLect.Name = "FacultyLabelLect";
            this.FacultyLabelLect.Size = new System.Drawing.Size(73, 17);
            this.FacultyLabelLect.TabIndex = 6;
            this.FacultyLabelLect.Text = "Fakultetas";
            // 
            // SaveBackLecReg
            // 
            this.SaveBackLecReg.Location = new System.Drawing.Point(295, 346);
            this.SaveBackLecReg.Name = "SaveBackLecReg";
            this.SaveBackLecReg.Size = new System.Drawing.Size(207, 76);
            this.SaveBackLecReg.TabIndex = 7;
            this.SaveBackLecReg.Text = "Išsaugoti ir grįžti";
            this.SaveBackLecReg.UseVisualStyleBackColor = true;
            this.SaveBackLecReg.Click += new System.EventHandler(this.SaveBackLecReg_Click);
            // 
            // BackLecReg
            // 
            this.BackLecReg.Location = new System.Drawing.Point(63, 346);
            this.BackLecReg.Name = "BackLecReg";
            this.BackLecReg.Size = new System.Drawing.Size(207, 76);
            this.BackLecReg.TabIndex = 9;
            this.BackLecReg.Text = "Grįžti";
            this.BackLecReg.UseVisualStyleBackColor = true;
            this.BackLecReg.Click += new System.EventHandler(this.BackLecReg_Click);
            // 
            // SubjectPanel
            // 
            this.SubjectPanel.Controls.Add(this.BackSubjReg);
            this.SubjectPanel.Controls.Add(this.SaveBackSubjReg);
            this.SubjectPanel.Controls.Add(this.FacultyLabelSubj);
            this.SubjectPanel.Controls.Add(this.FacultySelectSubj);
            this.SubjectPanel.Controls.Add(this.NameLabelSubj);
            this.SubjectPanel.Controls.Add(this.NameTextBoxSubj);
            this.SubjectPanel.Controls.Add(this.SaveNextSubjReg);
            this.SubjectPanel.Location = new System.Drawing.Point(0, 0);
            this.SubjectPanel.Name = "SubjectPanel";
            this.SubjectPanel.Size = new System.Drawing.Size(793, 437);
            this.SubjectPanel.TabIndex = 10;
            this.SubjectPanel.Visible = false;
            // 
            // BackSubjReg
            // 
            this.BackSubjReg.Location = new System.Drawing.Point(63, 346);
            this.BackSubjReg.Name = "BackSubjReg";
            this.BackSubjReg.Size = new System.Drawing.Size(207, 76);
            this.BackSubjReg.TabIndex = 13;
            this.BackSubjReg.Text = "Grįžti";
            this.BackSubjReg.UseVisualStyleBackColor = true;
            this.BackSubjReg.Click += new System.EventHandler(this.BackSubjReg_Click);
            // 
            // SaveBackSubjReg
            // 
            this.SaveBackSubjReg.Location = new System.Drawing.Point(295, 346);
            this.SaveBackSubjReg.Name = "SaveBackSubjReg";
            this.SaveBackSubjReg.Size = new System.Drawing.Size(207, 76);
            this.SaveBackSubjReg.TabIndex = 12;
            this.SaveBackSubjReg.Text = "Išsaugoti ir grįžti";
            this.SaveBackSubjReg.UseVisualStyleBackColor = true;
            this.SaveBackSubjReg.Click += new System.EventHandler(this.SaveBackSubjReg_Click);
            // 
            // FacultyLabelSubj
            // 
            this.FacultyLabelSubj.AutoSize = true;
            this.FacultyLabelSubj.Location = new System.Drawing.Point(60, 82);
            this.FacultyLabelSubj.Name = "FacultyLabelSubj";
            this.FacultyLabelSubj.Size = new System.Drawing.Size(73, 17);
            this.FacultyLabelSubj.TabIndex = 11;
            this.FacultyLabelSubj.Text = "Fakultetas";
            // 
            // FacultySelectSubj
            // 
            this.FacultySelectSubj.FormattingEnabled = true;
            this.FacultySelectSubj.ItemHeight = 16;
            this.FacultySelectSubj.Items.AddRange(new object[] {
            "Chemijos ir geomokslų",
            "Ekonomokos ir verslo administravimo",
            "Filologijos",
            "Filosofijos",
            "Fizikos",
            "Gyvybės mokslų centras",
            "Istorijos",
            "Kauno",
            "Komunikacijos",
            "Matematikos ir informatikos",
            "Medicinos",
            "Tarptautinių santykių ir politikos mokslų institutas",
            "Teisės",
            "Verslo mokykla"});
            this.FacultySelectSubj.Location = new System.Drawing.Point(63, 102);
            this.FacultySelectSubj.Name = "FacultySelectSubj";
            this.FacultySelectSubj.Size = new System.Drawing.Size(315, 228);
            this.FacultySelectSubj.TabIndex = 6;
            // 
            // NameLabelSubj
            // 
            this.NameLabelSubj.AutoSize = true;
            this.NameLabelSubj.Location = new System.Drawing.Point(60, 20);
            this.NameLabelSubj.Name = "NameLabelSubj";
            this.NameLabelSubj.Size = new System.Drawing.Size(88, 17);
            this.NameLabelSubj.TabIndex = 1;
            this.NameLabelSubj.Text = "Pavadinimas";
            // 
            // NameTextBoxSubj
            // 
            this.NameTextBoxSubj.Location = new System.Drawing.Point(63, 40);
            this.NameTextBoxSubj.Name = "NameTextBoxSubj";
            this.NameTextBoxSubj.Size = new System.Drawing.Size(670, 22);
            this.NameTextBoxSubj.TabIndex = 0;
            // 
            // ListAllPanel
            // 
            this.ListAllPanel.Controls.Add(this.ListSubjLabel);
            this.ListAllPanel.Controls.Add(this.ListLectLabel);
            this.ListAllPanel.Controls.Add(this.ListSubjTable);
            this.ListAllPanel.Controls.Add(this.ListLectTable);
            this.ListAllPanel.Controls.Add(this.ListBack);
            this.ListAllPanel.Location = new System.Drawing.Point(0, 0);
            this.ListAllPanel.Name = "ListAllPanel";
            this.ListAllPanel.Size = new System.Drawing.Size(797, 447);
            this.ListAllPanel.TabIndex = 3;
            this.ListAllPanel.Visible = false;
            // 
            // ListSubjLabel
            // 
            this.ListSubjLabel.AutoSize = true;
            this.ListSubjLabel.Location = new System.Drawing.Point(3, 212);
            this.ListSubjLabel.Name = "ListSubjLabel";
            this.ListSubjLabel.Size = new System.Drawing.Size(54, 17);
            this.ListSubjLabel.TabIndex = 4;
            this.ListSubjLabel.Text = "Dalykai";
            // 
            // ListLectLabel
            // 
            this.ListLectLabel.AutoSize = true;
            this.ListLectLabel.Location = new System.Drawing.Point(3, 9);
            this.ListLectLabel.Name = "ListLectLabel";
            this.ListLectLabel.Size = new System.Drawing.Size(70, 17);
            this.ListLectLabel.TabIndex = 3;
            this.ListLectLabel.Text = "Dėstytojai";
            // 
            // ListSubjTable
            // 
            this.ListSubjTable.AllowUserToAddRows = false;
            this.ListSubjTable.AllowUserToDeleteRows = false;
            this.ListSubjTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListSubjTable.Location = new System.Drawing.Point(4, 232);
            this.ListSubjTable.Name = "ListSubjTable";
            this.ListSubjTable.ReadOnly = true;
            this.ListSubjTable.RowHeadersWidth = 51;
            this.ListSubjTable.RowTemplate.Height = 24;
            this.ListSubjTable.Size = new System.Drawing.Size(790, 170);
            this.ListSubjTable.TabIndex = 2;
            // 
            // ListLectTable
            // 
            this.ListLectTable.AllowUserToAddRows = false;
            this.ListLectTable.AllowUserToDeleteRows = false;
            this.ListLectTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListLectTable.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ListLectTable.Location = new System.Drawing.Point(0, 29);
            this.ListLectTable.Name = "ListLectTable";
            this.ListLectTable.ReadOnly = true;
            this.ListLectTable.RowHeadersWidth = 51;
            this.ListLectTable.RowTemplate.Height = 24;
            this.ListLectTable.Size = new System.Drawing.Size(793, 170);
            this.ListLectTable.TabIndex = 1;
            // 
            // ListBack
            // 
            this.ListBack.Location = new System.Drawing.Point(324, 408);
            this.ListBack.Name = "ListBack";
            this.ListBack.Size = new System.Drawing.Size(120, 30);
            this.ListBack.TabIndex = 0;
            this.ListBack.Text = "Grįžti";
            this.ListBack.UseVisualStyleBackColor = true;
            this.ListBack.Click += new System.EventHandler(this.ListBack_Click);
            // 
            // RegForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SubjectPanel);
            this.Controls.Add(this.LecturerPanel);
            this.Controls.Add(this.ListAllPanel);
            this.Controls.Add(this.Menu);
            this.Name = "RegForm";
            this.Text = "Registracija";
            this.Menu.ResumeLayout(false);
            this.LecturerPanel.ResumeLayout(false);
            this.LecturerPanel.PerformLayout();
            this.SubjectPanel.ResumeLayout(false);
            this.SubjectPanel.PerformLayout();
            this.ListAllPanel.ResumeLayout(false);
            this.ListAllPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListSubjTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListLectTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Menu;
        private System.Windows.Forms.Button ListAll;
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
        private System.Windows.Forms.Panel ListAllPanel;
        private System.Windows.Forms.Button ListBack;
        private System.Windows.Forms.DataGridView ListLectTable;
        private System.Windows.Forms.Label ListSubjLabel;
        private System.Windows.Forms.Label ListLectLabel;
        private System.Windows.Forms.DataGridView ListSubjTable;
    }
}

