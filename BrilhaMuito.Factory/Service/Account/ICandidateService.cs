using System;
using BrilhaMuito.Domain.Vote;

namespace BrilhaMuito.Factory.Service.Account
{
    public interface ICandidateService
    {
        void Save(PendingVote vote);
        VoteSummary Compute(Guid sessionId);

    }
}