using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

        public Parser(StreamWriter streamWriter, Faculty faculty)
        {
            this.streamWriter = streamWriter;
            this.faculty = faculty;
        }
        public void parseTimetable(string text, string url)
        {
            string[] textLines = text.Split(Environment.NewLine.ToCharArray());
            //check for empty timetable
            int i;
            if (textLines[192].Equals(""))
            {
                if (textLines[198].Equals(""))
                {
                    streamWriter.WriteLine("Failed to parse " + url);
                    streamWriter.Flush();
                    return;
                }
                else i = 202;
            }
            else i = 196;
            //get all lecturers and subjects
            while (i < textLines.Length)
            {
                if (textLines[i].Equals("")) break;
                while (!textLines[i + 2].Equals("")) i += 2;
                if(!textLines[i].Contains("BUS")) AddSubject(textLines[i]);

                i += 10;
                if( !textLines[i].Any(c => Char.IsDigit(c)) && !textLines[i].Contains("Dėstytojas") ) AddLecturer(textLines[i]);

                for (; i < textLines.Length; i += 2) if (textLines[i].Equals("")) break;
                i += 6;
            }
            //get which subjects are optional
            i += 16;
            while (i < textLines.Length)
            {
                if (textLines[i].Equals("")) break;
                optionalSubjects.Add(textLines[i].Substring(1));
                i += 2;
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
                        subject.IsOptional = true;
                        break;
                    }
                }
            }
        }

        public List<String> parseFaculty(string text)
        {
            List<string> urls = new List<string>();
            string[] textLines = text.Split(Environment.NewLine.ToCharArray());
            for (int j = 0; j < textLines.Length; j++)
            {
                if (textLines[j].Contains("<div class=\"col-sm-12\">"))
                {
                    j += 7;
                    int index = textLines[j].IndexOf('"');
                    textLines[j] = textLines[j].Substring(index+1);
                    index = textLines[j].IndexOf('"');
                    textLines[j] = textLines[j].Substring(0, index);
                    if (textLines[j].Contains("bendrosios-universitetines-studijos") || textLines[j].Contains("bendros-universitetines-studijos")) continue;
                    urls.Add("https://tvarkarasciai.vu.lt" + textLines[j]);
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
