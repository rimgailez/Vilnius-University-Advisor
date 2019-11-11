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
    public partial class TOP5BUSSubjects : ContentPage
    {
        TOP5BUSSubjectViewModel viewModel;
        public TOP5BUSSubjects()
        {
            InitializeComponent();
            TOP5BUSSubjectListView.BindingContext = viewModel = new TOP5BUSSubjectViewModel();
        }

        async void OnSubjectSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var subject = args.SelectedItem as Subject;
            if (subject == null)
                return;
            await DisplayAlert(subject.name, subject.ToString(), "OK");
            TOP5BUSSubjectListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Subjects.Count == 0)
                viewModel.LoadSubjectsCommand.Execute(null);
        }
    }
}