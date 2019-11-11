using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VUA_App.Services;
using VUA_App.Models;

namespace VUA_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogIn : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        public LogIn()
        {
            InitializeComponent();
        }
        public async void OnClick(object sender, EventArgs e)
        {
            if (Username.Text.Equals("") || Password.Text.Equals("")) 
                await DisplayAlert(MainResources.FillInAllFields, MainResources.BlankFields, "OK");
            else if (!DataFetcher.GetInstance().CheckIfUserNameExists(Username.Text))
            {
                await DisplayAlert(MainResources.UserNotFound, MainResources.UserNotFoundCaption, "OK");
                Username.Text = "";
                Password.Text = "";
            }
            else if (!DataFetcher.GetInstance().CheckIfCorrectPassword(Username.Text, Password.Text))
            {
                await DisplayAlert(MainResources.WrongPassword, MainResources.WrongPasswordCaption, "OK");
                Password.Text = "";
            }
            else
            {
                DataFetcher.GetInstance().SetCurrentUser(DataFetcher.GetInstance().GetAllUsers().ToList().Find(us => us.userName.Equals(Username.Text)));
                await DisplayAlert(MainResources.SuccessfulLogIn, MainResources.LogInCaption, "OK");
                MenuItems.LogIn();
                await RootPage.NavigateFromMenu((int)MenuItemType.LecturersList);
            }
        }
    }
}