using API1.Enumerations;
using API1.Helpers;
using API1.ViewModels;
using DataAccess;
using JWT.Algorithms;
using JWT.Builder;
using NETCore.Encrypt.Extensions;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using Users.Helpers;

namespace Users.Controllers
{
    [RoutePrefix("api/Auth")]
    public class AuthController : ApiController
    {
        /// Registration
        [Route("Register")]
        public IHttpActionResult Register(RegViewModel model)
        {
            try
            {
                using (var db = new SysRecomProjectEntities())
                {
                    var key = ConfigurationManager.AppSettings["passwordHashedKey"];
                    var Password = model.Password.HMACSHA256(key);

                    var user = new User
                    {
                        Pseudo = model.Pseudo,
                        Email = model.Email,
                        Password = Password,
                        Created = DateTime.Now,
                        Updated = DateTime.Now,
                        Enabled = true,
                        RoleId = (int)RoleEnum.User
                    };

                    db.User.Add(user);

                    db.SaveChanges();
                    return Ok(new { user.Id });
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
        [HttpPost]
        [HttpOptions]
        [Route("Login")]
        public AuthResponse Post(AuthViewModel model)
        {
            var ar = new AuthResponse();
            try
            {
                using (var db = new SysRecomProjectEntities())
                {
                  
                    var key = ConfigurationManager.AppSettings["passwordHashedKey"];
                    var passwordHashed = model.Password.HMACSHA256(key);
                    var usr = db.User.FirstOrDefault(u => u.Enabled &&
                        u.Email == model.UserName && u.Password == passwordHashed);

                    if (usr != null)
                    {
                        ar.Code = "200";
                        ar.Message = "Connected successfully.";
                        var secret = ConfigurationManager.AppSettings["tokenSecret"];
                        // Encrypt
                        var exp = DateTimeOffset.Now.AddHours(int.Parse(ConfigurationManager.AppSettings["tokenExpirationTime"])).ToUnixTimeSeconds();
                        var token = new JwtBuilder()
                            .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
                            .WithSecret(secret)
                            .AddClaim("Exp", exp)
                            .AddClaim("UserId", usr.Id)
                            //.AddClaim("RoleId", usr.RoleId)
                            .Encode();
                        ar.Token = token;
                        ar.Email = usr.Email;
                        ar.Created = usr.Created;
                    }
                    else
                    {
                        ar.Code = "400";
                        ar.Message = "Wrong login or password.";
                    }
                    return ar;
                }
            }
            catch (Exception ex)
            {
                ar.Code = "-01";
                ar.Message = ex.Message;
                return ar;
            }
        }
        // Reset Psw
        [HttpPost]
        [Route("ResetPassword")]
        public IHttpActionResult ResetPassword(string email, string password)
        {
            try
            {
                using (var db = new SysRecomProjectEntities())
                {
                    var currentUser = db.User.FirstOrDefault(u => u.Enabled && u.Email == email.Replace(" ", "+"));
                    if (currentUser == null) return NotFound();
                    var key = ConfigurationManager.AppSettings["passwordHashedKey"];
                    currentUser.Password = password.HMACSHA256(key);
                    db.SaveChanges();
                    return Ok(new { Success = true, Message = "New Password Has been updated successfully" });
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("ForgotPassword")]
        [Obsolete]
        public IHttpActionResult ForgotPassword(string email)
        {
            try
            {
                using (var db = new SysRecomProjectEntities())
                {


                    var currentUser = db.User.FirstOrDefault(u => u.Enabled && u.Email == email);
                    if (currentUser == null) return NotFound();
                    var key = ConfigurationManager.AppSettings["passwordHashedKey"];
                    var passwordGenerated = PasswordHasher.CreatePassword(8);
                    currentUser.Password = passwordGenerated.HMACSHA256(key);
                    db.SaveChanges();
                    var reportTemplate = Path.Combine(HttpContext.Current.Server.MapPath("~/Views/Shared"), "EmailForgotPassword.cshtml");
                    var model = new UserEmailViewModel
                    {
                        Email = new EmailRecepient
                        { Email = currentUser.Email, UserName = currentUser.Pseudo },
                        Subject = "CoffeeCode | Forgot Password",
                        Password = passwordGenerated,
                        UserName = currentUser.Pseudo,
                    };
                    EmailHelper.SendUserForgotPassword(reportTemplate, model);
                    return Ok(new { Message = "New Password Has been generated successfully" });
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}