using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using RepoModel;
using WebApps.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;



namespace WebApps.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET: Account
        private DALEntities dal = new DALEntities();

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public void ExternalLogin(string returnUrl)
        //{
        //    // Redirect to the Google OAuth 2.0 user consent screen
        //    HttpContext.GetOwinContext().Authentication.Challenge(
        //        new AuthenticationProperties { RedirectUri = "/" },
        //        "Google"
        //    );
        //}

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            try
            {
                // Verification.    
                if (this.Request.IsAuthenticated)
                {
                    // Info.    
                    return this.RedirectToLocal(returnUrl);
                }                
            }
            catch (Exception ex)
            {
                // Info    
                Console.Write(ex);
            }
            // Info.    
            return this.View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountView model, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var loginInfo = this.dal.LoginByUsernamePassword(model.Username, model.Password).ToList();
                    if (loginInfo != null && loginInfo.Count() > 0)
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
                // Verification.    
                if (Url.IsLocalUrl(returnUrl))
                {
                    // Info.    
                    return this.Redirect(returnUrl);
                }
            }
            catch (Exception ex)
            {
                // Info    
                throw ex;
            }
            // Info.    
            return this.RedirectToAction("Index", "Home");
        }
       
    }
}
