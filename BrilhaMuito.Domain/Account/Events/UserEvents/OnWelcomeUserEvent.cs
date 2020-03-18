using System;
using BrilhaMuito.Domain.Account.Entities;
using BrilhaMuito.SharedKernel.Resources;

namespace BrilhaMuito.Domain.Account.Events.UserEvents
{
    public class OnWelcomeUserEvent
    {
        public OnWelcomeUserEvent(User user, string newPassword)
        {
            User = user;
            NewPassword = newPassword;
            Body = Template.WelcomeUserBody;
            Subject = Template.WelcomeUserSubject;
            Date = DateTime.Now;
        }

        public User User { get; }
        public string Body { get; }
        public string Subject { get; }
        public string NewPassword { get;  }
        public DateTime Date { get; }
    }
}