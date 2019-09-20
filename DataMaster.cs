using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilnius_University_Advisor
{
    static class DataMaster
    {
        static List<Lecturer> lecturers = new List<Lecturer>();
        static List<Subject> subjects = new List<Subject>();
        //get project directory
        static string projectPath = Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)).FullName).FullName;
        public static void ReadFromJson()
        {
            string lecturerInput = File.ReadAllText(projectPath + "/lecturers.json");
            lecturers = JsonConvert.DeserializeObject<List<Lecturer>>(lecturerInput);
            string subjectInput = File.ReadAllText(projectPath + "/subjects.json");
            subjects = JsonConvert.DeserializeObject<List<Subject>>(subjectInput);
        }
        public static void AddLecturer(string name, Faculty faculty)
        {
            lecturers.Add(new Lecturer(name, faculty));
            lecturers = lecturers.OrderBy(lecturer => lecturer.name).ToList();
            string output = JsonConvert.SerializeObject(lecturers, Formatting.Indented);
            File.WriteAllText(projectPath + "/lecturers.json", output);
        }
        public static void AddSubject(string name, Faculty faculty, bool IsOptional, bool IsBUS)
        {
            subjects.Add(new Subject(name, faculty, IsOptional, IsBUS));
            subjects = subjects.OrderBy(subject => subject.name).ToList();
            string output = JsonConvert.SerializeObject(subjects, Formatting.Indented);
            File.WriteAllText(projectPath + "/subjects.json", output);
        }
        public static List<Lecturer> getLecturers()
        {
            return lecturers;
        }
        public static List<Subject> getSubjects()
        {
            return subjects;
        }
    }
}
