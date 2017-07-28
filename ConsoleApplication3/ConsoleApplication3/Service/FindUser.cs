using System.Collections.Generic;
using ConsoleApplication3.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ConsoleApplication3.Service
{
    public class Find : CheckExisting
    {
        public User CheckForExistingId(string Id)
        {
            string message;
            Collection = new ConnectToDb().ConnectToMongo(out message);
            var doc = collection.Find(Builders<BsonDocument>.Filter.Eq("_id", Id)).ToList();

            if (doc.Count == 0)
            {
                return null;
            }
            var returnThis = new User();
            foreach (var user in doc)
            {
                returnThis.Email = user.GetElement("email").ToString();
                returnThis.UserName = user.GetElement("userName").ToString();
                returnThis.Name = user.GetElement("name").ToString();
                returnThis.Id = user.GetElement("_id").ToString();
            }

            return returnThis;
        }


        public List<BsonDocument> CheckForUsers(string Name)
        {
            string message;
            Collection = new ConnectToDb().ConnectToMongo(out message);
            var doc = collection.Find(Builders<BsonDocument>.Filter.Eq("name", Name)).ToList();

            if (doc.Count == 0)
            {
                return null;
            }
            var returnThis = new User();
            foreach (var user in doc)
            {
                returnThis.Email = user.GetElement("email").ToString();
                returnThis.UserName = user.GetElement("userName").ToString();
                returnThis.Name = user.GetElement("name").ToString();
                returnThis.Id = user.GetElement("_id").ToString();
            }

            return doc;
        }

    }
}