using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VUA_api
{
    public class Review
    {
        public int ID { get; set; }
        public string username { get; set; }
        private int scoreField;
        public int score
        {
            get => scoreField;
            set
            {
                if (value < 0 || value > 5) throw new ArgumentOutOfRangeException();
                else scoreField = value;
            }
        }
        public string text { get; set; }
        public string date { get; set; }
        public Review(string username, int score, string text)
        {
            this.username = username;
            this.scoreField = score;
            this.text = text;
            this.date = DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
        }
    }
}
