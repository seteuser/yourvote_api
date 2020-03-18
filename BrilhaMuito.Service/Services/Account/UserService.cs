using System;
using System.Collections.Generic;
using System.Linq;
using BrilhaMuito.Domain.Account.Entities;
using BrilhaMuito.Domain.Account.Events.UserEvents;
using BrilhaMuito.Domain.Account.Scopes;
using BrilhaMuito.Factory.Cryptography;
using BrilhaMuito.Factory.Helper;
using BrilhaMuito.Factory.Repository.Account;
using BrilhaMuito.Factory.Service.Account;
using BrilhaMuito.Service.Handlers.Account;

namespace BrilhaMuito.Service.Services.Account
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly CryptoBase _cryptoBase;
        private readonly OnForgotUserHandler _onForgotUserHandler;
        private readonly OnWelcomeUserHandler _onWelcomeUserHandler;

        public UserService(IUserRepository userRepository, CryptoBase cryptoBase,
            OnForgotUserHandler onForgotUserHandler, OnWelcomeUserHandler onWelcomeUserHandler)
        {
            _userRepository = userRepository;
            _cryptoBase = cryptoBase;
            _onForgotUserHandler = onForgotUserHandler;
            _onWelcomeUserHandler = onWelcomeUserHandler;
        }

        public void Save(User user)
        {
            if (_userRepository.ExistEmail(user.Email))
                throw new Exception("e-mail exist");

            Argument.IsNotInvalidEmail(user.Email, "E-mail");
            Argument.IsNotEmpty(user.FirstName, "FirstName");
            Argument.IsNotEmpty(user.LastName, "LastName");
            Argument.IsNotEmpty(user.Password, "Password");

            user.UserId = Guid.NewGuid();
            var newPassword = user.Password;
            user.Salt = _cryptoBase.GenerateSalt(5);
            var password = EncryptPassword(newPassword, user.Salt);
            user.Password = password;
            _userRepository.Save(user);
            //_onWelcomeUserHandler.Handler(new OnWelcomeUserEvent(user, newPassword));
        }

        public void Delete(Guid userId)
        {
            Argument.IsNotEmpty(userId);
            _userRepository.Delete(userId);
        }

        public void Update(User user)
        {
            Argument.IsNotEmpty(user.UserId);
            if (!string.IsNullOrEmpty(user.Password))
            {
                var salt = _userRepository.GetSaltById(user.UserId);
                var encryptedPassword = EncryptPassword(user.Password, salt);
                user.Password = encryptedPassword;
            }

            if (string.IsNullOrEmpty(user.FirstName))
                Argument.IsNotEmpty(user.FirstName, "FirstName");
            if (string.IsNullOrEmpty(user.LastName))
                Argument.IsNotEmpty(user.LastName, "LastName");
            if (string.IsNullOrEmpty(user.Email))
                Argument.IsNotInvalidEmail(user.Email, "E-mail");

            _userRepository.Update(user);
        }

        public User SignIn(string email, string password)
        {
            Argument.IsNotInvalidEmail(email, "E-mail");
            Argument.IsNotEmpty(password, "Password");
            var salt = _userRepository.GetSaltByEmail(email);
            if (salt == null)
                return null;
            var encryptedPassword = EncryptPassword(password, salt);
            var document = _userRepository.SignIn(email, encryptedPassword);
            return document?.ToUser();
        }


        public void Enable(Guid userId)
        {
            Argument.IsNotEmpty(userId);
            _userRepository.Enable(userId);
        }

        public void Disable(Guid userId)
        {
            Argument.IsNotEmpty(userId);
            _userRepository.Disable(userId);
        }

        public string Forgot(string email)
        {
            Argument.IsNotInvalidEmail(email, "E-mail");
            var document = _userRepository.GetUserByEmail(email);
            if (document == null)
                return null;
            var user = document.ToUser();
            var newPassword = Guid.NewGuid().ToString().Substring(0, 5);
            var encryptedPassword = EncryptPassword(newPassword, user.Salt);
            user.Password = encryptedPassword;
            _userRepository.Update(user);
            //_onForgotUserHandler.Handler(new OnForgotUserEvent(user, newPassword));
            return newPassword;
        }

        public IEnumerable<User> GetUsers()
        {
            var documents = _userRepository.AllUsers();
            var users = documents.ToArray().Select(x => (IDictionary<string, object>)x)
                  .Select(a => a.ToUser()).ToArray();
            return users.ToArray();
        }

        public User GetUserById(Guid userId)
        {
            Argument.IsNotEmpty(userId);
            var document = _userRepository.GetUserById(userId);
            return document?.ToUser();
        }

        private string EncryptPassword(string password, string salt)
        {
            return _cryptoBase.GenerateSalted(password, salt);
        }

    }
}