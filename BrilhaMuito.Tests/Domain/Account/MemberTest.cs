using System;
using BrilhaMuito.Domain.Account.Entities;
using BrilhaMuito.Factory.Repository.Account;
using BrilhaMuito.Service.Services.Account;
using FluentAssertions;
using Moq;
using NUnit.Framework;
namespace BrilhaMuito.Tests.Domain.Account
{
    [TestFixture]
    public class MemberTest
    {
        private readonly Mock<IMemberRepository> _mock;
        public MemberTest()
        {
            _mock = new Mock<IMemberRepository>();
        }

        [Test]
        public void Saving_And_Validating_Member_Registration()
        {
            var member = new Member(Guid.NewGuid(), Guid.NewGuid(), "William", "LastName", "willian.m.souz@live.com",
                "Dev Junior", new DateTime(1995, 03, 20), true);
            _mock.Setup(x => x.Save(It.IsAny<Member>()));
            var memberService = new MemberService(_mock.Object);
            memberService.Save(member);
            memberService.Should().NotBeNull();
        }

        [Test]
        public void Validating_Email_And_Returning_Exception_When_Saving_A_member()
        {
            var member = new Member(Guid.NewGuid(), Guid.NewGuid(), "William", "LastName", "willian.m.souzlive.com",
                "Dev Junior", new DateTime(1995, 03, 20), true);
            _mock.Setup(x => x.Save(It.IsAny<Member>()));
            var memberService = new MemberService(_mock.Object);
            Assert.Throws<ArgumentException>(() => memberService.Save(member));
            memberService.Should().NotBeNull();
        }

        [Test]
        public void Validating_FirstName_And_LastName_And_Returning_Exception_When_Saving_A_Member()
        {
            var member = new Member(Guid.NewGuid(), Guid.NewGuid(), "", "", "willian.m.souza@live.com",
                "Dev Junior", new DateTime(1995, 03, 20), true);
            _mock.Setup(x => x.Save(It.IsAny<Member>()));
            var memberService = new MemberService(_mock.Object);
            Assert.Throws<ArgumentException>(() => memberService.Save(member));
            memberService.Should().NotBeNull();
        }

    }
}
