using System;
using System.Linq;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System.IO;
using System.Collections.ObjectModel;
using System.Globalization;

namespace SokBotApp.ViewModels
{
    public class EventsPageViewModel
    {
        private string _host = "";
        private string _username = "";
        private string _password = "";
        private int _port;
        private string _remoteDirectory = "";
        private readonly string localpath = "../../../eventfiles";
        private ObservableCollection<Student> _members { get; set; } = new ObservableCollection<Student>();

        private void GetDataConnection()
        {
            _host = "94.103.84.38";
            _username = "root";
            _password = "WsLa7NupHyGVte"; // 25Nsia6M44ngcn86 WsLa7NupHyGVte
            _port = 22;
            _remoteDirectory = "/root/Events";

        }


        public EventsPageViewModel()
        {
            GetDataConnection();
            //FutureEvents = new ObservableCollection<Event>();
            //PastEvents = new ObservableCollection<Event>();

            using SftpClient sftp = new(_host, _port, _username, _password);
            try
            {
                sftp.Connect();
                var files = sftp.ListDirectory(_remoteDirectory);
                var cultureInfo = new CultureInfo("ru-RU");
                string separator = "__";

                foreach (var file in files)
                {
                    var name = file.Name;
                    var rrr = sftp.ListDirectory(_remoteDirectory + "/" + name);
                    foreach (var r in rrr)
                    {
                        bool isEventFile = r.Name.Contains(separator);
                        if (isEventFile)
                        {
                            string str = r.Name.Substring(r.Name.IndexOf('_') + 2);
                            string nameevent = r.Name.Substring(0, r.Name.IndexOf('_'));
                            string getDate = str.Replace(".json", "");
                            var dateTime = DateTime.Parse(getDate, cultureInfo);

                            if (dateTime > DateTime.Now)
                            {
                                //Event sokEvent = new Event(nameevent, dateTime);
                                //futureEvents.Add(sokEvent);
                            }
                            else
                            {
                                //Event sokEvent1 = new Event(nameevent, dateTime);
                                //pastEvents.Add(sokEvent1);
                            }


                            var downloadpath = localpath + "/" + r.Name;
                            using Stream filestream = File.OpenWrite(downloadpath);
                            sftp.DownloadFile(r.FullName, filestream);

                        }

                    }
                }

                sftp.Disconnect();
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception has been caught" + e.ToString());
            }
        }

        
    }
}
