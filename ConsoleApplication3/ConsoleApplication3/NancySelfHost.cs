using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Nancy.Hosting.Self;

namespace ConsoleApplication3
{
    class NancySelfHost
    {
        private NancyHost m_nancyHost;

        private readonly HostConfiguration _configuration = new HostConfiguration()
        {
            UrlReservations = new UrlReservations() { CreateAutomatically = true }
        };

        public void Start()
        {
            var newUri = new Uri(ConfigurationManager.AppSettings["Hosting"]);
            m_nancyHost = new NancyHost(_configuration,newUri );
            try
            {
                m_nancyHost.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot connect to Hosting");
                throw;
            }


            Console.WriteLine("Your application is running on " + newUri);
        }

        public void Stop()
        {
            m_nancyHost.Stop();
            Console.WriteLine("Stopped. Good bye!");
        }
    }
}
