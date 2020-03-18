using System;
using BrilhaMuito.Factory.Helper;
using MongoDB.Driver;

namespace BrilhaMuito.Infrastructure.Context
{
    public class MongoDataContext
    {
        public MongoDataContext()
            : this("mongodb")
        {
        }

        public MongoDataContext(string connectionName)
        {
            try
            {
                var url = new ConfigurationManagerHelper().GetConnectionString(connectionName);
                var mongoUrl = new MongoUrl(url);
                IMongoClient client = new MongoClient(mongoUrl);
                MongoDatabase = client.GetDatabase(mongoUrl.DatabaseName);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public IMongoDatabase MongoDatabase { get; }
    }
}
