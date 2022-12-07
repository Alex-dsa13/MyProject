using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokBotApp.Entities
{
    public class ServerConnectConfig
    {
        private string host = "195.2.74.154";
        private string username = "root";
        private string password = "n6Rt2cqSxp3527V4";
        private int port = 22;
        private string remoteDirectory = "/root/Events";

        public string Host { get { return host; } }
        public string Username { get { return username; } }
        public string Password { get { return password; } }
        public int Port { get { return port; } }
        public string RemoteDirectory { get { return remoteDirectory; } }


        public ServerConnectConfig()
        {

        }

    }
}
