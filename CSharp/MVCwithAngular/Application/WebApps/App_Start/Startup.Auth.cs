using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;


namespace WebApps
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                LogoutPath = new PathString("/Account/LogOff"),
                ExpireTimeSpan = TimeSpan.FromMinutes(5.0)
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            //app.UseGoogleAuthentication(
            //    clientId: "63901729926-ac9qt2e3vlpiq7tn4jouiimgb3gv19fc.apps.googleusercontent.com",
            //    clientSecret: "Li6yHkgnVxvzr8K6HTJmLdap");

        //    var authenticationOptions = new GoogleOAuth2AuthenticationOptions()
        //    {
        //        ClientId = "385162634767-9qjijuhr0shscl062cvbcjn8c0d1i2mk.apps.googleusercontent.com",
        //        ClientSecret = "avrTnQVJz3Dz_JBXE5nY7ept",
        //    };
        //authenticationOptions.Scope.Add("profile");
        //    authenticationOptions.Provider = new GoogleOAuth2AuthenticationProvider()
        //    {
        //        // [START read_google_profile_image_url]
        //        // After OAuth authentication completes successfully,
        //        // read user's profile image URL from the profile
        //        // response data and add it to the current user identity
        //        OnAuthenticated = context =>
        //        {
        //            var profileUrl = context.User["image"]["url"].ToString();
        //            context.Identity.AddClaim(new Claim(ClaimTypes.Uri, profileUrl));
        //            return Task.FromResult(0);
        //        }
        //        // [END read_google_profile_image_url]
        //    };
        //    app.UseGoogleAuthentication(authenticationOptions);
        }

    }
}
