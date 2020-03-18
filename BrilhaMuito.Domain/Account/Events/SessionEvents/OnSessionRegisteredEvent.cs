using BrilhaMuito.Domain.Account.Entities;
using System;

namespace BrilhaMuito.Domain.Account.Events.SessionEvents
{
    public class OnSessionRegisteredEvent 
    {
        public OnSessionRegisteredEvent(Session session)
        {
            Session = session;
            //EmailTitle = Template.EmailTitle;
            //EmailBody = Template.EmailBody;
            Date = DateTime.Now;
        }


        public Session Session { get; }

        public string Subject { get; }

        public string Body { get; }

        public DateTime Date { get; }
    }
}