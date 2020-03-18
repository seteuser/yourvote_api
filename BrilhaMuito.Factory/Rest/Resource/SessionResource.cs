using System;
using System.Collections.Generic;
using BrilhaMuito.Domain.Account.Entities;

namespace BrilhaMuito.Factory.Rest.Resource
{
    public class SessionResource
    {
        public SessionResource(Guid sessionId, Guid userId, string title, string description, Interval interval, IEnumerable<Guid> members, string token, bool active)
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
        public SessionResource() { }

        public Guid SessionId { get; set; }

        public Guid UserId { get; set; }

        public Image Image { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Interval Interval { get; set; }

        public IEnumerable<Guid> Members { get; set; }

        public string Token { get; set; }

        public bool Active { get; set; }

        //public bool SessionClosed => Interval.StartDate.Date >= DateTime.Today.Date || DateTime.Today.Date <= Interval.EndDate.Date;

        public override string ToString()
        {
            return $"Title: {Title}";
        }
    }
}