using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilnius_University_Advisor
{
    public class DataNode : IEquatable<DataNode>, IComparable<DataNode>
    {
        public string name { get; set; }
        public Faculty faculty { get; set; }
        public float score { get; set; }
        public int numberOfReviews { get; set; }

        public List<string> reviews;
        public DataNode(string name, Faculty faculty)
        {
            this.name = name;
            this.faculty = faculty;
            this.score = 0;
            this.numberOfReviews = 0;
            this.reviews = new List<string>();
        }

        public override bool Equals(object obj)
        {
            DataNode item = obj as DataNode;
            if (item == null) return false;
            if (name.Equals(item.name) && faculty == item.faculty) return true;
            else return false;
        }
        public override int GetHashCode()
        {
            int hashCode = name.GetHashCode();
            hashCode = hashCode * 7 + faculty.GetHashCode();
            return hashCode;
        }

        public bool Equals(DataNode other)
        {
            return other.name.Equals(this.name) && other.faculty==this.faculty;
        }

        public int CompareTo(DataNode other)
        {
            int result = this.name.CompareTo(other.name);
            if (result == 0)
                return this.faculty.CompareTo(other.faculty);
            else return result;
        }
    }
}
