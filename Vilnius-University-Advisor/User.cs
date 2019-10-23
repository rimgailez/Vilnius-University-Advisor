using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilnius_University_Advisor
{
    class User : DataNode
    {
        public string userName;
        private string password;
        public string studyProgram;

        public User(string name, Faculty faculty, string userName, string password, string eMail, string phoneNumber, string studyProgram) : base(name, faculty) {
            this.userName = userName;
            this.Password = password;
            this.EMail = eMail;
            this.PhoneNumber = phoneNumber;
            this.studyProgram = studyProgram;
        }

        public string Password { get => password; set => password = value; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
    }
}
