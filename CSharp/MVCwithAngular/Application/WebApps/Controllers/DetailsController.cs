using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebApps.Factories;

namespace WebApps.Controllers
{
  public class DetailsController : ApiController
  {
    public HttpResponseMessage Get(string id)
    {
      var response = Request.CreateResponse(HttpStatusCode.OK);
      response.Content = new StringContent(JsonConvert.SerializeObject(DeCipher.Decrypt(id).ToUpper()), Encoding.UTF8, "application/json");
      return response;
    }
  }
}
