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

        public User(string name, Faculty faculty, string userName, string password) : base(name, faculty) {
            this.userName = userName;
            this.Password = password;
        }

        public string Password { get => password; set => password = value; }

    }
}
