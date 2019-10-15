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

        UniversityEntitiesList<Lecturer> lecturers = new UniversityEntitiesList<Lecturer>();
        UniversityEntitiesList<Subject> subjects = new UniversityEntitiesList<Subject>();

        public readonly JsonReaderWriter jsonReaderWriter = new JsonReaderWriter();

        private DataMaster() { }
        public static DataMaster GetInstance()
        {
            return instance;
        }

        public void ReadData()
        {
            lecturers.SetListOfUniversityEntities(jsonReaderWriter.ReadLecturers());
            subjects.SetListOfUniversityEntities(jsonReaderWriter.ReadSubjects());
        }

        public void WriteData()
        {
            lecturers.Sort();
            jsonReaderWriter.WriteLecturers(lecturers.GetListOfUniversityEntities());
            subjects.Sort();
            jsonReaderWriter.WriteSubjects(subjects.GetListOfUniversityEntities());
        }

        public void AddLecturer(string name, Faculty faculty)
        {
            AddLecturer(new Lecturer(name, faculty));
        }

        public void AddLecturer(Lecturer lecturerNew)
        {
            AddLecturerWithoutWriting(lecturerNew);
            lecturers.Sort();
            WriteData();
        }

        public void AddLecturerWithoutWriting(Lecturer lecturer)
        {
            lecturers.AddEntityWithoutWriting(lecturer);
        }

        public void AddSubject(string name, Faculty faculty, bool isOptional, bool isBUS)
        {
            AddSubject(new Subject(name, faculty, isOptional, isBUS));
        }

        public void AddSubject(Subject subjectNew)
        {
            AddSubjectWithoutWriting(subjectNew);
            subjects.Sort();
            WriteData();
        }

        public void AddSubjectWithoutWriting(Subject subject)
        {
            subjects.AddEntityWithoutWriting(subject);
        }

        public void EvaluateLecturer(Lecturer lecturer, float lecturerScore, string text, string username)
        {
            lecturers.EvaluateEntity(lecturer, lecturerScore, new Review(username, (int)lecturerScore, text));
        }

        public void EvaluateSubject(Subject subject, float subjectScore, string text, string username)
        {
            subjects.EvaluateEntity(subject, subjectScore, new Review(username, (int)subjectScore, text));
        }

        public List<Subject> GetBUSSubjects(Faculty faculty = Faculty.None)
        {
            List<Subject> BUSSubjects = new List<Subject>();
            if (faculty == Faculty.None)
            {
                BUSSubjects = (from subject in subjects
                              where subject.isBUS == true
                              select subject).ToList();
            }
            else
            {
                BUSSubjects = (from subject in subjects
                               where subject.isBUS == true && subject.faculty == faculty
                               select subject).ToList();
            }
            return BUSSubjects;
        }

        public List<Subject> GetSubjectsByTypeAndFaculty(bool isOptional, Faculty faculty)
        {
            List<Subject> someSubjects = (from subject in subjects
                                          where subject.isOptional == isOptional &&
                                                subject.faculty == faculty
                                          select subject).ToList();
            return someSubjects;
        }

        public List<Lecturer> GetLecturersByFaculty(Faculty faculty)
        {
            return lecturers.GetEntitiesByFaculty(faculty);
        }

        public List<Subject> GetSubjectsByFaculty(Faculty faculty)
        {
            return subjects.GetEntitiesByFaculty(faculty);
        }

        public List<Subject> GetSubjectSearchResults(String enteredWord, Faculty faculty)
        {
            return subjects.GetEntitySearchResults(enteredWord, faculty);
        }

        public List<Lecturer> GetLecturerSearchResults(String enteredWord, Faculty faculty)
        {
            return lecturers.GetEntitySearchResults(enteredWord, faculty);
        }
    }
}
