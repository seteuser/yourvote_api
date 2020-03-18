using System;
using Api.BrilhaMuito.Controllers;
using BrilhaMuito.Factory.Service.Account;
using Moq;
using NUnit.Framework;
namespace BrilhaMuito.Tests.Controller.Account
{
    [TestFixture]
    public class UserControllerTest
    {
        private readonly Mock<IUserService> _mock;
        public UserControllerTest()
        {
            _mock = new Mock<IUserService>();
        }

        [Test]
        public void Email_Should_Not_Exist_And_Returning_Exception()
        {
            var controller = new UserController(_mock.Object);
            _mock.Setup(x => x.Forgot(It.IsAny<string>()));
            Assert.Throws<Exception>(() => controller.Forgot("william@hotmail.com.br"));
        }
    }
}