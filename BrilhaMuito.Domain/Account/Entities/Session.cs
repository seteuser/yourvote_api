using System;
using System.Collections.Generic;

namespace BrilhaMuito.Domain.Account.Entities
{
    public class Session : IEntityBase
    {
        public Session(Guid sessionId, Guid userId, string title, string description, Interval interval, IEnumerable<Guid> members, string token, bool active)
        {
            SessionId = sessionId;
            UserId = userId;
            Title = title;
            Description = description;
            Interval = interval;
            Members = members;
            Token = token;
            Active = active;
        }
        public Session() { }

        public Guid SessionId { get; set; }

        public Guid UserId { get; set; }

        public Image Image { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Interval Interval { get; set; }

        public IEnumerable<Guid> Members { get; set; }

        public string Token { get; set; }

        public bool Active { get; set; }

        public override string ToString()
        {
            return $"Title: {Title}";
        }
    }
    public class SessionPending
    {
        public SessionPending(Guid sessionId, Guid userId, string title, string description,
            IEnumerable<Candidate> candidates, Interval interval, string token)
        {
            SessionId = sessionId;
            UserId = userId;
            Title = title;
            Description = description;
            Candidates = candidates;
            Interval = interval;
            Token = token;
        }

        public Guid SessionId { get; }

        public Guid UserId { get; }

        public string Title { get; }

        public string Description { get; }

        public IEnumerable<Candidate> Candidates { get; }

        public Interval Interval { get; }

        public string Token { get; }

        public bool IsClosed => DateTime.Today.Date > Interval.StartDate.Date && DateTime.Today.Date >= Interval.EndDate.Date;

        public override string ToString()
        {
            return $"Title: {Title}";
        }

    }
}