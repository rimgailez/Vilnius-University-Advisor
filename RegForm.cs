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
            Menu.Hide();
            LecturerPanel.Show();
        }

        private void SaveNextLecReg_Click(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)FacultySelectLect.SelectedIndex;
            Lecturer lecturer = new Lecturer(NameTextBoxLect.Text, faculty);
            Program.AddLecturer(lecturer);
            NameTextBoxLect.Text = "";
            FacultySelectLect.ClearSelected();
        }

        private void SaveBackLecReg_Click(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)FacultySelectLect.SelectedIndex;
            Lecturer lecturer = new Lecturer(NameTextBoxLect.Text, faculty);
            Program.AddLecturer(lecturer);
            NameTextBoxLect.Text = "";
            FacultySelectLect.ClearSelected();
            LecturerPanel.Hide();
            Menu.Show();

        }

        private void BackLecReg_Click(object sender, EventArgs e)
        {
            NameTextBoxLect.Text = "";
            FacultySelectLect.ClearSelected();
            LecturerPanel.Hide();
            Menu.Show();
        }

        private void SaveNextSubjReg_Click(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)FacultySelectSubj.SelectedIndex;
            Subject subject = new Subject(NameTextBoxSubj.Text, faculty);
            Program.AddSubject(subject);
            NameTextBoxSubj.Text = "";
            FacultySelectSubj.ClearSelected();
        }

        private void SubjReg_Click(object sender, EventArgs e)
        {
            Menu.Hide();
            SubjectPanel.Show();
        }

        private void SaveBackSubjReg_Click(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)FacultySelectSubj.SelectedIndex;
            Subject subject = new Subject(NameTextBoxSubj.Text, faculty);
            Program.AddSubject(subject);
            NameTextBoxSubj.Text = "";
            FacultySelectSubj.ClearSelected();
            SubjectPanel.Hide();
            Menu.Show();
        }

        private void BackSubjReg_Click(object sender, EventArgs e)
        {
            NameTextBoxSubj.Text = "";
            FacultySelectSubj.ClearSelected();
            SubjectPanel.Hide();
            Menu.Show();
        }

        private void ListBack_Click(object sender, EventArgs e)
        {
            AllLecturers.Hide();
            Menu.Show();
        }

        private void FacultySelectSubj_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FacultyLabelLect_Click(object sender, EventArgs e)
        {

        }

        private void ListSubj_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = Program.getSubjects();
            //display correct panel
            Menu.Hide();
            AllSubjects.Show();
        }

        private void ListLect_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = Program.getLecturers();
            //display correct panel
            Menu.Hide();
            AllLecturers.Show();
        }
    }
}
