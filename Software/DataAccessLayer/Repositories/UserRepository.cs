using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : Repository<USER>
    {
        public UserRepository() :base (new DataBase())
        {
            
        }

        public override int Add(USER entity, bool saveChanges = true)
        {
            var user = new USER
            {
                username = entity.username,
                email = entity.email,
                password = entity.password,
                userTypeID = entity.userTypeID,
                totalPoints = entity.totalPoints,
            };
            Entities.Add(user);
            if(saveChanges)
            {
                return SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public bool UserExists(string email)
        {
           return Entities.Any<USER>(u => u.email == email);
        }

        public bool UsernameExists(string username)
        {
            return Entities.Any<USER>(u => u.username == username);
        }

        public USER GetUserByUsername(string username)
        {
            return Entities.FirstOrDefault(u => u.username == username);
        }

        public void UpdateUserScore(string username, int newScore)
        {
            var user = Entities.FirstOrDefault(u => u.username == username);
            if (user != null)
            {
                user.totalPoints += newScore; 
                SaveChanges();
            }
        }

        public List<USER> GetTopPlayers(int topN)
        {
            var users = Entities.OrderByDescending(u => u.totalPoints)
                        .Take(topN)
                        .ToList() 
                        .Select(u => new USER
                        {
                            username = u.username,
                            totalPoints = u.totalPoints
                        })
                        .ToList();

            return users;
        }

        public int GetUserIdByUsername(string username)
        {
            var user = Entities.FirstOrDefault(u => u.username == username);
            if (user != null)
            {
                return user.userID;
            }
            else
            {
                throw new Exception("User not found.");
            }
        }
    }
}
