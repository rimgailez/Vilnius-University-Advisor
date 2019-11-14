using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VUA_App.Models;
using VUA_App.Services;
using Xamarin.Forms;

namespace VUA_App.ViewModels
{
    class ActiveUsersViewModel: BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; }
        public Command LoadUsersCommand { get; set; }
        public ActiveUsersViewModel()
        {
            Title = "Browse";
            Users = new ObservableCollection<User>();
            LoadUsersCommand = new Command(() => ExecuteLoadUsersCommand());
        }

        void ExecuteLoadUsersCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            IEnumerable<User> users;
            users = DataFetcher.GetInstance().GetTop3ActiveUsers();
            Users.Clear();
            foreach (User usr in users) Users.Add(usr);
            IsBusy = false;
        }
    }
}
