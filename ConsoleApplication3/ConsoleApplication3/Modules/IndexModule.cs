using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication3.Models;
using ConsoleApplication3.Service;
using MongoDB.Bson;
using Nancy;

namespace ConsoleApplication3.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                return View["index22"];
            };


            Get["/register"] = parameters =>
            {
                return View["register2"];
            };


            Get["/users/Name/{value}"] = parameters =>
            {
                List<BsonDocument> list = new Find().CheckForUsers(parameters.value);
                return list.Aggregate(string.Empty, (current, element) => current + (element.ToJson()));
                //return View["ViewUser", new Find().CheckForExistingId(parameters.value)];
            };



            Get["/users/id/{value}"] = parameters =>
            {
                User userToFind = new Find().CheckForExistingId(parameters.value);
                if (Request.Headers.ContentType.Contains("xml"))
                {
                    return Negotiate
                        .WithModel(userToFind.ToJson())
                        .WithMediaRangeModel("application/xml", userToFind);

                }
                else if (Request.Headers.ContentType.Contains("json"))
                {

                    return userToFind.ToJson();
                }
                else if (Request.Headers.ContentType == "")
                {

                    return userToFind;
                }

                return "Not a valid type";
            };



        }

    }
    
}