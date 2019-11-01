using System;
using System.Collections.Generic;
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

        public string userName { get; set; }
        public string password { get; set; }
        public string studyProgram { get; set; }
        public string eMail { get; set; }
        public string phoneNumber { get; set; }

        public List<Activity> userHistory { get; set; }
        public User(string name, Faculty faculty, string userName, string password, string eMail, string phoneNumber, string studyProgram)
        {
            this.name = name;
            this.faculty = faculty;
            this.userName = userName;
            this.password = password;
            this.eMail = eMail;
            this.phoneNumber = phoneNumber;
            this.studyProgram = studyProgram;
            this.userHistory = new List<Activity>();
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
