using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VUA_App.Models
{
    public class Subject : DataNode
    {
        public bool isOptional; //Ar pasirenkamasis dalykas
        public bool isBUS;
        public Subject(string name, Faculty faculty, bool isOptional, bool isBUS) : base(name, faculty) {
            this.isOptional = isOptional;
            this.isBUS = isBUS;
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
