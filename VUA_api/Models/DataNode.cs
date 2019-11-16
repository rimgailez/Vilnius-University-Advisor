using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VUA_api
{
    public class DataNode : IEquatable<DataNode>, IComparable<DataNode>
    {
        public int ID { get; set; }
        public string name { get; set; }
        private Faculty facultyField;
        public Faculty faculty
        {
            get => facultyField;
            set
            {
                if (value == Faculty.None)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    facultyField = value;
                }
            }
        }

        private float scoreField;
        public float score
        {
            get => scoreField;
            set
            {
                if (value < 0 || value > 5) throw new ArgumentOutOfRangeException();
                else scoreField = value;
            }
        }
        public int numberOfReviews { get; set; }
        public DataNode(string name, Faculty faculty)
        {
            this.name = name;
            this.facultyField = faculty;
            this.scoreField = 0;
            this.numberOfReviews = 0;
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
