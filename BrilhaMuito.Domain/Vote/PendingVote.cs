using System;

namespace BrilhaMuito.Domain.Vote
{
    public class PendingVote
    {
        public Guid Id { get; set; }

        public Guid CandidateId { get; set; }

        public Guid SessionId { get; set; }
    }
}