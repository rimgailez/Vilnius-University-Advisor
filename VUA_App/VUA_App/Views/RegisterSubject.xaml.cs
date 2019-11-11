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
    public partial class RegisterSubject : ContentPage
    {
        public RegisterSubject()
        {
            InitializeComponent();
            SubjectFaculty.ItemsSource = GetFacultyList();
        }

        private void OnCheckedChanged(object sender, EventArgs e)
        {
            if (IsBUS.IsChecked && !IsOptional.IsChecked)
            {
                IsOptional.IsChecked = true;
                return;
            }
        }

        public async void OnRegisterSubject(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)SubjectFaculty.SelectedIndex;
            DataFetcher.GetInstance().AddSubject(SubjectName.Text, faculty, IsOptional.IsChecked, IsBUS.IsChecked);
            DataFetcher.GetInstance().AddToHistory(MainResources.RegisteredSubject + SubjectName.Text + ";");
            await DisplayAlert(MainResources.RegisteredSubject, SubjectName.Text, "OK");
            SubjectName.Text = "";
            IsOptional.IsChecked = false;
            IsBUS.IsChecked = false;
            SubjectFaculty.SelectedItem = null;
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