using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using VUA_App.Models;
using VUA_App.Services;

namespace VUA_App.ViewModels
{
    class LecturerViewModel : BaseViewModel
    {
        public ObservableCollection<Lecturer> Lecturers { get; set; }
        public Command LoadLecturersCommand { get; set; }
        public LecturerViewModel()
        {
            Title = "Browse";
            Lecturers = new ObservableCollection<Lecturer>();
            LoadLecturersCommand = new Command(async (fetchParams) => await ExecuteLoadLecturersCommand(fetchParams));
        }

        async Task ExecuteLoadLecturersCommand(dynamic fetchParams) {
            if (IsBusy)
                return;
            IsBusy = true;
            IEnumerable<Lecturer> lecturers;
            Faculty faculty = Faculty.None;
            string searchTerm = null;
            if(fetchParams != null)
            {
                if (fetchParams.faculty != null) faculty = fetchParams.faculty;
                if (fetchParams.searchTerm != null && fetchParams.searchTerm != "") searchTerm = fetchParams.searchTerm;
            }
            if (searchTerm != null) lecturers = DataFetcher.GetInstance().GetLecturerSearchResults(searchTerm, faculty);
            else if (faculty != Faculty.None) lecturers = DataFetcher.GetInstance().GetLecturersByFaculty(faculty);
            else lecturers = DataFetcher.GetInstance().GetLecturers();
            Lecturers.Clear();
            foreach(Lecturer lecturer in lecturers) Lecturers.Add(lecturer);
            IsBusy = false;
        }
    }
}
