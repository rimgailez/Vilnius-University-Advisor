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
            ListSubjTable.DataSource = DataMaster.GetInstance().GetBUSSubjects();
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void CHGF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.Chemistry_and_Geosciences);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void EVAF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.Economics_and_Business_Administration);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void FLF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.Philology);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void FSF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.Philosophy);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void FF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.Physics);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void GMC_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.Life_Sciences);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void IF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.History);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void KNF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.Kaunas);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void KF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.Communication);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void MIF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.Mathematics_and_Informatics);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void MF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.Medicine);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void TSPMI_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.International_Relations_and_Political_Science);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void TF_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.Law);
            SetColumnsWidth();
            DisplayOptionalSubjects();
        }

        private void VM_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(true, Faculty.Business);
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
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.Chemistry_and_Geosciences);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void EVAF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.Economics_and_Business_Administration);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void FLF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.Philology);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void FSF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.Philosophy);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void FF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.Physics);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void GMC1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.Life_Sciences);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void IF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.History);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void KNF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.Kaunas);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void KF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.Communication);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void MIF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.Mathematics_and_Informatics);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void MF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.Medicine);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void TSPMI1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.International_Relations_and_Political_Science);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void TF1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.Law);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void VM1_Click(object sender, EventArgs e)
        {
            ListSubjTable.DataSource = null;
            ListSubjTable.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(false, Faculty.Business);
            SetColumnsWidth();
            DisplayMandatorySubjects();
        }

        private void ReviewLecturer_Click(object sender, EventArgs e)
        {
            //display correct panel
            MainMenu.Hide();
            EvaluateLecturer.Show();
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
            ListLectTable.DataSource = DataMaster.GetInstance().GetLecturersByFaculty(Faculty.Chemistry_and_Geosciences);
            SetColumnsWidthForLecturers();
        }

        private void EVAF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().GetLecturersByFaculty(Faculty.Economics_and_Business_Administration);
            SetColumnsWidthForLecturers();
        }

        private void FLF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().GetLecturersByFaculty(Faculty.Philology);
            SetColumnsWidthForLecturers();
        }

        private void FSF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().GetLecturersByFaculty(Faculty.Philosophy);
            SetColumnsWidthForLecturers();
        }

        private void FF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().GetLecturersByFaculty(Faculty.Physics);
            SetColumnsWidthForLecturers();
        }

        private void GMC2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().GetLecturersByFaculty(Faculty.Life_Sciences);
            SetColumnsWidthForLecturers();
        }

        private void IF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().GetLecturersByFaculty(Faculty.History);
            SetColumnsWidthForLecturers();
        }

        private void KNF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().GetLecturersByFaculty(Faculty.Kaunas);
            SetColumnsWidthForLecturers();
        }

        private void KF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().GetLecturersByFaculty(Faculty.Communication);
            SetColumnsWidthForLecturers();
        }

        private void MIF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().GetLecturersByFaculty(Faculty.Mathematics_and_Informatics);
            SetColumnsWidthForLecturers();
        }

        private void MF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().GetLecturersByFaculty(Faculty.Medicine);
            SetColumnsWidthForLecturers();
        }

        private void TSPMI2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().GetLecturersByFaculty(Faculty.International_Relations_and_Political_Science);
            SetColumnsWidthForLecturers();
        }

        private void TF2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().GetLecturersByFaculty(Faculty.Law);
            SetColumnsWidthForLecturers();
        }

        private void VM2_Click(object sender, EventArgs e)
        {
            //get or refresh data
            ListLectTable.DataSource = null;
            ListLectTable.DataSource = DataMaster.GetInstance().GetLecturersByFaculty(Faculty.Business);
            SetColumnsWidthForLecturers();
        }

        private void SelectFacultyLect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)SelectFacultyLect.SelectedIndex;
            FilteredLecturersList.DataSource = null;
            FilteredLecturersList.DataSource = DataMaster.GetInstance().GetLecturersByFaculty(faculty);
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
        }

        private void SelectFacultySubj_SelectedIndexChanged(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)SelectFacultySubj.SelectedIndex;
            FilteredSubjectsList.DataSource = null;
            if (IsBUSSubject.Checked)
            {
                FilteredSubjectsList.DataSource = DataMaster.GetInstance().GetBUSSubjects(faculty);
                FilteredSubjectsList.DisplayMember = MainResources.Name;
            } else
            {
                FilteredSubjectsList.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(IsOptionalSubject.Checked, faculty);
                FilteredSubjectsList.DisplayMember = MainResources.Name;
            }
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
            if (FilteredLecturersList.SelectedItem == null || NumericEvaluationLect.Value == 0 || ReviewLectEvalTxtBox.Text.Equals("") || LectUsernameTxtBox.Text.Equals(""))
            {
                MessageBox.Show(MainResources.FillInAllFields, MainResources.BlankFields, 0, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                Lecturer selectedLecturer = (Lecturer)FilteredLecturersList.SelectedItem;
                DataMaster.GetInstance().EvaluateLecturer(selectedLecturer, (float)NumericEvaluationLect.Value, ReviewLectEvalTxtBox.Text, LectUsernameTxtBox.Text);
                return true;
            }
        }
        private void ClearAllFieldsInLectForms()
        {
            SelectFacultyLect.Text = "";
            FilteredLecturersList.DataSource = null;
            ReviewLectEvalTxtBox.Text = "";
            LectUsernameTxtBox.Text = "";
            EvaluationCommentLabel.Text = "...";
            NumericEvaluationLect.Value = 0;
        }

        private Boolean EvaluateSubjectWithValidations()
        {
            if (FilteredSubjectsList.SelectedItem == null || NumericEvaluationSubj.Value == 0 || ReviewSubjEvalTxtBox.Text.Equals("") || SubjUsernameTxtBox.Text.Equals(""))
            {
                MessageBox.Show(MainResources.FillInAllFields, MainResources.BlankFields, 0, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                Subject selectedSubject = (Subject)FilteredSubjectsList.SelectedItem;
                DataMaster.GetInstance().EvaluateSubject(selectedSubject, (float)NumericEvaluationSubj.Value, ReviewSubjEvalTxtBox.Text, SubjUsernameTxtBox.Text);
                return true;
            }
        }

        private void ClearAllFieldsInSubjForm()
        {
            IsMandatorySubject.Checked = true;
            IsOptionalSubject.Checked = false;
            IsBUSSubject.Checked = false;

            SelectFacultySubj.Text = "";
            FilteredSubjectsList.DataSource = null;
            ReviewSubjEvalTxtBox.Text = "";
            SubjUsernameTxtBox.Text = "";
            SubjEvalCommentLab.Text = "...";
            NumericEvaluationSubj.Value = 0;
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

        private void OneLecturer_Click(object sender, EventArgs e)
        {
            MainMenu.Hide();
            SingleLecturer.Show();
        }

        private void AllFaculties_SelectedIndexChanged(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)AllFaculties.SelectedIndex;
            AllLect.DataSource = null;
            AllLect.DataSource = DataMaster.GetInstance().GetLecturersByFaculty(faculty);
            AllLect.DisplayMember = MainResources.Name;
        }

        private void ShowLecturerInfo_Click(object sender, EventArgs e)
        {
            Info.Text = "";
            if (AllLect.SelectedItem != null)
            {
                Info.Text = DataMaster.GetInstance().GetLecturerInfo((Lecturer)AllLect.SelectedItem, (Faculty)AllFaculties.SelectedIndex);
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
            AllFaculties.Text = "";
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
            AllFaculties1.Text = "";
            AllSubj.DataSource = null;
            SubjSearchField.Text = "";
            MainMenu.Show();
        }

        private void AllFaculties1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)AllFaculties1.SelectedIndex;
            AllSubj.DataSource = null;
            AllSubj.DataSource = DataMaster.GetInstance().GetSubjectsByFaculty(faculty);
            AllSubj.DisplayMember = MainResources.Name;
        }

        private void ShowSubjectInfo_Click(object sender, EventArgs e)
        {
            Info1.Text = "";
            if (AllSubj.SelectedItem != null)
            {
                Info1.Text = DataMaster.GetInstance().GetSubjectInfo((Subject)AllSubj.SelectedItem, (Faculty)AllFaculties1.SelectedIndex);
            }
            else
            {
                MessageBox.Show(MainResources.DidntChooseSubject);
            }
        }

        private void BackSubEvaluation_Click(object sender, EventArgs e)
        {
            ClearAllFieldsInSubjForm();
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
                    FilteredSubjectsList.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(IsOptionalSubject.Checked, faculty);
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
                    FilteredSubjectsList.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(IsOptionalSubject.Checked, faculty);
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
                    FilteredSubjectsList.DataSource = DataMaster.GetInstance().GetBUSSubjects();
                    FilteredSubjectsList.DisplayMember = MainResources.Name;
                }
                else
                {
                    FilteredSubjectsList.DataSource = null;
                    FilteredSubjectsList.DataSource = DataMaster.GetInstance().GetBUSSubjects(faculty);
                    FilteredSubjectsList.DisplayMember = MainResources.Name;
                }
            }
            else
            {
                IsOptionalSubject.Checked = true;
                if (!SelectFacultySubj.Text.Equals("")){
                    FilteredSubjectsList.DataSource = null;
                    FilteredSubjectsList.DataSource = DataMaster.GetInstance().GetSubjectsByTypeAndFaculty(IsOptionalSubject.Checked, faculty);
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
                AllLect.DataSource = DataMaster.GetInstance().GetLecturerSearchResults(LectSearchField.Text, faculty);
                AllLect.DisplayMember = MainResources.Name;
            }
            else
            {
                MessageBox.Show(MainResources.SelectFaculty, MainResources.BlankFields, 0, MessageBoxIcon.Exclamation);
            }
        }

        private void SubjSearchButton_Click(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)AllFaculties1.SelectedIndex;
            if (AllFaculties1.SelectedItem != null)
            {
                AllSubj.DataSource = null;
                AllSubj.DataSource = DataMaster.GetInstance().GetSubjectSearchResults(SubjSearchField.Text, faculty);
                AllSubj.DisplayMember = MainResources.Name;
            }
            else
            {
                MessageBox.Show(MainResources.SelectFaculty, MainResources.BlankFields, 0, MessageBoxIcon.Exclamation);
            }
        }
    }
}
