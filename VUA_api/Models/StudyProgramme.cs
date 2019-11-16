using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace VUA_api
{
    public class StudyProgramme : IEquatable<StudyProgramme>, IComparable<StudyProgramme>
    {
        [Key]
        public string name { get; set; }

        public Faculty faculty { get; set; }

        public StudyProgramme(string name, Faculty faculty)
        {
            this.name = name;
            this.faculty = faculty;
        }

        public int CompareTo(StudyProgramme other)
        {
            return this.name.CompareTo(other.name);
        }

        public bool Equals(StudyProgramme other)
        {
            return name == other.name;
        }
    }
}
