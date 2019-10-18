using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VUA_api
{
    public class Lecturer : DataNode, IEquatable<Lecturer>
    {
        public Lecturer(string name, Faculty faculty) : base(name, faculty) { }

        public bool Equals(Lecturer other)
        {
            return base.Equals(other);
        }
        public override string ToString()
        {
            return MainResources.LecturerName + base.ToString();
        }
    }
}
