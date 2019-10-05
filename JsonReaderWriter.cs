using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilnius_University_Advisor
{
    class JsonReaderWriter
    {
        public string projectPath = Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)).FullName).FullName;
        char directorySeparator = Path.DirectorySeparatorChar;
        
        public List<Lecturer> ReadLecturers()
        {
            string lecturerInput = File.ReadAllText(projectPath + directorySeparator + "lecturers.json");
            return JsonConvert.DeserializeObject<List<Lecturer>>(lecturerInput);
        }
        public List<Subject> ReadSubjects()
        {
            string subjectInput = File.ReadAllText(projectPath + directorySeparator + "subjects.json");
            return JsonConvert.DeserializeObject<List<Subject>>(subjectInput);
        }
        public void WriteLecturers(List<Lecturer> lecturers)
        {
            string output = JsonConvert.SerializeObject(lecturers, Formatting.Indented);
            File.WriteAllText(projectPath + directorySeparator + "lecturers.json", output);
        }
        public void WriteSubjects(List<Subject> subjects)
        {
            string output = JsonConvert.SerializeObject(subjects, Formatting.Indented);
            File.WriteAllText(projectPath + directorySeparator + "subjects.json", output);
        }
    }

}
