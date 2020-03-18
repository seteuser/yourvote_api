using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using BrilhaMuito.Domain.Account.Entities;
using BrilhaMuito.Factory.Repository.Account;
using BrilhaMuito.Infrastructure.Context;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace BrilhaMuito.Infrastructure.Account
{
    public class SessionRepository : RepositoryBase<BsonDocument>, ISessionRepository
    {
        private readonly MongoDataContext _mongoDataContext;
        public SessionRepository(MongoDataContext mongoDataContext)
        {
            _mongoDataContext = mongoDataContext;
        }
        protected override string CollectionName => "Session";
        protected override IMongoCollection<BsonDocument> Collection => _mongoDataContext.MongoDatabase
            .GetCollection<BsonDocument>(CollectionName);

        public void Save(Session session)
        {
            var document = new BsonDocument
            {
                {"_id", Guid.NewGuid().ToString()},
                {"UserId", session.UserId.ToString()},
                {"Title", session.Title},
                {"Description", session.Description},
                {"Interval",
                    new BsonDocument
                    {
                        {"StartDate", session.Interval.StartDate},
                        {"EndDate", session.Interval.EndDate}
                    }
                },
                {"Members", new BsonArray(session.Members.Select(x=>x.ToString()).ToArray())},
                {"Token", session.Token},
                {"CreateDate", DateTime.Now.ToString("s")},
                {"Active", true}
            };

            base.Save(document);
        }

        public void Update(Session session)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("_id", session.SessionId.ToString()),
                Builders<BsonDocument>.Filter.Eq("Active", true)
            );
            var update = Builders<BsonDocument>.Update
                .Set("Title", session.Title)
                .Set("Description", session.Description)
                .Set("Interval", new BsonDocument
                {
                    {"StartDate", session.Interval.StartDate},
                    {"EndDate", session.Interval.EndDate}
                }).Set("Members", session.Members.Select(x => x.ToString()))
                .Set("ModifyDate", DateTime.Now.ToString("s"))
                .Set("Token", session.Token);

            Collection.UpdateOne(filter, update, new UpdateOptions { IsUpsert = true });
        }

        public ExpandoObject GetSessionById(Guid sessionId)
        {
            var document = GetById(sessionId);
            if (document == null) return null;
            var result = BsonSerializer.Deserialize<ExpandoObject>(document);
            return result;
        }

        public ExpandoObject GetSessionByToken(string token)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("Token", token),
                Builders<BsonDocument>.Filter.Eq("Active", true)
            );
            var document = Collection.Find(filter).SingleOrDefault();
            if (document == null) return null;
            var result = BsonSerializer.Deserialize<ExpandoObject>(document);
            return result;
        }

        public IEnumerable<ExpandoObject> GetSessionsByUserId(Guid userId)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("UserId", userId.ToString()),
                Builders<BsonDocument>.Filter.Eq("Active", true)
            );

            var documents = Collection.Find(filter).ToList();
            var result = documents?.Select(x => BsonSerializer.Deserialize<ExpandoObject>(x)).ToArray();
            return result;
        }

        public void Enable(Guid sessionId)
        {
            Set(sessionId, "Active", true);
        }

        public void Disable(Guid sessionId)
        {
            Set(sessionId, "Active", false);
        }
    }
}