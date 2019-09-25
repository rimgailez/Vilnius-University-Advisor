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
        public override bool Equals(object obj)
        {
            Lecturer item = obj as Lecturer;
            if (item == null) return false;
            if (name == item.name && faculty == item.faculty) return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
