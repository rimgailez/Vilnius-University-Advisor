using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VUA_App.Models;
using VUA_App.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VUA_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EvaluateSubject : ContentPage
    {
        public EvaluateSubject()
        {
            InitializeComponent();
            SelectSubjectFaculty.ItemsSource = GetFacultyList();
            SelectSubjectFaculty.SelectedIndexChanged += FacultyChosen;

            UserName.Items.Clear();
            UserName.Items.Add(DataFetcher.GetInstance().GetCurrentUser().userName);
            UserName.Items.Add(MainResources.AnonymousUser);
        }

        private void FacultyChosen(object sender, EventArgs e)
        {
            SelectSubject.Items.Clear();

            if (IsBUS.IsChecked)
            {
                foreach (Subject subj in DataFetcher.GetInstance().GetBUSSubjects())
                {
                    SelectSubject.Items.Add(subj.name);
                }
            }
            else
            {
                foreach (Subject subj in DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(IsOptional.IsChecked, (Faculty)SelectSubjectFaculty.SelectedIndex))
                {
                    SelectSubject.Items.Add(subj.name);
                }
            }
        }

        private void IsMandatory_CheckedChanged(object sender, EventArgs e)
        {
            if (IsMandatory.IsChecked)
            {
                IsBUS.IsChecked = false;
                IsBUS.IsEnabled = false;
                IsOptional.IsChecked = false;

                if (SelectSubjectFaculty.SelectedItem != null)
                {
                    SelectSubject.Items.Clear();
                    Faculty faculty = (Faculty)SelectSubjectFaculty.SelectedIndex;
                    foreach (Subject subj in DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(IsOptional.IsChecked, faculty))
                    {
                        SelectSubject.Items.Add(subj.name);
                    }
                }
            }
            else
            {
                IsOptional.IsChecked = true;
            }
        }

        private void IsOptional_CheckedChanged(object sender, EventArgs e)
        {
            if (IsOptional.IsChecked)
            {
                IsMandatory.IsChecked = false;
                IsBUS.IsEnabled = true;

                if (SelectSubjectFaculty.SelectedItem != null)
                {
                    SelectSubject.Items.Clear();
                    Faculty faculty = (Faculty)SelectSubjectFaculty.SelectedIndex;
                    foreach (Subject subj in DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(IsOptional.IsChecked, faculty))
                    {
                        SelectSubject.Items.Add(subj.name);
                    }
                }
            }
            else
            {
                IsMandatory.IsChecked = true;
            }
        }

        private void IsBUS_CheckedChanged(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)SelectSubjectFaculty.SelectedIndex;

            if (IsBUS.IsChecked)
            {
                if (SelectSubjectFaculty.SelectedItem == null)
                {
                    SelectSubject.Items.Clear();
                    foreach (Subject subj in DataFetcher.GetInstance().GetBUSSubjects())
                    {
                        SelectSubject.Items.Add(subj.name);
                    }
                }
                else
                {
                    SelectSubject.Items.Clear();
                    SelectSubject.ItemsSource = null;
                    foreach (Subject subj in DataFetcher.GetInstance().GetBUSSubjects(faculty))
                    {
                        SelectSubject.Items.Add(subj.name);
                    }
                }
            }
            else
            {
                IsOptional.IsChecked = true;
                if (SelectSubjectFaculty.SelectedItem != null)
                {
                    SelectSubject.Items.Clear();
                    SelectSubject.ItemsSource = null;
                    foreach (Subject subj in DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(IsOptional.IsChecked, faculty))
                    {
                        SelectSubject.Items.Add(subj.name);
                    }
                }
            }
        }

        public async void OnSubjEvaluation(object sender, EventArgs e)
        {
            if (SelectSubjectFaculty.SelectedItem == null || SelectSubject.SelectedItem == null || NumericEvaluation.Text == "" ||
                SubjectComments.Text == "" || UserName.SelectedItem == null)
            {
                await DisplayAlert(MainResources.FillInAllFields, MainResources.BlankFields, "OK");
            }
            else
            {
                Subject selectedSubject = DataFetcher.GetInstance().GetSubjectsByFaculty((Faculty)SelectSubjectFaculty.SelectedIndex).ToList().Find(subj => subj.name.Equals(SelectSubject.SelectedItem.ToString()));
                DataFetcher.GetInstance().EvaluateSubject(selectedSubject, (float)ConvertStringToDecimal(NumericEvaluation.Text), SubjectComments.Text, UserName.SelectedItem.ToString());
                DataFetcher.GetInstance().AddToHistory(MainResources.EvaluatedSubject + selectedSubject.name + ";");
                await DisplayAlert(MainResources.SuccessfulSubjEvaluation, MainResources.EvaluationCaption, "OK");
                ClearFields();
            }
        }

        private void ClearFields()
        {
            SelectSubjectFaculty.SelectedItem = null;
            SelectSubject.SelectedItem = null;
            SelectSubject.Items.Clear();
            SubjectComments.Text = "";
            NumericEvaluation.Text = "";
            UserName.SelectedItem = null;
            EvaluationLabel.Text = "";
            IsMandatory.IsChecked = true;
            IsOptional.IsChecked = false;
            IsBUS.IsChecked = false;
        }

        public decimal ConvertStringToDecimal(string strValue)
        {
            if (string.IsNullOrEmpty(strValue))
                strValue = "0";
            decimal resultdecimal;
            if (decimal.TryParse(strValue, out resultdecimal))
            {
                return resultdecimal;
            }
            return 0;
        }
        public void OnImgButton1Clicked(object sender, EventArgs e)
        {
            EvaluationLabel.Text = MainResources.String6;
            NumericEvaluation.Text = "1";
        }

        public void OnImgButton2Clicked(object sender, EventArgs e)
        {
            EvaluationLabel.Text = MainResources.String7;
            NumericEvaluation.Text = "2";
        }

        public void OnImgButton3Clicked(object sender, EventArgs e)
        {
            EvaluationLabel.Text = MainResources.String8;
            NumericEvaluation.Text = "3";
        }

        public void OnImgButton4Clicked(object sender, EventArgs e)
        {
            EvaluationLabel.Text = MainResources.String9;
            NumericEvaluation.Text = "4";
        }

        public void OnImgButton5Clicked(object sender, EventArgs e)
        {
            EvaluationLabel.Text = MainResources.String10;
            NumericEvaluation.Text = "5";
        }

        private List<string> GetFacultyList()
        {
            return new List<string>
            {
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
                "Verslo"
            };
        }
    }
}