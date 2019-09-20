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
    }
}
