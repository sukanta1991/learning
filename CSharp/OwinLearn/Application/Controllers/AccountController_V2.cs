using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using TestLogin.DBContext;
using TestLogin.Models;
using Microsoft.Owin.Security;
using System.DirectoryServices;

namespace TestLogin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private learningEntities1 databaseManager = new learningEntities1();
        
        public AccountController()
        {

        }
       [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            try
            {   
                if (this.Request.IsAuthenticated)
                {
                    return this.RedirectToLocal(returnUrl);
                }
                else
                {
                    string uName = System.IO.Path.GetFileName(System.Environment.UserName);
                    if (this.isValidMailID(uName))
                    {
                        this.SignInUser(uName, false);
                        return this.RedirectToLocal(returnUrl);
                    }
                }
            }
            catch (Exception ex)
            {  
                Console.Write(ex);
            }  
            return this.View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountViewModels model, string returnUrl)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var loginInfo = this.databaseManager.LoginByUsernamePassword(model.Username, model.Password).ToList();
                    if(loginInfo != null && loginInfo.Count() > 0)
                    {
                        var loginDetails = loginInfo.First();
                        this.SignInUser(loginDetails.username, false);
                        return this.RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid userName or Password");
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex); 
            }
            return this.View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            try
            {
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                authenticationManager.SignOut();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return this.RedirectToAction("Login", "Account");
        }


        private void SignInUser(string username, bool isPersistent)
        {
            var claims = new List<Claim>();
            try
            {
                claims.Add(new Claim(ClaimTypes.Name, username));
                var claimIdenties = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, claimIdenties);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            try
            {  
                if (Url.IsLocalUrl(returnUrl))
                {    
                    return this.Redirect(returnUrl);
                }
            }
            catch (Exception ex)
            {   
                throw ex;
            }
            return this.RedirectToAction("Index", "Home");
        }
   
        public bool isValidMailID(String mailID)
        {

            try
            {
                System.DirectoryServices.DirectoryEntry dirEntry = new System.DirectoryServices.DirectoryEntry("LDAP://SukantaServer");
                System.DirectoryServices.DirectorySearcher dirSearcher = new System.DirectoryServices.DirectorySearcher(dirEntry);

                dirSearcher.Filter = "(SAMAccountName=" + mailID + ")";

                System.DirectoryServices.SearchResult result = dirSearcher.FindOne();

                if (result != null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                //throw new Exception("User not authenticated: " + ex.Message);
                return false;
            }
        }

    }
}
