using BunchofBrackets.BL;
using BunchofBrackets.MVCUI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Windows.Forms;

namespace BunchofBrackets.MVCUI.Controllers
{
    public class UserController : Controller
    {



        public ActionResult Login(string returnurl = "")
        {
            ViewBag.ReturnUrl = returnurl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user, string returnurl = "")
        {
            try
            {
                if (UserManager.Login(user))
                {
                    Session["user"] = user;
                    ViewBag.Message = "Welcome back " + user.FirstName;
                    if (returnurl == "")
                    {
                        return View("Detail", "User", user.Id);
                    }
                    return Redirect(returnurl);
                }
                ViewBag.Message("no dice");
                return View(user);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(user);
            }
        }
        public ActionResult Detail(Guid id)
        {
            if (Authenticate.IsAuthenticated() && id == Guid.Empty)
            {
                Profile profile = new Profile();
                profile.LoggedInUser = (User)Session["user"];
                profile.ProfileUser = (User)Session["user"];

                return View(profile);
            }
            else if (Authenticate.IsAuthenticated())
            {
                Profile profile = new Profile();
                profile.LoggedInUser = (User)Session["user"];
                profile.ProfileUser = UserManager.LoadById(id);
                return View(profile);

            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }

        }
        public ActionResult Edit(Guid id)
        {
           User user = new User();
           user = UserManager.LoadById(id); 
           return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                if (user.File != null)
                {
                    user.ImageSource = user.File.FileName;
                    string target = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(user.File.FileName));

                    if (!System.IO.File.Exists(target))
                    {
                        user.File.SaveAs(target);
                        ViewBag.Message = "File Uploaded Successfully";
                    }
                    else
                    {

                        ViewBag.Message = "File did not upload";
                    }
                }
                else
                {
                    user.FirstName = "profile.png";
                }
                    UserManager.Update(user);
                    return RedirectToAction("Detail", user.Id);
                
            }
            catch 
            {

                return View();
            }
            
        }
        public ActionResult Logout()
        {
            if (Authenticate.IsAuthenticated())
            {
                Session["user"] = null;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }

        [HttpGet]
        public ActionResult Get()
        {
            return View(UserManager.Load());
        }
        public ActionResult Create()
        {
            User user = new User();
            return View(user);
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                if (user.Password == user.ConfirmationPassword)
                {
                    if (user.File != null)
                    {
                        user.ImageSource = user.File.FileName;
                        string target = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(user.File.FileName));

                        if (!System.IO.File.Exists(target))
                        {
                            user.File.SaveAs(target);
                            ViewBag.Message = "File Uploaded Successfully";
                        }
                        else
                        {

                            ViewBag.Message = "File did not upload";
                        }
                    }
                    //if password and confirm are correct, do the thing
                    UserManager.Insert(user);

                    //logs in the user after account creation
                    Session["user"] = user;
                    ViewBag.Message = "Welcome " + user.FirstName;

                    return RedirectToAction("Detail", "User", new {id = user.Id });

                }
                else
                {
                    //go back to the create screen with the two fields blank
                    ViewBag.Message = "Passwords did not match";
                    user.Password = string.Empty;
                    user.ConfirmationPassword = string.Empty;
                    return View(user);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult InsertABunchOfUsers()
        {
            User me = new User
            {
                FirstName = "Zachary",
                LastName = "Vander Velden",
                Username = "zv",
                Password = "zv"
            };
            UserManager.Insert(me);
            User user = new User
            {
                FirstName = "Achraf",
                LastName = "Briki",
                Username = "ab",
                Password = "ab"
            };
            UserManager.Insert(user);
            RelationshipManager.Insert(new BL.Models.Relationship { Friend1 = user, Friend2 = me, isFriend = true });
            user = new User
            {
                FirstName = "Stephen",
                LastName = "Lee",
                Username = "sl",
                Password = "sl"
            };
            UserManager.Insert(user);
            RelationshipManager.Insert(new BL.Models.Relationship { Friend1 = user, Friend2 = me, isFriend = true });
            user = new User
            {
                FirstName = "Lydia",
                LastName = "Schmalz",
                Username = "ls",
                Password = "ls"
            };
            UserManager.Insert(user);
            RelationshipManager.Insert(new BL.Models.Relationship { Friend1 = user, Friend2 = me, isFriend = true });
            user = new User
            {
                FirstName = "Mary Kay",
                LastName = "Hinkson",
                Username = "hb",
                Password = "hb"
            };
            UserManager.Insert(user);
            RelationshipManager.Insert(new BL.Models.Relationship { Friend1 = user, Friend2 = me, isFriend = true });
            user = new User
            {
                FirstName = "Joe",
                LastName = "Wetzel",
                Username = "jw",
                Password = "jw"
            };
            UserManager.Insert(user);
            RelationshipManager.Insert(new BL.Models.Relationship { Friend1 = user, Friend2 = me, isFriend = true });
            user = new User
            {
                FirstName = "Brian",
                LastName = "Foote",
                Username = "bf",
                Password = "bf"
            };
            UserManager.Insert(user);
            RelationshipManager.Insert(new BL.Models.Relationship { Friend1 = user, Friend2 = me, isFriend = true });
            user = new User
            {
                FirstName = "Jebediah",
                LastName = "Jacobson",
                Username = "jj",
                Password = "jj"
            };
            UserManager.Insert(user);
            user = new User
            {
                FirstName = "Alex",
                LastName = "Arduino",
                Username = "aa",
                Password = "aa"
            };
            UserManager.Insert(user);
            user = new User
            {
                FirstName = "Brittany",
                LastName = "Bulldozer",
                Username = "bb",
                Password = "bb"
            };
            UserManager.Insert(user);
            user = new User
            {
                FirstName = "Courtney",
                LastName = "Carol",
                Username = "cc",
                Password = "cc"
            };
            UserManager.Insert(user);
            user = new User
            {
                FirstName = "Donna",
                LastName = "Draco",
                Username = "dd",
                Password = "dd"
            };
            UserManager.Insert(user);
            user = new User
            {
                FirstName = "Leon",
                LastName = "Soros",
                Username = "ls",
                Password = "ls"
            };
            UserManager.Insert(user);
            user = new User
            {
                FirstName = "Kory",
                LastName = "Killburn",
                Username = "ls",
                Password = "ls"
            };
            UserManager.Insert(user);
            user = new User
            {
                FirstName = "Ned",
                LastName = "Soros",
                Username = "ls",
                Password = "ls"
            };
            UserManager.Insert(user);
            user = new User
            {
                FirstName = "Lauren",
                LastName = "Ipsum",
                Username = "ls",
                Password = "ls"
            };
            UserManager.Insert(user);
            user = new User
            {
                FirstName = "Suzy",
                LastName = "Ipsum",
                Username = "ls",
                Password = "ls"
            };
            UserManager.Insert(user);
            user = new User
            {
                FirstName = "Tony",
                LastName = "Tiger",
                Username = "ls",
                Password = "ls"
            };
            UserManager.Insert(user);
            user = new User
            {
                FirstName = "Remmie",
                LastName = "Remmie",
                Username = "ls",
                Password = "ls"
            };
            UserManager.Insert(user);
            user = new User
            {
                FirstName = "Lu",
                LastName = "Tia",
                Username = "ls",
                Password = "ls"
            };
            UserManager.Insert(user);
            user = new User
            {
                FirstName = "Mario",
                LastName = "Mario",
                Username = "ls",
                Password = "ls"
            };
            UserManager.Insert(user);
            user = new User
            {
                FirstName = "Luigi",
                LastName = "Mario",
                Username = "ls",
                Password = "ls"
            };
            UserManager.Insert(user);
            user = new User
            {
                FirstName = "Barns",
                LastName = "Stevie",
                Username = "ls",
                Password = "ls"
            };
            UserManager.Insert(user);
            user = new User
            {
                FirstName = "Otto",
                LastName = "Names",
                Username = "ls",
                Password = "ls"
            };
            return RedirectToAction("Create", "Bracket");
        }

    }
}