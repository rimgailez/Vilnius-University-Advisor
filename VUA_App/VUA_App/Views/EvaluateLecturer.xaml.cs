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
    public partial class EvaluateLecturer : ContentPage
    {
        public EvaluateLecturer()
        {
            InitializeComponent();

            SelectLecturerFaculty.ItemsSource = GetFacultyList();
            SelectLecturerFaculty.SelectedIndexChanged += FacultyChosen;

            UserName.Items.Clear();
            UserName.Items.Add(DataFetcher.GetInstance().GetCurrentUser().Result.userName);
            UserName.Items.Add(MainResources.AnonymousUser);
        }
        private async void FacultyChosen(object sender, EventArgs e)
        {
            SelectLecturer.Items.Clear();
            foreach (Lecturer lect in await DataFetcher.GetInstance().GetLecturersByFaculty((Faculty)SelectLecturerFaculty.SelectedIndex))
            {
                SelectLecturer.Items.Add(lect.name);
            }
        }

        public async void OnLectEvaluation(object sender, EventArgs e)
        {
            Lecturer selectedLecturer = (await DataFetcher.GetInstance().GetLecturersByFaculty((Faculty)SelectLecturerFaculty.SelectedIndex)).ToList().Find(lect => lect.name.Equals(SelectLecturer.SelectedItem.ToString()));
            if ( SelectLecturerFaculty.SelectedItem == null || SelectLecturer.SelectedItem == null || NumericEvaluation.Text == "" ||
                LecturerComments.Text == "" || UserName.SelectedItem == null )
            {
                await DisplayAlert(MainResources.FillInAllFields, MainResources.BlankFields, "OK");
            }
            else if(await DataFetcher.GetInstance().CheckIfLecturerWasEvaluated(selectedLecturer.ID))
            {
                await DisplayAlert(MainResources.CantEvaluateLecturer, MainResources.AlreadyEvaluatedLecturer, "OK");
                ClearFields();
            }
            else
            {
                DataFetcher.GetInstance().EvaluateLecturer(selectedLecturer, (float)ConvertStringToDecimal(NumericEvaluation.Text), LecturerComments.Text, UserName.SelectedItem.ToString());
                DataFetcher.GetInstance().AddToHistory(MainResources.EvaluatedLecturer + selectedLecturer.name + ";");
                await DisplayAlert(MainResources.SuccessfulLectEvaluation, MainResources.EvaluationCaption, "OK");
                ClearFields();
            }
        }

        private void ClearFields()
        {
            SelectLecturerFaculty.SelectedItem = null;
            SelectLecturer.SelectedItem = null;
            LecturerComments.Text = "";
            NumericEvaluation.Text = "";
            UserName.SelectedItem = null;
            EvaluationLabel.Text = "";
        }

        public decimal ConvertStringToDecimal(string strValue)
        {
            if (string.IsNullOrEmpty(strValue))
                strValue = "0";
            decimal resultdecimal;
            if (decimal.TryParse(strValue, out resultdecimal))
            {
                return resultdecimal;
            }
            return 0;
        }
        public void OnImgButton1Clicked(object sender, EventArgs e)
        {
            EvaluationLabel.Text = MainResources.String1;
            NumericEvaluation.Text = "1";
        }

        public void OnImgButton2Clicked(object sender, EventArgs e)
        {
            EvaluationLabel.Text = MainResources.String2;
            NumericEvaluation.Text = "2";
        }

        public void OnImgButton3Clicked(object sender, EventArgs e)
        {
            EvaluationLabel.Text = MainResources.String3;
            NumericEvaluation.Text = "3";
        }

        public void OnImgButton4Clicked(object sender, EventArgs e)
        {
            EvaluationLabel.Text = MainResources.String4;
            NumericEvaluation.Text = "4";
        }

        public void OnImgButton5Clicked(object sender, EventArgs e)
        {
            EvaluationLabel.Text = MainResources.String5;
            NumericEvaluation.Text = "5";
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