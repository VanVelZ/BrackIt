using BunchofBrackets.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunchofBrackets.BL
{
    public class Team : DataModel
    {
        public string Name { get; set; }
        public List<User> Members { get; set; }
        public string ImageSource { get; set; }
        public List<Message> Messages { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
