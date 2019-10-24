using System;
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

        /*
       [HttpPost("add")]
       public void Add([FromBody]JObject data)
       {
           string name = data["name"].ToObject<string>();
           Faculty faculty = data["faculty"].ToObject<Faculty>();
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
       */

    }
}