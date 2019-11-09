using System;
using System.Collections.Generic;
using System.Text;

namespace VUA_App.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        LecturersList,
        SubjectsList,
        LogIn,
        LogOut
    }
    public class MenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
