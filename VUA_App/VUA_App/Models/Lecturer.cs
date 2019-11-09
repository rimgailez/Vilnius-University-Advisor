using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VUA_App.Models
{
    class Lecturer : DataNode
    {
        public Lecturer(string name, Faculty faculty) : base(name, faculty) { }
        public override string ToString()
        {
            return MainResources.LecturerName + base.ToString();
        }
    }
}
