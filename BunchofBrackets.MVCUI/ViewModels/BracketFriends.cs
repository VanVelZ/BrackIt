using BunchofBrackets.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace BunchofBrackets.MVCUI.ViewModels
{
    public class BracketFriends 
    { 
        public Bracket Bracket { get; set; }

        [DisplayName("Select Participants")]
        public IEnumerable<Guid> SelectedPlayerIds { get; set; }
        public IEnumerable<User> Players { get; set; }
        public HttpPostedFileBase File { get; set; }

        public BracketFriends()
        {
        }
        public BracketFriends(List<User> players, Bracket bracket)
        {
            Players = players;
            Bracket = bracket;
            SelectedPlayerIds = Helper.ObjectManipulation.GetIds(players);
        }
    }
}