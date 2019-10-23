using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilnius_University_Advisor
{
    class User
    {
        public string Name { get; set; }
        public Faculty UserFaculty { get; set; }
        public string UserName { get; set; }
        private string password;
        public string StudyProgram { get; set; }
        public string Password { get => password; set => password = value; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
        public User(string name, Faculty faculty, string userName, string password, string eMail, string phoneNumber, string studyProgram)
        {
            this.Name = name;
            this.UserFaculty = faculty;
            this.UserName = userName;
            this.Password = password;
            this.EMail = eMail;
            this.PhoneNumber = phoneNumber;
            this.StudyProgram = studyProgram;
        }
    }
}
