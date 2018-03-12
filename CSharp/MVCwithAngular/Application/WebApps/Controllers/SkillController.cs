using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer;
using mod = RepoModel;
using Newtonsoft.Json;
using System.Text;
using WebApps.Factories;

namespace WebApps.Controllers
{
  public class SkillController : ApiController
  {
    private DALEntities dbContext = new DALEntities();
    
    public HttpResponseMessage Get(string id)
    {
      var response = Request.CreateResponse(HttpStatusCode.OK);
      response.Content = new StringContent(JsonConvert.SerializeObject(dbContext.ufn_getSkills(DeCipher.Decrypt(id))), Encoding.UTF8, "application/json");
      return response;
    }
    public HttpResponseMessage Post([FromBody]mod.SkillParam skillModel)
    {
      if (!ModelState.IsValid)
      {
        var resposnse = Request.CreateResponse(HttpStatusCode.BadRequest);
        resposnse.Content = new StringContent(JsonConvert.SerializeObject(ModelState), Encoding.UTF8, "application/json");
        return resposnse;
      }
      else
      {
        string trained= skillModel.skill.trained == null || skillModel.skill.trained == false? "No" :"Yes";
        var response = Request.CreateResponse(HttpStatusCode.OK);
        var result = dbContext.usp_insertSkills(skillModel.skill.skills, trained, DeCipher.Decrypt(skillModel.key));
        dbContext.SaveChanges();
        response.Content = new StringContent(JsonConvert.SerializeObject(result), Encoding.UTF8, "application/json");
        return response;
      }
    }

    public HttpResponseMessage Put([FromBody]mod.SkillParam skillModel)
    {
      if (!ModelState.IsValid)
      {
        var resposnse = Request.CreateResponse(HttpStatusCode.BadRequest);
        resposnse.Content = new StringContent(JsonConvert.SerializeObject(ModelState), Encoding.UTF8, "application/json");
        return resposnse;
      }
      string trained = skillModel.skill.trained == null || skillModel.skill.trained == false ? "No" : "Yes";
      var response = Request.CreateResponse(HttpStatusCode.OK);
      var result = dbContext.usp_updateSkills(skillModel.skill.skills, trained, DeCipher.Decrypt(skillModel.key));
      dbContext.SaveChanges();
      response.Content = new StringContent(JsonConvert.SerializeObject(result), Encoding.UTF8, "application/json");
      return response;
    }

    public HttpResponseMessage Delete([FromBody]mod.SkillParam skillModel)
    {
      var result = dbContext.usp_deleteSkills(skillModel.skill.skills, DeCipher.Decrypt(skillModel.key));
        var response = Request.CreateResponse(HttpStatusCode.Accepted);
        response.Content = new StringContent(JsonConvert.SerializeObject(result), Encoding.UTF8, "application/json");
        return response;
      
    }
  }
}
