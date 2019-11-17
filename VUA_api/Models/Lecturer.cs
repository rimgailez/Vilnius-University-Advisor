using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VUA_api.Models;

namespace VUA_api
{
    public class Lecturer : DataNode, IEquatable<Lecturer>
    {
        public List<LecturerReview> reviews { get; set; }
        public Lecturer(string name, Faculty faculty) : base(name, faculty) 
        {
            this.reviews = new List<LecturerReview>();
        }

        public bool Equals(Lecturer other)
        {
            return base.Equals(other);
        }
    }
}
