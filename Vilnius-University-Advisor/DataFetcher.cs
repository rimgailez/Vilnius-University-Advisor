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
using Microsoft.AspNetCore.SignalR.Client;

namespace Vilnius_University_Advisor
{
    class DataFetcher
    { 
        private static readonly DataFetcher instance  = new DataFetcher();
        HttpClient client = new HttpClient();
        public event EventHandler<string> errorMessage;

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

        public void AddLecturer(Lecturer lecturerNew)
        {
            PostObject("lecturer/add", lecturerNew);
        }

        public void AddLecturerWithoutWriting(Lecturer lecturer)
        {
            PostObject("lecturer/add", lecturer);
        }

        public void AddSubject(string name, Faculty faculty, bool isOptional, bool isBUS)
        {
            AddSubject(new Subject(name, faculty, isOptional, isBUS));
        }

        public void AddSubject(Subject subjectNew)
        {
            PostObject("subject/add", subjectNew);
        }

        public void AddSubjectWithoutWriting(Subject subject)
        {
            PostObject("subject/add", subject);
        }
        
        public void AddUser(string name, Faculty faculty, string userName, string password, string eMail, string phoneNumber, string studyProgram )
        {
            AddUser(new User(name, faculty, userName, password, eMail, phoneNumber, studyProgram));
        }

        public void AddUser(User userNew)
        {
            PostObject("user/add", userNew);
        }

        public void AddUserWithoutWriting(User user)
        {
            PostObject("user/add", user);
        }

        public void EvaluateLecturer(Lecturer lecturer, float lecturerScore, string text, string username)
        {
            JObject jObject = new JObject();
            jObject.Add("lecturer", JToken.FromObject(lecturer));
            jObject.Add("score", lecturerScore);
            jObject.Add("text", text);
            jObject.Add("username", username);
            PostObject("lecturer/evaluate", jObject);
        }

        public void EvaluateSubject(Subject subject, float subjectScore, string text, string username)
        {
            JObject jObject = new JObject();
            jObject.Add("subject", JToken.FromObject(subject));
            jObject.Add("score", subjectScore);
            jObject.Add("text", text);
            jObject.Add("username", username);
            PostObject("subject/evaluate", jObject);
        }

        public IEnumerable<Subject> GetBUSSubjects(Faculty faculty = Faculty.None)
        {
            string request = "subject/BUS/";
            if (!faculty.Equals(Faculty.None)) request = request + ((int)faculty).ToString();
            return GetEnumerableFromAPI<Subject>(request).Result;
        }
        public IEnumerable<Subject> GetSubjectsByTypeAndFaculty(bool isOptional, Faculty faculty)
        {
            string request = "subject/TypeFaculty/" + isOptional.ToString() + "/" + ((int)faculty).ToString();
            return GetEnumerableFromAPI<Subject>(request).Result;
        }

        public IEnumerable<Lecturer> GetLecturersByFaculty(Faculty faculty)
        {
            string request = "lecturer/faculty/" + ((int)faculty).ToString();
            return GetEnumerableFromAPI<Lecturer>(request).Result;

        }

        public IEnumerable<Subject> GetSubjectsByFaculty(Faculty faculty)
        {
            string request = "subject/faculty/" + ((int)faculty).ToString();
            return GetEnumerableFromAPI<Subject>(request).Result;
        }

        public IEnumerable<Subject> GetSubjectSearchResults(String enteredWord, Faculty faculty)
        {
            string request = "subject/search/" + ((int)faculty).ToString() + "/" + enteredWord;
            return GetEnumerableFromAPI<Subject>(request).Result;
        }

        public IEnumerable<Lecturer> GetLecturerSearchResults(String enteredWord, Faculty faculty)
        {
            string request = "lecturer/search/" + ((int)faculty).ToString() + "/" + enteredWord;
            return GetEnumerableFromAPI<Lecturer>(request).Result;
        }

        public IEnumerable<Subject> GetTop10Subjects()
        {
            string request = "subject/top";
            return GetEnumerableFromAPI<Subject>(request).Result;
        }

        public IEnumerable<Subject> GetTop5BUSSubjects()
        {
            string request = "subject/topBUS";
            return GetEnumerableFromAPI<Subject>(request).Result;
        }

        public IEnumerable<Lecturer> GetTop10Lecturers()
        {
            string request = "lecturer/top";
            return GetEnumerableFromAPI<Lecturer>(request).Result;
        }

        
        public IEnumerable<User> GetAllUsers()
        {
            string request = "user/all";
            return GetEnumerableFromAPI<User>(request).Result;
        }

        public Boolean CheckIfUserNameExists(string userName)
        {
            string request = "user/checkUserName/" + userName;
            return GetObjectFromAPI<Boolean>(request).Result;
        }

        public Boolean CheckIfCorrectPassword(string userName, string password)
        {
            string request = "user/checkPassword/" + userName + "/" + password;
            return GetObjectFromAPI<Boolean>(request).Result;
        }
        
        public User GetCurrentUser()
        {
            string request = "user/getUser/";
            return GetObjectFromAPI<User>(request).Result;
        }

        public void SetCurrentUser(User user)
        {
            PostObject("user/setUser", user);
        }

        public void AddToHistory(string activity)
        {
            PostObject("user/addHistory", activity);
        }

        public List<Activity> GetHistory()
        {
            string request = "user/getHistory";
            return (List<Activity>)GetEnumerableFromAPI<Activity>(request).Result;
        }

        public async void RunScraper(RegForm regForm)
        {
            HubConnection connection = new HubConnectionBuilder()
                .WithUrl(ConfigurationManager.AppSettings.Get("Key0") + "scraperMessages")
                .Build();
            connection.On<string>("progress", (message) =>
            {
                regForm.updateScraperTextbox(message);
            });
            try
            {
                await connection.StartAsync();
                await connection.InvokeAsync("StartScraper");
            }
            catch (HttpRequestException e) { errorMessage?.Invoke(this, "Nera interneto"); }
        }

        public IEnumerable<StudyProgramme> GetStudyProgrammesByFaculty(Faculty faculty)
        {
            string request = "studyProgramme/faculty/" + ((int)faculty).ToString();
            return GetEnumerableFromAPI<StudyProgramme>(request).Result;
        }

        public IEnumerable<User> GetTop5ActiveLecturersEvaluators()
        {
            string request = "user/getTopLectEvaluators";
            return GetEnumerableFromAPI<User>(request).Result;
        }

        public IEnumerable<User> GetTop5ActiveSubjectsEvaluators()
        {
            string request = "user/getTopSubjEvaluators";
            return GetEnumerableFromAPI<User>(request).Result;
        }

        public List<User> GetTop3ActiveUsers()
        {
            string request = "user/getTopUsers";
            return (List<User>)GetEnumerableFromAPI<User>(request).Result;
        }

        public async Task<IEnumerable<T>> GetEnumerableFromAPI<T>(string request)
        {
            List<T> objects = new List<T>();
            try
            {
                HttpResponseMessage response = await client.GetAsync(request).ConfigureAwait(false);
                if (response.IsSuccessStatusCode) objects = await response.Content.ReadAsAsync<List<T>>();
            } catch(HttpRequestException e) { errorMessage?.Invoke(this, MainResources.NoCoonection); }
            return objects;
        }
        public async Task<T> GetObjectFromAPI<T>(string request)
        {
            T result = default;
            try
            {
                HttpResponseMessage response = await client.GetAsync(request).ConfigureAwait(false);
                if (response.IsSuccessStatusCode) result = await response.Content.ReadAsAsync<T>();
            } catch(HttpRequestException e) { errorMessage?.Invoke(this, MainResources.NoCoonection); }
            return result;

        }
        public async void PostObject(string request, Object objectToPost)
        {
            try
            {
                await client.PostAsJsonAsync(request, objectToPost);
            }
            catch (HttpRequestException e) { errorMessage?.Invoke(this, MainResources.NoCoonection); }
        }
    }
}
