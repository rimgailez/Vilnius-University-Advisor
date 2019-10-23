using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VUA_api
{
    public class User : DataNode, IEquatable<User>
    {
        public string userName;
        private string password;
        public string studyProgram;

        public User(string name, Faculty faculty, string userName, string password, string eMail, string phoneNumber, string studyProgram) : base(name, faculty)
        {
            this.userName = userName;
            this.Password = password;
            this.EMail = eMail;
            this.PhoneNumber = phoneNumber;
            this.studyProgram = studyProgram;
        }

        public string Password { get => password; set => password = value; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }

        public bool Equals(User other)
        {
            return userName == other.userName ;
        }
    }
}
