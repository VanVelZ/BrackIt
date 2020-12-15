using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BunchofBrackets.BL;
using BunchofBrackets.BL.Models;

namespace BunchofBrackets
{
    public static class Authenticate
    {
        public static bool IsAuthenticated()
        {
            if (HttpContext.Current.Session == null) return false;
            else return HttpContext.Current.Session["user"] != null;
        }
        public static bool IsModerator(Bracket bracket)
        {
            if (IsAuthenticated())
            {
                User user = (User)HttpContext.Current.Session["user"];


                return user.Id == bracket.Moderator.Id;
            }
            else return false;
        }
        public static bool IsParticipant(Match match, User user = null)
        {
            if (IsAuthenticated())
            {
                if (user == null) user = (User)HttpContext.Current.Session["user"];
                if (match.Player2 == null && match.Player1.Id == user.Id) return true;
                else if (match.Player2 == null && match.Player1.Id != user.Id) return false;
                else return (user.Id == match.Player1.Id || user.Id == match.Player2.Id);
            }
            else return false;
        }
        public static bool IsParticipant(Bracket bracket, User user = null)
        {
            if (IsAuthenticated())
            {
                foreach(Match match in bracket.Matches)
                {
                    if (IsParticipant(match, user)) return true;
                }

                return false;
            }
            else return false;
        }
    }
}