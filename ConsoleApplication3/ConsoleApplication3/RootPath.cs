using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace ConsoleApplication3
{
    public class RootPath : IRootPathProvider
    {
        public string GetRootPath()
        {
            return StaticConfiguration.IsRunningDebug
                ? Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", ".."))
                : AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}
