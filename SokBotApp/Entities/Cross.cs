using SokBotApp.Views;
using System;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace SokBotApp.Entities
{
    public class Cross : Event, INavigate
    {
        private string _eventFolderName = "Crosses/Cross" + DateTime.Now.Year.ToString() + ".json";
        private string _eventFileName = "Cross" + DateTime.Now.Year.ToString() + ".json";


        public string EventFolderName { get { return _eventFolderName; } }
        public string EventFileName { get { return _eventFileName; } }


        public Cross()
        {

            //DownloadEventFile(_eventFolderName);
            //GetMembers(_eventFileName);
        }
        public override void GetMembers(string nameFile)
        {
            using (StreamReader filestream = new StreamReader(_localpath + "/" + nameFile))
            {
                string json = filestream.ReadToEnd();
                var js = Newtonsoft.Json.Linq.JArray.Parse(json);

                foreach (var member in js)
                {
                    var id = int.Parse(member["StudentId"]!.ToString());
                    var distance = int.Parse(member["Route"]!.ToString());
                    var descipline = 0;

                    if (distance == 2) { descipline = 0; }
                    else { descipline = 1; }

                    var student = Students.FirstOrDefault(x => x.Id == id);
                    if (student != null)
                    {
                        student.Descipline = descipline;
                        Members.Add(student);
                    }
                }
            }
        }

        public Page NavigateTo()
        {
            var nav = new CrossPage(this);
            return nav;
        }
    }
}
