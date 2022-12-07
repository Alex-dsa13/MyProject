using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokBotApp.ViewModels
{
    public class MindGamesViewModel : MembersPageViewModel
    {
        public MindGamesViewModel(ObservableCollection<Student> members) : base(members)
        {
        }
    }
}
