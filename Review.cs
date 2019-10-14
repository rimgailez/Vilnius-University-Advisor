using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilnius_University_Advisor
{
    public struct Review
    {
        public string username;
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
        public string text;
        public DateTime date;
        public Review(string username, int score, string text)
        {
            this.date = DateTime.Today;
            this.username = username;
            this.scoreField = score;
            this.text = text;
        }
    }
}
