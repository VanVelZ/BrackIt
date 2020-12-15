using BunchofBrackets.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunchofBrackets.BL
{
    public static class UserManager
    {
        public static List<User> Load()
        {

            using (BoBEntities bob = new BoBEntities())
            {
                List<User> users = new List<User>();
                bob.tblUsers
                    .ToList()
                    .ForEach(u => users.Add(new BL.User
                    {
                        Id = u.Id,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Password = u.Password,
                        Username = u.Username,
                        ImageSource = u.ImageSource
                      
                    }));
                return users;

            }
        }
        public static User LoadById(Guid id)
        {
            using (BoBEntities bob = new BoBEntities())
            {
                tblUser row = bob.tblUsers.FirstOrDefault(u => u.Id == id);
                return new User { Id = row.Id, FirstName = row.FirstName, LastName = row.LastName, Username = row.Username, ImageSource = row.ImageSource, Password = row.Password };
            }
        }
        public static User LoadById(Guid? id)
        {
                if(id == Guid.Empty)
                {
                    return null;
                }
                else
                {
                    return LoadById((Guid)id);
                }
            
        }

        public static int Insert(User user)
        {

            using (BoBEntities bob = new BoBEntities())
            {
                tblUser row = new tblUser
                {
                    Id = Guid.NewGuid(),
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Password = GetHash(user.Password),
                    Username = user.Username,
                    ImageSource = user.ImageSource
                };
                bob.tblUsers.Add(row);
                user.Id = row.Id;
                user.Password = row.Password;
                return bob.SaveChanges();
            }
        }
        public static int Update(User user)
        {
            using (BoBEntities bob = new BoBEntities())
            {
                tblUser row = bob.tblUsers.FirstOrDefault(c => c.Id == user.Id);
                int results = 0;
                if (row != null)
                {
                    row.FirstName = user.FirstName;
                    row.LastName = user.LastName;
                    row.Password = GetHash(user.Password);
                    row.Username = user.Username;
                    row.ImageSource = user.ImageSource;

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
                    tblUser row = bob.tblUsers.FirstOrDefault(c => c.Id == id);
                    int results = 0;
                    if (row != null)
                    {
                        bob.tblUsers.Remove(row);
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
