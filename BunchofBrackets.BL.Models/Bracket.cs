using BunchofBrackets.BL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BunchofBrackets.BL
{
    public class Bracket : DataModel
    {
        public User Moderator { get; set; }
        public List<Guid> Players { get; set; } = new List<Guid>();
        [DisplayName("Bracket Name")]
        public string Name { get; set; }
        public List<Match> Matches { get; set; } = new List<Match>();
        public List<Match> SortedMatches { get
            {
                return Matches.OrderBy(m => m.Round).ToList();
            }
            set { }
        }
        [DisplayName("Game Category")]
        public string Game { get; set; }
        [DisplayName("Image")]
        public string ImageSource { get; set; } = "profile.png";
        public override string ToString()
        {
            return Name;
        }
        public int OriginalRoundCount { get; set; }
        [DisplayName("Current Division")]
        public int CurrentDivision { get; set; }


        public int FinalDivision
        {
            get
            {
                {
                    int division = 1;
                    double round = OriginalRoundCount;
                    while (round > 1)
                    {
                        round = round / 2;
                        division++;
                    }
                    return division;
                }
            }
        }


        public int GetLastRoundOfDivision()
        {
            int roundsfordivision = OriginalRoundCount;
            int round = OriginalRoundCount;

            for(int i = 1; i < CurrentDivision; i++)
            {
                roundsfordivision = (int)Math.Ceiling((decimal)roundsfordivision / 2);
                round += roundsfordivision;
            }
            return round;
        }
        public int GetFirstRoundOfDivision()
        {
            if (CurrentDivision == 1) return 1;

            int roundcount = OriginalRoundCount;
            int firstround = 1;

            for(int i = 2; i <= CurrentDivision; i++)
            {
                firstround += roundcount;
                roundcount = (int)Math.Ceiling((decimal)roundcount / 2);
            }
            return firstround;
        }
    }
}
