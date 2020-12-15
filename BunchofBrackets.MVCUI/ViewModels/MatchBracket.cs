using BunchofBrackets.BL;
using BunchofBrackets.BL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BunchofBrackets.MVCUI.ViewModels
{
    public class MatchBracket
    {
        public Match Match { get; set; }
        public Bracket Bracket { get; set; }
        [DisplayName("Choose a Winner")]
        public Guid WinnerId { get; set; }
        public IEnumerable<User> Participants { get; set; }
        public Guid MatchId { get; set; }
        public Guid BracketId { get; set; }
        public MatchBracket()
        {

        }
        public MatchBracket(Match match)
        {
            Match = match;
            Bracket = BracketManager.LoadById(Match.BracketId);
            List<User> users = new List<User>();
            users.Add(match.Player1);
            users.Add(match.Player2);
            Participants = users;
            MatchId = Match.Id;
            BracketId = Bracket.Id;
        }
    }
}