using BunchofBrackets.BL.Models;
using BunchofBrackets.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunchofBrackets.BL
{
    public static class BracketManager
    {
        public static List<Bracket> Load()
        {
            using (BoBEntities bob = new BoBEntities())
            {
                List<Bracket> brackets = new List<Bracket>();
                bob.tblBrackets
                    .ToList()
                    .ForEach(b => brackets.Add(new Bracket
                    {
                        Id = b.Id,
                        Moderator = UserManager.LoadById(b.ModeratorId),
                        Name = b.Name,
                        ImageSource = b.ImageSource,
                        Matches = MatchManager.Load(b.Id),
                        Game = b.Game,
                        OriginalRoundCount = b.OriginalRoundCount,
                        CurrentDivision = b.CurrentDivision
                        
                    }));
                return brackets;

            }
        }
        public static Bracket LoadById(Guid id)
        {
            using (BoBEntities bob = new BoBEntities())
            {
                tblBracket row = bob.tblBrackets
                    .FirstOrDefault(b => b.Id == id);
                return new BL.Bracket { CurrentDivision = row.CurrentDivision, Id = row.Id, ImageSource = row.ImageSource, Moderator = UserManager.LoadById(row.ModeratorId), Name = row.Name, Matches = MatchManager.Load(row.Id), Game = row.Game, OriginalRoundCount = row.OriginalRoundCount };

            }
        }
        public static int Insert(Bracket bracket)
        {
            using (BoBEntities bob = new BoBEntities())
            {
                tblBracket row = new tblBracket
                {
                    Id = Guid.NewGuid(),
                    Name = bracket.Name,
                    ImageSource = bracket.ImageSource,
                    ModeratorId = bracket.Moderator.Id,
                    Game = bracket.Game,
                    OriginalRoundCount = bracket.OriginalRoundCount,
                    CurrentDivision = bracket.CurrentDivision
                };

                bracket.Id = row.Id;
                if (bracket.Matches.Count > 0)bracket.Matches.ForEach(m => MatchManager.Insert(m, bracket.Id));
                bob.tblBrackets.Add(row);
                return bob.SaveChanges();
            }
        }
        public static int Update(Bracket bracket)
        {
            using (BoBEntities bob = new BoBEntities())
            {
                tblBracket row = bob.tblBrackets.FirstOrDefault(c => c.Id == bracket.Id);
                int results = 0;
                if (row != null)
                {
                    row.Name = bracket.Name;
                    row.ModeratorId = bracket.Moderator.Id;
                    row.ImageSource = bracket.ImageSource;
                    row.OriginalRoundCount = bracket.OriginalRoundCount;
                    row.Game = bracket.Game;
                    row.CurrentDivision = bracket.CurrentDivision;
                    results = bob.SaveChanges();
                }
                else
                {
                    throw new Exception("Row was not found");
                }
                return results;
            }
        }
        public static int Delete(Guid id)
        {
            try
            {
                using (BoBEntities bob = new BoBEntities())
                {
                    tblBracket row = bob.tblBrackets.FirstOrDefault(c => c.Id == id);
                    int results = 0;
                    if (row != null)
                    {
                        bob.tblBrackets.Remove(row);
                        results = bob.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row was not found");
                    }
                    return results;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
