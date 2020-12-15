using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunchofBrackets.BL.Models
{
    public class Relationship : DataModel
    {
        public User Friend1 { get; set; }
        public User Friend2 { get; set; }
        public DateTime StartDate { get; set; }
        public bool isFriend { get; set; }
    }
}
