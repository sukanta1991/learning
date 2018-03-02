using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using TryingAngular.DBContext;

namespace TryingAngular.Controllers
{
    public class BookController : ApiController
    {
        private learningEntities dbContext = new learningEntities();
        public HttpResponseMessage Get()
        {   
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(dbContext.books.ToList()), Encoding.UTF8, "application/json");
            return response;
        }
        public  HttpResponseMessage Post([FromBody]book bookModel)
        {
            if (!ModelState.IsValid)
            {
                var resposnse = Request.CreateResponse(HttpStatusCode.BadRequest);
                resposnse.Content = new StringContent(JsonConvert.SerializeObject(ModelState), Encoding.UTF8, "application/json");
                return resposnse;
            }
            else
            {
                //Use commented code to insert value explicitely into the identity column
                //var p = dbContext.books.OrderByDescending(x => x.bookId).FirstOrDefault();
                //bookModel.bookId = p == null ? 0 : p.bookId + 1;
                //dbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.books ON");
                bookModel.readbook = bookModel.readbook == null || bookModel.readbook=="" ? "No" : bookModel.readbook;
                dbContext.books.Add(bookModel);
                dbContext.SaveChanges();
               // dbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.books OFF");
                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(bookModel), Encoding.UTF8, "application/json");
                return response;
            }
        }
        public HttpResponseMessage Delete(int id)
        {
            book bookChange = dbContext.books.Find(id);
            if(bookChange == null)
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
        public HttpResponseMessage Put(int id, [FromBody]book bookModel)
        {
            if (!ModelState.IsValid)
            {
                var resposnse = Request.CreateResponse(HttpStatusCode.BadRequest);
                resposnse.Content = new StringContent(JsonConvert.SerializeObject(ModelState), Encoding.UTF8, "application/json");
                return resposnse;
            }
            if(id != bookModel.bookId)
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
