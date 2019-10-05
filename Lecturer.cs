using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilnius_University_Advisor
{
    class Lecturer : DataNode, IEquatable<Lecturer>
    {
        public Lecturer(string name, Faculty faculty) : base(name, faculty) { }
        public override bool Equals(object obj)
        {
            Lecturer item = obj as Lecturer;
            if (item == null) return false;
            if (name.Equals(item.name) && faculty == item.faculty) return true;
            else return false;
        }

        public bool Equals(Lecturer other)
        {
            return base.Equals(this);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
