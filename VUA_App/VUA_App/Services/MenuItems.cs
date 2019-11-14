using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VUA_App.Models;

namespace VUA_App.Services
{
    static class MenuItems
    {
        public static ObservableCollection<Models.MenuItem> menuItems = new ObservableCollection<Models.MenuItem>
        {
            new Models.MenuItem { Id = MenuItemType.LogIn, Title="Prisijungti"},
            new Models.MenuItem { Id = MenuItemType.CreateAccount, Title="Registruotis"},
            new Models.MenuItem { Id = MenuItemType.LecturersList, Title="Dėstytojai"},
            new Models.MenuItem { Id = MenuItemType.SubjectsList, Title="Dalykai"},
            new Models.MenuItem { Id = MenuItemType.TOP10Subjects, Title="TOP10 dalykai"},
            new Models.MenuItem { Id = MenuItemType.TOP10Lecturers, Title="TOP10 dėstytojai"},
            new Models.MenuItem { Id = MenuItemType.TOP5BUSSubjects, Title="TOP5 BUS dalykai"}
        };

        public static void LogIn()
        {
            menuItems.Clear();
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.LecturersList, Title = "Dėstytojai" });
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.SubjectsList, Title = "Dalykai" });
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.TOP10Subjects, Title = "TOP10 dalykai" });
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.TOP10Lecturers, Title = "TOP10 dėstytojai" });
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.TOP5BUSSubjects, Title = "TOP5 BUS dalykai" });
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.EvaluateLecturer, Title = "Įvertinti dėstytoją" });
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.EvaluateSubject, Title = "Įvertinti dalyką" });
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.ViewActivityHistory, Title = "Veiklos istorija" });
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.ViewMostActiveUsers, Title = "Aktyviausi naudotojai" });
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.RegisterSubject, Title = "Registruoti dalyką" });
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.RegisterLecturer, Title = "Registruoti dėstytoją" });
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.EvaluateLecturer, Title = "Vertinti dėstytoją" });
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.LogOut, Title = "Atsijungti" });
        }
        public static void LogOut()
        {
            menuItems.Clear();
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.LogIn, Title = "Prisijungti" });
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.CreateAccount, Title = "Registruotis" });
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.LecturersList, Title = "Dėstytojai" });
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.SubjectsList, Title = "Dalykai" });
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.TOP10Subjects, Title = "TOP10 dalykai" });
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.TOP10Lecturers, Title = "TOP10 dėstytojai" });
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.TOP5BUSSubjects, Title = "TOP5 BUS dalykai" });
        }
    }
}
