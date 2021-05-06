using System.Collections.Generic;
using StackOverflow.DomainModels;

namespace StackOverflow.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        void InsertUser(User user);
        void UpdateUserDetails(User user);
        void UpdateUserPassword(User user);
        void DeleteUser(int userid);
        List<User> GetUsers();
        //required when login
        User GetUsersByEmailAndPassword(string email, string password);
        User GetUserByEmail(string email);
        User GetsUsersById(int userid);
        int GetLatestUserId();
    }
}