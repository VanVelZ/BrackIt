using BunchofBrackets.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BunchofBrackets.MVCUI.ViewModels
{
    public class SearchResults
    {
        public string SearchTerm { get; set; } = "";
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Bracket> Brackets { get; set; }
    }
}