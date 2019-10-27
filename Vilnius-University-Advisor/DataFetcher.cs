using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace Vilnius_University_Advisor
{
    class DataFetcher
    { 
        private static readonly DataFetcher instance  = new DataFetcher();
        HttpClient client = new HttpClient();

        private DataFetcher() 
        {
            string reference;
            reference = ConfigurationManager.AppSettings.Get("Key0");
            client.BaseAddress = new Uri(reference);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static DataFetcher GetInstance()
        {
            return instance;
        }

        public void AddLecturer(string name, Faculty faculty)
        {
            AddLecturer(new Lecturer(name, faculty));
        }

        public async void AddLecturer(Lecturer lecturerNew)
        {
            await client.PostAsJsonAsync("lecturer/add", lecturerNew);
        }

        public async void AddLecturerWithoutWriting(Lecturer lecturer)
        {
            await client.PostAsJsonAsync("lecturer/add", lecturer);
        }

        public void AddSubject(string name, Faculty faculty, bool isOptional, bool isBUS)
        {
            AddSubject(new Subject(name, faculty, isOptional, isBUS));
        }

        public async void AddSubject(Subject subjectNew)
        {
            await client.PostAsJsonAsync("subject/add", subjectNew);
        }

        public async void AddSubjectWithoutWriting(Subject subject)
        {
            await client.PostAsJsonAsync("subject/add", subject);
        }
        
        public void AddUser(string name, Faculty faculty, string userName, string password, string eMail, string phoneNumber, string studyProgram )
        {
            AddUser(new User(name, faculty, userName, password, eMail, phoneNumber, studyProgram));
        }

        public async void AddUser(User userNew)
        {
            await client.PostAsJsonAsync("user/add", userNew);
        }

        public async void AddUserWithoutWriting(User user)
        {
            await client.PostAsJsonAsync("user/add", user);
        }

        public void EvaluateLecturer(Lecturer lecturer, float lecturerScore, string text, string username)
        {
            JObject jObject = new JObject();
            jObject.Add("lecturer", JToken.FromObject(lecturer));
            jObject.Add("score", lecturerScore);
            jObject.Add("text", text);
            jObject.Add("username", username);
            client.PostAsJsonAsync("lecturer/evaluate", jObject);
        }

        public void EvaluateSubject(Subject subject, float subjectScore, string text, string username)
        {
            JObject jObject = new JObject();
            jObject.Add("subject", JToken.FromObject(subject));
            jObject.Add("score", subjectScore);
            jObject.Add("text", text);
            jObject.Add("username", username);
            client.PostAsJsonAsync("subject/evaluate", jObject);
        }

        public IEnumerable<Subject> GetBUSSubjects(Faculty faculty = Faculty.None)
        {
            return GetBUSSubjectsAsync(faculty).Result;
        }
        public async Task<IEnumerable<Subject>> GetBUSSubjectsAsync(Faculty faculty)
        {
            string request = "subject/BUS/";
            if (!faculty.Equals(Faculty.None)) request = request + ((int)faculty).ToString();
            List<Subject> subjects = null;
            HttpResponseMessage response = await client.GetAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode) subjects = await response.Content.ReadAsAsync<List<Subject>>();
            return subjects;
        }

        public IEnumerable<Subject> GetSubjectsByTypeAndFaculty(bool isOptional, Faculty faculty)
        {
            return GetSubjectsByTypeAndFacultyAsync(isOptional, faculty).Result;
        }
        public async Task<IEnumerable<Subject>> GetSubjectsByTypeAndFacultyAsync(bool isOptional, Faculty faculty)
        {
            List<Subject> subjects = null;
            HttpResponseMessage response = await client.GetAsync("subject/TypeFaculty/" + isOptional.ToString() + "/" + ((int)faculty).ToString()).ConfigureAwait(false);
            if (response.IsSuccessStatusCode) subjects = await response.Content.ReadAsAsync<List<Subject>>();
            return subjects;
        }

        public IEnumerable<Lecturer> GetLecturersByFaculty(Faculty faculty)
        {
            Task<IEnumerable<Lecturer>> lecturers = GetLecturersByFacultyAsync(faculty);
            return lecturers.Result;
        }
        public async Task<IEnumerable<Lecturer>> GetLecturersByFacultyAsync(Faculty faculty)
        {
            List<Lecturer> lecturers = null;
            int facultyInt = (int)faculty;
            HttpResponseMessage response = await client.GetAsync("lecturer/faculty/" + facultyInt.ToString()).ConfigureAwait(false);
            if (response.IsSuccessStatusCode) lecturers = await response.Content.ReadAsAsync<List<Lecturer>>();
            return lecturers;
        }

        public IEnumerable<Subject> GetSubjectsByFaculty(Faculty faculty)
        {
            return GetSubjectsByFacultyAsync(faculty).Result;
        }
        public async Task<IEnumerable<Subject>> GetSubjectsByFacultyAsync(Faculty faculty)
        {
            List<Subject> subjects = null;
            int facultyInt = (int)faculty;
            HttpResponseMessage response = await client.GetAsync("subject/faculty/" + facultyInt.ToString()).ConfigureAwait(false);
            if (response.IsSuccessStatusCode) subjects = await response.Content.ReadAsAsync<List<Subject>>();
            return subjects;
        }

        public IEnumerable<Subject> GetSubjectSearchResults(String enteredWord, Faculty faculty)
        {
            return GetSubjectSearchResultsAsync(enteredWord, faculty).Result;
        }
        public async Task<IEnumerable<Subject>> GetSubjectSearchResultsAsync(String enteredWord, Faculty faculty)
        {
            List<Subject> subjects = null;
            int facultyInt = (int)faculty;
            HttpResponseMessage response = await client.GetAsync("subject/search/" + facultyInt.ToString() + "/" + enteredWord).ConfigureAwait(false);
            if (response.IsSuccessStatusCode) subjects = await response.Content.ReadAsAsync<List<Subject>>();
            return subjects;
        }

        public IEnumerable<Lecturer> GetLecturerSearchResults(String enteredWord, Faculty faculty)
        {
            return GetLecturerSearchResultsAsync(enteredWord, faculty).Result;
        }
        public async Task<IEnumerable<Lecturer>> GetLecturerSearchResultsAsync(String enteredWord, Faculty faculty)
        {
            List<Lecturer> lecturers = null;
            int facultyInt = (int)faculty;
            HttpResponseMessage response = await client.GetAsync("lecturer/search/" + facultyInt.ToString() + "/" + enteredWord).ConfigureAwait(false);
            if (response.IsSuccessStatusCode) lecturers = await response.Content.ReadAsAsync<List<Lecturer>>();
            return lecturers;
        }

        public IEnumerable<Subject> GetTop10Subjects()
        {
            return GetTop10SubjectsAsync().Result;
        }
        public async Task<IEnumerable<Subject>> GetTop10SubjectsAsync()
        {
            string request = "subject/top";
            List<Subject> subjects = null;
            HttpResponseMessage response = await client.GetAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode) subjects = await response.Content.ReadAsAsync<List<Subject>>();
            return subjects;
        }

        public IEnumerable<Subject> GetTop5BUSSubjects()
        {
            return GetTop5BUSSubjectsAsync().Result;
        }
        public async Task<IEnumerable<Subject>> GetTop5BUSSubjectsAsync()
        {
            string request = "subject/topBUS";
            List<Subject> subjects = null;
            HttpResponseMessage response = await client.GetAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode) subjects = await response.Content.ReadAsAsync<List<Subject>>();
            return subjects;
        }

        public IEnumerable<Lecturer> GetTop10Lecturers()
        {
            return GetTop10LecturersAsync().Result;
        }
        public async Task<IEnumerable<Lecturer>> GetTop10LecturersAsync()
        {
            string request = "lecturer/top";
            List<Lecturer> lecturers = null;
            HttpResponseMessage response = await client.GetAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode) lecturers = await response.Content.ReadAsAsync<List<Lecturer>>();
            return lecturers;
        }

        
        public IEnumerable<User> GetAllUsers()
        {
            return GetAllUsersAsync().Result;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            string request = "user/all";
            List<User> users = null;
            HttpResponseMessage response = await client.GetAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode) users = await response.Content.ReadAsAsync<List<User>>();
            return users;
        }

        public Boolean CheckIfUserNameExists(string userName)
        {
            return CheckIfUserNameExistsAsync(userName).Result;
        }

        public async Task<Boolean> CheckIfUserNameExistsAsync(string userName)
        {
            Boolean result = false;
            HttpResponseMessage response = await client.GetAsync("user/checkUserName/" + userName).ConfigureAwait(false);
            if (response.IsSuccessStatusCode) result = await response.Content.ReadAsAsync<Boolean>();
            return result;
        }

        public Boolean CheckIfCorrectPassword(string userName, string password)
        {
            return CheckIfCorrectPasswordAsync(userName, password).Result;
        }

        public async Task<Boolean> CheckIfCorrectPasswordAsync(string userName, string password)
        {
            Boolean result = false;
            HttpResponseMessage response = await client.GetAsync("user/checkPassword/" + userName + "/" + password).ConfigureAwait(false);
            if (response.IsSuccessStatusCode) result = await response.Content.ReadAsAsync<Boolean>();
            return result;
        }
        
        public User GetCurrentUser()
        {
            return GetCurrentUserAsync().Result;
         }

        public async Task<User> GetCurrentUserAsync()
        {
        User curUser = null;
        HttpResponseMessage response = await client.GetAsync("user/getUser/").ConfigureAwait(false);
        if (response.IsSuccessStatusCode) curUser = await response.Content.ReadAsAsync<User>();
            return curUser;
        }

        public async void SetCurrentUser(User user)
        {
            await client.PostAsJsonAsync("user/setUser", user);
        }

        public async void AddToHistory(string activity)
        {
            await client.PostAsJsonAsync("user/addHistory", activity);
        }

        public List<Activity> GetHistory()
        {
            return GetHistoryAsync().Result;
        }

        public async Task<List<Activity>> GetHistoryAsync()
        {
            string request = "user/getHistory";
            List<Activity> activity = null;
            HttpResponseMessage response = await client.GetAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode) activity = await response.Content.ReadAsAsync<List<Activity>>();
            return activity;
        }

    }
}
