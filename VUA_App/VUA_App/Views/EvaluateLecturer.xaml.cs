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
    public partial class EvaluateLecturer : ContentPage
    {
        public EvaluateLecturer()
        {
            InitializeComponent();
            SelectLecturerFaculty.ItemsSource = GetFacultyList();
            SelectLecturerFaculty.SelectedIndexChanged += FacultyChosen;
            UserName.Text = DataFetcher.GetInstance().GetCurrentUser().userName;
        }
        private void FacultyChosen(object sender, EventArgs e)
        {
            SelectLecturer.Items.Clear();
            foreach (Lecturer lect in DataFetcher.GetInstance().GetLecturersByFaculty((Faculty)SelectLecturerFaculty.SelectedIndex))
            {
                SelectLecturer.Items.Add(lect.name);
            }
        }

        public async void OnEvaluation(object sender, EventArgs e)
        {
            if ( SelectLecturerFaculty.SelectedItem == null || SelectLecturer.SelectedItem == null || LecturerComments.Text == "")
            {
                await DisplayAlert(MainResources.FillInAllFields, MainResources.BlankFields, "OK");
            }
            else
            {
                Lecturer selectedLecturer = (Lecturer)SelectLecturer.SelectedItem;
                DataFetcher.GetInstance().EvaluateLecturer(selectedLecturer, (float)0.2, LecturerComments.Text, UserName.Text);
                DataFetcher.GetInstance().AddToHistory(MainResources.EvaluatedLecturer + selectedLecturer.name + ";");
                await DisplayAlert(MainResources.SuccessfulLectEvaluation, MainResources.EvaluationCaption, "OK");
                SelectLecturerFaculty.SelectedItem = null;
                SelectLecturer.SelectedItem = null;
                LecturerComments.Text = "";
            }
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