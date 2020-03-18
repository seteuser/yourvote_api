using BrilhaMuito.Domain.Account.Events.UserEvents;
using BrilhaMuito.Service.Services.Common;

namespace BrilhaMuito.Service.Handlers.Account
{
    public class OnWelcomeUserHandler 
    {
        public void Handler(OnWelcomeUserEvent ars)
        {
            var body = ars.Body.Replace("#name#", ars.User.FullName).Replace("#email#", ars.User.Email)
                .Replace("#password#", ars.NewPassword);
            var subject = ars.Subject.Replace("#name#", ars.User.FirstName);
            EmailCommon.Send(body, subject, ars.User);
        }
    }
}