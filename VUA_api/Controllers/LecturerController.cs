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
        private readonly DataMaster dataMaster;

        public LecturerController(DataMaster serv)
        {
            dataMaster = serv;
        }

        [HttpPost("add")]
        public void Add([FromBody]JObject data)
        {
            string name = data["name"].ToObject<string>();
            Faculty faculty = data["faculty"].ToObject<Faculty>();
            dataMaster.AddLecturer(name, faculty);
        }

        [HttpPost("evaluate")]
        public void Evaluate([FromBody]JObject data)
        {
            Lecturer lecturerNew = data["lecturer"].ToObject<Lecturer>();
            float score = data["score"].ToObject<float>();
            string text = data["text"].ToObject<string>();
            string username = data["username"].ToObject<string>();
            Lecturer lecturerRef = null;
            foreach(Lecturer lecturer in dataMaster.lecturers)
            {
                if (lecturer.Equals(lecturerNew))
                {
                    lecturerRef = lecturer;
                    break;
                }
            }
            dataMaster.EvaluateLecturer(lecturerRef, score, text, username);
        }

        [HttpGet]
        public IEnumerable<Lecturer> GetAll()
        {
            return dataMaster.lecturers;
        }

        [HttpGet("faculty/{faculty}")]
        public IEnumerable<Lecturer> GetFaculty(Faculty faculty)
        {
            return dataMaster.GetLecturersByFaculty(faculty);
        }

        [HttpGet("search/{faculty}/{term}")]
        public IEnumerable<Lecturer> GetSearch(string term, Faculty faculty)
        {
            return dataMaster.GetLecturerSearchResults(term, faculty);
        }

        [HttpGet("top")]
        public IEnumerable<Lecturer> GetTop10()
        {
            return dataMaster.GetTop10Lecturers();
        }

        [HttpGet("scraper")]
        public string RunScraper()
        {
            //new Scraper.ScraperMain(dataMaster.jsonReaderWriter.projectPath).StartScrap();
            return "Scraper is done";
        }
    }
}