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
    public partial class RegisterLecturer : ContentPage
    {
        public RegisterLecturer()
        {
            InitializeComponent();
            LecturerFaculty.ItemsSource = GetFacultyList();
        }

        public async void OnRegisterLecturer(object sender, EventArgs e)
        {
            Faculty faculty = (Faculty)LecturerFaculty.SelectedIndex;
            DataFetcher.GetInstance().AddLecturer(LecturerName.Text, faculty);
            DataFetcher.GetInstance().AddToHistory(MainResources.RegisteredLecturer + LecturerName.Text + ";");
            await DisplayAlert(MainResources.RegisteredLecturer, LecturerName.Text, "OK");
            LecturerName.Text = "";
            LecturerFaculty.SelectedItem = null;
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