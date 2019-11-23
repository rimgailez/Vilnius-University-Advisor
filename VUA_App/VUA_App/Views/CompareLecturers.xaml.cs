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
    public partial class CompareLecturers : ContentPage
    {
        public CompareLecturers()
        {
            InitializeComponent();
            LecturerFaculty1.ItemsSource = GetFacultyList();
            LecturerFaculty1.SelectedIndexChanged += FacultySelected1;
            LecturerFaculty2.ItemsSource = GetFacultyList();
            LecturerFaculty2.SelectedIndexChanged += FacultySelected2;
        }

        private void FacultySelected1(object sender, EventArgs e)
        {
            LecturerName1.Items.Clear();
            foreach (Lecturer lect in DataFetcher.GetInstance().GetLecturersByFaculty((Faculty)LecturerFaculty1.SelectedIndex))
            {
                LecturerName1.Items.Add(lect.name);
            }
        }

        private void FacultySelected2(object sender, EventArgs e)
        {
            LecturerName2.Items.Clear();
            foreach (Lecturer lect in DataFetcher.GetInstance().GetLecturersByFaculty((Faculty)LecturerFaculty2.SelectedIndex))
            {
                LecturerName2.Items.Add(lect.name);
            }
        }

        public async void OnCompare(object sender, EventArgs e)
        {
            if (LecturerName1.SelectedItem == null || LecturerName2.SelectedItem == null)
            {
                await DisplayAlert(MainResources.DidntChooseLecturer, MainResources.BlankFields, "OK");
            }
            else
            {
                Evaluation1.Text = "";
                Number1.Text = "";
                Comments1.Text = "";
                Evaluation2.Text = "";
                Number2.Text = "";
                Comments2.Text = "";
                Lecturer selectedLecturer1 = DataFetcher.GetInstance().GetLecturersByFaculty((Faculty)LecturerFaculty1.SelectedIndex).ToList().Find(lect => lect.name.Equals(LecturerName1.SelectedItem.ToString()));
                Lecturer selectedLecturer2 = DataFetcher.GetInstance().GetLecturersByFaculty((Faculty)LecturerFaculty2.SelectedIndex).ToList().Find(lect => lect.name.Equals(LecturerName2.SelectedItem.ToString()));
                Evaluation1.Text = MainResources.DataNodeEvaluation + selectedLecturer1.score.ToString();
                Number1.Text = MainResources.NumberOfReviews + selectedLecturer1.numberOfReviews.ToString();
                int nr = 1;
                Comments1.Text = Comments1.Text + MainResources.DataNodeComments + "\r\n";
                foreach (Review review in selectedLecturer1.reviews)
                {
                    Comments1.Text = Comments1.Text + nr + ". "
                        + MainResources.ReviewUsername + review.username
                        + MainResources.ReviewScore + review.score + "\r\n"
                        + MainResources.ReviewDate + review.date + "\r\n"
                        + MainResources.DataNodeComment + "\r\n" + review.text + "\r\n";
                    nr++;
                }
                Evaluation2.Text = MainResources.DataNodeEvaluation + selectedLecturer2.score.ToString();
                Number2.Text = MainResources.NumberOfReviews + selectedLecturer2.numberOfReviews.ToString();
                nr = 1;
                Comments2.Text = Comments2.Text + MainResources.DataNodeComments + "\r\n";
                foreach (Review review in selectedLecturer2.reviews)
                {
                    Comments2.Text = Comments2.Text + nr + ". "
                        + MainResources.ReviewUsername + review.username
                        + MainResources.ReviewScore + review.score + "\r\n"
                        + MainResources.ReviewDate + review.date + "\r\n"
                        + MainResources.DataNodeComment + "\r\n" + review.text + "\r\n";
                    nr++;
                }
            }
        }

        public void ClearFields()
        {
            LecturerFaculty1.SelectedItem = null;
            LecturerName1.SelectedItem = null;
            Evaluation1.Text = "";
            Number1.Text = "";
            Comments1.Text = "";
            LecturerFaculty2.SelectedItem = null;
            LecturerName2.SelectedItem = null;
            Evaluation2.Text = "";
            Number2.Text = "";
            Comments2.Text = "";
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