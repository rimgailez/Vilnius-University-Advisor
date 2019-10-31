using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilnius_University_Advisor
{
    public class DataNode
    {
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
        public List<Review> reviews;
        public DataNode(string name, Faculty faculty)
        {
            this.name = name;
            this.faculty = faculty;
            this.scoreField = 0;
            this.numberOfReviews = 0;
            this.reviews = new List<Review>();
        }
        public override string ToString()
        {
            return GetInformation();
        }

        public string GetInformation()
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
                        + MainResources.ReviewScore + item.score + "\r\n"
                        + MainResources.ReviewDate + item.date + "\r\n"
                        + MainResources.DataNodeComment + "\r\n" + item.text + "\r\n";
                    number++;
                }
            }
            return information;
        }
    }
}
