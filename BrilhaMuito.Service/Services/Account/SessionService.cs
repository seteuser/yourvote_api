using System;
using System.Collections.Generic;
using System.Linq;
using BrilhaMuito.Domain.Account.Entities;
using BrilhaMuito.Domain.Account.Scopes;
using BrilhaMuito.Factory.Helper;
using BrilhaMuito.Factory.Repository.Account;
using BrilhaMuito.Factory.Service.Account;

namespace BrilhaMuito.Service.Services.Account
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMemberRepository _memberRepository;

        public SessionService(ISessionRepository sessionRepository, IUserRepository userRepository, IMemberRepository memberRepository)
        {
            _sessionRepository = sessionRepository;
            _userRepository = userRepository;
            _memberRepository = memberRepository;
            //_onSessionRegisteredHandler = new OnSessionRegisteredHandler();
        }


        public string Save(Session session)
        {
            Argument.IsNotNull(session.Title, "Title");
            Argument.IsNotNull(session.Description, "Description");
            Argument.IsNotInvalidDate(session.Interval.StartDate, "StartDate");
            Argument.IsNotInvalidDate(session.Interval.EndDate, "EndDate");
            Argument.IsNotEmpty(session.UserId);
            Argument.IsNotEmpty(session.Members.ToArray(), "Candidates");
            if (session.Interval.EndDate <= session.Interval.StartDate)
                throw new ArgumentException("EndDate less than StartDate");

            var token = Guid.NewGuid().ToString().Substring(0, 5).ToUpper();
            session.Token = token;
            _sessionRepository.Save(session);
            return token;
        }

        public void Delete(Guid sessionId)
        {
            Argument.IsNotEmpty(sessionId);
            _sessionRepository.Delete(sessionId);
        }

        public string Update(Session session)
        {
            Argument.IsNotEmpty(session.UserId);
            Argument.IsNotEmpty(session.SessionId);
            Argument.IsNotEmpty(session.Members.ToArray(), "Candidates");

            if (DateTime.MinValue.Equals(session.Interval.StartDate))
                Argument.IsNotInvalidDate(session.Interval.StartDate, "StartDate");
            if (DateTime.MinValue.Equals(session.Interval.EndDate))
                Argument.IsNotInvalidDate(session.Interval.EndDate, "EndDate");
            if (string.IsNullOrEmpty(session.Title))
                Argument.IsNotNull(session.Title, "Title");
            if (string.IsNullOrEmpty(session.Description))
                Argument.IsNotNull(session.Description, "Description");

            var token = Guid.NewGuid().ToString().Substring(0, 5).ToUpper();
            _sessionRepository.Update(session);
            return token;
        }

        public Session GetSessionById(Guid sessionId)
        {
            Argument.IsNotEmpty(sessionId);
            var expandoObject = _sessionRepository.GetSessionById(sessionId);
            var dictionary = (IDictionary<string, object>)expandoObject;
            var interval = ((IDictionary<string, object>)dictionary["Interval"]).ToInterval();
            var memberObjects = (List<object>)dictionary["Members"];
            var members = memberObjects.Select(x => Guid.Parse(x.ToString())).ToArray();
            var session = new Session(Guid.Parse(dictionary["_id"].ToString()),
                Guid.Parse(dictionary["UserId"].ToString()),
                dictionary["Title"].ToString(), dictionary["Description"].ToString(), interval, members,
                dictionary["Token"].ToString(), bool.Parse(dictionary["Active"].ToString()));
            return session;
        }

        public SessionPending GetSessionByToken(string token)
        {
            Argument.IsNotEmpty(token, "Token");
            var sessionObject = _sessionRepository.GetSessionByToken(token);
            if (sessionObject == null) return null;
            var session = sessionObject.ToSession();
            var membersObject = _memberRepository.GetMembersById(session.Members.ToArray());
            var candidates = membersObject.Select(x => (IDictionary<string, object>)x)
                            .Select(x => new Candidate(Guid.Parse(x["_id"].ToString()),
                                        Guid.Parse(x["UserId"].ToString()), x["FirstName"].ToString(),
                                        x["LastName"].ToString(),
                                        x["Email"].ToString(), x["Description"].ToString(),
                                        Convert.ToDateTime(x["Birthday"].ToString())));
            return new SessionPending(session.SessionId, session.UserId, session.Title, session.Description, candidates,
                session.Interval, session.Token);
        }

        public IEnumerable<Session> GetSessionsByUserId(Guid userId)
        {
            Argument.IsNotEmpty(userId);
            var documents = _sessionRepository.GetSessionsByUserId(userId);
            var sessions = documents.ToArray().Select(x => (IDictionary<string, object>)x)
                .Select(a => a.ToSession()).ToArray();
            return sessions;
        }

        public void Enable(Guid sessionId)
        {
            Argument.IsNotEmpty(sessionId);
            _sessionRepository.Enable(sessionId);
        }

        public void Disable(Guid sessionId)
        {
            Argument.IsNotEmpty(sessionId);
            _sessionRepository.Disable(sessionId);
        }

    }
}