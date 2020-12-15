using BunchofBrackets.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunchofBrackets.BL
{
    public static class AccountManager
    {
        private static string GetHash(string passcode)
        {
            using (var hash = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(passcode);
                return Convert.ToBase64String(hash.ComputeHash(hashbytes));
            }
        }

        public static bool Login(User user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.Username.ToString()))
                {
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        using (BoBEntities bob = new BoBEntities())
                        {
                            tblUser tblUser = bob.tblUsers.FirstOrDefault(u => u.Username == user.Username);
                            if (tblUser != null)
                            {
                                //Check password
                                if (tblUser.Password == GetHash(user.Password))
                                {
                                    //User could login
                                    user.FirstName = tblUser.FirstName;
                                    user.LastName = tblUser.LastName;
                                    user.ImageSource = tblUser.ImageSource;
                                    user.Id = tblUser.Id;
                                    return true;
                                }
                                else
                                {
                                    throw new Exception("Could not login with these credentials");
                                }
                            }
                            else
                            {
                                throw new Exception("UserId could not be found");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Password was not set");
                    }
                }
                else
                {
                    throw new Exception("UserId was not set");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
