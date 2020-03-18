using System;
using System.Collections.Generic;
using BrilhaMuito.Domain.Account.Entities;

namespace BrilhaMuito.Factory.Service.Account
{
    public interface IUserService
    {
        void Save(User user);

        void Delete(Guid userId);

        void Update(User user);

        User SignIn(string email, string password);

        IEnumerable<User> GetUsers();

        User GetUserById(Guid userId);

        void Enable(Guid userId);

        void Disable(Guid userId);

        string Forgot(string email);

    }
}