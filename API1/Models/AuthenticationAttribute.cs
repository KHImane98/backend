using DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Helpers;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using JWT.Algorithms;
using JWT.Builder;
using API1.ViewModels;

namespace API1.Models
{
    public class AuthenticationAttribute : AuthorizationFilterAttribute
    {
        private string Role { get; }

        public AuthenticationAttribute(string role = "")
        {
            Role = role.Trim();
          
        }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            try
            {
                if (actionContext.Request.Headers.Authorization != null)
                {
                    var authToken = actionContext.Request.Headers.Authorization.Parameter;
                    var secret = ConfigurationManager.AppSettings["tokenSecret"];
                    var json = new JwtBuilder()
                        .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
                        .WithSecret(secret)
                        .MustVerifySignature()
                        .Decode(authToken);

                    var at = Json.Decode<AuthToken>(json);
                  
                    if (IsAuthorizedUser(int.Parse(at.UserId)))
                    {
                        Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(at.UserId), null);
                    }
                    else
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    }
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            catch (Exception ex)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }
        public bool IsAuthorizedUser(int userId)
        {
            using (var db = new SysRecomProjectEntities())
            {
                var user = db.User.FirstOrDefault(u => u.Id == userId && u.Enabled );
                if (user.Role?.Name == Role) return true;
                else return false;
            }
        }
    }
}