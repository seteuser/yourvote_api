using System;
using BrilhaMuito.Domain.Account.Scopes;

namespace BrilhaMuito.Domain.Account.Entities
{
    public class Candidate
    {
        public Candidate(Guid candidateId, Guid userId, string firstName, string lastName, string email, string description, DateTime birthday)
        {
            CandidateId = candidateId;
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Description = description;
            Age = birthday.MyAge();
            Birthday = birthday;
        }
        public Guid CandidateId { get; }

        public Guid UserId { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public string Description { get; }

        public int Age { get; }

        public DateTime Birthday { get; }
    }
}