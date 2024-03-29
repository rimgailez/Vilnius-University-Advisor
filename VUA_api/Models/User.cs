﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VUA_api
{
    public class User : IEquatable<User>, IComparable<User>
    {
        public string name { get; set; }
        private Faculty faculty;
        public Faculty userFaculty 
        {
             get => faculty;
             set
              {
                   if (value == Faculty.None)
                   {
                     throw new ArgumentOutOfRangeException();
                   }
                   else
                   {
                     faculty = value;
                   }
              }
        }
        [Key]
        public string userName { get; set; }
        public string password { get; set; }
        public string studyProgram { get; set; }
        public string eMail { get; set; }
        public string phoneNumber { get; set; }
        public int evaluatedLecturers { get; set; }
        public int evaluatedSubjects { get; set; }
        public List<Activity> userHistory { get; set; }
        public User(string name, Faculty userFaculty, string userName, string password, string eMail, string phoneNumber, string studyProgram)
        {
            this.name = name;
            this.faculty = userFaculty;
            this.userName = userName;
            this.password = password;
            this.eMail = eMail;
            this.phoneNumber = phoneNumber;
            this.studyProgram = studyProgram;
            this.userHistory = new List<Activity>();
        }

        public User()
        {
        }

        public bool Equals(User other)
        {
            return userName == other.userName ;
        }

        public int CompareTo(User other)
        {
            int result = this.name.CompareTo(other.name);
            if (result == 0)
                return this.userName.CompareTo(other.userName);
            else return result;
        }
    }
}
