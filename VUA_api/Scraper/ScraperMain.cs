using CefSharp;
using CefSharp.OffScreen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace VUA_api.Scraper
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
        private static object locker = new Object();

        public ScraperMain(string path)
        {
            streamWriter = new StreamWriter(path + Path.DirectorySeparatorChar + "Scraper" + Path.DirectorySeparatorChar + "log.txt");
        }
        public void StartScrap()
        {
            CefSettings settings = new CefSettings();
            settings.LogSeverity = LogSeverity.Verbose;
            settings.CefCommandLineArgs.Add("no-proxy-server", "1");
            if (!Cef.IsInitialized)
            {
                if (!Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null))
                {
                    throw new Exception("Unable to Initialize Cef");
                }
            }
            List<Thread> threads = new List<Thread>();
            Parser parser = new Parser(Faculty.None);
            foreach (string url in mainUrls)
            {
                Fetcher fetcher = new Fetcher();
                var htmlTask = fetcher.GetFacultyHtml(vuUrl + url);
                string mainHtml = htmlTask.Result;

                List<String> subUrls = parser.parseFaculty(mainHtml, url);
                streamWriter.WriteLine("Parsed " + subUrls.Count + " URLs from " + url);
                streamWriter.Flush();

                Thread thread = new Thread(()=>ScrapTimetables(url, subUrls, fetcher));
                threads.Add(thread);
                thread.Start();
            }
            foreach (Thread thread in threads) thread.Join();
            //regForm.updateScraperTextbox("Scraper is done.");
            DataMaster.GetInstance().WriteData();
            streamWriter.Dispose();
        }
        private void ScrapTimetables(string url, List<string> subUrls, Fetcher fetcher)
        {
            foreach (string subUrl in subUrls)
            {
                //regForm.updateScraperTextbox("Parsing " + subUrl);
                Parser parserSub = new Parser(getFaculty(url));
                var subTextTask = fetcher.GetTimetableText(subUrl);
                string subText = subTextTask.Result;
                parserSub.parseTimetable(subText, subUrl);

                List<Lecturer> lecturers = parserSub.lecturers;
                List<Subject> subjects = parserSub.subjects;
                lock (locker)
                {
                    streamWriter.WriteLine("Parsed " + lecturers.Count + " lecturers and " + subjects.Count + " subjects from " + subUrl);
                    streamWriter.Flush();
                }
                //regForm.updateScraperTextbox("Parsed " + lecturers.Count + " lecturers and " + subjects.Count + " subjects from " + subUrl);

                AddLecturers(lecturers);
                AddSubjects(subjects);
            }

        }

        private void AddSubjects(List<Subject> subjects)
        {
            foreach (Subject subject in subjects)
            {
                DataMaster.GetInstance().AddSubjectWithoutWriting(subject);
            }
        }

        private void AddLecturers(List<Lecturer> lecturers)
        {
            foreach (Lecturer lecturer in lecturers)
            {
                DataMaster.GetInstance().AddLecturerWithoutWriting(lecturer);
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
