using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunchofBrackets.BL
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Category> Categories { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
