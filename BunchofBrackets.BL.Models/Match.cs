using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunchofBrackets.BL.Models
{
    public class Match : DataModel
    {
        public User Player1 { get; set; }
        public int Round { get; set; }
        public Guid BracketId { get; set; }
        public int Division { get; set; }
#nullable enable
        public User? Player2 { get; set; } = new User();
        public User? ReportingPlayer { get; set; } = new User();
        public User? Winner { get; set; } = new User();
        public DateTime? DueDate { get; set; }
        public DateTime? ScheduledDate { get; set; }
    }
}
