using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace Vilnius_University_Advisor
{
    static class Program
    {
        public static List<Lecturer> lecturers = new List<Lecturer>();
        public static List<Subject> subjects = new List<Subject>();
        //get project directory
        static string projectPath = Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)).FullName).FullName;
        [STAThread]
        static void Main()
        {
            //read from json files
            string lecturerInput = File.ReadAllText(projectPath + "/lecturers.json");
            lecturers = JsonConvert.DeserializeObject< List<Lecturer> >(lecturerInput);
            string subjectInput = File.ReadAllText(projectPath + "/subjects.json");
            subjects = JsonConvert.DeserializeObject< List<Subject> >(subjectInput);
            //run WinForm
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RegForm());
        }
        public static void AddLecturer(Lecturer lecturer)
        {
            lecturers.Add(lecturer);
            string output = JsonConvert.SerializeObject(lecturers, Formatting.Indented);
            File.WriteAllText(projectPath + "/lecturers.json", output);
        }
        public static void AddSubject(Subject subject)
        {
            subjects.Add(subject);
            string output = JsonConvert.SerializeObject(subjects, Formatting.Indented);
            File.WriteAllText(projectPath + "/subjects.json", output);
        }
        public static List<Lecturer> getLecturers()
        {
            lecturers = lecturers.OrderBy(lecturer => lecturer.name).ToList();
           return lecturers;
        }
        public static List<Subject> getSubjects()
        {
            subjects = subjects.OrderBy(subject => subject.name).ToList();
            return subjects;
        }
    }
}
