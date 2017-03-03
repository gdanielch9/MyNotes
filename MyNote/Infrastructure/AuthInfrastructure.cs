using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyNote.Infrastructure
{
    public class AuthInfrastructure : IAuthInfrastructure
    {
        public string GetCurrentUserId()
        {
            var user = HttpContext.Current.GetOwinContext().Authentication.User;
            var userId = user.Identity.GetUserId();

            return userId;
        }
    }
}