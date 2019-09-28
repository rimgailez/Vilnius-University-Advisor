using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilnius_University_Advisor
{
    public class Subject : DataNode
    {
        public bool IsOptional; //Ar pasirenkamasis dalykas
        public bool IsBUS;
        public Subject(string name, Faculty faculty, bool IsOptional, bool IsBUS) : base(name, faculty) {
            this.IsOptional = IsOptional;
            this.IsBUS = IsBUS;
        }
        public override bool Equals(object obj)
        {
            Subject item = obj as Subject;
            if (item == null) return false;
            if (name == item.name && faculty == item.faculty && IsOptional == item.IsOptional && IsBUS == item.IsBUS) return true;
            else return false;
        }
        public override int GetHashCode()
        {
            int hashCode = base.GetHashCode();
            hashCode = hashCode * 7 + IsOptional.GetHashCode();
            hashCode = hashCode * 7 + IsBUS.GetHashCode();
            return hashCode;
        }
    }
}
