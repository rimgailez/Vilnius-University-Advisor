using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilnius_University_Advisor
{
    class User
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
        public User(string name, Faculty faculty, string userName, string password, string eMail, string phoneNumber, string studyProgram)
        {
            this.name = name;
            this.userFaculty = faculty;
            this.userName = userName;
            this.password = password;
            this.eMail = eMail;
            this.phoneNumber = phoneNumber;
            this.studyProgram = studyProgram;
        }
    }
}
