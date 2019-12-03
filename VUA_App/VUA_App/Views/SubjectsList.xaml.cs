using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VUA_App.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VUA_App.Models;

namespace VUA_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubjectsList : ContentPage
    {
        SubjectViewModel viewModel;
        public SubjectsList()
        {
            InitializeComponent();

            SubjectListView.BindingContext = viewModel = new SubjectViewModel();
            viewModel.PropertyChanged += (sender, e) => { DisplayNumberOfSubjects(); };
            SelectFaculty.ItemsSource = GetFacultyList();
            SelectFaculty.SelectedIndexChanged += FacultySelected;
        }
        private void FacultySelected(object sender, EventArgs e)
        {
            var fetchParams = new
            {
                faculty = (Faculty)SelectFaculty.SelectedIndex,
                searchTerm = Search.Text,
                isOptional = IsOptional.IsChecked,
                isBUS = IsBUS.IsChecked
            };
            viewModel.LoadSubjectsCommand.Execute(fetchParams);
            //NumberOfSubjects.Text = MainResources.Showing + viewModel.Subjects.Count().ToString() + MainResources.Subjects;
            DisplayNumberOfSubjects();
        }
        private void OnSearchButtonPressed(object sender, EventArgs e)
        {
            var fetchParams = new
            {
                faculty = (Faculty)SelectFaculty.SelectedIndex,
                searchTerm = Search.Text,
                isOptional = IsOptional.IsChecked,
                isBUS = IsBUS.IsChecked
            };
            viewModel.LoadSubjectsCommand.Execute(fetchParams);
            //NumberOfSubjects.Text = MainResources.Showing + viewModel.Subjects.Count().ToString() + MainResources.Subjects;
            DisplayNumberOfSubjects();
        }

        private void DisplayNumberOfSubjects()
        {
                var facultyGroups = from subj in viewModel.Subjects
                                    group subj by subj.faculty;

                NumberOfSubjects.Text = MainResources.Showing + ":\r\n";
                foreach (var fGroup in facultyGroups)
                {
                    NumberOfSubjects.Text = NumberOfSubjects.Text + " " + fGroup.Count() + " " + MainResources.Subjects + " " +
                        MainResources.From + " " + GetFacultyList()[(int)fGroup.Key] + " " + MainResources.Faculty + "\r\n";
                }
        }

        private void OnCheckedChanged(object sender, EventArgs e)
        {
            if(IsBUS.IsChecked && !IsOptional.IsChecked)
            {
                IsOptional.IsChecked = true;
                return;
            }
            var fetchParams = new
            {
                faculty = (Faculty)SelectFaculty.SelectedIndex,
                searchTerm = Search.Text,
                isOptional = IsOptional.IsChecked,
                isBUS = IsBUS.IsChecked
            };
            viewModel.LoadSubjectsCommand.Execute(fetchParams);
            //NumberOfSubjects.Text = MainResources.Showing + viewModel.Subjects.Count().ToString() + MainResources.Subjects;
            DisplayNumberOfSubjects();
        }
        async void OnSubjectSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var subject = args.SelectedItem as Subject;
            if (subject == null)
                return;
            await DisplayAlert(subject.name, subject.ToString(), "OK");
            SubjectListView.SelectedItem = null;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.Subjects.Count == 0)
                viewModel.LoadSubjectsCommand.Execute(null);
            NumberOfSubjects.Text = MainResources.Showing + viewModel.Subjects.Count().ToString() + MainResources.Subjects;

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