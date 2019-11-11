using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using VUA_App.Models;
using VUA_App.Services;
using Xamarin.Forms;

namespace VUA_App.ViewModels
{
    class SubjectViewModel : BaseViewModel
    {
        public ObservableCollection<Subject> Subjects { get; set; }
        public Command LoadSubjectsCommand { get; set; }
        public SubjectViewModel()
        {
            Title = "Browse";
            Subjects = new ObservableCollection<Subject>();
            LoadSubjectsCommand = new Command((fetchParams) => ExecuteLoadSubjectsCommand(fetchParams));
        }

        void ExecuteLoadSubjectsCommand(dynamic fetchParams)
        {
            if (IsBusy)
                return;
            IsBusy = true;
            IEnumerable<Subject> subjects;
            Faculty faculty = Faculty.None;
            bool isOptional = false;
            bool isBUS = false;
            string searchTerm = null;
            if (fetchParams != null)
            {
                if (fetchParams.faculty != null) faculty = fetchParams.faculty;
                if (fetchParams.searchTerm != null && fetchParams.searchTerm != "") searchTerm = fetchParams.searchTerm;
                isOptional = fetchParams.isOptional;
                isBUS = fetchParams.isBUS;
            }
            if (searchTerm != null) subjects = DataFetcher.GetInstance().GetSubjectSearchResultsByType(faculty, searchTerm, isOptional, isBUS); //GetSubjectSearchResultsByType
            else if (faculty != Faculty.None)
            {
                if (isBUS) subjects = DataFetcher.GetInstance().GetBUSSubjects(faculty);
                else subjects = DataFetcher.GetInstance().GetSubjectsByTypeAndFaculty(isOptional, faculty);
            }
            else subjects = DataFetcher.GetInstance().GetSubjectsByType(isOptional, isBUS); //GetSubjectsByType
            Subjects.Clear();
            foreach (Subject subject in subjects) Subjects.Add(subject);
            IsBusy = false;
        }
    }
}
