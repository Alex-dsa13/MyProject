using SokBotApp.Entities;
using SokBotApp.Views;
using System;
using System.Windows.Controls;

namespace SokBotApp.ViewModels
{
    public class DodPageViewModel : Event, INavigate
    {
        private string _eventFolderName = "DoDs/DoD" + DateTime.Now.Year.ToString() + ".json";
        private string _eventFileName = "DoD" + DateTime.Now.Year.ToString() + ".json"; 

        public string EventFolderName { get { return _eventFolderName;  } }
        public string EventFileName { get { return _eventFileName; } }

        public DodPageViewModel()
        {

            //DownloadEventFile(_eventFolderName);
           // GetMembers(_eventFileName);
        }

        public Page NavigateTo()
        {
            var nav = new MembersPage(this);
            return nav;
        }
    }
}
