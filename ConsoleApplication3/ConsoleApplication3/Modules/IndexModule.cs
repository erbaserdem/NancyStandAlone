using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using ConsoleApplication3.Models;
using ConsoleApplication3.Service;
using MongoDB.Bson;
using Nancy;
using Nancy.Responses;
using Nancy.Xml;

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
                List<User> list = new Find().CheckForUsersWithName(parameters.value);
                if (Request.Headers.ContentType.Contains("xml"))
                {
                    return Response.AsXml(list);
                }
                else if (Request.Headers.ContentType.Contains("json"))
                {

                    return Response.AsJson(list);
                }
                else if (Request.Headers.ContentType == "")
                {

                    return list;
                }

                return "Not a valid type";
            };



            Get["/users/id/{value}"] = parameters =>
            {
                List<User> list = new Find().CheckForUsersWithId(parameters.value);
                if (Request.Headers.ContentType.Contains("xml"))
                {
                    return Response.AsXml(list);
                }
                else if (Request.Headers.ContentType.Contains("json"))
                {

                    return Response.AsJson(list);
                }
                else if (Request.Headers.ContentType == "")
                {

                    return list;
                }

                return "Not a valid type";
            };


            Get["/DeleteUser"] = parameters =>
            {
                return View["DeleteUser"];

            };

            Get["/SearchUser"] = parameters =>
            {
                return View["SearchUser"];

            };

















        }

    }
    
}