using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VUA_App.Models;
using VUA_App.Services;
using Xamarin.Forms;

namespace VUA_App.ViewModels
{
    class ActivityHistoryViewModel: BaseViewModel
    {
        public ObservableCollection<Activity> Activity { get; set; }
        public Command LoadActivityCommand { get; set; }
        public ActivityHistoryViewModel()
        {
            Title = "Browse";
            Activity = new ObservableCollection<Activity>();
            LoadActivityCommand = new Command(() => ExecuteLoadActivityCommand());
        }

        async void ExecuteLoadActivityCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            IEnumerable<Activity> activity;
            activity = await DataFetcher.GetInstance().GetHistory();
            Activity.Clear();
            foreach (Activity act in activity) Activity.Add(act);
            IsBusy = false;
        }
    }
}
