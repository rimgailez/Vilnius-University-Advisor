using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilnius_University_Advisor
{
    static class DataMaster
    {
        static List<Lecturer> lecturers = new List<Lecturer>();
        static List<Subject> subjects = new List<Subject>();
        //get project directory
        public static string projectPath = Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)).FullName).FullName;
        public static void ReadFromJson()
        {
            string lecturerInput = File.ReadAllText(projectPath + "/lecturers.json");
            lecturers = JsonConvert.DeserializeObject<List<Lecturer>>(lecturerInput);
            string subjectInput = File.ReadAllText(projectPath + "/subjects.json");
            subjects = JsonConvert.DeserializeObject<List<Subject>>(subjectInput);
        }
        public static void WriteToJson()
        {
            lecturers = lecturers.OrderBy(lecturer => lecturer.name).ToList();
            string output = JsonConvert.SerializeObject(lecturers, Formatting.Indented);
            File.WriteAllText(projectPath + "/lecturers.json", output);
            subjects = subjects.OrderBy(subject => subject.name).ToList();
            output = JsonConvert.SerializeObject(subjects, Formatting.Indented);
            File.WriteAllText(projectPath + "/subjects.json", output);

        }
        public static void AddLecturer(string name, Faculty faculty)
        {
            AddLecturer(new Lecturer(name, faculty));
        }
        public static void AddLecturer(Lecturer lecturerNew)
        {
            AddLecturerWithoutWriting(lecturerNew);
            lecturers = lecturers.OrderBy(lecturer => lecturer.name).ToList();
            string output = JsonConvert.SerializeObject(lecturers, Formatting.Indented);
            File.WriteAllText(projectPath + "/lecturers.json", output);
        }
        public static void AddLecturerWithoutWriting(Lecturer lecturer)
        {
            foreach (Lecturer lecturerCheck in lecturers)
            {
                if (lecturerCheck.Equals(lecturer)) return;
            }
            lecturers.Add(lecturer);
        }
        public static void AddSubject(string name, Faculty faculty, bool IsOptional, bool IsBUS)
        {
            AddSubject(new Subject(name, faculty, IsOptional, IsBUS));
        }
        public static void AddSubject(Subject subjectNew)
        {
            AddSubjectWithoutWriting(subjectNew);
            subjects = subjects.OrderBy(subject => subject.name).ToList();
            string output = JsonConvert.SerializeObject(subjects, Formatting.Indented);
            File.WriteAllText(projectPath + "/subjects.json", output);
        }
        public static void AddSubjectWithoutWriting(Subject subject)
        {
            foreach (Subject subjectCheck in subjects)
            {
                if (subjectCheck.Equals(subject)) return;
            }
            subjects.Add(subject);
        }
        public static void EvaluateLecturer(string lecturerName, float lecturerScore, string review)
        {
            Lecturer tempLecturer;
            tempLecturer = lecturers.Find(lecturer => lecturer.name.Equals(lecturerName));
            float sum = tempLecturer.score * tempLecturer.numberOfReviews;
            tempLecturer.numberOfReviews++;
            tempLecturer.score = (sum + lecturerScore)/tempLecturer.numberOfReviews;
            tempLecturer.reviews.Add(review);
            lecturers[lecturers.FindIndex(lecturer => lecturer.name.Equals(lecturerName))] = tempLecturer;
            string output = JsonConvert.SerializeObject(lecturers, Formatting.Indented);
            File.WriteAllText(projectPath + "/lecturers.json", output);
        }
        public static List<Lecturer> getLecturers()
        {
            return lecturers;
        }
        
        public static List<Subject> getSubjectsByType(bool IsOptional)
        {
            List<Subject> someSubjects = new List<Subject>();
            foreach (Subject aSubject in subjects)
            {
                if ((aSubject.IsOptional).Equals(IsOptional))
                {
                    someSubjects.Add(aSubject);
                }
            }
            return someSubjects;
        }

        public static List<Subject> getBUSSubjects()
        {
            List<Subject> BUSSubjects = new List<Subject>();
            foreach (Subject aSubject in subjects)
            {
                if ((aSubject.IsBUS).Equals(true))
                {
                    BUSSubjects.Add(aSubject);
                }
            }
            return BUSSubjects;
        }

        public static List<Subject> getSubjectsByTypeAndFaculty(bool IsOptional, Faculty faculty)
        {
            List<Subject> someSubjects = new List<Subject>();
            foreach (Subject aSubject in subjects)
            {
                if ((aSubject.IsOptional).Equals(IsOptional)&&(aSubject.faculty).Equals(faculty))
                {
                    someSubjects.Add(aSubject);
                }
            }
            return someSubjects;
        }

        public static List<Lecturer> getLecturersByFaculty(Faculty faculty)
        {
            List<Lecturer> someLecturers = new List<Lecturer>();
            foreach (Lecturer aLecturer in lecturers)
            {
                if ((aLecturer.faculty).Equals(faculty))
                {
                    someLecturers.Add(aLecturer);
                }
            }
            return someLecturers;
        }

    }
}
