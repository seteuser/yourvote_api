using System;
using System.Collections.Generic;
using System.Dynamic;
using BrilhaMuito.Domain.Account.Entities;

namespace BrilhaMuito.Factory.Repository.Account
{
    public interface IMemberRepository
    {
        void Save(Member member);

        void Delete(Guid memberId);

        void Update(Member member);

        ExpandoObject GetMemberById(Guid memberId);

        IEnumerable<ExpandoObject> GetMembersByUserId(Guid userId);

        void Enable(Guid memberId);

        void Disable(Guid memberId);

        IEnumerable<ExpandoObject> GetMembersById(IEnumerable<Guid> memberIds);
    }
}