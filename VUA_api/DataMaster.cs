using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VUA_api
{
    class DataMaster
    {
        private static readonly DataMaster instance  = new DataMaster();

        public UniversityEntitiesList<Lecturer> lecturers = new UniversityEntitiesList<Lecturer>();
        public UniversityEntitiesList<Subject> subjects = new UniversityEntitiesList<Subject>();
        public List<User> users = new List<User>();
        public List<StudyProgramme> studyProgrammes = new List<StudyProgramme>();
        public User currentUser { get; set; }

        public readonly JsonReaderWriter jsonReaderWriter = new JsonReaderWriter();

        private DataMaster() 
        {
            ReadData();
        }
        public static DataMaster GetInstance()
        {
            return instance;
        }
        
        public void ReadData() 
        {
            lecturers.SetListOfUniversityEntities(jsonReaderWriter.ReadLecturers());
            subjects.SetListOfUniversityEntities(jsonReaderWriter.ReadSubjects());
            users = jsonReaderWriter.ReadUsers();
            studyProgrammes = jsonReaderWriter.ReadStudyProgrammes();
        } 

        public void WriteData()
        {
            WriteLecturers();
            WriteSubjects();
        }
        public void WriteLecturers()
        {
            lecturers.Sort();
            jsonReaderWriter.WriteLecturers(lecturers.GetListOfUniversityEntities());
        }

        public void WriteSubjects()
        {
            subjects.Sort();
            jsonReaderWriter.WriteSubjects(subjects.GetListOfUniversityEntities());
        }

        public void WriteUsers()
        {
            users.Sort();
            jsonReaderWriter.WriteUsers(users);
        }

        public void WriteStudyProgrammes()
        {
            studyProgrammes.Sort();
            jsonReaderWriter.WriteStudyProgrammes(studyProgrammes);
        }

        public void AddLecturer(string name, Faculty faculty)
        {
            AddLecturer(new Lecturer(name, faculty));
        }

        public void AddLecturer(Lecturer lecturerNew)
        {
            AddLecturerWithoutWriting(lecturerNew);
            WriteLecturers();
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
            WriteSubjects();
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
            WriteUsers();
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
            WriteStudyProgrammes();
        }

        public void AddStudyProgrammeWithoutWriting(StudyProgramme studyProgramme)
        {
            if (!studyProgrammes.Contains(studyProgramme)) studyProgrammes.Add(studyProgramme);
        }
        public void EvaluateLecturer(Lecturer lecturer, float lecturerScore, string text, string username)
        {
            lecturers.EvaluateEntity(lecturer, lecturerScore, new Review(username, (int)lecturerScore, text));
            currentUser.evaluatedLecturers++;
            WriteUsers();
        }

        public void EvaluateSubject(Subject subject, float subjectScore, string text, string username)
        {
            subjects.EvaluateEntity(subject, subjectScore, new Review(username, (int)subjectScore, text));
            currentUser.evaluatedSubjects++;
            WriteUsers();
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
            return users.Exists(us => us.userName.Equals(username));
        }

        public Boolean CheckIfCorrectPassword(string userName, string password)
        {
            return users.Find(us => us.userName.Equals(userName)).password.Equals(password);
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
            WriteUsers();
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

        public void CountEvaluatedSubjAndLect()
        {
            foreach (User user in users)
            {
                user.evaluatedLecturers = 0;
                user.evaluatedSubjects = 0;
                foreach (Lecturer lect in lecturers)
                {
                    user.evaluatedLecturers += lect.reviews.Where(rev => rev.username.Equals(user.userName)).Count();
                }
                foreach (Subject subj in subjects)
                {
                    user.evaluatedSubjects += subj.reviews.Where(rev => rev.username.Equals(user.userName)).Count();
                }
            }
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

    }
}
