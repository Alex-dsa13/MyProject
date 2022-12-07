using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SokBotApp.Entities
{
    class InternetConnection
    {

        public static bool OK()
        {
            try
            {
                Dns.GetHostEntry("www.microsoft.com");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
