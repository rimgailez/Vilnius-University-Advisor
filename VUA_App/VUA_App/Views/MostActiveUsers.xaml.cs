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
    public partial class MostActiveUsers : ContentPage
    {
        ActiveUsersViewModel viewModel;
        public MostActiveUsers()
        {
            InitializeComponent();
            //ActiveUsersCollectionView.BindingContext = viewModel = new ActiveUsersViewModel();
        }

     //   protected override void OnAppearing()
     //   {
     //      base.OnAppearing();

     //       if (viewModel.Users.Count == 0)
     //           viewModel.LoadUsersCommand.Execute(null);
     //}
    }
}