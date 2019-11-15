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
    public partial class ActivityHistory : ContentPage
    {
        ActivityHistoryViewModel viewModel;
        public ActivityHistory()
        {
            InitializeComponent();
            ActivityHistoryListView.BindingContext = viewModel = new ActivityHistoryViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Activity.Count == 0)
                viewModel.LoadActivityCommand.Execute(null);
        }
    }
}