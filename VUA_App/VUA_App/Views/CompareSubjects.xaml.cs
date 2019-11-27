using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VUA_App.Models;
using VUA_App.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VUA_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompareSubjects : ContentPage
    {
        public CompareSubjects()
        {
            InitializeComponent();
            SubjectFaculty1.ItemsSource = GetFacultyList();
            SubjectFaculty1.SelectedIndexChanged += FacultySelected1;
            SubjectFaculty2.ItemsSource = GetFacultyList();
            SubjectFaculty2.SelectedIndexChanged += FacultySelected2;
        }

        private async void FacultySelected1(object sender, EventArgs e)
        {
            if (IsOptional1.IsChecked == true && IsMandatory1.IsChecked == true)
            {
                IsOptional1.IsChecked = false;
                IsMandatory1.IsChecked = false;
            }
            else if (IsOptional1.IsChecked == false && IsMandatory1.IsChecked == true)
            {
                SubjectName1.Items.Clear();
                foreach (Subject subj in await DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(false, (Faculty)SubjectFaculty1.SelectedIndex))
                {
                    SubjectName1.Items.Add(subj.name);
                }
            }
            else if (IsOptional1.IsChecked == true && IsMandatory1.IsChecked == false)
            {
                SubjectName1.Items.Clear();
                foreach (Subject subj in await DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(true, (Faculty)SubjectFaculty1.SelectedIndex))
                {
                    SubjectName1.Items.Add(subj.name);
                }
            }
            else
            {
                SubjectName1.Items.Clear();
                foreach (Subject subj in await DataFetcher.GetInstance().GetSubjectsByFaculty((Faculty)SubjectFaculty1.SelectedIndex))
                {
                    SubjectName1.Items.Add(subj.name);
                }
            }
        }

        private async void FacultySelected2(object sender, EventArgs e)
        {
            if (IsOptional2.IsChecked == true && IsMandatory2.IsChecked == true)
            {
                IsOptional2.IsChecked = false;
                IsMandatory2.IsChecked = false;
            }
            else if (IsOptional2.IsChecked == false && IsMandatory2.IsChecked == true)
            {
                SubjectName2.Items.Clear();
                foreach (Subject subj in await DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(false, (Faculty)SubjectFaculty2.SelectedIndex))
                {
                    SubjectName2.Items.Add(subj.name);
                }
            }
            else if (IsOptional2.IsChecked == true && IsMandatory2.IsChecked == false)
            {
                SubjectName2.Items.Clear();
                foreach (Subject subj in await DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(true, (Faculty)SubjectFaculty2.SelectedIndex))
                {
                    SubjectName2.Items.Add(subj.name);
                }
            }
            else
            {
                SubjectName2.Items.Clear();
                foreach (Subject subj in await DataFetcher.GetInstance().GetSubjectsByFaculty((Faculty)SubjectFaculty2.SelectedIndex))
                {
                    SubjectName2.Items.Add(subj.name);
                }
            }
        }

        private async void OnCheckedChanged1(object sender, CheckedChangedEventArgs e)
        {
            if (IsOptional1.IsChecked == true && IsMandatory1.IsChecked == true)
            {
                IsOptional1.IsChecked = false;
                IsMandatory1.IsChecked = false;
            }
            else if(IsMandatory1.IsChecked == true && SubjectFaculty1.SelectedItem != null)
            {
                SubjectName1.Items.Clear();
                foreach (Subject subj in await DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(false, (Faculty)SubjectFaculty1.SelectedIndex))
                {
                    SubjectName1.Items.Add(subj.name);
                }
            }
            else if(IsMandatory1.IsChecked == true && SubjectFaculty1.SelectedItem == null)
            {
                SubjectName1.Items.Clear();
                foreach (Subject subj in await DataFetcher.GetInstance().GetSubjectsByType(false, false))
                {
                    SubjectName1.Items.Add(subj.name);
                }
            }
            else if(IsMandatory1.IsChecked == false && IsOptional1.IsChecked == false && SubjectFaculty1.SelectedItem != null)
            {
                SubjectName1.Items.Clear();
                foreach (Subject subj in await DataFetcher.GetInstance().GetSubjectsByFaculty((Faculty)SubjectFaculty1.SelectedIndex))
                {
                    SubjectName1.Items.Add(subj.name);
                }
            }
            else if (IsMandatory1.IsChecked == false && IsOptional1.IsChecked == true && SubjectFaculty1.SelectedItem != null)
            {
                SubjectName1.Items.Clear();
                foreach (Subject subj in await DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(true, (Faculty)SubjectFaculty1.SelectedIndex))
                {
                    SubjectName1.Items.Add(subj.name);
                }
            }
            else if (IsMandatory1.IsChecked == false && IsOptional1.IsChecked == false && SubjectFaculty1.SelectedItem == null)
            {
                SubjectName1.Items.Clear();
                foreach (Subject subj in await DataFetcher.GetInstance().GetSubjects())
                {
                    SubjectName1.Items.Add(subj.name);
                }
            }
            else if (IsMandatory1.IsChecked == false && IsOptional1.IsChecked == true && SubjectFaculty1.SelectedItem == null)
            {
                SubjectName1.Items.Clear();
                foreach (Subject subj in await DataFetcher.GetInstance().GetSubjectsByType(true,false))
                {
                    SubjectName1.Items.Add(subj.name);
                }
            }
        }

        private async void OnCheckedChanged2(object sender, CheckedChangedEventArgs e)
        {
            if (IsOptional2.IsChecked == true && IsMandatory2.IsChecked == true)
            {
                IsOptional2.IsChecked = false;
                IsMandatory2.IsChecked = false;
            }
            else if (IsMandatory2.IsChecked == true && SubjectFaculty2.SelectedItem != null)
            {
                SubjectName2.Items.Clear();
                foreach (Subject subj in await DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(false, (Faculty)SubjectFaculty2.SelectedIndex))
                {
                    SubjectName2.Items.Add(subj.name);
                }
            }
            else if (IsMandatory2.IsChecked == true && SubjectFaculty2.SelectedItem == null)
            {
                SubjectName2.Items.Clear();
                foreach (Subject subj in await DataFetcher.GetInstance().GetSubjectsByType(false, false))
                {
                    SubjectName2.Items.Add(subj.name);
                }
            }
            else if (IsMandatory2.IsChecked == false && IsOptional2.IsChecked == false && SubjectFaculty2.SelectedItem != null)
            {
                SubjectName2.Items.Clear();
                foreach (Subject subj in await DataFetcher.GetInstance().GetSubjectsByFaculty((Faculty)SubjectFaculty2.SelectedIndex))
                {
                    SubjectName2.Items.Add(subj.name);
                }
            }
            else if (IsMandatory2.IsChecked == false && IsOptional2.IsChecked == true && SubjectFaculty2.SelectedItem != null)
            {
                SubjectName2.Items.Clear();
                foreach (Subject subj in await DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(true, (Faculty)SubjectFaculty2.SelectedIndex))
                {
                    SubjectName2.Items.Add(subj.name);
                }
            }
            else if (IsMandatory2.IsChecked == false && IsOptional2.IsChecked == false && SubjectFaculty2.SelectedItem == null)
            {
                SubjectName2.Items.Clear();
                foreach (Subject subj in await DataFetcher.GetInstance().GetSubjects())
                {
                    SubjectName2.Items.Add(subj.name);
                }
            }
            else if (IsMandatory2.IsChecked == false && IsOptional2.IsChecked == true && SubjectFaculty2.SelectedItem == null)
            {
                SubjectName2.Items.Clear();
                foreach (Subject subj in await DataFetcher.GetInstance().GetSubjectsByType(true, false))
                {
                    SubjectName2.Items.Add(subj.name);
                }
            }
        }


        private async void OnCompare(object sender, EventArgs e)
        {
            if (SubjectName1.SelectedItem == null || SubjectName2.SelectedItem == null)
            {
                await DisplayAlert(MainResources.DidntChooseSubject, MainResources.BlankFields, "OK");
                return;
            }
            else if (IsOptional2.IsChecked == false && IsMandatory2.IsChecked == false)
            {
                await DisplayAlert(MainResources.ChooseOptionalOrMandatory, MainResources.BlankFields, "OK");
                return;
            }

            if (IsMandatory1.IsChecked == true)
            {
                Subject selectedSubject1 = (await DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(false, (Faculty)SubjectFaculty1.SelectedIndex)).ToList().Find(subj => subj.name.Equals(SubjectName1.SelectedItem.ToString()));
                WriteInformation1(selectedSubject1);
            }
            else if (IsOptional1.IsChecked == true)
            {
                Subject selectedSubject1 = (await DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(true, (Faculty)SubjectFaculty1.SelectedIndex)).ToList().Find(subj => subj.name.Equals(SubjectName1.SelectedItem.ToString()));
                WriteInformation1(selectedSubject1);
            }

            if (IsMandatory2.IsChecked == true)
            {
                Subject selectedSubject2 = (await DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(false, (Faculty)SubjectFaculty2.SelectedIndex)).ToList().Find(subj => subj.name.Equals(SubjectName2.SelectedItem.ToString()));
                WriteInformation2(selectedSubject2);
            }
            else if (IsOptional2.IsChecked == true)
            {
                Subject selectedSubject2 = (await DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(true, (Faculty)SubjectFaculty2.SelectedIndex)).ToList().Find(subj => subj.name.Equals(SubjectName2.SelectedItem.ToString()));
                WriteInformation2(selectedSubject2);
            }
        }

        public void WriteInformation1(Subject subject)
        {
            Evaluation1.Text = "";
            Number1.Text = "";
            Comments1.Text = "";
            Evaluation1.Text = MainResources.DataNodeEvaluation + subject.score.ToString();
            Number1.Text = MainResources.NumberOfReviews + subject.numberOfReviews.ToString();
            int nr = 1;
            Comments1.Text = Comments1.Text + MainResources.DataNodeComments + "\r\n";
            foreach (Review review in subject.reviews)
            {
                Comments1.Text = Comments1.Text + nr + ". "
                    + MainResources.ReviewUsername + review.username
                    + MainResources.ReviewScore + review.score + "\r\n"
                    + MainResources.ReviewDate + review.date + "\r\n"
                    + MainResources.DataNodeComment + "\r\n" + review.text + "\r\n";
                nr++;
            }
        }

        public void WriteInformation2(Subject subject)
        {
            Evaluation2.Text = "";
            Number2.Text = "";
            Comments2.Text = "";
            Evaluation2.Text = MainResources.DataNodeEvaluation + subject.score.ToString();
            Number2.Text = MainResources.NumberOfReviews + subject.numberOfReviews.ToString();
            int nr = 1;
            Comments2.Text = Comments2.Text + MainResources.DataNodeComments + "\r\n";
            foreach (Review review in subject.reviews)
            {
                Comments2.Text = Comments2.Text + nr + ". "
                    + MainResources.ReviewUsername + review.username
                    + MainResources.ReviewScore + review.score + "\r\n"
                    + MainResources.ReviewDate + review.date + "\r\n"
                    + MainResources.DataNodeComment + "\r\n" + review.text + "\r\n";
                nr++;
            }
        }

        public void ClearFields()
        {
            SubjectFaculty1.SelectedItem = null;
            SubjectName1.SelectedItem = null;
            Evaluation1.Text = "";
            Number1.Text = "";
            Comments1.Text = "";
            IsMandatory1.IsChecked = false;
            IsOptional1.IsChecked = false;
            SubjectFaculty2.SelectedItem = null;
            SubjectName2.SelectedItem = null;
            Evaluation2.Text = "";
            Number2.Text = "";
            Comments2.Text = "";
            IsMandatory2.IsChecked = false;
            IsOptional2.IsChecked = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ClearFields();
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