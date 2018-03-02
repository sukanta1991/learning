using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using TryingAngular.DBContext;

namespace TryingAngular.Controllers
{
    public class LoginByUsernamePassword_ResultController : ApiController
    {
        private learningEntities db = new learningEntities();
        public HttpResponseMessage Get()
        {
          string res = "This is a test get message";
          var response = Request.CreateResponse(HttpStatusCode.OK);
          response.Content = new StringContent(JsonConvert.SerializeObject(res), Encoding.UTF8, "application/json");
          return response;

        }
    [HttpPost]
    
        public HttpResponseMessage Post([FromBody]LoginByUsernamePassword_Result users)
        {
          var loginInfo = db.LoginByUsernamePassword(users.username, users.password).ToList();
            bool res;
            if (loginInfo != null && loginInfo.Count() > 0)
            {
              res = true;
            }
            else
              res = false;
          
          var response = Request.CreateResponse(HttpStatusCode.OK);
          response.Content = new StringContent(JsonConvert.SerializeObject(res), Encoding.UTF8, "application/json");
          return response;
        }
  }
}
