using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication3.Models;
using ConsoleApplication3.Service;
using MongoDB.Bson;
using Nancy;

namespace ConsoleApplication3.Modules
{
    public class DeleteuserModule : NancyModule
    {
        string message = string.Empty;

        public DeleteuserModule()
        {
            Post["/DeleteUser/Id{value}"] = parameters =>
            {
                new DeleteUser().DeleteWithId(parameters.value, out message);
                return View["DeleteFeedBack", message];

            };

            Post["/DeleteUser/Id"] = parameters =>
            {
                var toDelete = Request.Form["Id"];
                new DeleteUser().DeleteWithId(toDelete, out message);
                return View["DeleteFeedBack", message];

            };

            Post["/DeleteUser/UserName/{value}"] = parameters =>
            {
                new DeleteUser().DeleteWithUserName(Request.Form["UserName"].value, out message);
                return View["DeleteFeedBack", message];
            };

            Post["/DeleteUser/UserName"] = parameters =>
            {
                var toDelete = Request.Form["UserName"];
                new DeleteUser().DeleteWithUserName(toDelete, out message);
                return View["DeleteFeedBack", message];
            };
        }


    }
}
