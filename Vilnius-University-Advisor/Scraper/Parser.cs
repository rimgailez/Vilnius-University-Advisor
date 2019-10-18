using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Vilnius_University_Advisor.Scraper
{
    class Parser
    {
        public List<Subject> subjects = new List<Subject>();
        public List<Lecturer> lecturers = new List<Lecturer>();
        List<string> optionalSubjects = new List<string>();
        Faculty faculty;
        StreamWriter streamWriter;
        string vuUrl = "https://tvarkarasciai.vu.lt";

        public Parser(StreamWriter streamWriter, Faculty faculty)
        {
            this.streamWriter = streamWriter;
            this.faculty = faculty;
        }
        public void parseTimetable(string text, string url)
        {
            string[] textLines = text.Split(Environment.NewLine.ToCharArray());
            bool foundCalender = false;
            foreach(string htmlLine in textLines)
            {
                //gets all lecturers and subjects
                if (!foundCalender && Regex.IsMatch(htmlLine, @".*id\s*=\s*""calendar"".*"))
                {
                    string patern = @"class\s*=\s*""fc-list-item-title fc-widget-content"".*?>.*?<\s*br\s*>\s*(.*?)\s*<\s*br\s*>.*?class\s*=\s*""card card-block"".*?>.*?<\s*br\s*>\s*(<\s*br\s*>\s*(.*?)\s*<\s*br\s*>|.*?<\s*a)";
                    MatchCollection matchCollection = Regex.Matches(htmlLine, patern);
                    foreach(Match match in matchCollection)
                    {
                        GroupCollection groupCollection = match.Groups;
                        if (!groupCollection[1].Value.Contains("BUS")) AddSubject(groupCollection[1].Value);
                        if(!groupCollection[3].Value.Equals("") && !Regex.IsMatch(groupCollection[3].Value, @".*\d.*")) AddLecturer(groupCollection[3].Value);
                    }
                    foundCalender = true;
                }
                //finds out which subjects are optional
                else
                {
                    Match match = Regex.Match(htmlLine, @".*?class\s*=\s*""checks"".*?type\s*=\s*""checkbox"".*?label\s*for\s*=.*?>\s*(.*?)\s*<\s*/\s*label\s*>");
                    if(foundCalender && match.Success)
                    {
                        GroupCollection groupCollection = match.Groups;
                        optionalSubjects.Add(groupCollection[1].Value);
                    }
                }
            }
            changeToOptional();
        }
        private void changeToOptional()
        {
            foreach(string optionalSubject in optionalSubjects)
            {
                foreach(Subject subject in subjects)
                {
                    if (optionalSubject.Equals(subject.name))
                    {
                        subject.isOptional = true;
                        break;
                    }
                }
            }
        }

        public List<String> parseFaculty(string text, string facultyUrl)
        {
            List<string> urls = new List<string>();
            string[] textLines = text.Split(Environment.NewLine.ToCharArray());
            string pattern = @"<a\s*href\s*=\s*""" + facultyUrl + @"groups/(.+)""\s*>";
            string busPattern = @".*(bendrosios-universitetines-studijos|bendros-universitetines-studijos).*";
            for (int j = 0; j < textLines.Length; j++)
            {
                Match result = Regex.Match(textLines[j], pattern);
                if (result.Success)
                {
                    GroupCollection groupCollection = result.Groups;
                    if (!Regex.IsMatch(groupCollection[1].Value, busPattern))
                    {
                        urls.Add(vuUrl + facultyUrl + "groups/" + groupCollection[1].Value);
                    }
                    
                }
            }
            return urls;
        }

        private void AddSubject(string name)
        {
            int commaIndex = name.IndexOf(',');
            if (commaIndex != -1)
            {
                name = name.Substring(0, commaIndex);
            }
            foreach(Subject subject in subjects)
            {
                if (subject.name.Equals(name)) return;
            }
            Subject subjectTemp = new Subject(name, faculty, false, false);
            subjects.Add(subjectTemp);
        }
        private void AddLecturer(string name)
        {
            int commaIndex = name.IndexOf(',');
            if (commaIndex != -1)
            {
                name = name.Substring(0, commaIndex);
            }
            foreach (Subject subject in subjects)
            {
                if (subject.name.Equals(name)) return;
            }
            Lecturer lecturer = new Lecturer(name, faculty);
            lecturers.Add(lecturer);
        }
    }
}
