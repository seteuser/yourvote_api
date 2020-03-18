using System;
using System.Collections.Generic;
using System.Dynamic;
using BrilhaMuito.Domain.Account.Entities;

namespace BrilhaMuito.Factory.Repository.Account
{
    public interface ISessionRepository
    {
        void Save(Session session);

        void Delete(Guid sessionId);

        void Update(Session session);

        ExpandoObject GetSessionById(Guid sessionId);

        ExpandoObject GetSessionByToken(string token);

        IEnumerable<ExpandoObject> GetSessionsByUserId(Guid userId);

        void Enable(Guid sessionId);

        void Disable(Guid sessionId);
    }
}