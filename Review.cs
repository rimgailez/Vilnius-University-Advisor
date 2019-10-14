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
        public int score;
        public string text;
        public DateTime date;
        public Review(string username, int score, string text)
        {
            this.date = DateTime.Today;
            this.username = username;
            this.score = score;
            this.text = text;
        }
    }
}
