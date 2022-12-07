using Newtonsoft.Json.Linq;
using SokBotApp.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SokBotApp.Entities
{
    class MindGames : Event, INavigate
    {

        private string _eventFolderName = "MindGames/MindGame2022/";
        private string _usersfile = "Users" + ".json";
        private string _teamsfile = "Teams" + ".json";
        private string _registeredteams = "RegistredTeams" + ".json";


        public string EventFolderName { get { return _eventFolderName; } }
        public string UsersFile { get { return _usersfile; } }
        public string TeamsFile { get { return _teamsfile; } }
        public string Registeredteams { get { return _registeredteams; } }

        public MindGames()
        {
            //DownloadEventFile(_eventFolderName + _usersfile);
            //DownloadEventFile(_eventFolderName + _teamsfile);
            //DownloadEventFile(_eventFolderName + _registeredteams);
            //GetMembers(_registeredteams);
        }

        public override void GetMembers(string registeredteams)
        {
            List<int> teams = new();

            using (StreamReader filestream = new StreamReader(_localpath + "/" + registeredteams))
            {
                string json = filestream.ReadToEnd();
                var js = JArray.Parse(json);

                foreach (var teamId in js)
                {
                    var s = teamId.ToString();
                    var d = int.Parse(s);
                    
                    teams.Add(d);
                }
            }


            using (StreamReader filestream = new StreamReader(_localpath + "/" + _usersfile))
            {
                string json = filestream.ReadToEnd();
                var js = Newtonsoft.Json.Linq.JArray.Parse(json);

                foreach (var member in js)
                {
                    var id = int.Parse(member["Id"]!.ToString());
                    var teamId = int.Parse(member["TeamId"]!.ToString());

                    var student = Students.FirstOrDefault(x => x.Id == id);
                    if (student != null && teams.Contains(teamId))
                    {
                        Members.Add(student);
                    }
                }
            }
        }

        public Page NavigateTo()
        {
            var nav = new MindGamesPage(this);
            return nav;
        }
    }
}
