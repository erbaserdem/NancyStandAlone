using System;
using System.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ConsoleApplication3.Service
{
    public class ConnectToDb
    {
        protected IMongoCollection<BsonDocument> _collection;

        public IMongoCollection<BsonDocument> Collection
        {
            get { return _collection; }

            set
            {
                _collection = value;
            }
        }

        public IMongoCollection<BsonDocument> ConnectToMongo(out string message)
        {
            message = null;
            message += "Trying to connect to database";
            message += Environment.NewLine;
            
            MongoClient client;

            try
            {
                client = new MongoClient(ConfigurationManager.AppSettings["MongoConnection"]);
            }
            catch
            {
                message+="Could ot connect to mongo server pls make sure theconnection is open";
                return null;
            }

            message += "Connection to Database Succesful";
            var database = client.GetDatabase(ConfigurationManager.AppSettings["Database"]);
            _collection = database.GetCollection<BsonDocument>(ConfigurationManager.AppSettings["Collection"]);
            return _collection;
        }
    }
}