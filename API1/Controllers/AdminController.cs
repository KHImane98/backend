using API1.Models;
using API1.ViewModels;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Http;

namespace API1.Controllers
{
    [Authentication("Admin")]
    public class AdminController : ApiController
    {
        #region Users
        // GET: Login
        [HttpGet]
        [Route("User")]
        public IHttpActionResult GetUsers()
        {
            try
            {
                using (var db = new SysRecomProjectEntities())
                {
                    var users = db.User.Where(u => u.Enabled).Select(t => new
                    {
                        t.Id,
                        t.Email,
                        t.Pseudo
                    }).ToList();

                    return Ok(users);
                }
            }

            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        // GET: User by Id
        [HttpGet]
        [Route("User/{id}")]
        public IHttpActionResult GetUser(int Id)
        {
            try
            {
                using (var db = new SysRecomProjectEntities())
                {
                    var persCheck = db.User.FirstOrDefault(r => r.Id == Id && r.Enabled);
                    if (persCheck == null) return NotFound();

                    var result = new
                    {
                        Id = persCheck.Id,
                        UserName = persCheck.Pseudo,
                        Email = persCheck.Email,


                    };

                    return Ok(result);
                }
            }

            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("User/{id}")]
        public IHttpActionResult PutUser(int id, UserViewModel viewModel)
        {
            try
            {

                using (var db = new SysRecomProjectEntities())
                {
                    var userId = int.Parse(Thread.CurrentPrincipal.Identity.Name);

                    var pers = db.User.FirstOrDefault(c => c.Id == id && c.Enabled);
                    if (pers == null) return NotFound();
                    var check = db.User.FirstOrDefault(c => c.Email == viewModel.Email && c.Enabled);
                    if (check == null)
                    {
                        pers.Email = viewModel.Email;
                        pers.Pseudo = viewModel.Pseudo;
                        pers.Updated = DateTime.Now;
                        db.SaveChanges();

                        return Ok("The user has been changed : " + pers.Id);
                    }
                    else
                    {
                        return BadRequest("This user already exists");
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("User/{id}")]
        public IHttpActionResult DeleteUser(int id)
        {
            try
            {
                using (var db = new SysRecomProjectEntities())
                {
                    var pers = db.User.FirstOrDefault(c => c.Id == id && c.Enabled);
                    if (pers == null) return NotFound();
                    pers.Enabled = false;
                    db.SaveChanges();

                    return Ok("The user has been deleted successfully");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
        #endregion
        #region Personne metiers
        [HttpGet]
        [Route("PersonneMetier")]
        public IHttpActionResult GetPersonneMetiers()
        {
            try
            {
                using (var db = new SysRecomProjectEntities())
                {
                    var result = db.Personne_metier.Where(r => r.Enabled).Select(t => new
                    {
                        Id = t.Id,
                        Name = t.Name,
                    }).ToList();

                    return Ok(result);
                }
            }

            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        // GET: PersonneMetier by Id
        [HttpGet]
        [Route("PersonneMetier/{id}")]
        public IHttpActionResult GetPersonneMetiers(int Id)
        {
            try
            {
                using (var db = new SysRecomProjectEntities())
                {
                    var persCheck = db.Personne_metier.FirstOrDefault(r => r.Id == Id && r.Enabled);
                    if (persCheck == null) return NotFound();

                    var result = new
                    {
                        Id = persCheck.Id,
                        Name = persCheck.Name,

                    };

                    return Ok(result);
                }
            }

            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        // POST: PersonneMetier
        [HttpPost]
        [Route("PersonneMetier")]
        public IHttpActionResult PostPersonneMetiers(AddPersonneMetierViewModel viewModel)
        {
            try
            {
                using (var db = new SysRecomProjectEntities())
                {
                    var userId = int.Parse(Thread.CurrentPrincipal.Identity.Name);

                    var check = db.Personne_metier.FirstOrDefault(c => c.Name == viewModel.Name && c.Enabled);
                    if (check == null)
                    {
                        var result = new Personne_metier
                        {
                            Name = viewModel.Name,
                            Enabled = true,
                            Created = DateTime.Now,
                            Updated = DateTime.Now,
                        };

                        db.Personne_metier.Add(result);

                        db.SaveChanges();
                        return Ok(new { result.Id });
                    }
                    else
                    {
                        return BadRequest("This person already exists");
                    }

                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        [HttpPut]
        [Route("PersonneMetier/{id}")]
        public IHttpActionResult PutPersonne_metier(int id, AddPersonneMetierViewModel viewModel)
        {
            try
            {

                using (var db = new SysRecomProjectEntities())
                {
                    var userId = int.Parse(Thread.CurrentPrincipal.Identity.Name);

                    var pers = db.Personne_metier.FirstOrDefault(c => c.Id == id && c.Enabled);
                    if (pers == null) return NotFound();
                    var check = db.Personne_metier.FirstOrDefault(c => c.Name == viewModel.Name && c.Enabled);
                    if (check == null)
                    {
                        pers.Name = viewModel.Name;
                        pers.Updated = DateTime.Now;
                        db.SaveChanges();

                        return Ok("The person has been changed : " + pers.Id);
                    }
                    else
                    {
                        return BadRequest("This person already exists");
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("PersonneMetier")]
        public IHttpActionResult DeletePersonne_metier(int id)
        {
            try
            {
                using (var db = new SysRecomProjectEntities())
                {
                    var pers = db.Personne_metier.FirstOrDefault(c => c.Id == id && c.Enabled);
                    if (pers == null) return NotFound();
                    pers.Enabled = false;
                    db.SaveChanges();

                    return Ok("The person has been deleted successfully");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
        #endregion
        #region Service
        [HttpGet]
        [Route("Service")]
        public IHttpActionResult GetService()
        {
            try
            {
                using (var db = new SysRecomProjectEntities())
                {
                    var result = db.Service.Where(r => r.Enabled).Select(t => new
                    {
                        Id = t.Id,
                        Name = t.Name,
                    }).ToList();

                    return Ok(result);
                }
            }

            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        // GET: service by Id
        [HttpGet]
        [Route("Service/{id}")]
        public IHttpActionResult GetService(int Id)
        {
            try
            {
                using (var db = new SysRecomProjectEntities())
                {
                    var ServiceCheck = db.Service.FirstOrDefault(r => r.Id == Id && r.Enabled);
                    if (ServiceCheck == null) return NotFound();

                    var result = new
                    {
                        Id = ServiceCheck.Id,
                        Name = ServiceCheck.Name,

                    };

                    return Ok(result);
                }
            }

            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        // POST: service
        [HttpPost]
        [Route("Service")]
        public IHttpActionResult PostService(AddServiceViewModel viewModel)
        {
            try
            {
                using (var db = new SysRecomProjectEntities())
                {
                    var check = db.Service.FirstOrDefault(c => c.Name == viewModel.Name && c.Enabled);
                    if (check == null)
                    {
                        var result = new Service
                        {
                            Name = viewModel.Name,
                            Enabled = true,
                            Created = DateTime.Now,
                            Updated = DateTime.Now,
                        };

                        db.Service.Add(result);

                        db.SaveChanges();
                        return Ok(new { result.Id });
                    }
                    else
                    {
                        return BadRequest("This Service already exists");
                    }

                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPut]
        [Route("Service/{id}")]
        public IHttpActionResult PutService(int id, AddServiceViewModel viewModel)
        {
            try
            {

                using (var db = new SysRecomProjectEntities())
                {

                    var Service = db.Service.FirstOrDefault(c => c.Id == id && c.Enabled);
                    if (Service == null) return NotFound();
                    var check = db.Service.FirstOrDefault(c => c.Name == viewModel.Name && c.Enabled);
                    if (check == null)
                    {
                        Service.Name = viewModel.Name;
                        Service.Updated = DateTime.Now;
                        db.SaveChanges();

                        return Ok("The person has been changed : " + Service.Id);
                    }
                    else
                    {
                        return BadRequest("This Service already exists");
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("Service/{id}")]
        public IHttpActionResult DeleteService(int id)
        {
            try
            {
                using (var db = new SysRecomProjectEntities())
                {
                    var Service = db.Service.FirstOrDefault(c => c.Id == id && c.Enabled);
                    if (Service == null) return NotFound();
                    Service.Enabled = false;
                    db.SaveChanges();

                    return Ok("The Service has been deleted successfully");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
        #endregion
        #region Categories
        [HttpGet]
        [Route("Category")]
        public IHttpActionResult GetCateg()
        {
            try
            {
                using (var db = new SysRecomProjectEntities())
                {
                    var categ = db.Categorie.Where(r => r.Enabled).Select(t => new
                    {
                        Id = t.Id,
                        Name = t.Name,
                    }).ToList();

                    return Ok(categ);
                }
            }

            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        // GET: Categorie by Id
        [HttpGet]
        [Route("Category/{id}")]
        public IHttpActionResult GetCateg(int Id)
        {
            try
            {
                using (var db = new SysRecomProjectEntities())
                {
                    var categCheck = db.Categorie.FirstOrDefault(r => r.Id == Id && r.Enabled);
                    if (categCheck == null) return NotFound();

                    var categ = new
                    {
                        Id = categCheck.Id,
                        Name = categCheck.Name,

                    };

                    return Ok(categ);
                }
            }

            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
        // POST: Categorie
        [HttpPost]
        [Route("Category")]
        public IHttpActionResult PostCateg(AddCategViewModel viewModel)
        {
            try
            {
                using (var db = new SysRecomProjectEntities())
                {
                    var userId = int.Parse(Thread.CurrentPrincipal.Identity.Name);

                    var checkcateg = db.Categorie.FirstOrDefault(c => c.Name == viewModel.name && c.Enabled);
                    if (checkcateg == null)
                    {
                        var categ = new Categorie
                        {
                            Name = viewModel.name,
                            Enabled = true,
                            Created = DateTime.Now,
                            Updated = DateTime.Now,
                        };

                        db.Categorie.Add(categ);

                        db.SaveChanges();
                        return Ok(new { categ.Id });
                    }
                    else
                    {
                        return BadRequest("This category already exists");
                    }

                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        [HttpPut]
        [Route("Category/{id}")]

        public IHttpActionResult PutCateg(int id, AddCategViewModel viewModel)
        {
            try
            {

                using (var db = new SysRecomProjectEntities())
                {
                    var userId = int.Parse(Thread.CurrentPrincipal.Identity.Name);

                    var categ = db.Categorie.FirstOrDefault(c => c.Id == id && c.Enabled);
                    if (categ == null) return NotFound();
                    var checkcateg = db.Categorie.FirstOrDefault(c => c.Name == viewModel.name && c.Enabled);
                    if (checkcateg == null)
                    {
                        categ.Name = viewModel.name;
                        categ.Updated = DateTime.Now;
                        db.SaveChanges();

                        return Ok("category has been changed : " + categ.Id);
                    }
                    else
                    {
                        return BadRequest("This category already exists");
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("Category/{id}")]

        public IHttpActionResult DeleteCateg(int id)
        {
            try
            {
                using (var db = new SysRecomProjectEntities())
                {
                    var categ = db.Categorie.FirstOrDefault(c => c.Id == id);
                    if (categ == null) return NotFound();
                    categ.Enabled = false;
                    db.SaveChanges();

                    return Ok("The category has been deleted successfully");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
        #endregion
        #region Recommandations approbation

        [HttpPost]
        [Route("Recommandation/{id}")]
        public IHttpActionResult RecomApprobation(int id, bool status)
        {
            try
            {
                using (var db = new SysRecomProjectEntities())
                {
                    var recomm = db.Recommandation.FirstOrDefault(r => r.Id == id && r.Enabled);
                    if (recomm != null && status)
                    {
                        recomm.Status = true;

                        recomm.Updated = DateTime.Now;
                        db.SaveChanges();
                        return Ok("The recommendation has been accepted");

                    }
                    else if (recomm != null && !status)
                    {
                        recomm.Status = false;
                        db.SaveChanges();
                        return Ok("The recommendation has been rejected");

                    }
                    else
                    {
                        return NotFound();
                    }
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