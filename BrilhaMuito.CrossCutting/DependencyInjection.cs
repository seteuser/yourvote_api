using BrilhaMuito.Factory.Cryptography;
using BrilhaMuito.Factory.Repository.Account;
using BrilhaMuito.Factory.Service.Account;
using BrilhaMuito.Infrastructure.Account;
using BrilhaMuito.Infrastructure.Context;
using BrilhaMuito.Service.Handlers.Account;
using BrilhaMuito.Service.Services.Account;
using SimpleInjector;


namespace BrilhaMuito.CrossCutting
{
    public static class DependencyInjection
    {
        public static void Configure(Container container)
        {
            //Lifestyle.Scoped e uma instancia por request.
            container.Register(() => new MongoDataContext(), Lifestyle.Scoped);

            container.Register<CryptoBase, Sha1>(Lifestyle.Scoped);
            container.Register<IUserService, UserService>();
            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
            container.Register(() => new OnWelcomeUserHandler(), Lifestyle.Scoped);
            container.Register(() => new OnForgotUserHandler(), Lifestyle.Scoped);

            container.Register<IMemberService, MemberService>();
            container.Register<IMemberRepository, MemberRepository>(Lifestyle.Scoped);
            container.Register(() => new OnWelcomeMemberHandler(), Lifestyle.Scoped);

            container.Register<ISessionService, SessionService>();
            container.Register<ISessionRepository, SessionRepository>(Lifestyle.Scoped);
            container.Register(() => new OnSessionRegisteredHandler(), Lifestyle.Scoped);

            container.Register<ICandidateService, CandidateService>();
            container.Register<ICandidateRepository, CandidateRepository>(Lifestyle.Scoped);
        }
    }
}
