using API1.Models;
using API1.ViewModels;
using DataAccess;
using NETCore.Encrypt.Extensions;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace API1.Controllers
{
    [Authentication("User")]
    public class UserController : ApiController
    {
        #region profile setting 
        [HttpGet]
        [Authentication]
        [Route("Profile")]
        public IHttpActionResult GetUserProfile()
        {
            //Log.Logger = new LoggerConfiguration().WriteTo.File(LogFile, rollingInterval: RollingInterval.Day)//.CreateLogger();
            try
            {
                using (var db = new SysRecomProjectEntities())
                {
                    var userId = int.Parse(Thread.CurrentPrincipal.Identity.Name);

                    var user = db.User.Find(userId);
                    if (user == null) return NotFound();
                    var userInfo = new
                    {
                        UserName = user.Pseudo,
                        Email = user.Email,
                        //ProfilePicture = user.UserInformation != null
                        //    ? apiUrl + user.UserInformation.ProfilePicture
                        //    : string.Empty,

                    };

                    return Ok(userInfo);
                }
            }
            catch (Exception ex)
            {
                //Log.Error(Resource.GetUserError, ex);
                //throw;
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// edit profile
        /// Post api/users/profile
        /// </summary>
        /// <param name="userVm"></param>
        /// <returns></returns>
        /// 
        [HttpPut]
        [Route("Profile")]
        public IHttpActionResult PutUserProfile(UserProfileViewModel userVm)
        {
            var userResponse = new UserProfileResponse();

            if (!string.IsNullOrWhiteSpace(userVm.Password) && userVm.CurrentPassword == userVm.Password)
            {
                userResponse.Success = false;
                userResponse.ErrorMessage = "The new password is already used";
                return Ok(userResponse);
            }

            using (var db = new SysRecomProjectEntities())
            {

                try
                {
                    var userId = int.Parse(Thread.CurrentPrincipal.Identity.Name);


                    var user = db.User.FirstOrDefault(e => e.Enabled && e.Id == userId);
                    if (user == null)
                    {
                        userResponse.Success = false;
                        userResponse.ErrorMessage = "UserUnauthorized";
                        return Ok(userResponse);
                    }

                    var userExists = db.User.FirstOrDefault(u =>
                        u.Enabled && u.Email == userVm.Email.Trim() && u.Id != userId);
                    if (userExists != null)
                    {
                        userResponse.Success = false;
                        userResponse.ErrorMessage = "UserLoginExists";
                        return Ok(userResponse);
                    }

                    var profilePicture = "";
                    var httpRequest = HttpContext.Current.Request;
                    if (httpRequest.Files.Count > 0)
                    {
                        const string directoryPath = "/uploads/profilePictures";
                        Directory.CreateDirectory(System.Web.Hosting.HostingEnvironment.MapPath(directoryPath) ??
                                                  throw new InvalidOperationException());

                        // Upload file
                        var guid = Guid.NewGuid();
                        var postedFile = httpRequest.Files[0];
                        var fileName = directoryPath + "/" + guid + "_g_" + postedFile.FileName;
                        var filePath = HttpContext.Current.Server.MapPath(fileName);
                        postedFile.SaveAs(filePath);
                        profilePicture = fileName;
                    }


                    user.Pseudo = userVm.UserName;
                    user.Email = userVm.Email;
                    user.Updated = DateTime.Now;
                    if (!string.IsNullOrEmpty(profilePicture))
                    {
                        user.ProfilePicture = profilePicture;
                    }

                    var key = ConfigurationManager.AppSettings["passwordHashedKey"];
                    if (!string.IsNullOrEmpty(userVm.Password))
                    {
                        if (userVm.CurrentPassword.HMACSHA256(key) == user.Password)
                            user.Password = userVm.Password.HMACSHA256(key);
                        else
                        {
                            userResponse.Success = false;
                            userResponse.ErrorMessage = "UserPasswordIncorrect";
                            return Ok(userResponse);
                        }
                    }

                    db.SaveChanges();
                    userResponse.Success = true;
                }
                catch (Exception ex)
                {
                    //tran.Rollback();
                    //Log.Error(Resource.NewUserError, ex);
                    userResponse.Success = false;
                    userResponse.ErrorMessage = "InternalServerError";
                    //throw;
                }

                //}
            }
            return Ok(userResponse);
        }

        [HttpPut]
        [Route("ProfilePicture")]
        public IHttpActionResult PutUserProfilePicture()
        {
            var userResponse = new UserProfileResponse();

            using (var db = new SysRecomProjectEntities())
            {

                try
                {
                    var userId = int.Parse(Thread.CurrentPrincipal.Identity.Name);
                    var user = db.User.FirstOrDefault(e => e.Id == userId);
                    if (user == null)
                    {
                        userResponse.Success = false;
                        userResponse.ErrorMessage = "UserUnauthorized";
                        return Ok(userResponse);
                    }

                    var profilePicture = "";
                    var httpRequest = HttpContext.Current.Request;
                    if (httpRequest.Files.Count > 0)
                    {
                        const string directoryPath = "/uploads/profilePictures";
                        Directory.CreateDirectory(System.Web.Hosting.HostingEnvironment.MapPath(directoryPath) ??
                                                  throw new InvalidOperationException());

                        // Upload file
                        var guid = Guid.NewGuid();
                        var postedFile = httpRequest.Files[0];
                        var fileName = directoryPath + "/" + guid + "_g_" + postedFile.FileName;
                        var filePath = HttpContext.Current.Server.MapPath(fileName);
                        postedFile.SaveAs(filePath);
                        profilePicture = fileName;
                    }


                    if (!string.IsNullOrEmpty(profilePicture))
                    {
                        user.ProfilePicture = profilePicture;
                        userResponse.NewProfilePicture = /*ApiUrl +*/ profilePicture;
                    }


                    db.SaveChanges();
                    userResponse.Success = true;
                }
                catch (Exception ex)
                {
                    userResponse.Success = false;
                    userResponse.ErrorMessage = "InternalServerError";
                }
            }


            return Ok(userResponse);
        }
        #endregion
        #region Recommandation
        // GET: Recommandation
        [HttpGet]
        [Route("Recommandation")]
        public IHttpActionResult GetRecomm()
        {
            try
            {
                using (var db = new SysRecomProjectEntities())
                {
                    var recom = db.Recommandation.Where(r => r.Enabled && (bool)r.Status).Select(t => new
                    {
                        Id = t.Id,
                        Name = t.Commentaire,
                        Avis = t.Avis,
                        Status = t.Status
                    }).ToList();

                    return Ok(recom);
                }
            }

            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        // GET: Recommandation by Id
        [HttpGet]
        [Route("Recommandation/{id}")]
        public IHttpActionResult GetRecomm(int Id)
        {
            try
            {
                using (var db = new SysRecomProjectEntities())
                {
                    var recomCheck = db.Recommandation.FirstOrDefault(r => r.Id == Id && r.Enabled && (bool)r.Status);
                    if (recomCheck == null) return NotFound();

                    var recom = new
                    {
                        Id = recomCheck.Id,
                        Name = recomCheck.Commentaire,
                        Avis = recomCheck.Avis,
                        Status = recomCheck.Status
                    };

                    return Ok(recom);
                }
            }

            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        // POST: Recommandation
        [HttpPost]
        [Route("Recommandation")]
        public IHttpActionResult PostRecomm(AddRecomViewModel viewModel)
        {
            try
            {
                using (var db = new SysRecomProjectEntities())
                {
                    var userId = int.Parse(Thread.CurrentPrincipal.Identity.Name);
                    if (viewModel.serviceId == null && viewModel.personne_metierId == null) return BadRequest("vous devez spécifier le service ou la personne métier");
                    var recom = new Recommandation
                    {
                        Avis = viewModel.Avis,
                        Commentaire = viewModel.Commentaire,
                        UserId = userId,
                        ServiceId = viewModel.serviceId != null ? viewModel.serviceId : null,
                        Personne_metierId = viewModel.personne_metierId != null ? viewModel.personne_metierId : null,
                        Created = DateTime.Now,
                        Updated = DateTime.Now,
                        Enabled = true
                    };

                    db.Recommandation.Add(recom);

                    db.SaveChanges();
                    return Ok(new { recom.Id });
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: Recommandation 
        [HttpDelete]
        [Route("Recommandation")]
        public IHttpActionResult DeleteRecom(int id)
        {
            try
            {
                using (var db = new SysRecomProjectEntities())
                {

                    // Check recomm exist
                    var recom = db.Recommandation.FirstOrDefault(c => c.Id == id && c.Enabled);
                    if (recom == null) return NotFound();

                    // Delete recomm 
                    recom.Enabled = false;
                    db.SaveChanges();

                    return Ok("The recommendation has been deleted successfully");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Route("Search")]
        // Search : Recommandation
        public IHttpActionResult Search(int? avis = null, int? categorieId = 0, int? serviceId = 0, int? personne_metierId = 0)
        {
            try
            {
                using (var db = new SysRecomProjectEntities())
                {
                    var recomm = db.Recommandation.Where(r => r.Enabled && (bool)r.Status);
                    // check category 
                    if (categorieId != null && categorieId != 0)
                    {
                        recomm = recomm.Where(r => r.Service.CategorieId == categorieId || r.Personne_metier.CategorieId == categorieId);
                    }
                    // check service 
                    if (serviceId != null && serviceId != 0)
                    {
                        recomm = recomm.Where(r => r.ServiceId == serviceId);
                    }
                    // check personne metier 
                    if (personne_metierId != null && personne_metierId != 0)
                    {
                        recomm = recomm.Where(r => r.Personne_metierId == personne_metierId);
                    }
                    // check avis
                    if (avis != null)
                    {
                        recomm = recomm.Where(r => r.Avis == avis);
                    }
                    var recmmandation = recomm.Select(t => new RecommandationModel
                    {
                        Id = t.Id,
                        Commentaire = t.Commentaire,
                        Avis = t.Avis
                    }).ToList();
                    return Ok(recmmandation);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        #endregion
    }
}