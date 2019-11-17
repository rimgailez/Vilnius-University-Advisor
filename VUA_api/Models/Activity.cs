using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VUA_api
{
    public class Activity
    {
        public int ID { get; set; }
        public string activityComment { get; set; }
        public string date { get; set; }

        public Activity(string activityComment)
        {
            this.activityComment = activityComment;
            this.date = DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
        }
    }
}
