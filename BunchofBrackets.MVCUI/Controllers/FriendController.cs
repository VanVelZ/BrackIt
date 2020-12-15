using BunchofBrackets.BL;
using BunchofBrackets.BL.Models;
using BunchofBrackets.MVCUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BunchofBrackets.MVCUI.Controllers
{
    public class FriendController : Controller
    {
        // GET: Friend
        public ActionResult FriendList()
        {
            if (Authenticate.IsAuthenticated())
            {
                return View(RelationshipManager.LoadFriends((User)Session["user"]));
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }
        public ActionResult AddFriend(User user)
        {
            if (Authenticate.IsAuthenticated())
            {
                User loggedinUser = (User)Session["user"];
                if (!RelationshipManager.isRelated(user, loggedinUser))
                {
                    Relationship relationship = new Relationship();
                    relationship.Friend1 = loggedinUser;
                    relationship.Friend2 = user;
                    relationship.isFriend = false;

                    RelationshipManager.Insert(relationship);

                    return View(user);
                }
                else
                {
                    ViewBag.Message = "You two are already friends";
                    return RedirectToAction("Detail", "User", new { id = user.Id });
                }
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }
        public ActionResult LoadRequests()
        {
            if (Authenticate.IsAuthenticated())
            {
                var requests = RelationshipManager.LoadUnapprovedReceived((User)Session["user"]);
                List<UsersRequest> ur = new List<UsersRequest>();
                foreach(var request in requests)
                {
                    ur.Add(new UsersRequest { Request = request, User = UserManager.LoadById(request.Friend1.Id) });
                }
                return View(ur);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }

        }
        public ActionResult Confirm(Guid id)
        {
            if (Authenticate.IsAuthenticated())
            {
                Relationship relationship = RelationshipManager.LoadById(id);
                relationship.Friend2 = ((User)Session["user"]);
                relationship.isFriend = true;
                relationship.StartDate = DateTime.Now;
                RelationshipManager.Update(relationship);
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }
        public ActionResult Deny(Guid id)
        {
            if (Authenticate.IsAuthenticated())
            {
                RelationshipManager.Delete(id);
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }
    }
}