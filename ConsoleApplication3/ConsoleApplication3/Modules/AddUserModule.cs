using System.IO;
using ConsoleApplication3.Models;
using ConsoleApplication3.Service;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using Nancy;
using Nancy.ModelBinding;

namespace ConsoleApplication3.Modules
{
    public class AddUserModule : NancyModule
    {
        string message = string.Empty;

        public AddUserModule()
        {
            Post["/NewUser"] = parameters =>
            {

                var k = parameters;
                if (Request.Headers.ContentType.Contains("xml"))
                {


                    var newUser = this.Bind<User>();
                    if (new AddUser().AddUserDb(newUser, out message))
                        return message + "Record succesfully Added";
                    else
                        return message;
                    //return "Xml deserialization not yet implemented";
                }
                else if  (Request.Headers.ContentType.Contains("json"))
                {
                    var newUser = this.Bind<User>();
                    if (new AddUser().AddUserDb(newUser, out message))
                        return message + "Record succesfully Added";
                    else
                        return message;
                }
                else if (Request.Headers.ContentType.Contains("form-urlencoded"))
                {
                    var newUser = this.Bind<User>();
                    if (new AddUser().AddUserDb(newUser, out message))
                        return View["tyforregister"];
                    else
                        return View["ErrorRegister",message];
                }


                return "Not a valid content type";

            };

        }

    }
}