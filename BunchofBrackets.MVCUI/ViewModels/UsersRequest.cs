using BunchofBrackets.BL;
using BunchofBrackets.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BunchofBrackets.MVCUI.ViewModels
{
    public class UsersRequest
    {
        public User User { get; set; }
        public Relationship Request { get; set; }
    }
}