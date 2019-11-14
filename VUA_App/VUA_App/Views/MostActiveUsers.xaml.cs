using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VUA_App.Models;
using VUA_App.Services;
using VUA_App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VUA_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MostActiveUsers : ContentPage
    {
        public MostActiveUsers()
        {
            InitializeComponent();
            List<User> users = DataFetcher.GetInstance().GetTop3ActiveUsers();
            FirstPlaceLabel.Text = users.ElementAt(0).userName;
            SecondPlaceLabel.Text = users.ElementAt(1).userName;
            ThirdPlaceLabel.Text = users.ElementAt(2).userName;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
     }
    }
}