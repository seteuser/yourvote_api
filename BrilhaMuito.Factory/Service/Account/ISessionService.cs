using System;
using System.Collections.Generic;
using BrilhaMuito.Domain.Account.Entities;

namespace BrilhaMuito.Factory.Service.Account
{
    public interface ISessionService
    {
        string Save(Session session);

        void Delete(Guid sessionId);

        string Update(Session session);

        Session GetSessionById(Guid sessionId);

        SessionPending GetSessionByToken(string token);

        IEnumerable<Session> GetSessionsByUserId(Guid userId);

        void Enable(Guid sessionId);

        void Disable(Guid sessionId);
    }
}