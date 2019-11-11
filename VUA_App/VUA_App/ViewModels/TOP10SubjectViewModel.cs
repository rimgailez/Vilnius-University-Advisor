using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VUA_App.Models;
using VUA_App.Services;
using Xamarin.Forms;

namespace VUA_App.ViewModels
{
    class TOP10SubjectViewModel : BaseViewModel
    {
        public ObservableCollection<Subject> Subjects { get; set; }
        public Command LoadSubjectsCommand { get; set; }
        public TOP10SubjectViewModel()
        {
            Title = "Browse";
            Subjects = new ObservableCollection<Subject>();
            LoadSubjectsCommand = new Command(() => ExecuteLoadSubjectsCommand());
        }

        void ExecuteLoadSubjectsCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            IEnumerable<Subject> subjects;
            subjects = DataFetcher.GetInstance().GetTop10Subjects();
            Subjects.Clear();
            foreach (Subject subject in subjects) Subjects.Add(subject);
            IsBusy = false;
        }
    }
}
