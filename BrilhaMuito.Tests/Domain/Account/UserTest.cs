using BrilhaMuito.Domain.Account.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace BrilhaMuito.Tests.Domain.Account
{
    [TestFixture]
    public class UserTest
    {
        private readonly List<User> _users;
        public UserTest()
        {
            _users = new List<User>
            {
                new User(Guid.Empty, "William", "Souza","William.m.souza@live.com","", "123", true),
                new User(Guid.NewGuid(), "Souza", "Moreira","souza@live.com","", "123", true),
                new User(Guid.NewGuid(), "Andre", "Marcos","andre@andre.com","",  "123", true),
                new User(Guid.Empty, "desativado", String.Empty, "William.m.souza@live.com","", "123", false),
                new User(Guid.NewGuid(), "email", " zuado","William.m.souzalive.com","", "123", true)
            };

        }

        [Test]
        public void User_Is_Not_Null()
        {
            var user = new User(Guid.Empty, "William", "LastName", "William.m.souza@live.com", "", "123", true);
            Assert.IsNotNull(user);
        }


        [Test]
        public void Use_rConstructor()
        {
            User user = new User(Guid.NewGuid(), String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, false);
        }

    }
}
