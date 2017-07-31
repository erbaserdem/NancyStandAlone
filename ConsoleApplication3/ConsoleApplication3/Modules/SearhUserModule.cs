using System.Collections.Generic;
using System.IO;
using ConsoleApplication3.Models;
using ConsoleApplication3.Service;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using Nancy;
using Nancy.ModelBinding;

namespace ConsoleApplication3.Modules
{
    public class SearchUserModule : NancyModule
    {
        string message = string.Empty;

        public SearchUserModule()
        {
            Post["/SearchUser/Id"] = parameters =>
            {
                var toSearch = Request.Form["Id"];
                var found = new Find().CheckForUsersWithId(toSearch);
                if (found ==null)
                {
                    return View["SearchResultFail"];
                }
                return View["SearchResultMultiple", found];
            };
            Post["/SearchUser/Name"] = parameters =>
            {
                var toSearch = Request.Form["Name"];
                var found = new Find().CheckForUsersWithName(toSearch);
                if (found == null)
                {
                    return View["SearchResultFail"];
                }
                return View["SearchResultMultiple", found];

            };
            Post["/SearchUser/UserName"] = parameters =>
            {
                var toSearch = Request.Form["UserName"];
                var found = new Find().CheckForUsersWithUserName(toSearch);
                if (found == null)
                {
                    return View["SearchResultFail"];
                }
                return View["SearchResultMultiple", found];
            };
        }

    }
}
