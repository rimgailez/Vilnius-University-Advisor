using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace VUA_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturerController : ControllerBase
    {
        DataMaster dataMaster = DataMaster.GetInstance();
        [HttpPut("add/{name}/{faculty}")]
        public void Add([FromBody]JObject data)
        {
            string name = data["name"].ToObject<string>();
            Faculty faculty = data["faculty"].ToObject<Faculty>();
            dataMaster.AddLecturer(name, faculty);
        }
        [HttpPut("evaluateNR/{id}/{score}/{text}/{username}")]
        public void Evaluate([FromBody]JObject data)
        {
            int id = data["id"].ToObject<int>();
            float score = data["score"].ToObject<float>();
            string text = data["text"].ToObject<string>();
            string username = data["username"].ToObject<string>();
            dataMaster.EvaluateLecturer(dataMaster.lecturers[id], score, text, username);
        }
        [HttpGet("faculty/{faculty}")]
        public IEnumerable<Lecturer> GetFaculty(Faculty faculty)
        {
            return dataMaster.GetLecturersByFaculty(faculty);
        }
        [HttpGet("search/{term}/{faculty}")]
        public IEnumerable<Lecturer> GetSearch(string term, Faculty faculty)
        {
            return dataMaster.GetLecturerSearchResults(term, faculty);
        }

    }
}