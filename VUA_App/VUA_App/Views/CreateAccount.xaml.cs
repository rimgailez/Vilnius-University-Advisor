using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VUA_App.Models;
using VUA_App.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VUA_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccount : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        public CreateAccount()
        {
            InitializeComponent();
            ChooseFaculty.ItemsSource = GetFacultyList();
            ChooseFaculty.SelectedIndexChanged += FacultyChosen;
        }

        private async void FacultyChosen(object sender, EventArgs e)
        {
            ChooseStudyProgramme.Items.Clear();
            foreach(StudyProgramme studies in await DataFetcher.GetInstance().GetStudyProgrammesByFaculty((Faculty)ChooseFaculty.SelectedIndex))
            {
                ChooseStudyProgramme.Items.Add(studies.name);
            }
        }

        public async void OnRegister(object sender, EventArgs e) 
        {
            if(Name.Text.Equals("") || PhoneNumber.Text.Equals("") || EMail.Text.Equals("") || 
            UserName.Text.Equals("") || Password.Text.Equals("") || RepeatedPassword.Text.Equals("") || 
            ChooseFaculty.SelectedItem.Equals("") || ChooseStudyProgramme.SelectedItem.Equals(""))
            {
                await DisplayAlert(MainResources.FillInAllFields, MainResources.BlankFields, "OK");
            }
            else if (!Regex.IsMatch(PhoneNumber.Text, @"^[+3706]\d{7}?"))
            {
                await DisplayAlert(MainResources.WrongPhoneNo, MainResources.BlankFields, "OK");
            }
            else if (!Regex.IsMatch(Name.Text, @"^\p{L}+(?:\s\p{L}+)+$", RegexOptions.IgnoreCase))
            {
                await DisplayAlert(MainResources.EnterNameAndUsername, MainResources.BlankFields, "OK");
            }
            else if (!Regex.IsMatch(EMail.Text, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", RegexOptions.IgnoreCase))
            {
                await DisplayAlert(MainResources.WrongEmail, MainResources.BlankFields, "OK");
            }
            else if (!Password.Text.Equals(RepeatedPassword.Text))
            {
                await DisplayAlert(MainResources.PasswordsDoNotMatch, MainResources.RepeatPassword, "OK");
                Password.Text = "";
                RepeatedPassword.Text = "";
            }
            else if (await DataFetcher.GetInstance().CheckIfUserNameExists(UserName.Text))
            {
                await DisplayAlert(MainResources.UserAlreadyExists, MainResources.UserNameExistsCaption, "OK");
            }
            else
            {
                Faculty faculty = (Faculty)ChooseFaculty.SelectedIndex;
                User user = new User(Name.Text, faculty, UserName.Text, Password.Text, EMail.Text, PhoneNumber.Text, ChooseStudyProgramme.SelectedItem.ToString());
                DataFetcher.GetInstance().AddUser(user);
                DataFetcher.GetInstance().SetCurrentUser(user);
                await DisplayAlert(MainResources.RegistrationSuccessful, MainResources.RegistrationCaption, "OK");
                MenuItems.LogIn();
                await RootPage.NavigateFromMenu((int)MenuItemType.LecturersList);
            }
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