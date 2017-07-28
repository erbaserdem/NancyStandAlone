using ConsoleApplication3.Models;
using MongoDB.Bson;

namespace ConsoleApplication3.Service
{
    public class AddUser : Validation
    {
        public bool AddUserDb(User toAdd, out string message)
        {
            message = string.Empty;
            Collection = new ConnectToDb().ConnectToMongo(out message);
            UserToCheck = toAdd;
            if (Collection != null && ValidateUserParameters(out message))
            {
                var documentToAdd = new BsonDocument
                {
                    { "name", toAdd.Name },
                    { "userName", toAdd.UserName },
                    { "email", toAdd.Email },
                    { "_id", toAdd.Id },
                };
                Collection.InsertOne(documentToAdd);
                return true;
            }
            else
            {
                return false;
            }




        }//
    }
}