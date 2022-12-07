using Newtonsoft.Json.Linq;
using Renci.SshNet;
using SokBotApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace SokBotApp.Entities
{


    public class Event : StudentsPageViewModel
    {



        private string? _name { get; set; }
        private DateTime? _eventDate { get; set; }
        private string? _shortDate { get; set; }

        private ObservableCollection<Student> _members  = new ObservableCollection<Student>();
        private ObservableCollection<Student> _filteredMembers { get; set; } = new ObservableCollection<Student>();

        private string _path = "/var/lib/docker/volumes/SOK/_data/Events/";
        private INavigate _navigate;


        protected string _localpath = "eventfiles";


        public ObservableCollection<Student> Members { get { return _members; } }
        public ObservableCollection<Student> FilteredMembers { get { return _filteredMembers; } }
        public string LocalPath { get { return _localpath; } }


        public Event()
        {

        }
        public virtual void GetMembers(string nameFile)
        {
            _members = new ObservableCollection<Student>();

            using (StreamReader filestream = new StreamReader(_localpath + "/" + nameFile))
            {
                string json = filestream.ReadToEnd();


                var js = JArray.Parse(json);
                foreach (var studentId in js)
                {
                    var s = studentId.ToString();
                    var d = int.Parse(s);
                    var member = Students.FirstOrDefault(x => x.Id == d);

                    if (member != null) _members.Add(member);

                }
            }

        }
        public void DownloadEventFile(string eventFile)
        {
            if (!Directory.Exists(_localpath))
            {
                Directory.CreateDirectory(_localpath);
            }
            var connect = new ServerConnectConfig();
            using (SftpClient sftp = new SftpClient(connect.Host, connect.Port, connect.Username, connect.Password))
            {
                try
                {
                    sftp.Connect();
                    try
                    {
                        var file = sftp.Get(_path + eventFile);
                        var downloadpath = _localpath + "/" + file.Name;
                        if (File.Exists(downloadpath))
                        {
                            File.Delete(downloadpath);
                        }
                        using (Stream filestream = File.OpenWrite(downloadpath))
                        {
                            sftp.DownloadFile(file.FullName, filestream);
                        }

                        sftp.Disconnect();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось найти файл мероприятия.");
                    }

                }
                catch
                {
                    MessageBox.Show("Не удалось подключиться к удаленному серверу.");
                }
            }
        }
        public void SetNavigate(INavigate nav)
        {
            _navigate = nav;
        }
        public Page DoNavigate()
        {
            return _navigate.NavigateTo();
        }
    }
}