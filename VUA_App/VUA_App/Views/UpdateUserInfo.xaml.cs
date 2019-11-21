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
        private static string connectionString = "";


        MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        public UpdateUserInfo()
        {
            InitializeComponent();

            User currentuser = DataFetcher.GetInstance().GetCurrentUser();
            UserName.Text = currentuser.userName;
            Name.Text = currentuser.name;
            PhoneNumber.Text = currentuser.phoneNumber;
            EMail.Text = currentuser.eMail;

            ChooseFaculty.ItemsSource = GetFacultyList();
            ChooseFaculty.SelectedIndex = (int)currentuser.userFaculty;
            FacultyChosen(this, new EventArgs());

            StudyProgramme studProgram = DataFetcher.GetInstance().GetStudyProgrammesByFaculty((Faculty)ChooseFaculty.SelectedIndex).ToList().Find(prog => prog.name.Equals(currentuser.studyProgram));
            ChooseStudyProgramme.SelectedIndex = DataFetcher.GetInstance().GetStudyProgrammesByFaculty((Faculty)ChooseFaculty.SelectedIndex).ToList().IndexOf(studProgram);
            
            ChooseFaculty.SelectedIndexChanged += FacultyChosen;
        }

        private void FacultyChosen(object sender, EventArgs e)
        {
            ChooseStudyProgramme.Items.Clear();
            foreach (StudyProgramme studies in DataFetcher.GetInstance().GetStudyProgrammesByFaculty((Faculty)ChooseFaculty.SelectedIndex))
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
                UpdateInfo(connectionString);
                await DisplayAlert(MainResources.DataChangedSuccessfully, MainResources.UpdateCaption, "OK");
            }
        }

        public async void OnChangePassword(object sender, EventArgs e)
        {
            if(CurrentPassword.Text.Equals("") || RepeatedPassword.Text.Equals("") || NewPassword.Text.Equals(""))
            {
                await DisplayAlert(MainResources.FillInAllFields, MainResources.BlankFields, "OK");
            }
            else if(!DataFetcher.GetInstance().CheckIfCorrectPassword(UserName.Text, CurrentPassword.Text))
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
                UpdatePassword(connectionString);
                await DisplayAlert(MainResources.PasswordChangedSuccessfully, MainResources.UpdateCaption, "OK");
            }
        }

        public async void OnAccountDelete(object sender, EventArgs e)
        {
            DeleteUser(connectionString);
            await DisplayAlert(MainResources.SuccessfulDeletion, MainResources.SuccessfulDeletionCaption, "OK");
            MenuItems.LogOut();
            await RootPage.NavigateFromMenu((int)MenuItemType.LogIn);
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

        private static void UpdateInfo(string connectionString)
        {
            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(
                  "SELECT userName, name, userFaculty, studyProgram, eMail, phoneNumber FROM dbo.User",
                  connection);

                dataAdapter.UpdateCommand = new SqlCommand(
                   "UPDATE dbo.User SET name = @name, userFaculty = @userFaculty, studyProgram = @studyProgram, eMail = @eMail, phoneNumber = @phoneNumber " +
                   "WHERE userName = @userName", connection);

                dataAdapter.UpdateCommand.Parameters.Add("@name", SqlDbType.NVarChar, 20, "name");
                dataAdapter.UpdateCommand.Parameters.Add("@userFaculty", SqlDbType.Int, 8, "userFaculty");
                dataAdapter.UpdateCommand.Parameters.Add("@studyProgram", SqlDbType.NVarChar, 30, "studyProgram");
                dataAdapter.UpdateCommand.Parameters.Add("@eMail", SqlDbType.NVarChar, 25, "eMail");
                dataAdapter.UpdateCommand.Parameters.Add("@phoneNumber", SqlDbType.NVarChar, 12, "phoneNumber");


                SqlParameter parameter = dataAdapter.UpdateCommand.Parameters.Add("@userName", SqlDbType.NVarChar);
                parameter.SourceColumn = "userName";
                parameter.SourceVersion = DataRowVersion.Original;

                DataTable userTable = new DataTable();
                dataAdapter.Fill(userTable);

                DataRow userRow = userTable.Rows[DataFetcher.GetInstance().GetAllUsers().ToList().IndexOf(DataFetcher.GetInstance().GetCurrentUser())];
                userRow["name"] = "new name";

                dataAdapter.Update(userTable);

                connection.Close();
            }
        }

        private static void UpdatePassword(string connectionString)
        {
            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(
                  "SELECT userName, password FROM dbo.User", connection);

                dataAdapter.UpdateCommand = new SqlCommand(
                   "UPDATE dbo.User SET password = @password " +
                   "WHERE userName = @userName", connection);

                dataAdapter.UpdateCommand.Parameters.Add("@password", SqlDbType.NVarChar, 20, "password");

                SqlParameter parameter = dataAdapter.UpdateCommand.Parameters.Add("@userName", SqlDbType.NVarChar);
                parameter.SourceColumn = "userName";
                parameter.SourceVersion = DataRowVersion.Original;

                DataTable userTable = new DataTable();
                dataAdapter.Fill(userTable);

                DataRow userRow = userTable.Rows[DataFetcher.GetInstance().GetAllUsers().ToList().IndexOf(DataFetcher.GetInstance().GetCurrentUser())];
                userRow["password"] = "new password";

                dataAdapter.Update(userTable);

                connection.Close();
            }
        }

        private static void DeleteUser(string connectionString)
        {
            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter();

                SqlCommand command = new SqlCommand(
                 "DELETE FROM dbo.User WHERE userName = @userName", connection);

                SqlParameter parameter = command.Parameters.Add(
                    "@userName", SqlDbType.NVarChar, 20, "userName");
                parameter.SourceVersion = DataRowVersion.Original;

                dataAdapter.DeleteCommand = command;

                DataTable userTable = new DataTable();
                dataAdapter.Fill(userTable);

                DataRow userRow = userTable.Rows[DataFetcher.GetInstance().GetAllUsers().ToList().IndexOf(DataFetcher.GetInstance().GetCurrentUser())];

                userRow.Delete();
                dataAdapter.Update(userTable);

                connection.Close();
            }
        }

    }
}