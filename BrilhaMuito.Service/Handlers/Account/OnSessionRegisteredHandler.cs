using BrilhaMuito.Domain.Account.Events.SessionEvents;
using BrilhaMuito.Service.Services.Common;

namespace BrilhaMuito.Service.Handlers.Account
{
    public class OnSessionRegisteredHandler 
    {
        public void Handle(OnSessionRegisteredEvent ars)
        {
            var title = ars.Subject.Replace("##TITLE##", ars.Session.Title);
            var body = ars.Body.Replace("##TITLE##", ars.Session.Title).Replace("##TOKEN##", ars.Session.Token);

            EmailCommon.Send(body, title, ars.Session);
        }
    }
}