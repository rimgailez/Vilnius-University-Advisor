using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilnius_University_Advisor
{
    public class Subject : DataNode, IEquatable<Subject>
    {
        public bool isOptional; //Ar pasirenkamasis dalykas

        public bool isBUS;

        public Subject(string name, Faculty faculty, bool isOptional, bool isBUS) : base(name, faculty) {
            this.isOptional = isOptional;
            this.isBUS = isBUS;
        }

        public override bool Equals(object obj)
        {
            Subject item = obj as Subject;
            if (item == null) return false;
            if (name.Equals(item.name) && faculty == item.faculty && isOptional == item.isOptional && isBUS == item.isBUS) return true;
            else return false;
        }

        public bool Equals(Subject other)
        {
            return name == other.name && faculty == other.faculty && isOptional == other.isOptional && isBUS == other.isBUS;
        }

        public override int GetHashCode()
        {
            int hashCode = base.GetHashCode();
            hashCode = hashCode * 7 + isOptional.GetHashCode();
            hashCode = hashCode * 7 + isBUS.GetHashCode();
            return hashCode;
        }
    }
}
