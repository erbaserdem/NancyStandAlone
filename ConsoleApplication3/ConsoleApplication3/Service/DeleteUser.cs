using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ConsoleApplication3.Service
{
    class DeleteUser : Validation
    {

        public bool DeleteWithId(string toDelete, out string message)
        {
            message = string.Empty;
            Collection = new ConnectToDb().ConnectToMongo(out message);
            if (Collection != null)
            {
                BsonDocument aa = collection.FindOneAndDelete((Builders<BsonDocument>.Filter.Eq("_id", toDelete)));
                //var kk = collection.Find((Builders<BsonDocument>.Filter.Eq("name", toDelete)));
                message = $"User with _id {toDelete} has been deleted.";
                return true;
            }
            else
            {
                return false;
            }
        }//


        public bool DeleteWithUserName(string toDelete, out string message)
        {
            message = string.Empty;
            Collection = new ConnectToDb().ConnectToMongo(out message);
            if (Collection != null)
            {
                Collection.DeleteOne((Builders<BsonDocument>.Filter.Eq("userName", toDelete)));
                message = $"User with UserName {toDelete} has been deleted.";
                return true;
            }
            else
            {
                return false;
            }
        }//


    }
}
