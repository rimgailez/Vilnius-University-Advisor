using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilnius_University_Advisor
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
