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
    public class UserRepository : RepositoryBase<BsonDocument>, IUserRepository
    {
        private readonly MongoDataContext _mongoDataContext;
        public UserRepository(MongoDataContext mongoDataContext)
        {
            _mongoDataContext = mongoDataContext;
        }
        protected override string CollectionName => "User";
        protected override IMongoCollection<BsonDocument> Collection =>
            _mongoDataContext.MongoDatabase.GetCollection<BsonDocument>(
                CollectionName);

        public void Save(User user)
        {
            var document = new BsonDocument
            {
                {"_id", user.UserId.ToString()},
                {"FirstName", user.FirstName},
                {"LastName", user.LastName},
                {"Email", user.Email},
                {"Password", user.Password},
                {"Salt", user.Salt},
                {"CreateDate",  DateTime.Now.ToString("s")},
                {"Active", true}
            };
            base.Save(document);
        }

        public void Update(User user)
        {
            var field = new Dictionary<string, string>
            {
                {"FirstName", user.FirstName},
                {"LastName", user.LastName},
                {"ModifyDate", DateTime.Now.ToString("s")}
            };

            if (!string.IsNullOrEmpty(user.Password))
                field.Add("Password", user.Password);

            Set(user.UserId, field);
        }

        public override void Delete(Guid userId)
        {
            base.Delete(userId);
        }

        public IEnumerable<ExpandoObject> AllUsers()
        {
            var documents = All().ToArray();
            var result = documents.Select(x => BsonSerializer.Deserialize<ExpandoObject>(x));
            return result;
        }

        public ExpandoObject GetUserById(Guid userId)
        {
            var document = GetById(userId);
            if (document == null) return null;
            var result = BsonSerializer.Deserialize<ExpandoObject>(document);
            return result;
        }

        public ExpandoObject SignIn(string email, string password)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("Email", email),
                Builders<BsonDocument>.Filter.Eq("Password", password),
                Builders<BsonDocument>.Filter.Eq("Active", true)
                );

            var document = Collection.Find(filter).SingleOrDefault();
            if (document == null) return null;
            var result = BsonSerializer.Deserialize<ExpandoObject>(document);
            return result;
        }

        public string GetSaltByEmail(string email)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Email", email);
            var projection = Builders<BsonDocument>.Projection.Include("Salt").Exclude("_id");
            var document = Collection.Find(filter).Project(projection).SingleOrDefault();
            if (document == null) return null;
            var result = BsonSerializer.Deserialize<IDictionary<string, object>>(document);
            return result["Salt"].ToString();
        }

        public string GetSaltById(Guid id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id.ToString());
            var projection = Builders<BsonDocument>.Projection.Include("Salt").Exclude("_id");
            var document = Collection.Find(filter).Project(projection).SingleOrDefault();
            if (document == null) return null;
            var result = BsonSerializer.Deserialize<IDictionary<string, object>>(document);
            return result["Salt"].ToString();
        }

        public void Enable(Guid userId)
        {
            Set(userId, "Active", true);
        }

        public void Disable(Guid userId)
        {
            Set(userId, "Active", false);
        }

        public ExpandoObject GetUserByEmail(string email)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("Email", email),
                Builders<BsonDocument>.Filter.Eq("Active", true)
            );

            var document = Collection.Find(filter).SingleOrDefault();
            if (document == null) return null;
            var result = BsonSerializer.Deserialize<ExpandoObject>(document);
            return result;
        }

        public bool ExistEmail(string email)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("Email", email),
                Builders<BsonDocument>.Filter.Eq("Active", true),
                Builders<BsonDocument>.Filter.Exists("Email")
            );
            var projection = Builders<BsonDocument>.Projection.Include("Email").Exclude("_id");
            var document = Collection.Find(filter).Project(projection).SingleOrDefault();
            if (document == null) return false;
            var result = BsonSerializer.Deserialize<IDictionary<string, object>>(document);
            var exist = !string.IsNullOrEmpty(result["Email"].ToString());
            return exist;
        }
    }
}