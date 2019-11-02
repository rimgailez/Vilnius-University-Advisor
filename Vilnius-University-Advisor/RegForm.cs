using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vilnius_University_Advisor
{
    public partial class RegForm : Form
    {
        static ValidationMsgPrinter validPrintObj = ValidationMsgPrinter.GetInstance();
        public delegate void Del(string message, string caption);
        public Del simpleMsg = validPrintObj.PrintOnlyMessage;
        public Del warningMsg = validPrintObj.PrintWarningMessage;
        string path = Directory.GetParent(Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)).FullName).FullName).FullName;

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
            DataFetcher.GetInstance().AddLecturer(NameTextBoxLect.Text, faculty);
            DataFetcher.GetInstance().AddToHistory(MainResources.RegisteredLecturer + NameTextBoxLect.Text + ";");
            NameTextBoxLect.Text = "";
            FacultySelectLect.ClearSelected();
        }

        private void SaveBackLecReg_Click(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)FacultySelectLect.SelectedIndex;
            DataFetcher.GetInstance().AddLecturer(NameTextBoxLect.Text, faculty);
            DataFetcher.GetInstance().AddToHistory(MainResources.RegisteredLecturer + NameTextBoxLect.Text + ";");
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
            DataFetcher.GetInstance().AddSubject(NameTextBoxSubj.Text, faculty, IsOptional.Checked, IsBUS.Checked);
            DataFetcher.GetInstance().AddToHistory(MainResources.RegisteredSubject + NameTextBoxSubj.Text + ";");
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
            DataFetcher.GetInstance().AddSubject(NameTextBoxSubj.Text, faculty, IsOptional.Checked, IsBUS.Checked);
            DataFetcher.GetInstance().AddToHistory(MainResources.RegisteredSubject + NameTextBoxSubj.Text + ";");
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

        public void SetColumnsWidth()
        {
            ListSubjTable.Columns[0].Width = 320;
            ListSubjTable.Columns[1].Width = 240;
            ListSubjTable.Columns[2].Width = 60;
            ListSubjTable.Columns[3].Width = 100;
        }

        public void DisplayOptionalSubjects()
        {
            //display correct panel
            OptionalSubjects.Hide();
            AllSubjects.Show();
        }

        private void BUS_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetBUSSubjects();
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void CHGF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.Chemistry_and_Geosciences);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void EVAF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.Economics_and_Business_Administration);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void FLF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.Philology);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void FSF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.Philosophy);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void FF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.Physics);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void GMC_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.Life_Sciences);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void IF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.History);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void KNF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.Kaunas);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void KF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.Communication);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void MIF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.Mathematics_and_Informatics);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void MF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.Medicine);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void TSPMI_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.International_Relations_and_Political_Science);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void TF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.Law);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void VM_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.Business);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        public void DisplayMandatorySubjects()
        {
            //display correct panel
            MandatorySubjects.Hide();
            AllSubjects.Show();
        }

        private void CHGF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.Chemistry_and_Geosciences);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void EVAF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.Economics_and_Business_Administration);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void FLF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.Philology);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void FSF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.Philosophy);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void FF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.Physics);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void GMC1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.Life_Sciences);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void IF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.History);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void KNF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.Kaunas);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void KF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.Communication);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void MIF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.Mathematics_and_Informatics);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void MF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.Medicine);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void TSPMI1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.International_Relations_and_Political_Science);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void TF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.Law);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void VM1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.Business);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void ReviewLecturer_Click(object sender, EventArgs e)
        {
            //display correct panel
            MainMenu.Hide();
            EvaluateLecturer.Show();
            ManageUserNameComBox(LectUsernameComBox);
            AnoniminisNaudotojasToolStripMenuItem.Visible = true;
        }

        public void SetColumnsWidthForLecturers()
        {
            ListLectTable.Columns[0].Width = 300;
            ListLectTable.Columns[1].Width = 260;
            ListLectTable.Columns[2].Width = 60;
            ListLectTable.Columns[3].Width = 100;
            //display correct panel
            LecturersByFaculty.Hide();
            AllLecturers.Show();
        }

        private void CHGF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataFetcher.GetInstance().GetLecturersByFaculty(Faculty.Chemistry_and_Geosciences);
            SetColumnsWidthForLecturers();
        }

        private void EVAF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataFetcher.GetInstance().GetLecturersByFaculty(Faculty.Economics_and_Business_Administration);
            SetColumnsWidthForLecturers();
        }

        private void FLF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataFetcher.GetInstance().GetLecturersByFaculty(Faculty.Philology);
            SetColumnsWidthForLecturers();
        }

        private void FSF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataFetcher.GetInstance().GetLecturersByFaculty(Faculty.Philosophy);
            SetColumnsWidthForLecturers();
        }

        private void FF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataFetcher.GetInstance().GetLecturersByFaculty(Faculty.Physics);
            SetColumnsWidthForLecturers();
        }

        private void GMC2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataFetcher.GetInstance().GetLecturersByFaculty(Faculty.Life_Sciences);
            SetColumnsWidthForLecturers();
        }

        private void IF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataFetcher.GetInstance().GetLecturersByFaculty(Faculty.History);
            SetColumnsWidthForLecturers();
        }

        private void KNF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataFetcher.GetInstance().GetLecturersByFaculty(Faculty.Kaunas);
            SetColumnsWidthForLecturers();
        }

        private void KF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataFetcher.GetInstance().GetLecturersByFaculty(Faculty.Communication);
            SetColumnsWidthForLecturers();
        }

        private void MIF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataFetcher.GetInstance().GetLecturersByFaculty(Faculty.Mathematics_and_Informatics);
            SetColumnsWidthForLecturers();
        }

        private void MF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataFetcher.GetInstance().GetLecturersByFaculty(Faculty.Medicine);
            SetColumnsWidthForLecturers();
        }

        private void TSPMI2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataFetcher.GetInstance().GetLecturersByFaculty(Faculty.International_Relations_and_Political_Science);
            SetColumnsWidthForLecturers();
        }

        private void TF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataFetcher.GetInstance().GetLecturersByFaculty(Faculty.Law);
            SetColumnsWidthForLecturers();
        }

        private void VM2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataFetcher.GetInstance().GetLecturersByFaculty(Faculty.Business);
            SetColumnsWidthForLecturers();
        }

        private void SelectFacultyLect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)SelectFacultyLect.SelectedIndex;
            FilteredLecturersList.DataSource = null;
            FilteredLecturersList.DataSource = DataFetcher.GetInstance().GetLecturersByFaculty(faculty);
            FilteredLecturersList.DisplayMember = MainResources.Name;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            NumericEvaluationLect.Value = 1;
            EvaluationCommentLabel.Text = MainResources.String1;
        }

        private void BackLecEvaluation_Click(object sender, EventArgs e)
        {
            ClearAllFieldsInLectForms();
            AnoniminisNaudotojasToolStripMenuItem.Visible = false;
            EvaluateLecturer.Hide();
            MainMenu.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            NumericEvaluationLect.Value = 2;
            EvaluationCommentLabel.Text = MainResources.String2;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            NumericEvaluationLect.Value = 3;
            EvaluationCommentLabel.Text = MainResources.String3;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            NumericEvaluationLect.Value = 4;
            EvaluationCommentLabel.Text = MainResources.String4;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            NumericEvaluationLect.Value = 5;
            EvaluationCommentLabel.Text = MainResources.String5;
        }

        private void ReviewSubject_Click(object sender, EventArgs e)
        {
            //display correct panel
            MainMenu.Hide();
            EvaluateSubjects.Show();
            ManageUserNameComBox(SubjUsernameComBox);
            AnoniminisNaudotojasToolStripMenuItem.Visible = true;
        }

        private void SelectFacultySubj_SelectedIndexChanged(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)SelectFacultySubj.SelectedIndex;
            FilteredSubjectsList.DataSource = null;
            if (IsBUSSubject.Checked)
            {
                FilteredSubjectsList.DataSource = DataFetcher.GetInstance().GetBUSSubjects(faculty);
                FilteredSubjectsList.DisplayMember = MainResources.Name;
            } else
            {
                FilteredSubjectsList.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(IsOptionalSubject.Checked, faculty);
                FilteredSubjectsList.DisplayMember = MainResources.Name;
            }
        }

        private void SaveBackLectEvaluation_Click(object sender, EventArgs e)
        {
            if (EvaluateLecturerWithValidations())
            {
                ClearAllFieldsInLectForms();
                AnoniminisNaudotojasToolStripMenuItem.Visible = false;
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
            if (FilteredLecturersList.SelectedItem == null || NumericEvaluationLect.Value == 0 || ReviewLectEvalTxtBox.Text.Equals("") || LectUsernameComBox.Text.Equals(""))
            {
                warningMsg(MainResources.FillInAllFields, MainResources.BlankFields);
                return false;
            }
            else
            {
                Lecturer selectedLecturer = (Lecturer)FilteredLecturersList.SelectedItem;
                DataFetcher.GetInstance().EvaluateLecturer(selectedLecturer, (float)NumericEvaluationLect.Value, ReviewLectEvalTxtBox.Text, LectUsernameComBox.Text);
                DataFetcher.GetInstance().AddToHistory(MainResources.EvaluatedLecturer + selectedLecturer.name + ";");
                return true;
            }
        }
        private void ClearAllFieldsInLectForms()
        {
            SelectFacultyLect.SelectedIndex = -1;
            FilteredLecturersList.DataSource = null;
            ReviewLectEvalTxtBox.Text = "";
            LectUsernameComBox.Text = "";
            EvaluationCommentLabel.Text = "...";
            NumericEvaluationLect.Value = 0;
        }

        private Boolean EvaluateSubjectWithValidations()
        {
            if (FilteredSubjectsList.SelectedItem == null || NumericEvaluationSubj.Value == 0 || ReviewSubjEvalTxtBox.Text.Equals("") || SubjUsernameComBox.Text.Equals(""))
            {
                warningMsg(MainResources.FillInAllFields, MainResources.BlankFields);
                return false;
            }
            else
            {
                Subject selectedSubject = (Subject)FilteredSubjectsList.SelectedItem;
                DataFetcher.GetInstance().EvaluateSubject(selectedSubject, (float)NumericEvaluationSubj.Value, ReviewSubjEvalTxtBox.Text, SubjUsernameComBox.Text);
                DataFetcher.GetInstance().AddToHistory(MainResources.EvaluatedSubject + selectedSubject.name + ";");
                return true;
            }
        }

        private void ClearAllFieldsInSubjForm()
        {
            IsMandatorySubject.Checked = true;
            IsOptionalSubject.Checked = false;
            IsBUSSubject.Checked = false;

            SelectFacultySubj.SelectedIndex = -1;
            FilteredSubjectsList.DataSource = null;
            ReviewSubjEvalTxtBox.Text = "";
            SubjUsernameComBox.Text = "";
            SubjEvalCommentLab.Text = "...";
            NumericEvaluationSubj.Value = 0;
        }

        private void RunScraper_Click(object sender, EventArgs e)
        {
            MainMenu.Hide();
            ScraperPanel.Show();
            DataFetcher.GetInstance().RunScraper(this);
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

        private void OneLecturer_Click(object sender, EventArgs e)
        {
            MainMenu.Hide();
            SingleLecturer.Show();
        }

        private void AllFaculties_SelectedIndexChanged(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)AllFaculties.SelectedIndex;
            AllLect.DataSource = null;
            AllLect.DataSource = DataFetcher.GetInstance().GetLecturersByFaculty(faculty);
            AllLect.DisplayMember = MainResources.Name;
        }

        private void ShowLecturerInfo_Click(object sender, EventArgs e)
        {
            Info.Text = "";
            if (AllLect.SelectedItem != null)
            {
                Info.Text = ((Lecturer)AllLect.SelectedItem).ToString();
            }
            else
            {
                MessageBox.Show(MainResources.DidntChooseLecturer);
            }
        }

        private void Return_Click(object sender, EventArgs e)
        {
            SingleLecturer.Hide();
            Info.Text = "";
            AllFaculties.SelectedIndex = -1;
            AllLect.DataSource = null;
            LectSearchField.Text = "";
            MainMenu.Show();
        }

        private void OneSubject_Click(object sender, EventArgs e)
        {
            MainMenu.Hide();
            SingleSubject.Show();
        }

        private void Return1_Click(object sender, EventArgs e)
        {
            SingleSubject.Hide();
            Info1.Text = "";
            AllFaculties1.SelectedIndex = -1;
            AllSubj.DataSource = null;
            SubjSearchField.Text = "";
            MainMenu.Show();
        }

        private void AllFaculties1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)AllFaculties1.SelectedIndex;
            AllSubj.DataSource = null;
            AllSubj.DataSource = DataFetcher.GetInstance().GetSubjectsByFaculty(faculty);
            AllSubj.DisplayMember = MainResources.Name;
        }

        private void ShowSubjectInfo_Click(object sender, EventArgs e)
        {
            Info1.Text = "";
            if (AllSubj.SelectedItem != null)
            {
                Info1.Text = ((Subject)AllSubj.SelectedItem).ToString();
            }
            else
            {
                MessageBox.Show(MainResources.DidntChooseSubject);
            }
        }

        private void BackSubEvaluation_Click(object sender, EventArgs e)
        {
            ClearAllFieldsInSubjForm();
            AnoniminisNaudotojasToolStripMenuItem.Visible = false;
            EvaluateSubjects.Hide();
            MainMenu.Show();
        }

        private void IsMandatorySubject_CheckedChanged(object sender, EventArgs e)
        {
            if (IsMandatorySubject.Checked)
            {
                IsBUSSubject.Checked = false;
                IsBUSSubject.Enabled = false;
                IsOptionalSubject.Checked = false;

                if (!SelectFacultySubj.Text.Equals(""))
                {
                    Faculty faculty = (Faculty)SelectFacultySubj.SelectedIndex;
                    FilteredSubjectsList.DataSource = null;
                    FilteredSubjectsList.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(IsOptionalSubject.Checked, faculty);
                    FilteredSubjectsList.DisplayMember = MainResources.Name;
                }
            }
            else
            {
                IsOptionalSubject.Checked = true;
            }
        }

        private void IsOptionalSubject_CheckedChanged(object sender, EventArgs e)
        {
            if (IsOptionalSubject.Checked)
            {
                IsMandatorySubject.Checked = false;
                IsBUSSubject.Enabled = true;

                if (!SelectFacultySubj.Text.Equals(""))
                {
                    Faculty faculty = (Faculty)SelectFacultySubj.SelectedIndex;
                    FilteredSubjectsList.DataSource = null;
                    FilteredSubjectsList.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(IsOptionalSubject.Checked, faculty);
                    FilteredSubjectsList.DisplayMember = MainResources.Name;
                }
            }
            else
            {
                IsMandatorySubject.Checked = true;
            }
        }

        private void EmojiScoreOne_Click(object sender, EventArgs e)
        {
            NumericEvaluationSubj.Value = 1;
            SubjEvalCommentLab.Text = MainResources.String6;
        }

        private void EmojiScoreTwo_Click(object sender, EventArgs e)
        {
            NumericEvaluationSubj.Value = 2;
            SubjEvalCommentLab.Text = MainResources.String7;
        }

        private void EmojiScoreThree_Click(object sender, EventArgs e)
        {
            NumericEvaluationSubj.Value = 3;
            SubjEvalCommentLab.Text = MainResources.String8;
        }

        private void EmojiScoreFour_Click(object sender, EventArgs e)
        {
            NumericEvaluationSubj.Value = 4;
            SubjEvalCommentLab.Text = MainResources.String9;
        }

        private void EmojiScoreFive_Click(object sender, EventArgs e)
        {
            NumericEvaluationSubj.Value = 5;
            SubjEvalCommentLab.Text = MainResources.String10;
        }

        private void SaveBackSubjEvaluation_Click(object sender, EventArgs e)
        {
            if (EvaluateSubjectWithValidations())
            {
                ClearAllFieldsInSubjForm();
                AnoniminisNaudotojasToolStripMenuItem.Visible = false;
                EvaluateSubjects.Hide();
                MainMenu.Show();
            }
        }

        private void SaveEvalNextSubj_Click(object sender, EventArgs e)
        {
            if (EvaluateSubjectWithValidations())
            {
                ClearAllFieldsInSubjForm();
            }
        }

        private void IsBUSSubject_CheckedChanged(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)SelectFacultySubj.SelectedIndex;
            
            if (IsBUSSubject.Checked)
            {
                if (SelectFacultySubj.Text.Equals(""))
                {
                    FilteredSubjectsList.DataSource = null;
                    FilteredSubjectsList.DataSource = DataFetcher.GetInstance().GetBUSSubjects();
                    FilteredSubjectsList.DisplayMember = MainResources.Name;
                }
                else
                {
                    FilteredSubjectsList.DataSource = null;
                    FilteredSubjectsList.DataSource = DataFetcher.GetInstance().GetBUSSubjects(faculty);
                    FilteredSubjectsList.DisplayMember = MainResources.Name;
                }
            }
            else
            {
                IsOptionalSubject.Checked = true;
                if (!SelectFacultySubj.Text.Equals("")){
                    FilteredSubjectsList.DataSource = null;
                    FilteredSubjectsList.DataSource = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(IsOptionalSubject.Checked, faculty);
                    FilteredSubjectsList.DisplayMember = MainResources.Name;
                }
            }
        }


        private void LectSearchButton_Click(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)AllFaculties.SelectedIndex;
            if (AllFaculties.SelectedItem != null)
            {
                AllLect.DataSource = null;
                AllLect.DataSource = DataFetcher.GetInstance().GetLecturerSearchResults(LectSearchField.Text, faculty);
                AllLect.DisplayMember = MainResources.Name;
            }
            else
            {
                warningMsg(MainResources.SelectFaculty, MainResources.BlankFields);
            }
        }

        private void SubjSearchButton_Click(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)AllFaculties1.SelectedIndex;
            if (AllFaculties1.SelectedItem != null)
            {
                AllSubj.DataSource = null;
                AllSubj.DataSource = DataFetcher.GetInstance().GetSubjectSearchResults(SubjSearchField.Text, faculty);
                AllSubj.DisplayMember = MainResources.Name;
            }
            else
            {
                warningMsg(MainResources.SelectFaculty, MainResources.BlankFields);
            }
        }

        private void TOP_Click(object sender, EventArgs e)
        {
            TOP10S.Text = "";
            TOP10L.Text = "";
            TOP5BUS.Text = "";
            int number = 1;
            foreach(Subject subject in DataFetcher.GetInstance().GetTop10Subjects())
            {
                TOP10S.Text = TOP10S.Text + number + ". " + subject.ToString() + "\r\n";
                number++;
            }
            number = 1;
            foreach (Subject subject in DataFetcher.GetInstance().GetTop5BUSSubjects())
            {
                TOP5BUS.Text = TOP5BUS.Text + number + ". " + MainResources.SubjectName + subject.GetInformation() + "\r\n";
                number++;
            }
            number = 1;
            foreach (Lecturer lecturer in DataFetcher.GetInstance().GetTop10Lecturers())
            {
                TOP10L.Text = TOP10L.Text + number + ". " + lecturer.ToString() + "\r\n";
                number++;
            }
            MainMenu.Hide();
            TOPLecturersAndSubjects.Show();
        }

        private void Return2_Click(object sender, EventArgs e)
        {
            TOPLecturersAndSubjects.Hide();
            MainMenu.Show();
        }

        private void LogInButtonInitWindow_Click(object sender, EventArgs e)
        {
            InitialWindow.Hide();
            LogIn.Show();
        }

        private void RegistrationButtonInitWindow_Click(object sender, EventArgs e)
        {
            InitialWindow.Hide();
            Registration.Show();
        }

        private void BackToInitWindowButtonR_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(MainResources.CancelRegistration, MainResources.CancelRegCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ClearRegistrationFields();
                Registration.Hide();
                InitialWindow.Show();
            }
        }

        private void BackToInitialWindowButtonLI_Click(object sender, EventArgs e)
        {
            ClearLogInFields();
            LogIn.Hide();
            InitialWindow.Show();
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            if (LogInWithValidations())
            {
                ClearLogInFields();
                simpleMsg(MainResources.SuccessfulLogIn, MainResources.LogInCaption);
                LogIn.Hide();
                RunScraper.Visible = true;
                LecReg.Visible = true;
                SubjReg.Visible = true;
                ReviewSubject.Visible = true;
                ReviewLecturer.Visible = true;
                ActivityHistory.Visible = true;
                SaveAsWordDocButton.Visible = true;
                SaveAsExcelButton.Visible = true;
                MostActiveUsersButton.Visible = true;
                MainMenu.Show();
            }
        }

        private void ClearLogInFields()
        {
            UserNameLogIn.Text = "";
            PasswordLogIn.Text = "";
        }

        private void ClearRegistrationFields()
        {
            UserFullName.Text = "";
            SelectFacultyUser.SelectedIndex = -1;
            UserNameRegistration.Text = "";
            PasswordRegistration.Text = "";
            RepeatPasswordReg.Text = "";
            StudyProgramReg.Items.Clear();
            EMailReg.Text = "";
            PhoneNoReg.Text = "";
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            MainMenu.Hide();
            InitialWindow.Show();
        }

        private Boolean LogInWithValidations()
        {
            if (UserNameLogIn.Text.Equals("") || PasswordLogIn.Text.Equals(""))
            {
                warningMsg(MainResources.BlankLogInFields, MainResources.BlankFields);
                return false;
            }
            else if (!DataFetcher.GetInstance().CheckIfUserNameExists(UserNameLogIn.Text))
            {
                warningMsg(MainResources.UserNotFound, MainResources.UserNotFoundCaption);
                UserNameLogIn.Text = "";
                PasswordLogIn.Text = ""; 
                return false;
            }
            else if(!DataFetcher.GetInstance().CheckIfCorrectPassword(UserNameLogIn.Text, PasswordLogIn.Text))
            {
                warningMsg(MainResources.WrongPassword, MainResources.WrongPasswordCaption);
                PasswordLogIn.Text = "";
                return false;
            }
            else
            {
                DataFetcher.GetInstance().SetCurrentUser(DataFetcher.GetInstance().GetAllUsers().ToList().Find(us => us.userName.Equals(UserNameLogIn.Text)));
                return true; 
            }
        }

        private Boolean RegisterWithValidations()
        {
            if (UserFullName.Text.Equals("") || SelectFacultyUser.Text.Equals("") || UserNameRegistration.Text.Equals("") ||
                PasswordRegistration.Text.Equals("") || RepeatPasswordReg.Text.Equals("") || StudyProgramReg.Text.Equals("") ||
                EMailReg.Text.Equals("") || PhoneNoReg.Text.Equals(""))
            {
                warningMsg(MainResources.FillInAllFields, MainResources.BlankFields);
                return false;
            }
            else if (!Regex.IsMatch(PhoneNoReg.Text, @"^[+3706]\d{7}?"))
            {
                warningMsg(MainResources.WrongPhoneNo, MainResources.WrongData);
                return false;
            }
            else if (!Regex.IsMatch(UserFullName.Text, @"^\p{L}+(?:\s\p{L}+)+$", RegexOptions.IgnoreCase))
            {
                warningMsg(MainResources.EnterNameAndUsername, MainResources.WrongData);
                return false;
            }
            else if (!Regex.IsMatch(EMailReg.Text, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", RegexOptions.IgnoreCase))
            {
                warningMsg(MainResources.WrongEmail, MainResources.WrongData);
                return false;
            }
            else if (!PasswordRegistration.Text.Equals(RepeatPasswordReg.Text))
            {
                warningMsg(MainResources.PasswordsDoNotMatch, MainResources.RepeatPassword);
                PasswordRegistration.Text = "";
                RepeatPasswordReg.Text = "";
                return false;
            }
            else if(DataFetcher.GetInstance().CheckIfUserNameExists(UserNameRegistration.Text))
            {
                warningMsg(MainResources.UserAlreadyExists, MainResources.UserNameExistsCaption);
                return false;
            }
            else
            {
                Faculty faculty = (Faculty)SelectFacultyUser.SelectedIndex;
                User user = new User(UserFullName.Text, faculty, UserNameRegistration.Text, PasswordRegistration.Text, EMailReg.Text, PhoneNoReg.Text, StudyProgramReg.Text);
                DataFetcher.GetInstance().AddUser(user);
                DataFetcher.GetInstance().SetCurrentUser(user);
                return true; 
            } 
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            if (RegisterWithValidations())
            {
                ClearRegistrationFields();
                simpleMsg(MainResources.RegistrationSuccessful, MainResources.RegistrationCaption);
                Registration.Hide();
                MainMenu.Show();
            }
        }

        private void LogInAsGuest_Click(object sender, EventArgs e)
        {
            InitialWindow.Hide();
            RunScraper.Visible = false;
            LecReg.Visible = false;
            SubjReg.Visible = false;
            ReviewSubject.Visible = false;
            ReviewLecturer.Visible = false;
            ActivityHistory.Visible = false;
            SaveAsWordDocButton.Visible = false;
            SaveAsExcelButton.Visible = false;
            MostActiveUsersButton.Visible = false;
            MainMenu.Show();
        }

        private void ActivityHistory_Click(object sender, EventArgs e)
        {
            History.Text = "";
            foreach(Activity activity in DataFetcher.GetInstance().GetHistory())
            {
                History.Text = History.Text + activity.date + " " + activity.activityComment + "\r\n";
            }
            MainMenu.Hide();
            ActivityWindow.Show();
        }

        private void Return3_Click(object sender, EventArgs e)
        {
            ActivityWindow.Hide();
            MainMenu.Show();
        }

        private void Rausva_Click(object sender, EventArgs e)
        {
            this.BackColor = Properties.Settings.Default.color1;
        }

        private void Melsva_Click(object sender, EventArgs e)
        {
            this.BackColor = Properties.Settings.Default.color2;
        }

        private void Numatytoji_Click(object sender, EventArgs e)
        {
            this.BackColor = Properties.Settings.Default.color3;
        }

        private void LeistiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.anonymous = true;
            ManageUserNameComBox(SubjUsernameComBox);
            ManageUserNameComBox(LectUsernameComBox);
        }

        private void NeleistiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.anonymous = false;
            ManageUserNameComBox(SubjUsernameComBox);
            ManageUserNameComBox(LectUsernameComBox);
        }

        private void SaveAsWordDocButton_Click(object sender, EventArgs e)
        {
            DocCreatorManager docManager = new DocCreatorManager(new WindowsDocCreator());
            docManager.CreateDocument<Activity>(path, DataFetcher.GetInstance().GetHistory());
            simpleMsg(MainResources.PathComment + " " + path, MainResources.PathCaption);
        }

        private void SaveAsExcelButton_Click(object sender, EventArgs e)
        {
            DocCreatorManager docManager = new DocCreatorManager(new ExcelDocCreator());
            docManager.CreateDocument<Activity>(path, DataFetcher.GetInstance().GetHistory());
            simpleMsg(MainResources.PathComment + " " + path, MainResources.PathCaption);
        }

        private void ManageUserNameComBox(ComboBox comBox)
        {
            if (!comBox.Items.Contains(DataFetcher.GetInstance().GetCurrentUser().userName))
            {
                comBox.Items.Add(DataFetcher.GetInstance().GetCurrentUser().userName);
            }

            comBox.Text = DataFetcher.GetInstance().GetCurrentUser().userName;

            if (Properties.Settings.Default.anonymous)
            {
                if (!comBox.Items.Contains(MainResources.AnonymousUser))
                {
                    comBox.Items.Add(MainResources.AnonymousUser);
                }
            }
            else
            {
                if (comBox.Items.Contains(MainResources.AnonymousUser))
                {
                    comBox.Items.Remove(MainResources.AnonymousUser);
                }
            }
        }

        private void SelectFacultyUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)SelectFacultyUser.SelectedIndex;
            StudyProgramReg.Items.Clear();
            foreach(StudyProgramme studies in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(faculty))
            {
                StudyProgramReg.Items.Add(studies.name);
            }
        }

        private void MostActiveUsersButton_Click(object sender, EventArgs e)
        {
            MostActiveUsersTxtBox.Text = "";
            EvalMostLectsTxtBox.Text = "";
            EvalMostSubjTxtBox.Text = "";

            DisplayActiveUsers(EvalMostLectsTxtBox, DataFetcher.GetInstance().GetTop5ActiveLecturersEvaluators());
            DisplayActiveUsers(EvalMostSubjTxtBox, DataFetcher.GetInstance().GetTop5ActiveSubjectsEvaluators());
            DisplayActiveUsers(MostActiveUsersTxtBox, DataFetcher.GetInstance().GetTop3ActiveUsers());

            MainMenu.Hide();
            MostactiveUsers.Show();
        }

        private void DisplayActiveUsers(TextBox txtBox, List<User> usersList)
        {
            int number = 1;
            foreach (User user in usersList)
            {
                txtBox.Text = txtBox.Text + number + ". " + MainResources.UserName + " " + user.userName + " \r\n" +
                    MainResources.EvaluatedLecturers + " " + user.evaluatedLecturers + " " +
                    MainResources.EvaluatedSubjects + " " + user.evaluatedSubjects + "\r\n\r\n";
                number++;
            }
        }

        private void BackToMenuButton_Click(object sender, EventArgs e)
        {
            MostactiveUsers.Hide();
            MainMenu.Show();
        }

    }
}
