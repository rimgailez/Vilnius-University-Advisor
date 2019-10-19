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

namespace Vilnius_University_Advisor
{
    class DataFetcher
    {
        private static readonly DataFetcher instance  = new DataFetcher();
        HttpClient client = new HttpClient();

        private DataFetcher() 
        {
            client.BaseAddress = new Uri("https://localhost:44368/api/");
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
            Console.WriteLine(facultyInt);
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
    }
}
