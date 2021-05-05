using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverflow.ViewModels;

namespace StackOverflow.ServiceLayer.Interfaces
{
    interface IUsersService
    {
        int InsertUser(RegisterViewModel registerViewModel);
        void UpdateUserDetails(EditUserDetailsViewModel editUserDetailsViewModel);
        void UpdateUserPassword(EditUserPasswordViewModel editUserPasswordViewModel);
        void DeleteUser(int userId);
        List<UserViewModel> GetAllUsers();
        UserViewModel GetUserByEmailAndPassword(string email,string password);
        UserViewModel GetUserByEmail(string email);
        UserViewModel GetUserByUserId(int userid);
    }
}
