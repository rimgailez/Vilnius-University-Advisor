using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilnius_University_Advisor
{
    class DataMaster
    {
        private static readonly DataMaster instance  = new DataMaster();

        List<Lecturer> lecturers = new List<Lecturer>();
        List<Subject> subjects = new List<Subject>();
        //get project directory
        public string projectPath = Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)).FullName).FullName;
        char directorySeparator = Path.DirectorySeparatorChar;

        private DataMaster() { }
        public static DataMaster GetInstance()
        {
            return instance;
        }
        public void ReadFromJson()
        {
            string lecturerInput = File.ReadAllText(projectPath + directorySeparator + "lecturers.json");
            lecturers = JsonConvert.DeserializeObject<List<Lecturer>>(lecturerInput);
            string subjectInput = File.ReadAllText(projectPath + directorySeparator +"subjects.json");
            subjects = JsonConvert.DeserializeObject<List<Subject>>(subjectInput);
        }
        public void WriteToJson()
        {
            lecturers = lecturers.OrderBy(lecturer => lecturer.name).ToList();
            string output = JsonConvert.SerializeObject(lecturers, Formatting.Indented);
            File.WriteAllText(projectPath + directorySeparator +"lecturers.json", output);
            subjects = subjects.OrderBy(subject => subject.name).ToList();
            output = JsonConvert.SerializeObject(subjects, Formatting.Indented);
            File.WriteAllText(projectPath + directorySeparator + "subjects.json", output);

        }
        public void AddLecturer(string name, Faculty faculty)
        {
            AddLecturer(new Lecturer(name, faculty));
        }
        public void AddLecturer(Lecturer lecturerNew)
        {
            AddLecturerWithoutWriting(lecturerNew);
            lecturers = lecturers.OrderBy(lecturer => lecturer.name).ToList();
            string output = JsonConvert.SerializeObject(lecturers, Formatting.Indented);
            File.WriteAllText(projectPath + directorySeparator + "lecturers.json", output);
        }
        public void AddLecturerWithoutWriting(Lecturer lecturer)
        {
            foreach (Lecturer lecturerCheck in lecturers)
            {
                if (lecturerCheck.Equals(lecturer)) return;
            }
            lecturers.Add(lecturer);
        }
        public void AddSubject(string name, Faculty faculty, bool IsOptional, bool IsBUS)
        {
            AddSubject(new Subject(name, faculty, IsOptional, IsBUS));
        }
        public void AddSubject(Subject subjectNew)
        {
            AddSubjectWithoutWriting(subjectNew);
            subjects = subjects.OrderBy(subject => subject.name).ToList();
            string output = JsonConvert.SerializeObject(subjects, Formatting.Indented);
            File.WriteAllText(projectPath + directorySeparator + "subjects.json", output);
        }
        public void AddSubjectWithoutWriting(Subject subject)
        {
            foreach (Subject subjectCheck in subjects)
            {
                if (subjectCheck.Equals(subject)) return;
            }
            subjects.Add(subject);
        }
        public void EvaluateLecturer(string lecturerName, float lecturerScore, string review)
        {
            Lecturer tempLecturer;
            tempLecturer = lecturers.Find(lecturer => lecturer.name.Equals(lecturerName));
            float sum = tempLecturer.score * tempLecturer.numberOfReviews;
            tempLecturer.numberOfReviews++;
            tempLecturer.score = (sum + lecturerScore)/tempLecturer.numberOfReviews;
            tempLecturer.reviews.Add(review);
            lecturers[lecturers.FindIndex(lecturer => lecturer.name.Equals(lecturerName))] = tempLecturer;
            string output = JsonConvert.SerializeObject(lecturers, Formatting.Indented);
            File.WriteAllText(projectPath + directorySeparator + "lecturers.json", output);
        }
        public List<Lecturer> getLecturers()
        {
            return lecturers;
        }
        
        public List<Subject> getSubjectsByType(bool IsOptional)
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

        public List<Subject> getBUSSubjects()
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

        public List<Subject> getSubjectsByTypeAndFaculty(bool IsOptional, Faculty faculty)
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

        public List<Lecturer> getLecturersByFaculty(Faculty faculty)
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
