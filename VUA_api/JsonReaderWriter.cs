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
        public string projectPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)).FullName).FullName).FullName).FullName;
        char directorySeparator = Path.DirectorySeparatorChar;
        
        public List<Lecturer> ReadLecturers()
        {
            string lecturerInput = "[]";
            try
            {
                lecturerInput = File.ReadAllText(projectPath + directorySeparator + MainResources.LecturersJson);
            }
            catch (IOException e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }
            catch (UnauthorizedAccessException e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }
            return JsonConvert.DeserializeObject<List<Lecturer>>(lecturerInput);
        }
        public List<Subject> ReadSubjects()
        {
            string subjectInput = "[]";
            try
            {
                subjectInput = File.ReadAllText(projectPath + directorySeparator + MainResources.SubjectsJson);
            } catch(IOException e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }
            return JsonConvert.DeserializeObject<List<Subject>>(subjectInput);
        }

        public void WriteLecturers(List<Lecturer> lecturers)
        {
            string output = JsonConvert.SerializeObject(lecturers, Formatting.Indented);
            try
            {
                File.WriteAllText(projectPath + directorySeparator + MainResources.LecturersJson, output);
            }
            catch (IOException e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }
            catch (UnauthorizedAccessException e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }
        }

        public void WriteSubjects(List<Subject> subjects)
        {
            string output = JsonConvert.SerializeObject(subjects, Formatting.Indented);
            try
            {
                File.WriteAllText(projectPath + directorySeparator + MainResources.SubjectsJson, output);
            }
            catch (IOException e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }
            catch (UnauthorizedAccessException e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }
        }

        public List<User> ReadUsers()
        {
            string userInput = "[]";
            try
            {
                userInput = File.ReadAllText(projectPath + directorySeparator + MainResources.UsersJson);
            }
            catch (IOException e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }
            catch (UnauthorizedAccessException e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }
              return JsonConvert.DeserializeObject<List<User>>(userInput);
        }

        public void WriteUsers(List<User> users)
        {
            string output = JsonConvert.SerializeObject(users, Formatting.Indented);
            try
            {
                File.WriteAllText(projectPath + directorySeparator + MainResources.UsersJson, output);
            }
            catch (IOException e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }
            catch (UnauthorizedAccessException e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }
        }

        public List<StudyProgramme> ReadStudyProgrammes()
        {
            string studyProgrammeInput = "[]";
            try
            {
                studyProgrammeInput = File.ReadAllText(projectPath + directorySeparator + MainResources.StudyProgrammeJson);
            }
            catch (IOException e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }
            catch (UnauthorizedAccessException e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }
            return JsonConvert.DeserializeObject<List<StudyProgramme>>(studyProgrammeInput);
        }

        public void WriteStudyProgrammes(List<StudyProgramme> studyProgrammes)
        {
            string output = JsonConvert.SerializeObject(studyProgrammes, Formatting.Indented);
            try
            {
                File.WriteAllText(projectPath + directorySeparator + MainResources.StudyProgrammeJson, output);
            }
            catch (IOException e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }
            catch (UnauthorizedAccessException e) { System.Diagnostics.Debug.WriteLine(e.ToString()); }
        }
    }
}
