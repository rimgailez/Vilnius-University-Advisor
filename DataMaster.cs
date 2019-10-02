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
        public void EvaluateLecturer(Lecturer lecturer, float lecturerScore, string review)
        {
            Lecturer tempLecturer;
            tempLecturer = lecturers.Find(lect => lect.Equals(lecturer));
            float sum = tempLecturer.score * tempLecturer.numberOfReviews;
            tempLecturer.numberOfReviews++;
            tempLecturer.score = (sum + lecturerScore)/tempLecturer.numberOfReviews;
            tempLecturer.reviews.Add(review);
            lecturers[lecturers.FindIndex(lect => lect.Equals(lecturer))] = tempLecturer;
            string output = JsonConvert.SerializeObject(lecturers, Formatting.Indented);
            File.WriteAllText(projectPath + directorySeparator + "lecturers.json", output);
        }

        public void EvaluateSubject(Subject subject, float subjectScore, string review)
        {
            Subject tempSubject;
            tempSubject = subjects.Find(subj => subj.Equals(subject));
            float sum = tempSubject.score * tempSubject.numberOfReviews;
            tempSubject.numberOfReviews++;
            tempSubject.score = (sum + subjectScore) / tempSubject.numberOfReviews;
            tempSubject.reviews.Add(review);
            subjects[subjects.FindIndex(subj => subj.Equals(subject))] = tempSubject;
            string output = JsonConvert.SerializeObject(subjects, Formatting.Indented);
            File.WriteAllText(projectPath + directorySeparator + "subjects.json", output);
        }

        public List<Subject> GetBUSSubjects()
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

        public List<Subject> GetBUSSubjectsByFaculty(Faculty faculty)
        {
            List<Subject> BUSSubjectsByFaculty = new List<Subject>();
            foreach (Subject aSubject in subjects)
            {
                if ((aSubject.IsBUS).Equals(true) && (aSubject.faculty).Equals(faculty))
                {
                    BUSSubjectsByFaculty.Add(aSubject);
                }
            }
            return BUSSubjectsByFaculty;
        }

        public List<Subject> GetSubjectsByTypeAndFaculty(bool IsOptional, Faculty faculty)
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

        public List<Lecturer> GetLecturersByFaculty(Faculty faculty)
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

        public string GetLecturerInfo(Lecturer lecturer, Faculty faculty)
        {
            string information = "";
            List<Lecturer> someLecturers = GetLecturersByFaculty(faculty);
            foreach (Lecturer aLecturer in someLecturers)
            {
                if ((aLecturer).Equals(lecturer))
                {
                    information = information + "Dėstytojo vardas: " + aLecturer.name + "\r\n";
                    information = information + "Dėstytojo įvertinimas: " + aLecturer.score + " iš 5\r\n";
                    information = information + "Įvertinimų skaičius: " + aLecturer.numberOfReviews + "\r\n";
                    if (aLecturer.numberOfReviews > 0)
                    {
                        int number = 1;
                        information = information + "Komentarai apie dėstytoją: " + "\r\n";
                        foreach (var item in aLecturer.reviews)
                        {
                            information = information + number + ". " + item + "\r\n";
                            number++;
                        }
                    }
                    return information;
                }
            }
            return "Dėstytojas nerastas";
        }

        public List<Subject> GetSubjectsByFaculty(Faculty faculty)
        {
            List<Subject> someSubjects = new List<Subject>();
            foreach (Subject aSubject in subjects)
            {
                if ((aSubject.faculty).Equals(faculty))
                {
                    someSubjects.Add(aSubject);
                }
            }
            return someSubjects;
        }

        public string GetSubjectInfo(Subject subject, Faculty faculty)
        {
            string information = "";
            List<Subject> someSubjects = GetSubjectsByFaculty(faculty);
            foreach (Subject aSubject in someSubjects)
            {
                if ((aSubject).Equals(subject))
                {
                    information = information + "Dalyko pavadinimas: " + aSubject.name + "\r\n";
                    if (aSubject.IsOptional)
                    {
                        information = information + "Dalykas yra pasirenkamasis\r\n";
                    }
                    else
                    {
                        information = information + "Dalykas yra privalomasis\r\n";
                    }
                    if (aSubject.IsBUS)
                    {
                        information = information + "Dalykas yra BUS\r\n";
                    }
                    information = information + "Dalyko įvertinimas: " + aSubject.score + " iš 5\r\n";
                    information = information + "Įvertinimų skaičius: " + aSubject.numberOfReviews + "\r\n";
                    if (aSubject.numberOfReviews > 0)
                    {
                        int number = 1;
                        information = information + "Komentarai apie dalyką: " + "\r\n";
                        foreach (var item in aSubject.reviews)
                        {
                            information = information + number + ". " + item + "\r\n";
                            number++;
                        }
                    }
                    return information;
                }
            }
            return "Dalykas nerastas";
        }

    }
}
