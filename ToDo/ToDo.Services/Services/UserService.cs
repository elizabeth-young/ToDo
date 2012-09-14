using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo.Common.Helpers;
using ToDo.Data;
using AutoMapper;

namespace ToDo.Services
{
    public interface IUserService
    {
        void Signup(UserModel model);
        AuthenticationModel Login(LoginModel model);
    }
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Signup(UserModel model)
        {
            model.Password = PasswordHash.CreateHash(model.Password);
            _userRepository.Add(Mapper.Map<UserModel, User>(model));
            _userRepository.Save();
        }

        public AuthenticationModel Login(LoginModel model)
        {
            var user = _userRepository.GetByUsername(model.Username);
            if(user == null || !PasswordHash.ValidatePassword(model.Password, user.Password))
            {
                throw new ValidationException("", "Username or Password is incorrect");
            }
            return new AuthenticationModel
                       {
                           Admin = user.Admin,
                           Name = user.Username,
                           UserId = user.Id
                       };
        }
    }
}
