using System;
using System.Collections.Generic;
using BrilhaMuito.Domain.Account.Entities;

namespace BrilhaMuito.Factory.Service.Account
{
    public interface IMemberService
    {
        void Save(Member member);

        void Delete(Guid memberId);

        void Update(Member member);

        Member GetMemberById(Guid memberId);

        IEnumerable<Member> GetMembersByUserId(Guid userId);

        void Enable(Guid memberId);

        void Disable(Guid memberId);
    }
}