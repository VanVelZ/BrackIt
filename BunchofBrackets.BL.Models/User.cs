using BunchofBrackets.BL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BunchofBrackets.BL
{
    public class User : DataModel
    {

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
       
        public string Password { get; set; }
        [DisplayName("Confirm Password")]
        public string ConfirmationPassword { get; set; }
        [DisplayName("Image")]
        public string ImageSource { get; set; } = "profile.png";
        public HttpPostedFileBase File { get; set; }
        [DisplayName("Username")]
        public string Username { get; set; }
        public List<User> Friends { get; set; }
        public string FullName { get{return FirstName + " " + LastName;}}

        public override string ToString()
        {
            return FullName;
        }
    }
}
