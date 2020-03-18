using System;
using BrilhaMuito.Domain.Vote;
using BrilhaMuito.Factory.Repository.Account;
using BrilhaMuito.Factory.Service.Account;

namespace BrilhaMuito.Service.Services.Account
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public void Save(PendingVote vote)
        {
            _candidateRepository.Save(vote);
        }

        public VoteSummary Compute(Guid sessionId)
        {
            throw new NotImplementedException();
        }
    }
}