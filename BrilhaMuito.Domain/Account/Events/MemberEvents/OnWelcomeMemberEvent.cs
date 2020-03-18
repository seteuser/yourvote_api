using System;
using BrilhaMuito.Domain.Account.Entities;
using BrilhaMuito.SharedKernel.Resources;

namespace BrilhaMuito.Domain.Account.Events.MemberEvents
{
    public class OnWelcomeMemberEvent
    {
        public OnWelcomeMemberEvent(Member member)
        {
            Member = member;
            Body = Template.WelcomeMemberBody;
            Subject = Template.WelcomeMemberSubject;
            Date = DateTime.Now;
        }

        public Member Member { get; }
        public string Body { get; }
        public string Subject { get; }
        public DateTime Date { get; }
    }
}