using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StackOverflow.ServiceLayer.Interfaces;
using StackOverflow.ViewModels;

namespace Stackoverflow.APIController
{
    public class AccountController : ApiController
    {
        private readonly IUsersService _usersService;

        public AccountController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        
        public string Get(string email)
        {
            UserViewModel model = _usersService.GetUserByEmail(email);
            if (model!=null)
            {
                return "Found";
            }
            else
            {
                return "Not Found";
            }
        }
    }
}
