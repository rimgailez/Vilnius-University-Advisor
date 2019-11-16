using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VUA_api.Context;

namespace VUA_api
{
    public class DataMaster
    {
        public UniversityEntitiesList<Lecturer> lecturers;
        public UniversityEntitiesList<Subject> subjects;
        public DbSet<User> users;
        public DbSet<StudyProgramme> studyProgrammes;
        public readonly ApiContext db;

        public static User currentUser { get; set; }
        public DataMaster(ApiContext dbtemp) 
        {
            db = dbtemp;
            lecturers = new UniversityEntitiesList<Lecturer>(db.lecturers);
            subjects = new UniversityEntitiesList<Subject>(db.subjects);
            users = db.users;
            studyProgrammes = db.studyProgrammes;
        }
        public void WriteData()
        {
            db.SaveChanges();
        }

        public void AddLecturer(string name, Faculty faculty)
        {
            AddLecturer(new Lecturer(name, faculty));
        }

        public void AddLecturer(Lecturer lecturerNew)
        {
            AddLecturerWithoutWriting(lecturerNew);
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
            WriteData();
        }

        public void AddSubjectWithoutWriting(Subject subject)
        {
            subjects.AddEntityWithoutWriting(subject);
        }

        public void AddUser(string name, Faculty faculty, string userName, string password, string eMail, string phoneNumber, string studyProgram)
        {
            AddUser(new User(name, faculty, userName, password, eMail, phoneNumber, studyProgram));
        }

        public void AddUser(User userNew)
        {
            AddUserWithoutWriting(userNew);
            WriteData();
        }
        public void AddUserWithoutWriting(User user)
        {
            if (!users.Contains(user)) users.Add(user);
        }

        public void AddStudyProgramme(string name, Faculty faculty)
        {
            AddStudyProgramme(new StudyProgramme(name, faculty));
        }

        public void AddStudyProgramme(StudyProgramme studyProgrammeNew)
        {
            AddStudyProgrammeWithoutWriting(studyProgrammeNew);
            WriteData();
        }

        public void AddStudyProgrammeWithoutWriting(StudyProgramme studyProgramme)
        {
            if (!studyProgrammes.Contains(studyProgramme)) studyProgrammes.Add(studyProgramme);
        }
        public void EvaluateLecturer(Lecturer lecturer, float lecturerScore, string text, string username)
        {
            lecturers.EvaluateEntity(lecturer, lecturerScore, new Review(username, (int)lecturerScore, text));
            currentUser.evaluatedLecturers++;
            WriteData();
        }

        public void EvaluateSubject(Subject subject, float subjectScore, string text, string username)
        {
            subjects.EvaluateEntity(subject, subjectScore, new Review(username, (int)subjectScore, text));
            currentUser.evaluatedSubjects++;
            WriteData();
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

        public List<Subject> GetTop10Subjects()
        {
            return subjects.GetTopEntities().GetRange(0, 10);
        }

        public List<Lecturer> GetTop10Lecturers()
        {
            return lecturers.GetTopEntities().GetRange(0, 10);
        }

        public List<Subject> GetTop5BUSSubjects()
        {
            return subjects.Where(subject => subject.isBUS).OrderByDescending(subject => subject.score).ToList().GetRange(0, 5);
        }

        public Boolean CheckIfUserNameExists(string username)
        {
            //return users.Exists(us => us.userName.Equals(username));
            return true;
        }

        public Boolean CheckIfCorrectPassword(string userName, string password)
        {
            //return users.Find(us => us.userName.Equals(userName)).password.Equals(password);
            return true;
        }

        public User GetCurrentUser()
        {
            return currentUser;
        }

        public void SetCurrentUser(User user)
        {
            currentUser = user;
        }

        public void AddToUserHistory(string activity)
        {
            foreach (User user in users)
            {
                if (user.Equals(currentUser))
                {
                    user.userHistory.Add(new Activity(activity));
                    currentUser = user;
                    break;
                }
            }
            WriteData();
        }

        public List<Activity> GetUserActivityHistory()
        {
            foreach (User user in users)
            {
                if (user.Equals(currentUser))
                {
                    currentUser = user;
                    break;
                }
            }
            return currentUser.userHistory;
        }

        public List<StudyProgramme> GetStudyProgrammesByFaculty(Faculty faculty)
        {
            return studyProgrammes.Where(studyProgramme => studyProgramme.faculty == faculty).ToList();
        }

        public List<User> GetTop5ActiveLecturersEvaluators()
        {
            return users.OrderByDescending(user => user.evaluatedLecturers).ToList().GetRange(0, 5);
        }

        public List<User> GetTop5ActiveSubjectsEvaluators()
        {
            return users.OrderByDescending(user => user.evaluatedSubjects).ToList().GetRange(0, 5);
        }

        public List<User> GetTop3ActiveUsers()
        {
            return users.OrderByDescending(user => user.evaluatedLecturers + user.evaluatedSubjects).ToList().GetRange(0, 3);
        }

        public List<Subject> GetSubjectsByType(bool isOptional, bool isBUS)
        {
            List<Subject> someSubjects = (from subject in subjects
                                          where subject.isOptional == isOptional &&
                                                subject.isBUS == isBUS
                                          select subject).ToList();
            return someSubjects;
        }
        public List<Subject> GetSubjectSearchResultsByType(string searchTerm, Faculty faculty, bool isOptional, bool isBUS)
        {
            List<Subject> searchResults = subjects.GetEntitySearchResults(searchTerm, faculty);
            List<Subject> someSubjects = (from subject in searchResults
                                          where subject.isOptional == isOptional &&
                                                subject.isBUS == isBUS
                                          select subject).ToList();
            return someSubjects;
        }


    }
}
