using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vilnius_University_Advisor
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
        }

        private void LecReg_Click(object sender, EventArgs e)
        {
            MainMenu.Hide();
            LecturerPanel.Show();
        }

        private void SaveNextLecReg_Click(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)FacultySelectLect.SelectedIndex;
            DataMaster.AddLecturer(NameTextBoxLect.Text, faculty);
            NameTextBoxLect.Text = "";
            FacultySelectLect.ClearSelected();
        }

        private void SaveBackLecReg_Click(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)FacultySelectLect.SelectedIndex;
            DataMaster.AddLecturer(NameTextBoxLect.Text, faculty);
            NameTextBoxLect.Text = "";
            FacultySelectLect.ClearSelected();
            LecturerPanel.Hide();
            MainMenu.Show();

        }

        private void BackLecReg_Click(object sender, EventArgs e)
        {
            NameTextBoxLect.Text = "";
            FacultySelectLect.ClearSelected();
            LecturerPanel.Hide();
            MainMenu.Show();
        }

        private void SaveNextSubjReg_Click(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)FacultySelectSubj.SelectedIndex;
            DataMaster.AddSubject(NameTextBoxSubj.Text, faculty, IsOptional.Checked, IsBUS.Checked);
            IsOptional.Checked = true;
            NameTextBoxSubj.Text = "";
            FacultySelectSubj.ClearSelected();
        }

        private void SubjReg_Click(object sender, EventArgs e)
        {
            MainMenu.Hide();
            SubjectPanel.Show();
        }

        private void SaveBackSubjReg_Click(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)FacultySelectSubj.SelectedIndex;
            DataMaster.AddSubject(NameTextBoxSubj.Text, faculty, IsOptional.Checked, IsBUS.Checked);
            IsOptional.Checked = true;
            NameTextBoxSubj.Text = "";
            FacultySelectSubj.ClearSelected();
            SubjectPanel.Hide();
            MainMenu.Show();
        }

        private void BackSubjReg_Click(object sender, EventArgs e)
        {
            NameTextBoxSubj.Text = "";
            FacultySelectSubj.ClearSelected();
            SubjectPanel.Hide();
            MainMenu.Show();
        }

        private void ListLectBack_Click(object sender, EventArgs e)
        {
            AllLecturers.Hide();
            MainMenu.Show();
        }

        private void ListSubj_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.getSubjects();
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            MainMenu.Hide();
            AllSubjects.Show();
        }

        private void ListLect_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.getLecturers();
            ListLectTable.Columns[0].Width = 400;
            ListLectTable.Columns[1].Width = 200;
            ListLectTable.Columns[2].Width = 40;
            ListLectTable.Columns[3].Width = 80;
            //display correct panel
            MainMenu.Hide();
            AllLecturers.Show();
        }

        private void ListSubjBack_Click(object sender, EventArgs e)
        {
            AllSubjects.Hide();
            MainMenu.Show();
        }
    }
}
