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
            DataMaster.GetInstance().AddLecturer(NameTextBoxLect.Text, faculty);
            NameTextBoxLect.Text = "";
            FacultySelectLect.ClearSelected();
        }

        private void SaveBackLecReg_Click(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)FacultySelectLect.SelectedIndex;
            DataMaster.GetInstance().AddLecturer(NameTextBoxLect.Text, faculty);
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
            DataMaster.GetInstance().AddSubject(NameTextBoxSubj.Text, faculty, IsOptional.Checked, IsBUS.Checked);
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
            DataMaster.GetInstance().AddSubject(NameTextBoxSubj.Text, faculty, IsOptional.Checked, IsBUS.Checked);
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
            //display correct panel
            MainMenu.Hide();
            OptionalSubjects.Show();
        }

        private void ListLect_Click(object sender, EventArgs e)
        {
            //display correct panel
            MainMenu.Hide();
            LecturersByFaculty.Show();
        }

        private void ListSubjBack_Click(object sender, EventArgs e)
        {
            AllSubjects.Hide();
            MainMenu.Show();
        }

        private void ListSubj1_Click(object sender, EventArgs e)
        {
            //display correct panel
            MainMenu.Hide();
            MandatorySubjects.Show();
        }

        private void BUS_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getBUSSubjects();
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            OptionalSubjects.Hide();
            AllSubjects.Show();
        }

        private void CHGF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(true, Faculty.Chemijos_ir_geomokslų);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            OptionalSubjects.Hide();
            AllSubjects.Show();
        }

        private void EVAF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(true, Faculty.Ekonomikos_ir_verslo_administravimo);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            OptionalSubjects.Hide();
            AllSubjects.Show();
        }

        private void FLF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(true, Faculty.Filologijos);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            OptionalSubjects.Hide();
            AllSubjects.Show();
        }

        private void FSF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(true, Faculty.Filosofijos);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            OptionalSubjects.Hide();
            AllSubjects.Show();
        }

        private void FF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(true, Faculty.Fizikos);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            OptionalSubjects.Hide();
            AllSubjects.Show();
        }

        private void GMC_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(true, Faculty.Gyvybės_mokslų);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            OptionalSubjects.Hide();
            AllSubjects.Show();
        }

        private void IF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(true, Faculty.Istorijos);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            OptionalSubjects.Hide();
            AllSubjects.Show();
        }

        private void KNF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(true, Faculty.Kauno);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            OptionalSubjects.Hide();
            AllSubjects.Show();
        }

        private void KF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(true, Faculty.Komunikacijos);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            OptionalSubjects.Hide();
            AllSubjects.Show();
        }

        private void MIF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(true, Faculty.Matematikos_ir_informatikos);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            OptionalSubjects.Hide();
            AllSubjects.Show();
        }

        private void MF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(true, Faculty.Medicinos);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            OptionalSubjects.Hide();
            AllSubjects.Show();
        }

        private void TSPMI_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(true, Faculty.Tarptautinių_santykių_ir_politikos_mokslų);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            OptionalSubjects.Hide();
            AllSubjects.Show();
        }

        private void TF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(true, Faculty.Teisės);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            OptionalSubjects.Hide();
            AllSubjects.Show();
        }

        

        private void CHGF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(false, Faculty.Chemijos_ir_geomokslų);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            MandatorySubjects.Hide();
            AllSubjects.Show();
        }

        private void EVAF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(false, Faculty.Ekonomikos_ir_verslo_administravimo);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            MandatorySubjects.Hide();
            AllSubjects.Show();
        }

        private void FLF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(false, Faculty.Filologijos);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            MandatorySubjects.Hide();
            AllSubjects.Show();
        }

        private void FSF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(false, Faculty.Filosofijos);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            MandatorySubjects.Hide();
            AllSubjects.Show();
        }

        private void FF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(false, Faculty.Fizikos);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            MandatorySubjects.Hide();
            AllSubjects.Show();
        }

        private void GMC1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(false, Faculty.Gyvybės_mokslų);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            MandatorySubjects.Hide();
            AllSubjects.Show();
        }

        private void IF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(false, Faculty.Istorijos);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            MandatorySubjects.Hide();
            AllSubjects.Show();
        }

        private void KNF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(false, Faculty.Kauno);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            MandatorySubjects.Hide();
            AllSubjects.Show();
        }

        private void KF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(false, Faculty.Komunikacijos);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            MandatorySubjects.Hide();
            AllSubjects.Show();
        }

        private void MIF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(false, Faculty.Matematikos_ir_informatikos);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            MandatorySubjects.Hide();
            AllSubjects.Show();
        }

        private void MF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(false, Faculty.Medicinos);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            MandatorySubjects.Hide();
            AllSubjects.Show();
        }

        private void TSPMI1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(false, Faculty.Tarptautinių_santykių_ir_politikos_mokslų);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            MandatorySubjects.Hide();
            AllSubjects.Show();
        }

        private void TF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(false, Faculty.Teisės);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            MandatorySubjects.Hide();
            AllSubjects.Show();
        }

        private void VM1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(false, Faculty.Verslo);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            MandatorySubjects.Hide();
            AllSubjects.Show();
        }

        private void VM_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().getSubjectsByTypeAndFaculty(true, Faculty.Verslo);
            ListSubjTable.Columns[0].Width = 400;
            ListSubjTable.Columns[1].Width = 200;
            ListSubjTable.Columns[2].Width = 40;
            ListSubjTable.Columns[3].Width = 80;
            //display correct panel
            OptionalSubjects.Hide();
            AllSubjects.Show();
        }

        private void ReviewLecturer_Click(object sender, EventArgs e)
        {
            //display correct panel
            MainMenu.Hide();
            EvaluateLecturer.Show();
        }

        private void CHGF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().getLecturersByFaculty(Faculty.Chemijos_ir_geomokslų);
            ListLectTable.Columns[0].Width = 400;
            ListLectTable.Columns[1].Width = 200;
            ListLectTable.Columns[2].Width = 40;
            ListLectTable.Columns[3].Width = 80;
            //display correct panel
            LecturersByFaculty.Hide();
            AllLecturers.Show();
        }

        private void EVAF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().getLecturersByFaculty(Faculty.Ekonomikos_ir_verslo_administravimo);
            ListLectTable.Columns[0].Width = 400;
            ListLectTable.Columns[1].Width = 200;
            ListLectTable.Columns[2].Width = 40;
            ListLectTable.Columns[3].Width = 80;
            //display correct panel
            LecturersByFaculty.Hide();
            AllLecturers.Show();
        }

        private void FLF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().getLecturersByFaculty(Faculty.Filologijos);
            ListLectTable.Columns[0].Width = 400;
            ListLectTable.Columns[1].Width = 200;
            ListLectTable.Columns[2].Width = 40;
            ListLectTable.Columns[3].Width = 80;
            //display correct panel
            LecturersByFaculty.Hide();
            AllLecturers.Show();
        }

        private void FSF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().getLecturersByFaculty(Faculty.Filosofijos);
            ListLectTable.Columns[0].Width = 400;
            ListLectTable.Columns[1].Width = 200;
            ListLectTable.Columns[2].Width = 40;
            ListLectTable.Columns[3].Width = 80;
            //display correct panel
            LecturersByFaculty.Hide();
            AllLecturers.Show();
        }

        private void FF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().getLecturersByFaculty(Faculty.Fizikos);
            ListLectTable.Columns[0].Width = 400;
            ListLectTable.Columns[1].Width = 200;
            ListLectTable.Columns[2].Width = 40;
            ListLectTable.Columns[3].Width = 80;
            //display correct panel
            LecturersByFaculty.Hide();
            AllLecturers.Show();
        }

        private void GMC2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().getLecturersByFaculty(Faculty.Gyvybės_mokslų);
            ListLectTable.Columns[0].Width = 400;
            ListLectTable.Columns[1].Width = 200;
            ListLectTable.Columns[2].Width = 40;
            ListLectTable.Columns[3].Width = 80;
            //display correct panel
            LecturersByFaculty.Hide();
            AllLecturers.Show();
        }

        private void IF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().getLecturersByFaculty(Faculty.Istorijos);
            ListLectTable.Columns[0].Width = 400;
            ListLectTable.Columns[1].Width = 200;
            ListLectTable.Columns[2].Width = 40;
            ListLectTable.Columns[3].Width = 80;
            //display correct panel
            LecturersByFaculty.Hide();
            AllLecturers.Show();
        }

        private void KNF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().getLecturersByFaculty(Faculty.Kauno);
            ListLectTable.Columns[0].Width = 400;
            ListLectTable.Columns[1].Width = 200;
            ListLectTable.Columns[2].Width = 40;
            ListLectTable.Columns[3].Width = 80;
            //display correct panel
            LecturersByFaculty.Hide();
            AllLecturers.Show();
        }

        private void KF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().getLecturersByFaculty(Faculty.Komunikacijos);
            ListLectTable.Columns[0].Width = 400;
            ListLectTable.Columns[1].Width = 200;
            ListLectTable.Columns[2].Width = 40;
            ListLectTable.Columns[3].Width = 80;
            //display correct panel
            LecturersByFaculty.Hide();
            AllLecturers.Show();
        }

        private void MIF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().getLecturersByFaculty(Faculty.Matematikos_ir_informatikos);
            ListLectTable.Columns[0].Width = 400;
            ListLectTable.Columns[1].Width = 200;
            ListLectTable.Columns[2].Width = 40;
            ListLectTable.Columns[3].Width = 80;
            //display correct panel
            LecturersByFaculty.Hide();
            AllLecturers.Show();
        }

        private void MF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().getLecturersByFaculty(Faculty.Medicinos);
            ListLectTable.Columns[0].Width = 400;
            ListLectTable.Columns[1].Width = 200;
            ListLectTable.Columns[2].Width = 40;
            ListLectTable.Columns[3].Width = 80;
            //display correct panel
            LecturersByFaculty.Hide();
            AllLecturers.Show();
        }

        private void TSPMI2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().getLecturersByFaculty(Faculty.Tarptautinių_santykių_ir_politikos_mokslų);
            ListLectTable.Columns[0].Width = 400;
            ListLectTable.Columns[1].Width = 200;
            ListLectTable.Columns[2].Width = 40;
            ListLectTable.Columns[3].Width = 80;
            //display correct panel
            LecturersByFaculty.Hide();
            AllLecturers.Show();
        }

        private void TF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().getLecturersByFaculty(Faculty.Teisės);
            ListLectTable.Columns[0].Width = 400;
            ListLectTable.Columns[1].Width = 200;
            ListLectTable.Columns[2].Width = 40;
            ListLectTable.Columns[3].Width = 80;
            //display correct panel
            LecturersByFaculty.Hide();
            AllLecturers.Show();
        }

        private void VM2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().getLecturersByFaculty(Faculty.Verslo);
            ListLectTable.Columns[0].Width = 400;
            ListLectTable.Columns[1].Width = 200;
            ListLectTable.Columns[2].Width = 40;
            ListLectTable.Columns[3].Width = 80;
            //display correct panel
            LecturersByFaculty.Hide();
            AllLecturers.Show();
        }

        private void SelectFacultyLect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)SelectFacultyLect.SelectedIndex;
            FilteredLecturersList.DataSource = null;
            FilteredLecturersList.DataSource = DataMaster.GetInstance().getLecturersByFaculty(faculty);
            FilteredLecturersList.DisplayMember = "name";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            NumericEvaluationLect.Value = 1;
            EvaluationCommentLabel.Text = "1 - esu visiškai nepatenkintas dėstytojo darbu.";
        }

        private void BackLecEvaluation_Click(object sender, EventArgs e)
        {
            ClearAllFieldsInLectForms();

            EvaluateLecturer.Hide();
            MainMenu.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            NumericEvaluationLect.Value = 2;
            EvaluationCommentLabel.Text = "2 - esu matęs kur kas geresnių dėstytojų...";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            NumericEvaluationLect.Value = 3;
            EvaluationCommentLabel.Text = "3 - dėstytojas didelio įspūdžio nepaliko.";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            NumericEvaluationLect.Value = 4;
            EvaluationCommentLabel.Text = "4 - dėstytojas gerai dirba savo darbą, bet vis dėlto šio to pasigedau.";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            NumericEvaluationLect.Value = 5;
            EvaluationCommentLabel.Text = "5 - dėstytojas puikiai išmano dėstomą dalyką ir geba informaciją pateikti labai aiškiai ir nuosekliai.";
        }

        private void ReviewSubject_Click(object sender, EventArgs e)
        {
            //display correct panel
            MainMenu.Hide();
            EvaluateSubjects.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SaveBackLectEvaluation_Click(object sender, EventArgs e)
        {
            if (EvaluateLecturerWithValidations())
            {
                ClearAllFieldsInLectForms();

                EvaluateLecturer.Hide();
                MainMenu.Show();
            }
        }

        private void SaveEvalNextLect_Click(object sender, EventArgs e)
        {
            if (EvaluateLecturerWithValidations())
            {
                ClearAllFieldsInLectForms();
            }

        }

        private Boolean EvaluateLecturerWithValidations()
        {
            if (FilteredLecturersList.SelectedItem == null || NumericEvaluationLect.Value == 0 || ReviewLectEvalTxtBox.Text.Equals(""))
            {
                MessageBox.Show("Prašome užpildyti visus formoje esančius laukus.", "Neužpildyti laukai", 0, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                Lecturer selectedLecturer = (Lecturer)FilteredLecturersList.SelectedItem;
                DataMaster.GetInstance().EvaluateLecturer(selectedLecturer.name, (float)NumericEvaluationLect.Value, ReviewLectEvalTxtBox.Text);
                return true;
            }
        }
        private void ClearAllFieldsInLectForms()
        {
            SelectFacultyLect.Text = "";
            FilteredLecturersList.DataSource = null;
            ReviewLectEvalTxtBox.Text = "";
            EvaluationCommentLabel.Text = "...";
            NumericEvaluationLect.Value = 0;
        }
        private void RunScraper_Click(object sender, EventArgs e)
        {
            MainMenu.Hide();
            ScraperPanel.Show();
            (new Scraper.ScraperMain(DataMaster.GetInstance().projectPath, this)).StartScrap();
            ScraperBack.Show();
        }
        public void updateScraperTextbox(string text)
        {
            ScraperLog.Text += text + System.Environment.NewLine;
            ScraperLog.SelectionStart = ScraperLog.Text.Length;
            ScraperLog.ScrollToCaret();
        }
        private void ScraperBack_Click(object sender, EventArgs e)
        {
            ScraperPanel.Hide();
            MainMenu.Show();
            ScraperBack.Hide();
            ScraperLog.Text = "";
        }
    }
}
