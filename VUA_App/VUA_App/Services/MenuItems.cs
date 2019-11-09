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
            new Models.MenuItem { Id = MenuItemType.LecturersList, Title="Dėstytojai"},
            new Models.MenuItem { Id = MenuItemType.SubjectsList, Title="Dalykai"}
        };

        public static void LogIn()
        {
            menuItems.Clear();
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.LecturersList, Title = "Dėstytojai" });
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.SubjectsList, Title = "Dalykai" });
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.LogOut, Title = "Atsijungti" });
        }
        public static void LogOut()
        {
            menuItems.Clear();
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.LogIn, Title = "Prisijungti" });
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.LecturersList, Title = "Dėstytojai" });
            menuItems.Add(new Models.MenuItem { Id = MenuItemType.SubjectsList, Title = "Dalykai" });
        }
    }
}
