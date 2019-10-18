using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace VUA_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        DataMaster dataMaster = DataMaster.GetInstance();
        [HttpPut("add/{name}/{faculty}/{isOptional}/{isBUS}")]
        public void Add([FromBody]JObject data)
        {
            string name = data["name"].ToObject<string>();
            Faculty faculty = data["faculty"].ToObject<Faculty>();
            bool isOptional = data["isOptional"].ToObject<bool>();
            bool isBUS = data["isBUS"].ToObject<bool>();
            dataMaster.AddSubject(name, faculty, isOptional, isBUS);
        }
        [HttpPut("evaluate")]
        public void Evaluate([FromBody]JObject data)
        {
            int id = data["id"].ToObject<int>();
            float score = data["score"].ToObject<float>();
            string text = data["text"].ToObject<string>();
            string username = data["username"].ToObject<string>();
            dataMaster.EvaluateSubject(dataMaster.subjects[id], score, text, username);
        }
        [HttpGet("faculty/{faculty}")]
        public IEnumerable<Subject> GetFaculty(Faculty faculty)
        {
            return dataMaster.GetSubjectsByFaculty(faculty);
        }
        [HttpGet("BUS")]
        public IEnumerable<Subject> GetBUS()
        {
            return dataMaster.GetBUSSubjects();
        }
        [HttpGet("BUS/{faculty}")]
        public IEnumerable<Subject> GetBUS(Faculty faculty)
        {
            return dataMaster.GetBUSSubjects(faculty);
        }
        [HttpGet("TypeFaculty/{isOptional}/{faculty}")]
        public IEnumerable<Subject> GetByTypeFaculty(bool isOptional, Faculty faculty)
        {
            return dataMaster.GetSubjectsByTypeAndFaculty(isOptional, faculty);
        }
        [HttpGet("search/{term}/{faculty}")]
        public IEnumerable<Subject> GetSearch(string term, Faculty faculty)
        {
            return dataMaster.GetSubjectSearchResults(term, faculty);
        }
    }
}