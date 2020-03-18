using System.Collections.Generic;
using BrilhaMuito.Domain.Account.Entities;

namespace BrilhaMuito.Domain.Vote
{
    public class VoteSummary
    {
        public IEnumerable<CandidateSummary> CandidateSummaries { get; set; }
    }

    public class CandidateSummary
    {
        public Candidate Candidate { get; set; }
        public int Count { get; set; }
        public bool Winner { get; set; }
    }
}