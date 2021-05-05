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
        private IUsersRepository _usersRepository;

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
            throw new NotImplementedException();
        }

        public UserViewModel GetUserByEmailAndPassword(string email, string password)
        {
            throw new NotImplementedException();
        }

        public UserViewModel GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public UserViewModel GetUserByUserId(int userid)
        {
            throw new NotImplementedException();
        }
    }
}
