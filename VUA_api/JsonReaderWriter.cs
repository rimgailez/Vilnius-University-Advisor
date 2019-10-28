using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VUA_api
{
    public class JsonReaderWriter
    {
        public string projectPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)).FullName).FullName).FullName;
        char directorySeparator = Path.DirectorySeparatorChar;
        
        public List<Lecturer> ReadLecturers()
        {
            string lecturerInput = File.ReadAllText(projectPath + directorySeparator + MainResources.LecturersJson);
            return JsonConvert.DeserializeObject<List<Lecturer>>(lecturerInput);
        }
        public List<Subject> ReadSubjects()
        {
            string subjectInput = File.ReadAllText(projectPath + directorySeparator + MainResources.SubjectsJson);
            return JsonConvert.DeserializeObject<List<Subject>>(subjectInput);
        }

        public void WriteLecturers(List<Lecturer> lecturers)
        {
            string output = JsonConvert.SerializeObject(lecturers, Formatting.Indented);
            File.WriteAllText(projectPath + directorySeparator + MainResources.LecturersJson, output);
        }

        public void WriteSubjects(List<Subject> subjects)
        {
            string output = JsonConvert.SerializeObject(subjects, Formatting.Indented);
            File.WriteAllText(projectPath + directorySeparator + MainResources.SubjectsJson, output);
        }

        public List<User> ReadUsers()
        {
              string userInput = File.ReadAllText(projectPath + directorySeparator + MainResources.UsersJson);
              return JsonConvert.DeserializeObject<List<User>>(userInput);
        }

        public void WriteUsers(List<User> users)
        {
            string output = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(projectPath + directorySeparator + MainResources.UsersJson, output);
        }
    }
}
