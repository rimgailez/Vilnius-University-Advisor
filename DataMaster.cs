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
        public string projectPath;
        JsonReaderWriter jsonReaderWriter = new JsonReaderWriter();

        private DataMaster() 
        {
            projectPath = jsonReaderWriter.projectPath;
        }

        public static DataMaster GetInstance()
        {
            return instance;
        }

        public void ReadData()
        {
            lecturers = jsonReaderWriter.ReadLecturers();
            subjects = jsonReaderWriter.ReadSubjects();
        }

        public void WriteData()
        {
            lecturers = lecturers.OrderBy(lecturer => lecturer.name).ToList();
            jsonReaderWriter.WriteLecturers(lecturers);
            subjects = subjects.OrderBy(subject => subject.name).ToList();
            jsonReaderWriter.WriteSubjects(subjects);

        }

        public void AddLecturer(string name, Faculty faculty)
        {
            UniversityEntity<Lecturer>.GetEntityInstance().AddEntity(new Lecturer(name, faculty), ref lecturers);
        }

        public void AddSubject(string name, Faculty faculty, bool isOptional, bool isBUS)
        {
            UniversityEntity<Subject>.GetEntityInstance().AddEntity(new Subject(name, faculty, isOptional, isBUS), ref subjects);
        }

        public void EvaluateLecturer(Lecturer lecturer, float lecturerScore, string review)
        {
            UniversityEntity<Lecturer>.GetEntityInstance().EvaluateUniversityEntity(lecturer, lecturerScore, review, ref lecturers, lecturer.reviews);
        }

        public void EvaluateSubject(Subject subject, float subjectScore, string review)
        {
            UniversityEntity<Subject>.GetEntityInstance().EvaluateUniversityEntity(subject, subjectScore, review, ref subjects, subject.reviews);
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

        public string GetLecturerInfo(Lecturer lecturer, Faculty faculty)
        {
            string information = "";
            List<Lecturer> someLecturers = UniversityEntity<Lecturer>.GetEntityInstance().GetEntitiesByFaculty(faculty, lecturers);

            foreach (Lecturer aLecturer in someLecturers)
            {
                if ((aLecturer).Equals(lecturer))
                {
                    information = information + MainResources.LecturerName + aLecturer.name + "\r\n";
                    information = information + MainResources.LecturerEvaluation + aLecturer.score + MainResources.From5 + "\r\n";
                    information = information + MainResources.NumberOfReviews + aLecturer.numberOfReviews + "\r\n";
                    if (aLecturer.numberOfReviews > 0)
                    {
                        int number = 1;
                        information = information + MainResources.CommentsLecturer + "\r\n";
                        foreach (var item in aLecturer.reviews)
                        {
                            information = information + number + ". " + item + "\r\n";
                            number++;
                        }
                    }
                    return information;
                }
            }
            return MainResources.LecturerNotFound;
        }

        public string GetSubjectInfo(Subject subject, Faculty faculty)
        {
            string information = "";
            List<Subject> someSubjects = UniversityEntity<Subject>.GetEntityInstance().GetEntitiesByFaculty(faculty, subjects);
            foreach (Subject aSubject in someSubjects)
            {
                if ((aSubject).Equals(subject))
                {
                    information = information + MainResources.SubjectName + aSubject.name + "\r\n";
                    if (aSubject.isOptional)
                    {
                        information = information + MainResources.Optional +"\r\n";
                    }
                    else
                    {
                        information = information + MainResources.Mandatory + "\r\n";
                    }
                    if (aSubject.isBUS)
                    {
                        information = information + MainResources.BUS + "\r\n";
                    }
                    information = information + MainResources.SubjectEvaluation + aSubject.score + MainResources.From5 + "\r\n";
                    information = information + MainResources.NumberOfReviews + aSubject.numberOfReviews + "\r\n";
                    if (aSubject.numberOfReviews > 0)
                    {
                        int number = 1;
                        information = information + MainResources.CommentsSubject + "\r\n";
                        foreach (var item in aSubject.reviews)
                        {
                            information = information + number + ". " + item + "\r\n";
                            number++;
                        }
                    }
                    return information;
                }
            }
            return MainResources.SubjectNotFound;
        }

        public List<Lecturer> GetLecturers()
        {
            return lecturers;
        }

        public List<Subject> GetSubjects()
        {
            return subjects;
        }

    }
}
