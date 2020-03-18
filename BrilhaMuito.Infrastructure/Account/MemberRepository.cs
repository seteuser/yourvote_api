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
    public class MemberRepository : RepositoryBase<BsonDocument>, IMemberRepository
    {
        private readonly MongoDataContext _mongoDataContext;
        public MemberRepository(MongoDataContext mongoDataContext)
        {
            _mongoDataContext = mongoDataContext;
        }

        protected override string CollectionName => "Member";

        protected override IMongoCollection<BsonDocument> Collection =>
            _mongoDataContext.MongoDatabase.GetCollection<BsonDocument>(
                CollectionName);

       

        public void Save(Member member)
        {
            var document = new BsonDocument
            {
                {"_id", Guid.NewGuid().ToString()},
                {"UserId", member.UserId.ToString()},
                {"FirstName", member.FirstName},
                {"LastName", member.LastName},
                {"Email", member.Email},
                {"Description", member.Description},
                {"Birthday", member.Birthday},
                {"CreateDate",  DateTime.Now.ToString("s")},
                {"Active", true}
            };
            base.Save(document);
        }

        public override void Delete(Guid memberId)
        {
            base.Delete(memberId);
        }

        public void Update(Member member)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("_id", member.MemberId.ToString()),
                Builders<BsonDocument>.Filter.Eq("Active", true)
            );

            var update = Builders<BsonDocument>.Update
                .Set("FirstName", member.FirstName)
                .Set("LastName", member.LastName)
                .Set("Email", member.Email)
                .Set("Description", member.Description)
                .Set("ModifyDate", DateTime.Now.ToString("s"));

            Collection.UpdateOne(filter, update, new UpdateOptions { IsUpsert = true });
        }

   
        public ExpandoObject GetMemberById(Guid memberId)
        {
            var document = GetById(memberId);
            if (document == null) return null;
            var result = BsonSerializer.Deserialize<ExpandoObject>(document);
            return result;
        }

        public IEnumerable<ExpandoObject> GetMembersByUserId(Guid userId)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("UserId", userId.ToString()),
                Builders<BsonDocument>.Filter.Eq("Active", true)
            );

            var documents = Collection.Find(filter).ToList();
            var result = documents?.Select(x => BsonSerializer.Deserialize<ExpandoObject>(x));
            return result;
        }

        public void Enable(Guid memberId)
        {
            Set(memberId, "Active", true);
        }

        public void Disable(Guid memberId)
        {
            Set(memberId, "Active", false);
        }

        public IEnumerable<ExpandoObject> GetMembersById(IEnumerable<Guid> memberIds)
        {
            var bsonValues = new BsonArray(memberIds.Select(o => o.ToString()));
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.In("_id", bsonValues),
                Builders<BsonDocument>.Filter.Eq("Active", true)
            );
            var documents = Collection.Find(filter).ToList();
            var result = documents?.Select(x => BsonSerializer.Deserialize<ExpandoObject>(x));
            return result;
        }
    }
}
