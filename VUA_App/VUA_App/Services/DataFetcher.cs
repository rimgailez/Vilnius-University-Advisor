using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using VUA_App.Models;
using System.Text;
using Xamarin.Forms;

namespace VUA_App.Services
{
    class DataFetcher
    {
        private static readonly DataFetcher instance = new DataFetcher();
        HttpClient client = new HttpClient();
        public event EventHandler<string> errorMessage;

        private DataFetcher()
        {
            string reference;
            //reference = ConfigurationManager.AppSettings.Get("Key0");
            reference = "http://localhost:52060/api/"; 
            if(Device.RuntimePlatform == Device.Android) reference = "http://10.0.2.2:52060/api/";
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
            Lecturer lecturer = null;
            try
            {
                lecturer = new Lecturer(name, faculty);
            }
            catch (ArgumentOutOfRangeException e) { errorMessage?.Invoke(this, MainResources.WrongData); }
            AddLecturer(lecturer);
        }

        public async void AddLecturer(Lecturer lecturerNew)
        {
            await PostObjectAsync("lecturer/add", lecturerNew);
        }

        public void AddSubject(string name, Faculty faculty, bool isOptional, bool isBUS)
        {
            Subject subject = null;
            try
            {
                subject = new Subject(name, faculty, isOptional, isBUS);
            }
            catch (ArgumentOutOfRangeException e) { errorMessage?.Invoke(this, MainResources.WrongData); }
            AddSubject(subject);
        }

        public async void AddSubject(Subject subjectNew)
        {
            await PostObjectAsync("subject/add", subjectNew);
        }

        public async void AddSubjectWithoutWriting(Subject subject)
        {
            await PostObjectAsync("subject/add", subject);
        }

        public void AddUser(string name, Faculty faculty, string userName, string password, string eMail, string phoneNumber, string studyProgram)
        {
            AddUser(new User(name, faculty, userName, password, eMail, phoneNumber, studyProgram));
        }

        public async void AddUser(User userNew)
        {
            await PostObjectAsync("user/add", userNew);
        }

        public async void AddUserWithoutWriting(User user)
        {
            await PostObjectAsync("user/add", user);
        }

        public async void EvaluateLecturer(Lecturer lecturer, float lecturerScore, string text, string username)
        {
            JObject jObject = new JObject();
            jObject.Add("lecturer", JToken.FromObject(lecturer));
            jObject.Add("score", lecturerScore);
            jObject.Add("text", text);
            jObject.Add("username", username);
            await PostObjectAsync("lecturer/evaluate", jObject);
        }

        public async void EvaluateSubject(Subject subject, float subjectScore, string text, string username)
        {
            JObject jObject = new JObject();
            jObject.Add("subject", JToken.FromObject(subject));
            jObject.Add("score", subjectScore);
            jObject.Add("text", text);
            jObject.Add("username", username);
            await PostObjectAsync("subject/evaluate", jObject);
        }

        public async Task<IEnumerable<Subject>> GetBUSSubjects(Faculty faculty = Faculty.None)
        {
            string request = "subject/BUS/";
            if (!faculty.Equals(Faculty.None)) request = request + ((int)faculty).ToString();
            return await GetEnumerableFromAPI<Subject>(request);
        }
        public async Task<IEnumerable<Subject>> GetSubjectsByTypeAndFaculty(bool isOptional, Faculty faculty)
        {
            string request = "subject/TypeFaculty/" + isOptional.ToString() + "/" + ((int)faculty).ToString();
            return await GetEnumerableFromAPI<Subject>(request);
        }

        public async Task<IEnumerable<Lecturer>> GetLecturersByFaculty(Faculty faculty)
        {
            string request = "lecturer/faculty/" + ((int)faculty).ToString();
            return await GetEnumerableFromAPI<Lecturer>(request);

        }

        public async Task<IEnumerable<Subject>> GetSubjectsByFaculty(Faculty faculty)
        {
            string request = "subject/faculty/" + ((int)faculty).ToString();
            return await GetEnumerableFromAPI<Subject>(request);
        }

        public async Task<IEnumerable<Subject>> GetSubjectSearchResults(String enteredWord, Faculty faculty)
        {
            string request = "subject/search/" + ((int)faculty).ToString() + "/" + enteredWord;
            return await GetEnumerableFromAPI<Subject>(request);
        }

        public async Task<IEnumerable<Lecturer>> GetLecturerSearchResults(String enteredWord, Faculty faculty)
        {
            string request = "lecturer/search/" + ((int)faculty).ToString() + "/" + enteredWord;
            return await GetEnumerableFromAPI<Lecturer>(request);
        }

        public async Task<IEnumerable<Subject>> GetTop10Subjects()
        {
            string request = "subject/top";
            return await GetEnumerableFromAPI<Subject>(request);
        }

        public async Task<IEnumerable<Subject>> GetTop5BUSSubjects()
        {
            string request = "subject/topBUS";
            return await GetEnumerableFromAPI<Subject>(request);
        }

        public async Task<IEnumerable<Lecturer>> GetTop10Lecturers()
        {
            string request = "lecturer/top";
            return await GetEnumerableFromAPI<Lecturer>(request);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            string request = "user/all";
            return await GetEnumerableFromAPI<User>(request);
        }

        public async Task<Boolean> CheckIfUserNameExists(string userName)
        {
            string request = "user/checkUserName/" + userName;
            return await GetObjectFromAPI<Boolean>(request);
        }

        public async Task<Boolean> CheckIfCorrectPassword(string userName, string password)
        {
            string request = "user/checkPassword/" + userName + "/" + password;
            return await GetObjectFromAPI<Boolean>(request);
        }

        public async Task<User> GetCurrentUser()
        {
            string request = "user/getUser/";
            return await GetObjectFromAPI<User>(request);
        }

        public async void SetCurrentUser(User user)
        {
            await PostObjectAsync("user/setUser", user);
        }

        public async void AddToHistory(string activity)
        {
            await PostObjectAsync("user/addHistory", activity);
        }

        public async Task<List<Activity>> GetHistory()
        {
            string request = "user/getHistory";
            return (List<Activity>)await GetEnumerableFromAPI<Activity>(request);
        }

        //public async void RunScraper(RegForm regForm)
        //{
        //    HubConnection connection = new HubConnectionBuilder()
        //        .WithUrl(ConfigurationManager.AppSettings.Get("Key0") + "scraperMessages")
        //        .Build();
        //    connection.On<string>("progress", (message) =>
        //    {
        //        regForm.updateScraperTextbox(message);
        //    });
        //    try
        //    {
        //        await connection.StartAsync();
        //        await connection.InvokeAsync("StartScraper");
        //    }
        //    catch (HttpRequestException e) { errorMessage?.Invoke(this, MainResources.NoConnection); }
        //}

        public async Task<IEnumerable<StudyProgramme>> GetStudyProgrammesByFaculty(Faculty faculty)
        {
            string request = "studyProgramme/faculty/" + ((int)faculty).ToString();
            return await GetEnumerableFromAPI<StudyProgramme>(request);
        }

        public async Task<IEnumerable<User>> GetTop5ActiveLecturersEvaluators()
        {
            string request = "user/getTopLectEvaluators";
            return await GetEnumerableFromAPI<User>(request);
        }

        public async Task<IEnumerable<User>> GetTop5ActiveSubjectsEvaluators()
        {
            string request = "user/getTopSubjEvaluators";
            return await GetEnumerableFromAPI<User>(request);
        }

        public async Task<List<User>> GetTop3ActiveUsers()
        {
            string request = "user/getTopUsers";
            return (List<User>)await GetEnumerableFromAPI<User>(request);
        }

        public async Task<IEnumerable<Lecturer>> GetLecturers()
        {
            string request = "lecturer";
            return await GetEnumerableFromAPI<Lecturer>(request);
        }

        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            string request = "subject";
            return await GetEnumerableFromAPI<Subject>(request);
        }
        
        public async Task<IEnumerable<Subject>> GetSubjectsByType(bool isOptional, bool isBUS)
        {
            string request = "subject/Type/" + isOptional + "/" + isBUS;
            return await GetEnumerableFromAPI<Subject>(request);
        }

        public async Task<IEnumerable<Subject>> GetSubjectSearchResultsByType(Faculty faculty, string searchTerm, bool isOptional, bool isBUS)
        {
            string request = "subject/SearchType/" + (int)faculty + "/" + searchTerm + "/" + isOptional + "/" + isBUS;
            return await GetEnumerableFromAPI<Subject>(request);
        }

        public async Task<IEnumerable<T>> GetEnumerableFromAPI<T>(string request)
        {
            List<T> objects = new List<T>();
            try
            {
                HttpResponseMessage response = await client.GetAsync(request).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    string contents = await response.Content.ReadAsStringAsync();
                    objects = JsonConvert.DeserializeObject<List<T>>(contents);
                };
            }
            catch (Exception e) { errorMessage?.Invoke(this, MainResources.NoConnection); }
            return objects;
        }

        public async Task<T> GetObjectFromAPI<T>(string request)
        {
            T result = default;
            try
            {
                HttpResponseMessage response = await client.GetAsync(request).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    string contents = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<T>(contents);
                };
            }
            catch (Exception e) { errorMessage?.Invoke(this, MainResources.NoConnection); }
            return result;

        }

        public async Task PostObjectAsync(string request, Object objectToPost)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objectToPost);
                var contents = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, contents);
            }
            catch (Exception e) { errorMessage?.Invoke(this, MainResources.NoConnection); }
        }

        public async void UpdateInfo(User user, string name, Faculty userFaculty, string studyProgram, string eMail, string phoneNumber)
        {
            JObject jObject = new JObject();
            jObject.Add("user", JToken.FromObject(user));
            jObject.Add("name", name);
            jObject.Add("userFaculty", (int)userFaculty);
            jObject.Add("studyProgram", studyProgram);
            jObject.Add("eMail", eMail);
            jObject.Add("phoneNumber", phoneNumber);
            await PostObjectAsync("user/updateData", jObject);
        }

        public async void UpdatePassword(User user, string password)
        {
            JObject jObject = new JObject();
            jObject.Add("user", JToken.FromObject(user));
            jObject.Add("password", password);
            await PostObjectAsync("user/updatePassword", jObject);
        }

        public async void DeleteUser(User user)
        {
            await PostObjectAsync("user/deleteUser", user);
        }

        public async Task<Boolean> CheckIfLecturerWasEvaluated(int id)
        {
            string request = "lecturer/checkIfWasEvaluated/" + id.ToString();
            return await GetObjectFromAPI<Boolean>(request);
        }

        public async Task<Boolean> CheckIfSubjectWasEvaluated(int id)
        {
            string request = "subject/checkIfWasEvaluated/" + id.ToString();
            return await GetObjectFromAPI<Boolean>(request);
        }
    }
}
