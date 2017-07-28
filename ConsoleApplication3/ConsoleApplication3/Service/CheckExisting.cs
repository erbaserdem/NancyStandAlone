using System.Collections.Generic;
using ConsoleApplication3.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ConsoleApplication3.Service
{
    public class CheckExisting
    {

        protected IMongoCollection<BsonDocument> collection;

        public IMongoCollection<BsonDocument> Collection
        {
            get { return collection; }

            set { collection = value; }
        }

        protected User _userToValidate;

        public User UserToCheck
        {
            get { return _userToValidate; }

            set { _userToValidate = value; }
        }

        public virtual List<BsonDocument> CheckForExistingId()
        {
            var doc = collection.Find(Builders<BsonDocument>.Filter.Eq("_id", _userToValidate.Id)).ToList();

            return doc;

        }

        public List<BsonDocument> CheckForExistingUserName()
        {
            var doc = collection.Find(Builders<BsonDocument>.Filter.Eq("userName", _userToValidate.UserName)).ToList();

            return doc;
        }

        public List<BsonDocument> CheckForExistingEmail()
        {

            var doc = collection.Find(Builders<BsonDocument>.Filter.Eq("email", _userToValidate.Email)).ToList();
           
            return doc;
        }

    }
}