using BunchofBrackets.BL;
using BunchofBrackets.MVCUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BunchofBrackets.MVCUI.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(SearchResults sr)
        {

            return View(sr);
        }

        public ActionResult Results(string searchterm)
        {
            SearchResults sr = new SearchResults();
            List<User> allUsers = UserManager.Load();
            List<Bracket> allBracket = BracketManager.Load();
            if (searchterm == null) searchterm = "";
            sr.SearchTerm = searchterm.ToLower();
            sr.Users = allUsers.Where(u => u.FullName.ToLower().Contains(searchterm) || u.Username.ToLower().Contains(searchterm));
            sr.Brackets = allBracket.Where(u => u.Name.ToLower().Contains(searchterm) || u.Game.ToLower().Contains(searchterm));
            if (sr.Users.Count() < 1 && sr.Brackets.Count() < 1) ViewBag.Message = "There are no results found with that query";
            return View(sr);
        }
    }
}