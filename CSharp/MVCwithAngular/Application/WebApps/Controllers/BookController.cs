using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer;
using mod=RepoModel;
using Newtonsoft.Json;
using System.Text;

namespace WebApps.Controllers
{
  public class BookController : ApiController
  {
    private DALEntities dbContext = new DALEntities();
    public HttpResponseMessage Get()
    {
      var response = Request.CreateResponse(HttpStatusCode.OK);
      response.Content = new StringContent(JsonConvert.SerializeObject(dbContext.books.ToList()), Encoding.UTF8, "application/json");
      return response;
    }
    public HttpResponseMessage Post([FromBody]mod.book bookModel)
    {
      if (!ModelState.IsValid)
      {
        var resposnse = Request.CreateResponse(HttpStatusCode.BadRequest);
        resposnse.Content = new StringContent(JsonConvert.SerializeObject(ModelState), Encoding.UTF8, "application/json");
        return resposnse;
      }
      else
      {
        bookModel.readbook = bookModel.readbook == null || bookModel.readbook == "" ? "No" : bookModel.readbook;
        dbContext.books.Add(bookModel);
        dbContext.SaveChanges();
        var response = Request.CreateResponse(HttpStatusCode.OK);
        response.Content = new StringContent(JsonConvert.SerializeObject(bookModel), Encoding.UTF8, "application/json");
        return response;
      }
    }
    public HttpResponseMessage Delete(int id)
    {
      mod.book bookChange = dbContext.books.Find(id);
      if (bookChange == null)
      {
        var resposnse = Request.CreateResponse(HttpStatusCode.BadRequest);
        resposnse.Content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
        return resposnse;
      }
      else
      {
        dbContext.books.Remove(bookChange);
        dbContext.SaveChanges();
        var response = Request.CreateResponse(HttpStatusCode.Accepted);
        response.Content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
        return response;
      }
    }
    public HttpResponseMessage Put(int id, [FromBody]mod.book bookModel)
    {
      if (!ModelState.IsValid)
      {
        var resposnse = Request.CreateResponse(HttpStatusCode.BadRequest);
        resposnse.Content = new StringContent(JsonConvert.SerializeObject(ModelState), Encoding.UTF8, "application/json");
        return resposnse;
      }
      if (id != bookModel.bookId)
      {
        var resposnse = Request.CreateResponse(HttpStatusCode.BadRequest);
        resposnse.Content = new StringContent(JsonConvert.SerializeObject(ModelState), Encoding.UTF8, "application/json");
        return resposnse;
      }
      dbContext.Entry(bookModel).State = System.Data.Entity.EntityState.Modified;
      dbContext.SaveChanges();
      var response = Request.CreateResponse(HttpStatusCode.NoContent);
      return response;
    }
  }
}
