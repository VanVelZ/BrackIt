using BunchofBrackets.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BunchofBrackets.MVCUI.ViewModels
{
    public class Profile
    {
        public User LoggedInUser { get; set; }
        public User ProfileUser { get; set; }
        public IEnumerable<Bracket> Brackets { get; set; }
    }
}