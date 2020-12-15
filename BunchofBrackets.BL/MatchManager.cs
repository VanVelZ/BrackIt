using BunchofBrackets.BL.Models;
using BunchofBrackets.PL;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System;

namespace BunchofBrackets.BL
{
    public static class MatchManager
    {
        public static List<Match> Load()
        {
            using (BoBEntities bob = new BoBEntities())
            {
                List<Match> matches = new List<Match>();
                bob.tblMatches
                    .ToList()
                    .ForEach(m => matches.Add(new Match
                    {
                        Id = m.Id,
                        Player1 = UserManager.LoadById(m.Team1),
                        Player2 = UserManager.LoadById(m.Team2),
                        Winner = UserManager.LoadById(m.Outcome),
                        BracketId = m.BracketId,
                        ReportingPlayer = UserManager.LoadById(m.ReportingPlayer),
                        Round = m.Round,
                        Division = m.Division
                    }));
                return matches;
            }
        }
        public static List<Match> Load(Guid bracketId)
        {
            using (BoBEntities bob = new BoBEntities())
            {
                List<Match> matches = new List<Match>();
                List<tblMatch> tblmatches = bob.tblMatches
                    .Where(m => m.BracketId == bracketId).ToList();
                tblmatches
                    .ForEach(m => matches.Add(new Match
                    {
                        Id = m.Id,
                        Player1 = UserManager.LoadById(m.Team1),
                        Player2 = UserManager.LoadById(m.Team2),
                        Winner = UserManager.LoadById(m.Outcome),
                        BracketId = m.BracketId,
                        ReportingPlayer = UserManager.LoadById(m.ReportingPlayer),
                        Round = m.Round,
                        Division = m.Division
                    }));
                return matches;
            }
        }
        public static Match LoadById(Guid id)
        {
            using (BoBEntities bob = new BoBEntities())
            {
                tblMatch row = bob.tblMatches.FirstOrDefault(m => m.Id == id);
                return new Match
                {
                    Id = row.Id,
                    Player1 = UserManager.LoadById(row.Team1),
                    Player2 = UserManager.LoadById(row.Team2),
                    Winner = UserManager.LoadById(row.Outcome),
                    BracketId = row.BracketId,
                    ReportingPlayer = UserManager.LoadById(row.ReportingPlayer),
                    Round = row.Round,
                    Division = row.Division
                };
            }

        }
        public static int Insert(Match match, Guid bracketid)
        {
            using (BoBEntities bob = new BoBEntities())
            {
                tblMatch row = new tblMatch
                {
                    Id = Guid.NewGuid(),
                    Team1 = match.Player1.Id,
                    Team2 = match.Player2.Id,
                    Outcome = match.Winner.Id,
                    BracketId = bracketid,
                    ReportingPlayer = match.ReportingPlayer.Id,
                    Round = match.Round,
                    Division = match.Division
                };
                match.Id = row.Id;
                bob.tblMatches.Add(row);
                return bob.SaveChanges();
            }
        }
        public static int Update(Match match)
        {
            using (BoBEntities bob = new BoBEntities())
            {
                tblMatch row = bob.tblMatches.FirstOrDefault(m => m.Id == match.Id);
                if(row != null)
                {
                    row.Team1 = match.Player1.Id;
                    row.Team2 = match.Player2.Id;
                    row.Outcome = match.Winner.Id;
                    row.ReportingPlayer = match.ReportingPlayer.Id;
                    row.Round = match.Round;
                    row.Division = match.Division;
                }
                return bob.SaveChanges();
            }
        }
        public static int Delete(Guid id)
        {

            using (BoBEntities bob = new BoBEntities())
            {
                tblMatch row = bob.tblMatches.FirstOrDefault(m => m.Id == id);

                if (row != null) bob.tblMatches.Remove(row);
                return bob.SaveChanges();
            }
        }

    }
}
