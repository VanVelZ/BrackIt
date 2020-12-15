using BunchofBrackets.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunchofBrackets.BL
{
    public class Message:DataModel
    {
        public List<User> Users { get; set; }
        public String Contents { get; set; }
        public DateTime SendDate { get; set; }


        public override string ToString()
        {
            return Contents;
        }
    }
}
