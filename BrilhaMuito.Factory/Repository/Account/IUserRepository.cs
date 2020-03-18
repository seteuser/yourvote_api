using System;
using System.Collections.Generic;
using System.Dynamic;
using BrilhaMuito.Domain.Account.Entities;

namespace BrilhaMuito.Factory.Repository.Account
{
    public interface IUserRepository
    {
        void Save(User user);

        void Update(User user);

        void Delete(Guid userId);

        IEnumerable<ExpandoObject> AllUsers();

        ExpandoObject GetUserById(Guid userId);

        ExpandoObject SignIn(string email, string password);

        string GetSaltByEmail(string email);

        string GetSaltById(Guid id);

        void Enable(Guid userId);

        void Disable(Guid userId);

        ExpandoObject GetUserByEmail(string email);

        bool ExistEmail(string email);
    }
}