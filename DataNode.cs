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

        public List<Review> reviews;
        public DataNode(string name, Faculty faculty)
        {
            this.name = name;
            this.faculty = faculty;
            this.scoreField = 0;
            this.numberOfReviews = 0;
            this.reviews = new List<Review>();
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
        public override string ToString()
        {
            string information = name + "\r\n";
            information = information + MainResources.DataNodeEvaluation + Decimal.Round((decimal)score, 2) + MainResources.From5 + "\r\n";
            information = information + MainResources.NumberOfReviews + numberOfReviews + "\r\n";
            if (numberOfReviews > 0)
            {
                int number = 1;
                information = information + MainResources.DataNodeComments + "\r\n";
                foreach (Review item in reviews)
                {
                    information = information + number + ". "
                        + MainResources.ReviewUsername + item.username
                        + MainResources.ReviewDate + item.date.ToShortDateString()
                        + MainResources.ReviewScore + item.score
                        + "\r\n" + item.text + "\r\n";
                    number++;
                }
            }
            return information;
        }
    }
}
