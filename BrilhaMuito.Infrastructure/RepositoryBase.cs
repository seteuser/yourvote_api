using System;
using System.Collections.Generic;
using System.Linq;
using BrilhaMuito.Factory.Repository;
using MongoDB.Driver;

namespace BrilhaMuito.Infrastructure
{
    public abstract class RepositoryBase<TDocument> : IRepositoryBase<TDocument>
    {
        protected abstract string CollectionName { get; }

        protected abstract IMongoCollection<TDocument> Collection { get; }

        public virtual void Save(TDocument document)
        {
            Collection.InsertOne(document);
        }

        public virtual void Update(Guid id, TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq("_id", id.ToString());
            //  Collection.UpdateOne(filter, new ObjectUpdateDefinition<TDocument>());
           Collection.UpdateOne(filter, new ObjectUpdateDefinition<TDocument>(document), new UpdateOptions() { IsUpsert = true });
        }

        public virtual void Delete(Guid id)
        {
            var filter = Builders<TDocument>.Filter.Eq("_id", id.ToString());
            Collection.DeleteOne(filter);
        }

        public virtual TDocument GetById(Guid id)
        {
            var filter = Builders<TDocument>.Filter.And(
                Builders<TDocument>.Filter.Eq("_id", id.ToString()),
                Builders<TDocument>.Filter.Eq("Active", true));
            return Collection.Find(filter).SingleOrDefault();
        }

        public virtual IEnumerable<TDocument> All()
        {
            return Collection.AsQueryable().ToArray();
        }

        public virtual void Set(Guid id, Dictionary<string, string> dictionary)
        {
            dictionary.ToList().ForEach(d => Set(id, d.Key, d.Value));
        }

        public virtual void Set<TValue>(Guid id, string key, TValue value)
        {
            var filter = Builders<TDocument>.Filter.Eq("_id", id.ToString());
            var update = Builders<TDocument>.Update.Set(key, value);
            Collection.UpdateOne(filter, update);
        }
    }
}
