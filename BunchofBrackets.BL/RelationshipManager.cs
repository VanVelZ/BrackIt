using BunchofBrackets.BL.Models;
using BunchofBrackets.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BunchofBrackets.BL
{
    public static class RelationshipManager
    {
        public static List<Relationship> LoadAll(User user)
        {
            using (BoBEntities bob = new BoBEntities())
            {
                List<Relationship> friends = new List<Relationship>();

                bob.tblRelationships
                    .Where(f => f.FriendId == user.Id || f.SenderId == user.Id)
                    .ToList()
                    .ForEach(f => friends.Add(new Relationship
                    {
                        Id = f.Id,
                        Friend1 = UserManager.LoadById(f.SenderId),
                        Friend2 = UserManager.LoadById(f.FriendId),
                        StartDate = f.FriendDate,
                        isFriend = f.isFriend
                    }));
                return friends;
            }
        }
        public static List<Relationship> LoadUnapprovedSent(User user)
        {
            using (BoBEntities bob = new BoBEntities())
            {
                List<Relationship> friends = new List<Relationship>();

                bob.tblRelationships
                    .Where(f => f.SenderId == user.Id && !f.isFriend)
                    .ToList()
                    .ForEach(f => friends.Add(new Relationship
                    {
                        Id = f.Id,
                        Friend1 = UserManager.LoadById(f.SenderId),
                        Friend2 = UserManager.LoadById(f.FriendId),
                        StartDate = f.FriendDate,
                        isFriend = f.isFriend
                    }));
                return friends;
            }
        }
        public static List<Relationship> LoadUnapprovedReceived(User user)
        {
            using (BoBEntities bob = new BoBEntities())
            {
                List<Relationship> friends = new List<Relationship>();

                bob.tblRelationships
                    .Where(f => f.FriendId == user.Id && !f.isFriend)
                    .ToList()
                    .ForEach(f => friends.Add(new Relationship
                    {
                        Id = f.Id,
                        Friend1 = UserManager.LoadById(f.SenderId),
                        Friend2 = UserManager.LoadById(f.FriendId),
                        StartDate = f.FriendDate,
                        isFriend = f.isFriend
                    }));
                return friends;
            }
        }
        public static bool isRelated(User user1, User user2 )
        {
            using (BoBEntities bob = new BoBEntities())
            {

                
                return bob.tblRelationships
                    .Where(f => (f.FriendId == user1.Id || f.SenderId == user1.Id) && (f.FriendId == user2.Id || f.SenderId == user2.Id)).Count() 
                    == 1;
            }

        }

        public static Relationship LoadById(Guid id)
        {
            using (BoBEntities bob = new BoBEntities())
            {
                tblRelationship row = bob.tblRelationships.FirstOrDefault(r => r.Id == id);

                Relationship relationship = new Relationship
                {
                    Id = row.Id,
                    Friend1 = UserManager.LoadById(row.SenderId),
                    Friend2 = UserManager.LoadById(row.FriendId),
                    isFriend = row.isFriend,
                    StartDate = row.FriendDate
                };
                return relationship;
            }
        }

        public static List<User> LoadFriends(User user)
        {
            using (BoBEntities bob = new BoBEntities())
            {
                List<Relationship> friends = new List<Relationship>();

                bob.tblRelationships
                    .Where(f => (f.FriendId == user.Id || f.SenderId == user.Id) && f.isFriend)
                    .ToList()
                    .ForEach(f => friends.Add(new Relationship
                    {
                        Id = f.Id,
                        Friend1 = UserManager.LoadById(f.SenderId),
                        Friend2 = UserManager.LoadById(f.FriendId),
                        StartDate = f.FriendDate,
                        isFriend = f.isFriend
                    }));

                List<User> users = new List<User>();
                foreach(var friend in friends)
                {
                    if (friend.Friend1 == user)
                    {
                        users.Add(friend.Friend2);
                    }
                    else
                    {
                        users.Add(friend.Friend1);

                    }
                }
                return users;
            }
        }
        public static int Insert(Relationship relationship)
        {
            using (BoBEntities bob = new BoBEntities())
            {
                tblRelationship row = new tblRelationship
                {
                    Id = Guid.NewGuid(),
                    SenderId = relationship.Friend1.Id,
                    FriendId = relationship.Friend2.Id,
                    isFriend = relationship.isFriend,
                    FriendDate = DateTime.Now
                };
                relationship.Id = row.Id;
                bob.tblRelationships.Add(row);
                return bob.SaveChanges();
            }

        }
        public static int Update(Relationship relationship)
        {
            using (BoBEntities bob = new BoBEntities())
            {
                tblRelationship row = bob.tblRelationships.FirstOrDefault(r => relationship.Id == r.Id);

                row.isFriend = relationship.isFriend;

                return bob.SaveChanges();
            }
        }
        public static int Delete(Guid id)
        {
            using (BoBEntities bob = new BoBEntities())
            {
                tblRelationship row = bob.tblRelationships.FirstOrDefault(r => id == r.Id);

                bob.tblRelationships.Remove(row);

                return bob.SaveChanges();
            }
        }
    }
}
