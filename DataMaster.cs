﻿using Newtonsoft.Json;
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

       /* List<Lecturer> lecturers = new List<Lecturer>();
        List<Subject> subjects = new List<Subject>();*/

        UniversityEntitiesList<Lecturer> lecturers = new UniversityEntitiesList<Lecturer>();
        UniversityEntitiesList<Subject> subjects = new UniversityEntitiesList<Subject>();

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
            lecturers.SetListOfUniversityEntities(jsonReaderWriter.ReadLecturers());
            subjects.SetListOfUniversityEntities(jsonReaderWriter.ReadSubjects());
        }

        public void WriteData()
        {
            var lecturersList = lecturers.GetListOfUniversityEntities();
            lecturersList.Sort();
            jsonReaderWriter.WriteLecturers(lecturersList);
            var subjectsList = subjects.GetListOfUniversityEntities();
            subjectsList.Sort();
            jsonReaderWriter.WriteSubjects(subjectsList);
        }

        public void AddLecturer(string name, Faculty faculty)
        {
            AddLecturer(new Lecturer(name, faculty));
        }

        public void AddLecturer(Lecturer lecturerNew)
        {
            AddLecturerWithoutWriting(lecturerNew);
            var lecturersList = lecturers.GetListOfUniversityEntities();
            lecturersList.Sort();
            lecturers.SetListOfUniversityEntities(lecturersList);

            WriteData();
        }

        public void AddLecturerWithoutWriting(Lecturer lecturer)
        {
            if(!lecturers.Contains(lecturer)) lecturers.Add(lecturer);
        }

        public void AddSubject(string name, Faculty faculty, bool isOptional, bool isBUS)
        {
            AddSubject(new Subject(name, faculty, isOptional, isBUS));
        }

        public void AddSubject(Subject subjectNew)
        {
            AddSubjectWithoutWriting(subjectNew);
            var subjectsList = subjects.GetListOfUniversityEntities();
            subjectsList.Sort();
            subjects.SetListOfUniversityEntities(subjectsList);
            WriteData();
        }

        public void AddSubjectWithoutWriting(Subject subject)
        {
            if(!subjects.Contains(subject)) subjects.Add(subject);
        }

        public void EvaluateLecturer(Lecturer lecturer, float lecturerScore, string review)
        {
            UniversityEntitiesList<Lecturer>.GetEntityInstance().EvaluateEntity(lecturer, lecturerScore, review, lecturers);
        }

        public void EvaluateSubject(Subject subject, float subjectScore, string review)
        {
            UniversityEntitiesList<Subject>.GetEntityInstance().EvaluateEntity(subject, subjectScore, review, subjects);
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
            return UniversityEntitiesList<Lecturer>.GetEntityInstance().GetEntitiesByFaculty(faculty, lecturers);
        }

        public List<Subject> GetSubjectsByFaculty(Faculty faculty)
        {
            return UniversityEntitiesList<Subject>.GetEntityInstance().GetEntitiesByFaculty(faculty, subjects);
        }

        public string GetLecturerInfo(Lecturer lecturer, Faculty faculty)
        {
            string information = "";
            List<Lecturer> someLecturers = GetLecturersByFaculty(faculty);
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
            List<Subject> someSubjects = GetSubjectsByFaculty(faculty);
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

        public List<Subject> GetSubjectSearchResults(String enteredWord, Faculty faculty)
        {
            return UniversityEntitiesList<Subject>.GetEntityInstance().GetEntitySearchResults(enteredWord, faculty, subjects);
        }

        public List<Lecturer> GetLecturerSearchResults(String enteredWord, Faculty faculty)
        {
            return UniversityEntitiesList<Lecturer>.GetEntityInstance().GetEntitySearchResults(enteredWord, faculty, lecturers);
        }

    }
}
