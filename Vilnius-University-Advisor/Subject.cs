using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilnius_University_Advisor
{
    public class Subject : DataNode, IEquatable<Subject>, IComparable<Subject>
    {
        public bool isOptional; //Ar pasirenkamasis dalykas

        public bool isBUS;

        public Subject(string name, Faculty faculty, bool isOptional, bool isBUS) : base(name, faculty) {
            this.isOptional = isOptional;
            this.isBUS = isBUS;
        }

        public int CompareTo(Subject other)
        {
            int result = base.CompareTo(other);
            if (result == 0 && !this.Equals(other))
            {
                if (!this.isOptional && other.isOptional) return 1;
                else if (!this.isBUS && other.isBUS) return 1;
                else return -1;
            }
            else return result;
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

        public override string ToString()
        {
            string information;
            if (isOptional) information = MainResources.Optional + "\r\n";
            else information = MainResources.Mandatory + "\r\n";

            if (isBUS) information = information + MainResources.BUS + "\r\n";
            information = information + MainResources.SubjectName + base.ToString();
            return information;
        }
    }
}
