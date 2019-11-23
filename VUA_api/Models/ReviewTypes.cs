using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VUA_api
{
    public class LecturerReview : Review
    {
        public LecturerReview(string username, int score, string text) : base(username, score, text)
        { }
    }
    public class SubjectReview : Review
    {
        public SubjectReview(string username, int score, string text) : base(username, score, text)
        { }
    }
}
