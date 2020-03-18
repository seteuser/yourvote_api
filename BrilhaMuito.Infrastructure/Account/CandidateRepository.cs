using System;
using System.Dynamic;
using BrilhaMuito.Domain.Vote;
using BrilhaMuito.Factory.Repository.Account;
using BrilhaMuito.Infrastructure.Context;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BrilhaMuito.Infrastructure.Account
{
    public class CandidateRepository : RepositoryBase<BsonDocument>, ICandidateRepository
    {
        private readonly MongoDataContext _mongoDataContext;
        public CandidateRepository(MongoDataContext mongoDataContext)
        {
            _mongoDataContext = mongoDataContext;
        }

        protected override string CollectionName => "Candidate";
        protected override IMongoCollection<BsonDocument> Collection =>
            _mongoDataContext.MongoDatabase.GetCollection<BsonDocument>(CollectionName);


        public void Save(PendingVote vote)
        {
            var document = new BsonDocument
            {
                {"_id", vote.Id.ToString() },
                {"SessionId", vote.SessionId.ToString() },
                {"CandidateId", vote.CandidateId.ToString() },
                {"CreateDate",  DateTime.Now.ToString("s")},
                {"Active", true}
            };
            base.Save(document);
        }

        public ExpandoObject Compute(Guid sessionId)
        {
            throw new NotImplementedException();
        }
    }
}