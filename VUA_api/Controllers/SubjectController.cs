﻿using System;
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
        [HttpPost("add")]
        public void Add([FromBody]JObject data)
        {
            string name = data["name"].ToObject<string>();
            Faculty faculty = data["faculty"].ToObject<Faculty>();
            bool isOptional = data["isOptional"].ToObject<bool>();
            bool isBUS = data["isBUS"].ToObject<bool>();
            dataMaster.AddSubject(name, faculty, isOptional, isBUS);
        }
        [HttpPost("evaluate")]
        public void Evaluate([FromBody]JObject data)
        {
            Subject subjectNew = data["subject"].ToObject<Subject>();
            float score = data["score"].ToObject<float>();
            string text = data["text"].ToObject<string>();
            string username = data["username"].ToObject<string>();
            Subject subjectRef = null;
            foreach (Subject subject in dataMaster.subjects)
            {
                if (subject.Equals(subjectNew))
                {
                    subjectRef = subject;
                    break;
                }
            }
            dataMaster.EvaluateSubject(subjectRef, score, text, username);
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
        [HttpGet("search/{faculty}/{term}")]
        public IEnumerable<Subject> GetSearch(Faculty faculty, string term)
        {
            return dataMaster.GetSubjectSearchResults(term, faculty);
        }
    }
}