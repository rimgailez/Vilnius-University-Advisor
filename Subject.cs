using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilnius_University_Advisor
{
    public class Subject : DataNode
    {
        public Subject(string name, Faculty faculty) : base(name, faculty) { }
    }
}
