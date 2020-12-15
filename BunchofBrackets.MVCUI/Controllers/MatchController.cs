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
    public class MatchController : Controller
    {
        // GET: Match
        public ActionResult Index()
        {
            return View();
        }

        // GET: Match/Details/5
        public PartialViewResult Details(Guid id)
        {
            return PartialView(id);
        }

        // GET: Match/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Match/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }




        // GET: Match/Edit/5
        public ActionResult Edit(Guid id)
        {
            var matchBracket = new MatchBracket(MatchManager.LoadById(id));

            if (Authenticate.IsParticipant(matchBracket.Match) || Authenticate.IsModerator(matchBracket.Bracket))
            {
                return View(matchBracket);
            }
            else
            {
                //TODO: Direct user to page that says they can't edit that match. possibly gray out matches that they are not part of 
                return RedirectToAction("Detail", "Bracket", new { returnurl = HttpContext.Request.Url });
            }
        }



        // POST: Match/Edit/5
        [HttpPost]
        public ActionResult Edit(MatchBracket matchBracket)
        {
            try
            {
                User user = (User)Session["user"];
                matchBracket.Match = MatchManager.LoadById(matchBracket.MatchId);
                matchBracket.Match.ReportingPlayer = user;
                matchBracket.Match.Winner = UserManager.LoadById(matchBracket.WinnerId);

                MatchManager.Update(matchBracket.Match);
                matchBracket.Bracket = BracketManager.LoadById(matchBracket.BracketId);

                if (matchBracket.Match.Winner != null)
                {
                    bool isDivisionOver = true;
                    for (int i = matchBracket.Bracket.GetFirstRoundOfDivision() - 1; i < matchBracket.Bracket.GetLastRoundOfDivision(); i++)
                    {
                        isDivisionOver = matchBracket.Bracket.SortedMatches[i].Winner != null;
                        //end the loop if any of the matches are not finished
                        if (isDivisionOver == false) break;
                    }

                    if (isDivisionOver)
                    {
                        for (int i = matchBracket.Bracket.GetFirstRoundOfDivision() - 1; i < matchBracket.Bracket.GetLastRoundOfDivision(); i += 2)
                        {
                            Match match = new Match();
                            match.Round = (int)Math.Ceiling((double)matchBracket.Bracket.SortedMatches[i].Round / 2) + matchBracket.Bracket.OriginalRoundCount;
                            if (i + 1 == matchBracket.Bracket.GetLastRoundOfDivision())
                            {
                                match.Player1 = matchBracket.Bracket.SortedMatches[i].Winner;
                                match.ReportingPlayer = match.Player1;
                                match.Winner = match.Player1;
                                match.Division = matchBracket.Bracket.CurrentDivision + 1;
                            }
                            else
                            {
                                match.Player1 = matchBracket.Bracket.SortedMatches[i].Winner;
                                match.Player2 = matchBracket.Bracket.SortedMatches[i + 1].Winner;
                                match.Division = matchBracket.Bracket.CurrentDivision + 1;
                            }
                            matchBracket.Bracket.Matches.Add(match);
                            MatchManager.Insert(match, matchBracket.Bracket.Id);
                        }
                        matchBracket.Bracket.CurrentDivision++;
                        BracketManager.Update(matchBracket.Bracket);
                    }
                }
                return RedirectToAction("Details", "Bracket", new { @id = matchBracket.BracketId });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // GET: Match/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Match/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
