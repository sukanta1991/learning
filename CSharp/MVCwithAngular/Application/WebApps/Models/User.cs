using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Security.Principal;

namespace WebApps.Models
{
    public class User : ClaimsPrincipal
    {
        public User(IPrincipal principal) : base(principal as ClaimsPrincipal) { }

        public string Name => this.Identity.Name;
        public string UserId => this.FindFirst(ClaimTypes.NameIdentifier).Value;
        public string ProfileImage => this.FindFirst(ClaimTypes.Uri).Value;
    }
}
