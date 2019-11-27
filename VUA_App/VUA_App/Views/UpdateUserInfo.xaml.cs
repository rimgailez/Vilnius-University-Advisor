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
using System.Data.SqlClient;
using System.Data;

namespace VUA_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateUserInfo : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        public UpdateUserInfo()
        {
            InitializeComponent();

            User currentuser = DataFetcher.GetInstance().GetCurrentUser().Result;
            UserName.Text = currentuser.userName;
            Name.Text = currentuser.name;
            PhoneNumber.Text = currentuser.phoneNumber;
            EMail.Text = currentuser.eMail;

            ChooseFaculty.ItemsSource = GetFacultyList();
            ChooseFaculty.SelectedIndex = (int)currentuser.userFaculty;
            FacultyChosen(this, new EventArgs());

            StudyProgramme studProgram = DataFetcher.GetInstance().GetStudyProgrammesByFaculty((Faculty)ChooseFaculty.SelectedIndex).Result.ToList().Find(prog => prog.name.Equals(currentuser.studyProgram));
            ChooseStudyProgramme.SelectedIndex = DataFetcher.GetInstance().GetStudyProgrammesByFaculty((Faculty)ChooseFaculty.SelectedIndex).Result.ToList().IndexOf(studProgram);
            
            ChooseFaculty.SelectedIndexChanged += FacultyChosen;
        }

        private async void FacultyChosen(object sender, EventArgs e)
        {
            ChooseStudyProgramme.Items.Clear();
            foreach (StudyProgramme studies in await DataFetcher.GetInstance().GetStudyProgrammesByFaculty((Faculty)ChooseFaculty.SelectedIndex))
            {
                ChooseStudyProgramme.Items.Add(studies.name);
            }
        }

        public async void OnSaveInfo(object sender, EventArgs e)
        {
            if (Name.Text.Equals("") || PhoneNumber.Text.Equals("") || EMail.Text.Equals("") ||
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
            else
            {
                Faculty faculty = (Faculty)ChooseFaculty.SelectedIndex;
                DataFetcher.GetInstance().UpdateInfo(await DataFetcher.GetInstance().GetCurrentUser(), Name.Text, faculty,
                    (await DataFetcher.GetInstance().GetStudyProgrammesByFaculty(faculty)).ToList().ElementAt(ChooseStudyProgramme.SelectedIndex).name,
                    EMail.Text, PhoneNumber.Text);
                await DisplayAlert(MainResources.DataChangedSuccessfully, MainResources.UpdateCaption, "OK");
            }
        }

        public async void OnChangePassword(object sender, EventArgs e)
        {
            if(CurrentPassword.Text.Equals("") || RepeatedPassword.Text.Equals("") || NewPassword.Text.Equals(""))
            {
                await DisplayAlert(MainResources.FillInAllFields, MainResources.BlankFields, "OK");
            }
            else if(!await DataFetcher.GetInstance().CheckIfCorrectPassword(UserName.Text, CurrentPassword.Text))
            {
                await DisplayAlert(MainResources.WrongPassword, MainResources.WrongPasswordCaption, "OK");
                CurrentPassword.Text = "";
            }
            else if (!NewPassword.Text.Equals(RepeatedPassword.Text))
            {
                await DisplayAlert(MainResources.PasswordsDoNotMatch, MainResources.RepeatPassword, "OK");
                NewPassword.Text = "";
                RepeatedPassword.Text = "";
            }
            else
            {
                DataFetcher.GetInstance().UpdatePassword(await DataFetcher.GetInstance().GetCurrentUser(), NewPassword.Text);
                await DisplayAlert(MainResources.PasswordChangedSuccessfully, MainResources.UpdateCaption, "OK");
                CurrentPassword.Text = "";
                NewPassword.Text = "";
                RepeatedPassword.Text = "";
            }
        }

        public async void OnAccountDelete(object sender, EventArgs e)
        {
            var answer = await DisplayAlert(MainResources.DeleteUser, MainResources.DeleteUserCaption, "OK", "Cancel");
            if (answer)
            {
                DataFetcher.GetInstance().DeleteUser(await DataFetcher.GetInstance().GetCurrentUser());
                await DisplayAlert(MainResources.SuccessfulDeletion, MainResources.SuccessfulDeletionCaption, "OK");
                MenuItems.LogOut();
                await RootPage.NavigateFromMenu((int)MenuItemType.LogIn);
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