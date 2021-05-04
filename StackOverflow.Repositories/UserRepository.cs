using System.Collections.Generic;
using System.Linq;
using StackOverflow.DomainModels;
using StackOverflow.Repositories.Interfaces;

namespace StackOverflow.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly  StackOverflowDbContext db;

        public UsersRepository()
        {
            db = new StackOverflowDbContext();
        }
        public void InsertUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void UpdateUserDetails(User user)
        {
            User updateUser = db.Users.FirstOrDefault(u => u.UserId == user.UserId);
            if (updateUser!=null)
            {
                updateUser.Name = user.Name;
                //cannot change email
                updateUser.Mobile = user.Mobile;
                db.SaveChanges();
            }
        }

        public void UpdateUserPassword(User user)
        {
            User updateUser = db.Users.FirstOrDefault(u => u.UserId == user.UserId);
            if (updateUser != null)
            {
                updateUser.PasswordHash = user.PasswordHash;
                db.SaveChanges();
            }
        }

        public void DeleteUser(int userid)
        {
            User deleteUser = db.Users.FirstOrDefault(u => u.UserId == userid);
            if (deleteUser != null)
            {
                db.Users.Remove(deleteUser);
                db.SaveChanges();
            }
        }

        public List<User> GetUsers()
        {
            List<User> users = db.Users.Where(u => u.IsAdmin == false).OrderBy(u => u.Name).ToList();
            return users;
        }

        
        public List<User> GetUsersByEmailAndPassword(string email, string password)
        {
            List<User> users = db.Users.Where(u => u.Email == email && u.PasswordHash==password).ToList();
            return users;
        }

        public List<User> GetUserByEmail(string email)
        {
            List<User> users = db.Users.Where(u => u.Email == email).ToList();
            return users;
        }

        public List<User> GetsUsersById(int userid)
        {
            List<User> users = db.Users.Where(u => u.UserId == userid).ToList();
            return users;
        }

        public int GetLatestUserId()
        {
            int latestId = db.Users.Max(u => u.UserId);
            return latestId;
        }
    }
}
