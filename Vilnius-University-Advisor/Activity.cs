using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vilnius_University_Advisor
{
    public class Activity
    {
        public string activityComment { get; set; }
        public string date { get; set; }

        public Activity(string activityComment)
        {
            this.activityComment = activityComment;
            this.date = DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
        }
        
        public override string ToString()
        {
            return this.date + " " + this.activityComment;
        }
    }
}
