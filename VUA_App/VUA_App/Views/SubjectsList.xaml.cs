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
        }
        private void OnCheckedChanged(object sender, EventArgs e)
        {
            var fetchParams = new
            {
                faculty = (Faculty)SelectFaculty.SelectedIndex,
                searchTerm = Search.Text,
                isOptional = IsOptional.IsChecked,
                isBUS = IsBUS.IsChecked
            };
            viewModel.LoadSubjectsCommand.Execute(fetchParams);
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