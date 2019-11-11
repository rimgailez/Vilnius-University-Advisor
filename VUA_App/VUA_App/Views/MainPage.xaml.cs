using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using VUA_App.Models;
using VUA_App.Services;

namespace VUA_App.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.LecturersList:
                        MenuPages.Add(id, new NavigationPage(new LecturersList()));
                        break;
                    case (int)MenuItemType.SubjectsList:
                        MenuPages.Add(id, new NavigationPage(new SubjectsList()));
                        break;
                    case (int)MenuItemType.LogIn:
                        MenuPages.Add(id, new NavigationPage(new LogIn()));
                        break;
                    case (int)MenuItemType.CreateAccount:
                        MenuPages.Add(id, new NavigationPage(new CreateAccount()));
                        break;
                    case (int)MenuItemType.RegisterSubject:
                        MenuPages.Add(id, new NavigationPage(new RegisterSubject()));
                        break;
                    case (int)MenuItemType.RegisterLecturer:
                        MenuPages.Add(id, new NavigationPage(new RegisterLecturer()));
                        break;
                    case (int)MenuItemType.TOP10Subjects:
                        MenuPages.Add(id, new NavigationPage(new TOP10Subjects()));
                        break;
                    case (int)MenuItemType.TOP10Lecturers:
                        MenuPages.Add(id, new NavigationPage(new TOP10Lecturers()));
                        break;
                    case (int)MenuItemType.TOP5BUSSubjects:
                        MenuPages.Add(id, new NavigationPage(new TOP5BUSSubjects()));
                        break;
                    case (int)MenuItemType.LogOut:
                        MenuItems.LogOut();
                        MenuPages.Add(id, new NavigationPage(new LogIn()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}