using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VUA_App.Models;
using VUA_App.Services;
using Xamarin.Forms;

namespace VUA_App.ViewModels
{
    class TOP10LecturerViewModel : BaseViewModel
    {
        public ObservableCollection<Lecturer> Lecturers { get; set; }
        public Command LoadSubjectsCommand { get; set; }
        public TOP10LecturerViewModel()
        {
            Title = "Browse";
            Lecturers = new ObservableCollection<Lecturer>();
            LoadSubjectsCommand = new Command(() => ExecuteLoadSubjectsCommand());
        }

        void ExecuteLoadSubjectsCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            IEnumerable<Lecturer> lecturers;
            lecturers = DataFetcher.GetInstance().GetTop10Lecturers();
            Lecturers.Clear();
            foreach (Lecturer lecturer in lecturers) Lecturers.Add(lecturer);
            IsBusy = false;
        }
    }
}
