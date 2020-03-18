using System;
using System.Dynamic;
using BrilhaMuito.Domain.Vote;

namespace BrilhaMuito.Factory.Repository.Account
{
    public interface ICandidateRepository
    {
        void Save(PendingVote vote);
        ExpandoObject Compute(Guid sessionId);
    }
}