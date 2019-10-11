using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Vilnius_University_Advisor.Scraper
{
    public class ScraperMain
    {
        string vuUrl = "https://tvarkarasciai.vu.lt";
        string[] mainUrls = new string[]
        {
            "/chgf/",
            "/ef/",
            "/flf/",
            "/fsf/",
            "/ff/",
            "/600000/",
            "/kf/",
            "/mif/",
            "/vm/"
        };
        StreamWriter streamWriter;
        RegForm regForm;

        public ScraperMain(string path, RegForm regForm)
        {
            streamWriter = new StreamWriter(path + Path.DirectorySeparatorChar + "Scraper" + Path.DirectorySeparatorChar + "log.txt");
            this.regForm = regForm;
        }
        [STAThread]     
        public void StartScrap()
        {
            foreach (string url in mainUrls)
            {
                Fetcher fetcher = new Fetcher();
                Parser parser = new Parser(streamWriter, Faculty.None);
                string mainHtml = fetcher.GetFacultyHtml(vuUrl + url);
                List<String> subUrls = parser.parseFaculty(mainHtml, url);
                streamWriter.WriteLine("Parsed " + subUrls.Count + " URLs from " + url);
                streamWriter.Flush();
                regForm.updateScraperTextbox("Parsed " + subUrls.Count + " URLs from " + url);
                foreach(string subUrl in subUrls)
                {
                    regForm.updateScraperTextbox("Parsing " + subUrl);
                    Parser parserSub = new Parser(streamWriter, getFaculty(url));
                    string subText = fetcher.GetTimetableText(subUrl);
                    parserSub.parseTimetable(subText, subUrl);

                    List<Lecturer> lecturers = parserSub.lecturers;
                    List<Subject> subjects = parserSub.subjects;

                    streamWriter.WriteLine("Parsed " + lecturers.Count + " lecturers and " + subjects.Count + " subjects from " + subUrl);
                    streamWriter.Flush();
                    regForm.updateScraperTextbox("Parsed " + lecturers.Count + " lecturers and " + subjects.Count + " subjects from " + subUrl);

                    AddLecturers(lecturers);
                    AddSubjects(subjects);
                }
                DataMaster.GetInstance().WriteData();
            }
            regForm.updateScraperTextbox("Scraper is done.");
            streamWriter.Dispose();
        }

        private void AddSubjects(List<Subject> subjects)
        {
            foreach(Subject subject in subjects)
            {
                UniversityEntity<Subject>.GetEntityInstance().AddEntityWithoutWriting(subject, ref subjects);
            }
        }

        private void AddLecturers(List<Lecturer> lecturers)
        {
            foreach(Lecturer lecturer in lecturers)
            {
                UniversityEntity<Lecturer>.GetEntityInstance().AddEntityWithoutWriting(lecturer, ref lecturers);
            }
        }

        private Faculty getFaculty(string url)
        {
            if (url.Equals(mainUrls[0])) return Faculty.Chemistry_and_Geosciences;
            else if (url.Equals(mainUrls[1])) return Faculty.Economics_and_Business_Administration;
            else if (url.Equals(mainUrls[2])) return Faculty.Philology;
            else if (url.Equals(mainUrls[3])) return Faculty.Philosophy;
            else if (url.Equals(mainUrls[4])) return Faculty.Physics;
            else if (url.Equals(mainUrls[5])) return Faculty.Life_Sciences;
            else if (url.Equals(mainUrls[6])) return Faculty.Communication;
            else if (url.Equals(mainUrls[7])) return Faculty.Mathematics_and_Informatics;
            else if (url.Equals(mainUrls[8])) return Faculty.Business;
            else return Faculty.None;
        }
    }

}
