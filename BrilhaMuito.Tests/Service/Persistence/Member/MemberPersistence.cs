using System;
using BrilhaMuito.Factory.Extension;
using BrilhaMuito.Factory.Repository.Account;
using BrilhaMuito.Infrastructure.Account;
using BrilhaMuito.Infrastructure.Context;
using BrilhaMuito.Service.Services.Account;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BrilhaMuito.Tests.Service.Persistence.Member
{
    [TestFixture]
    public class MemberPersistence
    {
        private readonly MemberService _memberService;
        public MemberPersistence()
        {
            _memberService = new MemberService(new MemberRepository(new MongoDataContext()));
        }

        [Test]
        public void Member_Should_Be_Added_To_The_Mongo_Repository()
        {
            var member = new BrilhaMuito.Domain.Account.Entities.Member(Guid.NewGuid(), Guid.NewGuid(),
                "William", "Souza", "william.m.souza@live.com", "Desenvolvedor", new DateTime(1995, 03, 20), true);
            var mockMemberRepository = new Mock<IMemberRepository>();
            var memberService = new MemberService(mockMemberRepository.Object);
            memberService.Save(member);
            mockMemberRepository.Verify(x => x.Save(It.IsAny<BrilhaMuito.Domain.Account.Entities.Member>()));
            memberService.Should().NotBeNull();
        }

        [Test]
        public void Member_Should_Be_Get_By_Id_From_Mongo_Repository()
        {
            var memberId = Guid.NewGuid();
            var memberObject = new BrilhaMuito.Domain.Account.Entities.Member(memberId, Guid.NewGuid(),
                    "William", "Souza", "william.m.souza@live.com", "Desenvolvedor", new DateTime(1995, 03, 20), true)
                .ToExpando<BrilhaMuito.Domain.Account.Entities.Member>();
            var mockMemberRepository = new Mock<IMemberRepository>();
            mockMemberRepository.Setup(x => x.GetMemberById(It.IsAny<Guid>())).Returns(memberObject);
            var memberService = new MemberService(mockMemberRepository.Object);
            var memberById = memberService.GetMemberById(memberId);
            Assert.IsNotNull(memberById);
        }

        [Test]
        public void Member_Should_Be_Deleted_From_Mongo_Repository()
        {
            var memberId = Guid.NewGuid();
            var mockMemberRepository = new Mock<IMemberRepository>();
            mockMemberRepository.Setup(x => x.Delete(It.IsAny<Guid>()));
            var memberService = new MemberService(mockMemberRepository.Object);
            memberService.Delete(memberId);
            mockMemberRepository.Verify(x => x.Delete(memberId));
        }

        [Test]
        public void Member_Should_Be_Update_From_Mongo_Repository()
        {
            var id = Guid.NewGuid();
            var member = new BrilhaMuito.Domain.Account.Entities.Member(id, Guid.NewGuid(),
                "William", "Souza", "william.m.souza@live.com", "Desenvolvedor", new DateTime(1995, 03, 20), true);
            var mockMemberRepository = new Mock<IMemberRepository>();
            mockMemberRepository.Setup(p => p.Update(It.IsAny<BrilhaMuito.Domain.Account.Entities.Member>())).Callback(
                new Action<BrilhaMuito.Domain.Account.Entities.Member>(
                    m =>
                    {
                        m.LastName = "Moreira";
                        m.Description = "Desenvolvedor Junior";
                    })).Verifiable();
            var memberService = new MemberService(mockMemberRepository.Object);
            memberService.Update(member);
            mockMemberRepository.Setup(x => x.GetMemberById(It.IsAny<Guid>()))
                .Returns(member.ToExpando<BrilhaMuito.Domain.Account.Entities.Member>());
            var memberById = memberService.GetMemberById(id);
            Assert.IsNotNull(memberById);
        }

        [Test]
        public void Member_Should_Be_Save_From_Mongo_Repository()
        {
            var member = new BrilhaMuito.Domain.Account.Entities.Member(Guid.NewGuid(), Guid.NewGuid(),
                "William", "Souza", "william.m.souza@live.com", "Desenvolvedor", new DateTime(1995, 03, 20), true);
            _memberService.Save(member);
        }

    }
}
