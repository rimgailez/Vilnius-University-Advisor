using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VUA_App.Models;
using VUA_App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VUA_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TOP10Lecturers : ContentPage
    {
        TOP10LecturerViewModel viewModel;
        public TOP10Lecturers()
        {
            InitializeComponent();
            TOP10LecturerListView.BindingContext = viewModel = new TOP10LecturerViewModel();
        }

        async void OnLecturerSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var lecturer = args.SelectedItem as Lecturer;
            if (lecturer == null)
                return;
            await DisplayAlert(lecturer.name, lecturer.ToString(), "OK");
            TOP10LecturerListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Lecturers.Count == 0)
                viewModel.LoadSubjectsCommand.Execute(null);
        }
    }
}