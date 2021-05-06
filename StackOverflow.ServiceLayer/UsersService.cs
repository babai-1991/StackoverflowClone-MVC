using System;
using System.Collections.Generic;
using AutoMapper;
using StackOverflow.DomainModels;
using StackOverflow.Repositories;
using StackOverflow.Repositories.Interfaces;
using StackOverflow.ServiceLayer.Interfaces;
using StackOverflow.ViewModels;

namespace StackOverflow.ServiceLayer
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService()
        {
            _usersRepository = new UsersRepository();
        }
        public int InsertUser(RegisterViewModel registerViewModel)
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.CreateMap<RegisterViewModel, User>();
                config.IgnoreUnMapped();
            });

            IMapper mapper = configuration.CreateMapper();

            User user = mapper.Map<RegisterViewModel, User>(registerViewModel);
            user.PasswordHash = Sha256HashGenerator.GenerateHash(registerViewModel.Password);
            _usersRepository.InsertUser(user);
            int latestUserId = _usersRepository.GetLatestUserId();
            return latestUserId;
        }

        public void UpdateUserDetails(EditUserDetailsViewModel editUserDetailsViewModel)
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.CreateMap<EditUserDetailsViewModel, User>();
                config.IgnoreUnMapped();
            });

            IMapper mapper = configuration.CreateMapper();

            User user = mapper.Map<EditUserDetailsViewModel, User>(editUserDetailsViewModel);
            _usersRepository.UpdateUserDetails(user);

        }

        public void UpdateUserPassword(EditUserPasswordViewModel editUserPasswordViewModel)
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.CreateMap<EditUserPasswordViewModel, User>();
                config.IgnoreUnMapped();
            });

            IMapper mapper = configuration.CreateMapper();

            User user = mapper.Map<EditUserPasswordViewModel, User>(editUserPasswordViewModel);
            user.PasswordHash = Sha256HashGenerator.GenerateHash(editUserPasswordViewModel.Password);
            _usersRepository.UpdateUserPassword(user);
        }

        public void DeleteUser(int userId)
        {
            _usersRepository.DeleteUser(userId);
        }

        public List<UserViewModel> GetAllUsers()
        {
            List<User> users = _usersRepository.GetUsers();

            var configuration = new MapperConfiguration(config =>
            {
                config.CreateMap<User, UserViewModel>();
                config.IgnoreUnMapped();
            });

            IMapper mapper = configuration.CreateMapper();

            List<UserViewModel> usersList = mapper.Map<List<User>, List<UserViewModel>>(users);
            return usersList;
        }

        public UserViewModel GetUserByEmailAndPassword(string email, string password)
        {
            UserViewModel model = null;
            var passwordHash = Sha256HashGenerator.GenerateHash(password);
            User users = _usersRepository.GetUsersByEmailAndPassword(email, passwordHash);

            if (users != null)
            {
                var configuration = new MapperConfiguration(config =>
                {
                    config.CreateMap<User, UserViewModel>();
                    config.IgnoreUnMapped();
                });

                IMapper mapper = configuration.CreateMapper();
                model = mapper.Map<User, UserViewModel>(users);
            }
            return model;
        }

        public UserViewModel GetUserByEmail(string email)
        {
            UserViewModel model = null;
            User user = _usersRepository.GetUserByEmail(email);

            if (user != null)
            {
                var configuration = new MapperConfiguration(config =>
                {
                    config.CreateMap<User, UserViewModel>();
                    config.IgnoreUnMapped();
                });

                IMapper mapper = configuration.CreateMapper();
                model = mapper.Map<User, UserViewModel>(user);
            }
            return model;
        }

        public UserViewModel GetUserByUserId(int userid)
        {
            UserViewModel model = null;
            User user = _usersRepository.GetsUsersById(userid);

            if (user != null)
            {
                var configuration = new MapperConfiguration(config =>
                {
                    config.CreateMap<User, UserViewModel>();
                    config.IgnoreUnMapped();
                });

                IMapper mapper = configuration.CreateMapper();
                model = mapper.Map<User, UserViewModel>(user);
            }
            return model;
        }
    }
}
