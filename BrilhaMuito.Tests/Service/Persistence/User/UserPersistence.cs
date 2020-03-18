using System;
using BrilhaMuito.Factory.Cryptography;
using BrilhaMuito.Factory.Extension;
using BrilhaMuito.Factory.Repository.Account;
using BrilhaMuito.Infrastructure.Account;
using BrilhaMuito.Infrastructure.Context;
using BrilhaMuito.Service.Handlers.Account;
using BrilhaMuito.Service.Services.Account;
using Moq;
using NUnit.Framework;

namespace BrilhaMuito.Tests.Service.Persistence.User
{
    [TestFixture]
    public class UserPersistence
    {
        [Test]
        public void Forgot_User_Password()
        {
            var mock = new Mock<IUserRepository>();
            var user = new BrilhaMuito.Domain.Account.Entities.User(Guid.Empty, "William", "Souza",
                "william.m.souza@live.com", "dinair", "sg2SWgg=", true);

            var userObject = user.ToExpando<BrilhaMuito.Domain.Account.Entities.User>();
            mock.Setup(x => x.GetUserByEmail(It.IsAny<string>())).Returns(userObject);
            var memberService = new UserService(mock.Object, new Sha1(), new OnForgotUserHandler(), new OnWelcomeUserHandler());
            var newPassword = memberService.Forgot(user.Email);

            Assert.IsNotNull(newPassword);
            Assert.IsNotEmpty(newPassword);
        }


        [Test]
        public void User_Should_Return_Email_Existing_Mongo_Repository()
        {
            var user = new BrilhaMuito.Domain.Account.Entities.User(Guid.Empty, "William", "Souza",
                "william.m.souza@live.com", "dinair", "sg2SWgg=", true);

            var userService = new UserService(new UserRepository(new MongoDataContext()), new Sha1(),
                new OnForgotUserHandler(),
                new OnWelcomeUserHandler());

            Assert.Throws<Exception>(() => userService.Save(user));
        }


        [Test]
        public void User_Should_Be_Method_Forgot()
        {
            var userService = new UserService(new UserRepository(new MongoDataContext()), new Sha1(),
                new OnForgotUserHandler(),
                new OnWelcomeUserHandler());


            var user = userService.Forgot("william.m.souza@live.com");

        }
    }
}