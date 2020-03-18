using System;
using System.Collections.Generic;
using System.Linq;
using BrilhaMuito.Domain.Account.Entities;
using BrilhaMuito.Factory.Repository.Account;
using BrilhaMuito.Infrastructure.Account;
using BrilhaMuito.Infrastructure.Context;
using BrilhaMuito.Service.Services.Account;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BrilhaMuito.Tests.Service.Persistence.Session
{
    [TestFixture]
    public class SessionPersistence
    {
        private readonly SessionService _sessionService;
        private readonly Mock<ISessionRepository> _mockSession;
        private readonly Mock<IUserRepository> _mockUser;
        private readonly Mock<IMemberRepository> _mockMember;
        public SessionPersistence()
        {
            _sessionService = new SessionService(new SessionRepository(new MongoDataContext()),
                new UserRepository(new MongoDataContext()), new MemberRepository(new MongoDataContext()));
            _mockSession = new Mock<ISessionRepository>();
            _mockMember = new Mock<IMemberRepository>();
            _mockUser = new Mock<IUserRepository>();
        }


        [Test]
        public void Saving_And_Validating_Session_Registration()
        {
            var session = new BrilhaMuito.Domain.Account.Entities.Session(Guid.NewGuid(), Guid.NewGuid(), "Dev mais Dev", "DEV PLENO",
                new Interval(DateTime.Now.AddDays(-3), DateTime.Now), new List<Guid>
                {
                    Guid.NewGuid(),
                    Guid.NewGuid()
                }, string.Empty, true);

            _mockSession.Setup(x => x.Save(It.IsAny<BrilhaMuito.Domain.Account.Entities.Session>()));
            var sessionService = new SessionService(_mockSession.Object, _mockUser.Object, _mockMember.Object);
            sessionService.Save(session);
            sessionService.Should().NotBeNull();
        }

        [Test]
        public void Title_And_Description_Is_Null_And_Returning_Exception_When_Saving_A_Session()
        {

            var session = new BrilhaMuito.Domain.Account.Entities.Session(Guid.NewGuid(), Guid.NewGuid(), null, null,
                new Interval(DateTime.Now.AddDays(-3), DateTime.Now), new List<Guid>
                {
                    Guid.NewGuid(),
                    Guid.NewGuid()
                }, string.Empty, true);

            _mockSession.Setup(x => x.Save(It.IsAny<BrilhaMuito.Domain.Account.Entities.Session>()));
            var sessionService = new SessionService(_mockSession.Object, _mockUser.Object, _mockMember.Object);
            Assert.Throws<ArgumentNullException>(() => sessionService.Save(session));
            sessionService.Should().NotBeNull();
        }


        [Test]
        public void Validating_Interval_And_Returning_Exception_When_Saving_A_Session()
        {
            var session = new BrilhaMuito.Domain.Account.Entities.Session(Guid.NewGuid(), Guid.NewGuid(), "Dev", "Dev1",
                new Interval(DateTime.MinValue, DateTime.MinValue), new List<Guid>
                {
                    Guid.NewGuid(),
                    Guid.NewGuid()
                }, string.Empty, true);

            _mockSession.Setup(x => x.Save(It.IsAny<BrilhaMuito.Domain.Account.Entities.Session>()));
            var sessionService = new SessionService(_mockSession.Object, _mockUser.Object, _mockMember.Object);
            Assert.Throws<ArgumentOutOfRangeException>(() => sessionService.Save(session));
            sessionService.Should().NotBeNull();
        }



        [Test]
        public void Validating_Members_And_Returning_Exception_When_Saving_A_Session()
        {
            var session = new BrilhaMuito.Domain.Account.Entities.Session(Guid.NewGuid(), Guid.NewGuid(), "Dev", "Dev1",
                new Interval(DateTime.Now.AddDays(-7), DateTime.Now), new List<Guid>
                {
                }, string.Empty, true);

            _mockSession.Setup(x => x.Save(It.IsAny<BrilhaMuito.Domain.Account.Entities.Session>()));
            var sessionService = new SessionService(_mockSession.Object, _mockUser.Object, _mockMember.Object);
            Assert.Throws<ArgumentException>(() => sessionService.Save(session));
            sessionService.Should().NotBeNull();
        }

        [Test]
        public void Session_Should_Returning_Candidates()
        {
            var session = _sessionService.GetSessionById(Guid.Parse("159a4b06-9678-4ed5-9396-dcc733dba2be"));
            var sessionPending = _sessionService.GetSessionByToken(session.Token);
            Assert.IsTrue(sessionPending.Candidates.ToArray().Any());
        }


    }
}