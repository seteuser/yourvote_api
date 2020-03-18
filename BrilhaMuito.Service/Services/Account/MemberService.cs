using System;
using System.Collections.Generic;
using System.Linq;
using BrilhaMuito.Domain.Account.Entities;
using BrilhaMuito.Domain.Account.Scopes;
using BrilhaMuito.Factory.Helper;
using BrilhaMuito.Factory.Repository.Account;
using BrilhaMuito.Factory.Service.Account;

namespace BrilhaMuito.Service.Services.Account
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public void Save(Member member)
        {
            Argument.IsNotEmpty(member.FirstName, "FirstName");
            Argument.IsNotEmpty(member.LastName, "LastName");
            Argument.IsNotInvalidEmail(member.Email, "E-mail");
            Argument.IsNotEmpty(member.UserId);
            Argument.IsNotInvalidDate(member.Birthday, "Birthday");

            _memberRepository.Save(member);
        }

        public void Delete(Guid memberId)
        {
            Argument.IsNotEmpty(memberId);
            _memberRepository.Delete(memberId);
        }

        public void Update(Member member)
        {
            Argument.IsNotEmpty(member.UserId);
            Argument.IsNotEmpty(member.MemberId);

            if (string.IsNullOrEmpty(member.Email))
                Argument.IsNotInvalidEmail(member.Email, "E-mail");
            if (string.IsNullOrEmpty(member.FirstName))
                Argument.IsNotEmpty(member.FirstName, "FirstName");
            if (string.IsNullOrEmpty(member.LastName))
                Argument.IsNotEmpty(member.LastName, "LastName");
            if (DateTime.MinValue.Equals(member.Birthday))
                Argument.IsNotInvalidDate(member.Birthday, "Birthday");

            _memberRepository.Update(member);
        }

        public Member GetMemberById(Guid memberId)
        {
            Argument.IsNotEmpty(memberId);
            var document = _memberRepository.GetMemberById(memberId);
            return document?.ToMember();
        }

        public IEnumerable<Member> GetMembersByUserId(Guid userId)
        {
            Argument.IsNotEmpty(userId);
            var documents = _memberRepository.GetMembersByUserId(userId);
            var members = documents.ToArray().Select(x => (IDictionary<string, object>)x)
                .Select(a => a.ToMember()).ToArray();
            return members;
        }

        public void Enable(Guid memberId)
        {
            Argument.IsNotEmpty(memberId);
            _memberRepository.Enable(memberId);
        }

        public void Disable(Guid memberId)
        {
            Argument.IsNotEmpty(memberId);
            _memberRepository.Disable(memberId);
        }
    }
}
