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

        public User(string name, Faculty faculty, string userName, string password) : base(name, faculty)
        {
            this.userName = userName;
            this.Password = password;
        }

        public string Password { get => password; set => password = value; }
        /*
        public override bool Equals(object obj) {
            User item = obj as User;
            if (item == null) return false;
            if (userName.Equals(item.userName)) return true;
            else return false;
        }*/

        public bool Equals(User other)
        {
            return userName == other.userName ;
        }
    }
}
