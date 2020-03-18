using BrilhaMuito.Domain.Account.Events.UserEvents;
using BrilhaMuito.Service.Services.Common;

namespace BrilhaMuito.Service.Handlers.Account
{
    public class OnForgotUserHandler
    {
        public void Handler(OnForgotUserEvent ars)
        {
            var body = ars.Body.Replace("#name#", ars.User.FullName).Replace("#password#", ars.NewPassword);
            var subject = ars.Subject;
            EmailCommon.Send(body, subject, ars.User);
        }
    }
}