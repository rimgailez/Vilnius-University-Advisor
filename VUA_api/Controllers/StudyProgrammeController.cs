using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VUA_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyProgrammeController : ControllerBase
    {
        DataMaster dataMaster = DataMaster.GetInstance();

        [HttpPost("add")]
        public void Add([FromBody]JObject data)
        {
            string name = data["name"].ToObject<string>();
            Faculty faculty = data["faculty"].ToObject<Faculty>();
            dataMaster.AddStudyProgramme(name, faculty);
        }

        [HttpGet]
        public IEnumerable<StudyProgramme> GetAll()
        {
            return dataMaster.studyProgrammes;
        }

        [HttpGet("faculty/{faculty}")]
        public IEnumerable<StudyProgramme> GetFaculty(Faculty faculty)
        {
            return dataMaster.GetStudyProgrammesByFaculty(faculty);
        }

    }
}
