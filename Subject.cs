using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilnius_University_Advisor
{
    class Subject
    {
        public string name { get; set; }
        public float score { get; set; }
        public int numberOfReviews { get; set; }
        public List<string> reviews;
        public Faculty faculty { get; set; }

        public Subject(string name, Faculty faculty)
        {
            this.name = name;
            this.faculty = faculty;
            this.score = 0;
            this.numberOfReviews = 0;
            this.reviews = new List<string>();
        }
    }
}
