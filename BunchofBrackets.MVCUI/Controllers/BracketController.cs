using BunchofBrackets.BL;
using BunchofBrackets.BL.Models;
using BunchofBrackets.MVCUI.Helper;
using BunchofBrackets.MVCUI.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Web;
using System.Web.Mvc;

namespace BunchofBrackets.MVCUI.Controllers
{
    public class BracketController : Controller
    {
        // GET: Bracket
        public ActionResult Index()
        {
            return View(BracketManager.Load());
        }
        public ActionResult List(Guid id)
        {
            User user = UserManager.LoadById(id);
            List<Bracket> brackets = BracketManager.Load().Where(b => b.Moderator.Id == user.Id || Authenticate.IsParticipant(b, user)).ToList();
            return View(brackets);
        }
        public ActionResult Details(Guid id)
        {
            if (Authenticate.IsAuthenticated())
            {
                Bracket b = BracketManager.LoadById(id);
                BracketMatches bm = new BracketMatches(b, b.SortedMatches);
                bm.ViewingUser = (User)Session["user"];
                b.Matches.Where(m => m.Player2 == null).ForEach(m => m.Player2 = new BL.User());
                return View("Details", bm);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }


        public ActionResult Create()
        {
            if (Authenticate.IsAuthenticated()) {
                Bracket bracket = new Bracket();
                User user = (User)Session["user"];
                
                user.Friends = RelationshipManager.LoadFriends(user);
                
                BracketFriends bracketFriends = new BracketFriends(user.Friends, bracket);

                return View(bracketFriends);
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }
        [HttpPost]
        public ActionResult Create(BracketFriends bracketFriends)
        {
            if (Authenticate.IsAuthenticated())
            {
                List<Guid> ids = bracketFriends.SelectedPlayerIds.ToList();


                Bracket bracket = bracketFriends.Bracket;
                if (bracketFriends.File != null)
                {
                    bracket.ImageSource = bracketFriends.File.FileName;
                    string target = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(bracketFriends.File.FileName));

                    if (!System.IO.File.Exists(target))
                    {
                        bracketFriends.File.SaveAs(target);
                        ViewBag.Message = "File Uploaded Successfully";
                    }
                    else
                    {

                        ViewBag.Message = "File did not upload";
                    }
                }
                bracket.CurrentDivision = 1;
                bracket.Matches = Helper.ObjectManipulation.DivideIntoMatches(ids);

                bracket.Moderator = (User)Session["user"];
                bracket.OriginalRoundCount = bracket.Matches.Count;

                BracketManager.Insert(bracket);

                return RedirectToAction("Details", new {@id = bracket.Id });
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }
        public ActionResult Edit(Guid id)
        {
            if (Authenticate.IsAuthenticated())
            {
                return View(BracketManager.LoadById(id));
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }
        [HttpPost]
        public ActionResult Edit(Bracket bracket)
        {
            try
            {
                // TODO: Add update logic here
                BracketManager.Update(bracket);
                return RedirectToAction("Home");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(bracket);
            }
        }
        public ActionResult Delete(Guid id)
        {
            if (Authenticate.IsAuthenticated())
            {
                return View(BracketManager.LoadById(id));
            }
            else
            {
                return RedirectToAction("Login", "User", new { returnurl = HttpContext.Request.Url });
            }
        }
        [HttpDelete]
        public ActionResult Delete(Bracket bracket)
        {
            try
            {
                // TODO: Add update logic here
                BracketManager.Delete(bracket.Id);
                return RedirectToAction("Home");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(bracket);
            }
        }
    }
}