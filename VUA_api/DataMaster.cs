﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VUA_api.Context;
using VUA_api.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace VUA_api
{
    public class DataMaster
    {
        public DbSet<Lecturer> lecturers;
        public DbSet<Subject> subjects;
        public DbSet<User> users;
        public DbSet<StudyProgramme> studyProgrammes;
        public readonly ApiContext db;

        public static string connectionString;

        public static User currentUser { get; set; }
        public DataMaster(ApiContext dbtemp, IConfiguration config) 
        {
            connectionString = config.GetValue<string>("ConnectionStrings:ApiContext");
            db = dbtemp;
            lecturers = db.lecturers;
            subjects = db.subjects;
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
            if (!lecturers.Contains(lecturer)) lecturers.Add(lecturer);
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
            if (!subjects.Contains(subject)) subjects.Add(subject);
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
            Func<Lecturer, float, float> calculateScore = delegate (Lecturer lecturerNew, float newScore)
            {
                return ((lecturerNew.score * lecturerNew.numberOfReviews) + newScore) / (++lecturer.numberOfReviews);
            };
            lecturer.score = calculateScore(lecturer, lecturerScore);
            lecturer.reviews.Add(new LecturerReview(username, (int)lecturerScore, text));
            foreach (User user in users)
            {
                if (user.Equals(currentUser))
                {
                    user.evaluatedLecturers++;
                    break;
                }
            }
            currentUser.evaluatedLecturers++;
            WriteData();
        }

        public void EvaluateSubject(Subject subject, float subjectScore, string text, string username)
        {
            Func<Subject, float, float> calculateScore = delegate (Subject subjectNew, float newScore)
            {
                return ((subjectNew.score * subjectNew.numberOfReviews) + newScore) / (++subject.numberOfReviews);
            };
            subject.score = calculateScore(subject, subjectScore);
            subject.reviews.Add(new SubjectReview(username, (int)subjectScore, text));
            foreach (User user in users)
            {
                if (user.Equals(currentUser))
                {
                    user.evaluatedSubjects++;
                    break;
                }
            }
            currentUser.evaluatedSubjects++;
            WriteData();
        }

        public List<Subject> GetBUSSubjects(Faculty faculty = Faculty.None)
        {
            List<Subject> BUSSubjects = new List<Subject>();
            if (faculty == Faculty.None)
            {
                BUSSubjects = (from subject in subjects.Include(subj => subj.reviews).ToList()
                               where subject.isBUS == true
                               select subject).ToList();
            }
            else
            {
                BUSSubjects = (from subject in subjects.Include(subj => subj.reviews).ToList()
                               where subject.isBUS == true && subject.faculty == faculty
                               select subject).ToList();
            }
            return BUSSubjects;
        }

        public List<Subject> GetSubjectsByTypeAndFaculty(bool isOptional, Faculty faculty)
        {
            List<Subject> someSubjects = (from subject in subjects.Include(subj => subj.reviews).ToList()
                                          where subject.isOptional == isOptional &&
                                                subject.faculty == faculty
                                          select subject).ToList();
            return someSubjects;
        }

        public List<Lecturer> GetLecturersByFaculty(Faculty faculty)
        {
            return lecturers.Where(lect => lect.faculty == faculty).Include(lecturer => lecturer.reviews).ToList();
        }

        public List<Subject> GetSubjectsByFaculty(Faculty faculty)
        {
            return subjects.Where(subj => subj.faculty == faculty).Include(subject => subject.reviews).ToList();
        }

        public List<Subject> GetSubjectSearchResults(String enteredWord, Faculty faculty)
        {
            List<Subject> searchResult;
            if (faculty == Faculty.None)
            {
                searchResult = (from subj in subjects.Include(subject => subject.reviews).ToList()
                                where subj.name.ToLower().Contains(enteredWord.ToLower())
                                select subj).ToList();
            }
            else
            {
                searchResult = (from subj in subjects.Include(subject => subject.reviews).ToList()
                                where subj.name.ToLower().Contains(enteredWord.ToLower()) && subj.faculty == faculty
                                select subj).ToList();
            }
            return searchResult;
        }

        public List<Lecturer> GetLecturerSearchResults(String enteredWord, Faculty faculty)
        {
            List<Lecturer> searchResult;
            if (faculty == Faculty.None)
            {
                searchResult = (from lect in lecturers.Include(lecturer => lecturer.reviews).ToList()
                                where lect.name.ToLower().Contains(enteredWord.ToLower())
                                select lect).ToList();
            }
            else
            {
                searchResult = (from lect in lecturers.Include(lecturer => lecturer.reviews).ToList()
                                where lect.name.ToLower().Contains(enteredWord.ToLower()) && lect.faculty == faculty
                                select lect).ToList();
            }
            return searchResult;
        }

        public List<Subject> GetTop10Subjects()
        {
            return subjects.Include(subject => subject.reviews).OrderByDescending(subj => subj.score).Take(10).ToList();
        }

        public List<Lecturer> GetTop10Lecturers()
        {
            return lecturers.Include(lecturer => lecturer.reviews).OrderByDescending(lect => lect.score).Take(10).ToList();
        }

        public List<Subject> GetTop5BUSSubjects()
        {
            return subjects.Include(lecturer => lecturer.reviews).Where(subject => subject.isBUS).OrderByDescending(subject => subject.score).Take(5).ToList();
        }

        public Boolean CheckIfUserNameExists(string username)
        {
            return users.Any(us => us.userName.Equals(username));
        }

        public Boolean CheckIfCorrectPassword(string userName, string password)
        {
            return users.ToList().Find(us => us.userName.Equals(userName)).password.Equals(password);
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
            foreach (User user in users.Include(user => user.userHistory))
            {
                if (user.Equals(currentUser))
                {
                    currentUser = user;
                    break;
                }
            }
            return currentUser.userHistory.OrderBy(activity => activity.date).ToList();
        }

        public List<StudyProgramme> GetStudyProgrammesByFaculty(Faculty faculty)
        {
            return studyProgrammes.Where(studyProgramme => studyProgramme.faculty == faculty).ToList();
        }

        public List<User> GetTop3ActiveUsers()
        {
            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT userName, evaluatedLecturers, evaluatedSubjects FROM [User]", connection);
                SqlCommand command = new SqlCommand("SELECT userName, evaluatedLecturers, evaluatedSubjects FROM [User] " +
                  "WHERE userName = @userName" +
                  "ORDER BY evaluatedLecturers + evaluatedSubjects DESC" +
                  "FETCH FIRST 3 ROWS ONLY", connection);

                command.Parameters.Add("@userName", SqlDbType.NVarChar, 20);

                SqlParameter parameter = dataAdapter.SelectCommand.Parameters.Add("@userName", SqlDbType.NVarChar);
                parameter.SourceColumn = "userName";
                parameter.SourceVersion = DataRowVersion.Original;

                dataAdapter.SelectCommand = command;

                DataTable userTable = new DataTable();
                dataAdapter.Fill(userTable);
                List<User> topUsers = new List<User>();

                topUsers = (from DataRow dr in userTable.Rows
                               select new User()
                               {
                                   name = dr["name"].ToString(),
                                   userFaculty = (Faculty)dr["userFaculty"],
                                   userName = dr["username"].ToString(),
                                   password = dr["password"].ToString(),
                                   eMail = dr["eMail"].ToString(),
                                   phoneNumber = dr["phonrNumber"].ToString(),
                                   studyProgram = dr["studyProgram"].ToString()
                               }).ToList();
                return topUsers;
            }
                //return users.Include(user => user.userHistory).OrderByDescending(user => user.evaluatedLecturers + user.evaluatedSubjects).ToList().GetRange(0, 3);
        }

        public List<Subject> GetSubjectsByType(bool isOptional, bool isBUS)
        {
            List<Subject> someSubjects = (from subject in subjects.Include(subj => subj.reviews).ToList()
                                          where subject.isOptional == isOptional &&
                                                subject.isBUS == isBUS
                                          select subject).ToList();
            return someSubjects;
        }
        public List<Subject> GetSubjectSearchResultsByType(string searchTerm, Faculty faculty, bool isOptional, bool isBUS)
        {
            List<Subject> searchResult;
            if (faculty == Faculty.None)
            {
                searchResult = (from subj in subjects.Include(subject => subject.reviews).ToList()
                                where subj.name.ToLower().Contains(searchTerm.ToLower())
                                select subj).ToList();
            }
            else
            {
                searchResult = (from subj in subjects.Include(subject => subject.reviews).ToList()
                                where subj.name.ToLower().Contains(searchTerm.ToLower()) && subj.faculty == faculty
                                select subj).ToList();
            }
            List<Subject> someSubjects = (from subject in searchResult
                                          where subject.isOptional == isOptional &&
                                                subject.isBUS == isBUS
                                          select subject).ToList();
            return someSubjects;
        }

        public void UpdateInfo(User currentUser, string name, Faculty userFaculty, string studyProgram, string eMail, string phoneNumber)
        {
            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                //connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(
                  "SELECT userName, name, userFaculty, studyProgram, eMail, phoneNumber FROM [User]",
                  connection);

                dataAdapter.UpdateCommand = new SqlCommand(
                   "UPDATE [User] SET name = @name, userFaculty = @userFaculty, studyProgram = @studyProgram, eMail = @eMail, phoneNumber = @phoneNumber " +
                   "WHERE userName = @userName", connection);

                dataAdapter.UpdateCommand.Parameters.Add("@name", SqlDbType.NVarChar, 20, "name");
                dataAdapter.UpdateCommand.Parameters.Add("@userFaculty", SqlDbType.Int, 8, "userFaculty");
                dataAdapter.UpdateCommand.Parameters.Add("@studyProgram", SqlDbType.NVarChar, 30, "studyProgram");
                dataAdapter.UpdateCommand.Parameters.Add("@eMail", SqlDbType.NVarChar, 25, "eMail");
                dataAdapter.UpdateCommand.Parameters.Add("@phoneNumber", SqlDbType.NVarChar, 12, "phoneNumber");

                SqlParameter parameter = dataAdapter.UpdateCommand.Parameters.Add("@userName", SqlDbType.NVarChar);
                parameter.SourceColumn = "userName";
                parameter.SourceVersion = DataRowVersion.Original;

                DataTable userTable = new DataTable();
                dataAdapter.Fill(userTable);
                DataRow userRow = userTable.Rows[users.ToList().IndexOf(currentUser)];
                userRow["name"] = name;
                userRow["userFaculty"] = (int)userFaculty;
                userRow["studyProgram"] = studyProgram;
                userRow["eMail"] = eMail;
                userRow["phoneNumber"] = phoneNumber;

                dataAdapter.Update(userTable);

                connection.Close();
            }
        }

        public void UpdatePassword(User currentUser, string newPassword)
        {
            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(
                  "SELECT userName, password FROM [User]", connection);

                dataAdapter.UpdateCommand = new SqlCommand(
                   "UPDATE [User] SET password = @password " +
                   "WHERE userName = @userName", connection);

                dataAdapter.UpdateCommand.Parameters.Add("@password", SqlDbType.NVarChar, 20, "password");

                SqlParameter parameter = dataAdapter.UpdateCommand.Parameters.Add("@userName", SqlDbType.NVarChar);
                parameter.SourceColumn = "userName";
                parameter.SourceVersion = DataRowVersion.Original;

                DataTable userTable = new DataTable();
                dataAdapter.Fill(userTable);

                DataRow userRow = userTable.Rows[users.ToList().IndexOf(currentUser)];
                userRow["password"] = newPassword;

                dataAdapter.Update(userTable);

                connection.Close();
            }
        }

        public void DeleteUser(User currentUser)
        {
            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM [User]", connection);

                SqlCommand command = new SqlCommand(
                 "DELETE FROM [User] WHERE userName = @userName", connection);

                SqlParameter parameter = command.Parameters.Add(
                    "@userName", SqlDbType.NVarChar, 20, "userName");
                parameter.SourceVersion = DataRowVersion.Original;

                dataAdapter.DeleteCommand = command;

                DataTable userTable = new DataTable();
                dataAdapter.Fill(userTable);

                DataRow userRow = userTable.Rows[users.ToList().IndexOf(currentUser)];

                userRow.Delete();
                dataAdapter.Update(userTable);

                connection.Close();
            }
        }
    }
}
