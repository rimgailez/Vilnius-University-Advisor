using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using VUA_App.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VUA_App.Models;
using System.Collections.Generic;

namespace VUA_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    
    public partial class LecturersList : ContentPage
    {
        LecturerViewModel viewModel;
        public LecturersList()
        {
            InitializeComponent();

            LecturerListView.BindingContext = viewModel = new LecturerViewModel();
            SelectFaculty.ItemsSource = GetFacultyList();
            SelectFaculty.SelectedIndexChanged += FacultySelected;
        }

        private void FacultySelected(object sender, EventArgs e)
        {
            var fetchParams = new { faculty = (Faculty)SelectFaculty.SelectedIndex, searchTerm = Search.Text};
            viewModel.LoadLecturersCommand.Execute(fetchParams);
            NumberOfLecturers.Text = MainResources.Showing + viewModel.Lecturers.Aggregate(0, (current, lecturer) => current + 1).ToString() + MainResources.Lecturers;
        }
        void OnSearchButtonPressed(object sender, EventArgs e)
        {
            var fetchParams = new { faculty = (Faculty)SelectFaculty.SelectedIndex, searchTerm = Search.Text};
            viewModel.LoadLecturersCommand.Execute(fetchParams);
            NumberOfLecturers.Text = MainResources.Showing + viewModel.Lecturers.Aggregate(0, (current, lecturer) => current + 1).ToString() + MainResources.Lecturers;
        }
        async void OnLecturerSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var lecturer = args.SelectedItem as Lecturer;
            if (lecturer == null)
                return;
            await DisplayAlert(lecturer.name, lecturer.ToString(), "OK");
            LecturerListView.SelectedItem = null;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.Lecturers.Count == 0)
                viewModel.LoadLecturersCommand.Execute(null);
            NumberOfLecturers.Text = MainResources.Showing + viewModel.Lecturers.Aggregate(0, (current, lecturer) => current + 1).ToString() + MainResources.Lecturers;
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
