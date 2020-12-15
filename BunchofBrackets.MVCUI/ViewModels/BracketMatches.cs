using BunchofBrackets.BL;
using BunchofBrackets.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BunchofBrackets.MVCUI.ViewModels
{
    public class BracketMatches
    {
        public Bracket Bracket { get; set; }
        public IEnumerable<Match> Matches { get; set; }
        public User ViewingUser { get; set; }

        public BracketMatches()
        {

        }
        public BracketMatches(Bracket bracket, List<Match> matches)
        {
            Bracket = bracket;
            Matches = matches.OrderBy(m => m.Round);
        }
    }
}