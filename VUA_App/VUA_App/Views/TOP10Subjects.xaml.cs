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
    public partial class TOP10Subjects : ContentPage
    {
        TOP10SubjectViewModel viewModel;
        public TOP10Subjects()
        {
            InitializeComponent();
            TOP10SubjectListView.BindingContext = viewModel = new TOP10SubjectViewModel();
        }

        async void OnSubjectSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var subject = args.SelectedItem as Subject;
            if (subject == null)
                return;
            await DisplayAlert(subject.name, subject.ToString(), "OK");
            TOP10SubjectListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Subjects.Count == 0)
                viewModel.LoadSubjectsCommand.Execute(null);
        }
    }
}