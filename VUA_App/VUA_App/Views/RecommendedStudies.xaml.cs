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
    public partial class RecommendedStudies : ContentPage
    {
        private static int clickCount;
        private static int totalNumOfQuestions = 27;
        private string recommendedProgrammes;

        private static Dictionary<string, int> studyProgrammesScore = new Dictionary<string, int>();
        public RecommendedStudies()
        {
            InitializeComponent();
            FirstImage.Clicked += SwitchingValues;
            SecondImage.Clicked += SwitchingValues;
            SetInitialValues();
        }

        private void SetInitialValues()
        {
            clickCount = 1;
            recommendedProgrammes = "";
            studyProgrammesScore.Clear();
            foreach (Faculty faculty in Enum.GetValues(typeof(Faculty)))
            {
                foreach (StudyProgramme stud in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(faculty))
                {
                    studyProgrammesScore.Add(stud.name, 0);
                }
            }
            MainLabel.Text = MainResources.HowDoesItLook;
            AdditionalLabel.Text = MainResources.Plants;
            FirstImage.Source = "healthy_plant.PNG";
            SecondImage.Source = "dead_plant.PNG";
            PageLabel.Text = clickCount + " / " + totalNumOfQuestions;
        }

        public async void OnCancelTest(object sender, EventArgs e)
        {
            var answer = await DisplayAlert(MainResources.CancelTest, MainResources.CancelTestCaption, "OK", "Cancel");
            if (answer)
            {
                SetInitialValues();
            }
        }

        public void OnFirstImageButtonClicked(object sender, EventArgs e)
        {
            switch (clickCount)
            {
                case 1:
                    studyProgrammesScore["Meteorologija ir hidrologija"]++;
                    studyProgrammesScore["Biochemija"]++;
                    studyProgrammesScore["Geologija"]++;
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Life_Sciences)) 
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 2:
                    studyProgrammesScore["Apskaita ir auditas"]++;
                    studyProgrammesScore["Informacijos sistemos ir kibernetinė sauga"]++;
                    studyProgrammesScore["Verslo informacijos vadyba"]++;
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Mathematics_and_Informatics))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 3:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Communication))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Law))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Philology))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Philosophy))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 4:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Medicine))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Life_Sciences))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    studyProgrammesScore["Geografija"]++;
                    break;
                case 5:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Life_Sciences))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Medicine))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 6:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.History))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 7:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Business))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 8:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Physics))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 9:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Philology))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 10:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Economics_and_Business_Administration))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 11:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Mathematics_and_Informatics))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 12:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Medicine))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Life_Sciences))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 13:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Physics))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 14:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.History))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.International_Relations_and_Political_Science))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 15:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Philology))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Philosophy))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 16:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Business))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Communication))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.International_Relations_and_Political_Science))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Law))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 17:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Business))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Economics_and_Business_Administration))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 18:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Physics))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    studyProgrammesScore["Ergoterapija"]++;
                    studyProgrammesScore["Informacijos sistemos ir kibernetinė sauga"]++;
                    studyProgrammesScore["Bioinformatika"]++;
                    studyProgrammesScore["Duomenų mokslas"]++;
                    studyProgrammesScore["Informacinės technologijos"]++;
                    studyProgrammesScore["Informacinių sistemų inžinerija"]++;
                    studyProgrammesScore["Informatika"]++;
                    studyProgrammesScore["Programų sistemos"]++;
                    break;
                case 19:
                    studyProgrammesScore["Gamtamokslinis ugdymas (biologijos pedag.)"]++;
                    studyProgrammesScore["Gamtamokslinis ugdymas (chemijos pedag.)"]++;
                    studyProgrammesScore["Gamtamokslinis ugdymas (fizikos pedag.)"]++;
                    studyProgrammesScore["Psichologija"]++;
                    studyProgrammesScore["Socialinis darbas"]++;
                    studyProgrammesScore["Sociologija"]++;
                    studyProgrammesScore["Vaikystės pedagogika (Ikimokyklinio ugdymo pedagogika)"]++;
                    studyProgrammesScore["Vaikystės pedagogika (Pradinio ugdymo pedagogika)"]++;
                    studyProgrammesScore["Vaikystės pedagogika (specializacijos: Pradinio ugdymo pedagogika arba Ikimokyklinio ugdymo pedagogika)"]++;
                    break;
                case 20:
                    studyProgrammesScore["Socialinis darbas"]++;
                    studyProgrammesScore["Farmacija"]++;
                    studyProgrammesScore["Slauga"]++;
                    break;
                case 21:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Law))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Mathematics_and_Informatics))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 22:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Chemistry_and_Geosciences))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Life_Sciences))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Medicine))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 23:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Mathematics_and_Informatics))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 24:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Mathematics_and_Informatics))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Physics))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 25:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Chemistry_and_Geosciences))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.History))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Life_Sciences))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Medicine))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 26:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Business))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Economics_and_Business_Administration))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 27:
                    studyProgrammesScore["Programų sistemos"]++;
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Business))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Economics_and_Business_Administration))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    DisplayRecommendedProgrammes();
                    break;
            }
        }

        public void OnSecondImageButtonClicked(object sender, EventArgs e)
        {
            switch (clickCount)
            {
                case 1:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Business))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.International_Relations_and_Political_Science))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 2:
                    studyProgrammesScore["Vadyba"]++;
                    studyProgrammesScore["Ekonomika"]++;
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Communication))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 3:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Mathematics_and_Informatics))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Physics))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 4:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.History))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Philosophy))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Philology))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 5:
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Philosophy))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    foreach (StudyProgramme programme in DataFetcher.GetInstance().GetStudyProgrammesByFaculty(Faculty.Law))
                    {
                        studyProgrammesScore[programme.name]++;
                    }
                    break;
                case 27:
                    DisplayRecommendedProgrammes();
                    break;
            }
        }

        public async void DisplayRecommendedProgrammes()
        {
            recommendedProgrammes = "";
            foreach (KeyValuePair<string, int> kvp in studyProgrammesScore.OrderByDescending(val => val.Value).ToList().GetRange(0, 5))
            {
                recommendedProgrammes = recommendedProgrammes + kvp.Key + "\r\n";
            }

            if (!recommendedProgrammes.Equals(""))
            {
                await DisplayAlert(MainResources.RecommendedProgrammes, recommendedProgrammes, "Baigti");
            }
            else
            {
                await DisplayAlert(MainResources.RecommendedProgrammes, MainResources.NoRecommendedProgrammes, "OK");
            }

            SetInitialValues();
        }

        public void SwitchingValues(object sender, EventArgs e)
        {
            switch (clickCount)
            {
                case 1: 
                    clickCount++;
                    AdditionalLabel.Text = MainResources.Email;
                    FirstImage.Source = "clean_email.PNG";
                    SecondImage.Source = "full_email.PNG";
                    PageLabel.Text = clickCount + " / " + totalNumOfQuestions;
                    break;
                case 2:
                    clickCount++;
                    AdditionalLabel.Text = MainResources.Parties;
                    FirstImage.Source = "talking.PNG";
                    SecondImage.Source = "gaming.PNG";
                    PageLabel.Text = clickCount + " / " + totalNumOfQuestions;
                    break;
                case 3:
                    clickCount++;
                    AdditionalLabel.Text = MainResources.Leisure;
                    FirstImage.Source = "active_leisure.PNG";
                    SecondImage.Source = "books.PNG";
                    PageLabel.Text = clickCount + " / " + totalNumOfQuestions;
                    break;
                case 4:
                    clickCount++;
                    AdditionalLabel.Text = MainResources.Laboratory;
                    FirstImage.Source = "laboratory.PNG";
                    SecondImage.Source = "messy_lab.PNG";
                    PageLabel.Text = clickCount + " / " + totalNumOfQuestions;
                    break;
                case 5:
                    clickCount++;
                    MainLabel.Text = MainResources.LikedSubjects;
                    AdditionalLabel.Text = MainResources.History;
                    SetLikeDislikePageNo();
                    break;
                case 6:
                    clickCount++;
                    MainLabel.Text = MainResources.LikedSubjects;
                    AdditionalLabel.Text = MainResources.Marketing;
                    SetLikeDislikePageNo();
                    break;
                case 7:
                    clickCount++;
                    MainLabel.Text = MainResources.LikedSubjects;
                    AdditionalLabel.Text = MainResources.Physics;
                    SetLikeDislikePageNo();
                    break;
                case 8:
                    clickCount++;
                    MainLabel.Text = MainResources.LikedSubjects;
                    AdditionalLabel.Text = MainResources.ForeignLanguages;
                    SetLikeDislikePageNo();
                    break;
                case 9:
                    clickCount++;
                    MainLabel.Text = MainResources.LikedSubjects;
                    AdditionalLabel.Text = MainResources.Economy;
                    SetLikeDislikePageNo();
                    break;
                case 10:
                    clickCount++;
                    MainLabel.Text = MainResources.LikedSubjects;
                    AdditionalLabel.Text = MainResources.Math;
                    SetLikeDislikePageNo();
                    break;
                case 11:
                    clickCount++;
                    MainLabel.Text = MainResources.LikedSubjects;
                    AdditionalLabel.Text = MainResources.Biology;
                    SetLikeDislikePageNo();
                    break;
                case 12:
                    clickCount++;
                    MainLabel.Text = MainResources.Talent;
                    AdditionalLabel.Text = MainResources.FixBrokenThings;
                    SetLikeDislikePageNo();
                    break;
                case 13:
                    clickCount++;
                    MainLabel.Text = MainResources.Talent;
                    AdditionalLabel.Text = MainResources.BrainBattle;
                    SetLikeDislikePageNo();
                    break;
                case 14:
                    clickCount++;
                    MainLabel.Text = MainResources.Talent;
                    AdditionalLabel.Text = MainResources.PlayingInstrument;
                    SetLikeDislikePageNo();
                    break;
                case 15:
                    clickCount++;
                    MainLabel.Text = MainResources.Talent;
                    AdditionalLabel.Text = MainResources.Sociable;
                    SetLikeDislikePageNo();
                    break;
                case 16:
                    clickCount++;
                    MainLabel.Text = MainResources.Talent;
                    AdditionalLabel.Text = MainResources.BusinessMan;
                    SetLikeDislikePageNo();
                    break;
                case 17:
                    clickCount++;
                    MainLabel.Text = MainResources.Talent;
                    AdditionalLabel.Text = MainResources.TechnologiesExpert;
                    SetLikeDislikePageNo();
                    break;
                case 18:
                    clickCount++;
                    MainLabel.Text = MainResources.DreamJob;
                    AdditionalLabel.Text = MainResources.YouthProblems;
                    SetLikeDislikePageNo();
                    break;
                case 19:
                    clickCount++;
                    MainLabel.Text = MainResources.DreamJob;
                    AdditionalLabel.Text = MainResources.HelpOldPeople;
                    SetLikeDislikePageNo();
                    break;
                case 20:
                    clickCount++;
                    MainLabel.Text = MainResources.DreamJob;
                    AdditionalLabel.Text = MainResources.Office;
                    SetLikeDislikePageNo();
                    break;
                case 21:
                    clickCount++;
                    MainLabel.Text = MainResources.DreamJob;
                    AdditionalLabel.Text = MainResources.LaboratoryJob;
                    SetLikeDislikePageNo();
                    break;
                case 22:
                    clickCount++;
                    MainLabel.Text = MainResources.DreamJob;
                    AdditionalLabel.Text = MainResources.FlexibleWorkingHours;
                    SetLikeDislikePageNo();
                    break;
                case 23:
                    clickCount++;
                    MainLabel.Text = MainResources.DreamJob;
                    AdditionalLabel.Text = MainResources.Technologies;
                    SetLikeDislikePageNo();
                    break;
                case 24:
                    clickCount++;
                    MainLabel.Text = MainResources.DreamJob;
                    AdditionalLabel.Text = MainResources.Research;
                    SetLikeDislikePageNo();
                    break;
                case 25:
                    clickCount++;
                    MainLabel.Text = MainResources.DreamJob;
                    AdditionalLabel.Text = MainResources.Boss;
                    SetLikeDislikePageNo();
                    break;
                case 26:
                    clickCount++;
                    MainLabel.Text = MainResources.DreamJob;
                    AdditionalLabel.Text = MainResources.Business;
                    SetLikeDislikePageNo();
                    break;
            }
        }
        private void SetLikeDislikePageNo()
        {
            FirstImage.Source = "like.PNG";
            SecondImage.Source = "dislike.PNG";
            PageLabel.Text = clickCount + " / " + totalNumOfQuestions;
        }
    }
}