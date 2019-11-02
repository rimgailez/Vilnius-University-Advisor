﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace VUA_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DataMaster dataMaster = DataMaster.GetInstance();

       
       [HttpPost("add")]
       public void Add([FromBody]JObject data)
       {
           string name = data["name"].ToObject<string>();
           Faculty faculty = data["userFaculty"].ToObject<Faculty>();
           string userName = data["userName"].ToObject<string>();
           string password = data["password"].ToObject<string>();
           string eMail = data["eMail"].ToObject<string>();
           string phoneNumber = data["phoneNumber"].ToObject<string>();
           string studyProgram = data["studyProgram"].ToObject<string>();
           dataMaster.AddUser(name, faculty, userName, password, eMail, phoneNumber, studyProgram);
       }
       [HttpGet("all")]
       public IEnumerable<User> GetAll()
       {
           return dataMaster.users;
       }

       [HttpGet("checkUserName/{userName}")]
       public Boolean CheckUserName(string userName)
       {
           return dataMaster.CheckIfUserNameExists(userName);
       }

       [HttpGet("checkPassword/{userName}/{password}")]
       public Boolean CheckPassword(string userName, string password)
       {
            return dataMaster.CheckIfCorrectPassword(userName, password);
       }

       [HttpGet("getUser")]
       public User GetUser()
       {
            return dataMaster.GetCurrentUser();
       }

       [HttpPost("setUser")]
       public void SetUser([FromBody]User user)
       {
            dataMaster.SetCurrentUser(user);
       }

       [HttpPost("addHistory")]
       public void AddHistory([FromBody]string activityComment)
       {
            dataMaster.AddToUserHistory(activityComment);
       }

       [HttpGet("getHistory")]
       public List<Activity> GetActivityHistory()
       {
           return dataMaster.GetUserActivityHistory();
       }

        [HttpGet("getTopSubjEvaluators")]
        public List<User> GetTopActiveLecturersEvaluators()
        {
            return dataMaster.GetTop10ActiveSubjectsEvaluators();
        }

        [HttpGet("getTopLectEvaluators")]
        public List<User> GetTopActiveSubjectsEvaluators()
        {
            return dataMaster.GetTop10ActiveLecturersEvaluators();
        }

        [HttpGet("getTopUsers")]
        public List<User> GetTopUsers()
        {
            return dataMaster.GetTop10ActiveUsers();
        }

    }
}