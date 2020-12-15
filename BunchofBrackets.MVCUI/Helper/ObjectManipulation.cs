using BunchofBrackets.BL;
using BunchofBrackets.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BunchofBrackets.MVCUI.Helper
{
    public static class ObjectManipulation
    {
        public static List<Guid> GetIds(List<User> items)
        {
            List<Guid> ids = new List<Guid>();
            foreach(DataModel item in items)
            {
                ids.Add(item.Id);
            }
            return ids;
        }
        public static List<Match> DivideIntoMatches(List<Guid> ids)
        {
            List<Match> matches = new List<Match>();

            ids.Shuffle();
            float matchcount = (ids.Count / 2.0f);
            int playercount = 0;
            for (int i = 0; i < Math.Ceiling(matchcount); i++)
            {
                if (playercount + 1 == ids.Count)
                {
                    matches.Add(new BL.Models.Match
                    {
                        Player1 = UserManager.LoadById(ids[playercount]),
                        ReportingPlayer = UserManager.LoadById(ids[playercount]),
                        Round = i + 1,
                        Division = 1,
                        Winner = UserManager.LoadById(ids[playercount])
                    }); 

                }
                else
                {
                    matches.Add(new BL.Models.Match
                    {
                        Player1 = UserManager.LoadById(ids[playercount]),
                        Player2 = UserManager.LoadById(ids[playercount + 1]),
                        Division = 1,
                        Round = i + 1
                    });
                }
                playercount += 2;
            }
            return matches;
        }
    }
}