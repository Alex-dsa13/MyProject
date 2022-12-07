using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SokBotApp.Entities;

namespace SokBotApp.ViewModels
{
    public class MembersPageViewModel : Event
    {
        private ObservableCollection<Student> _eventMembers = new ObservableCollection<Student>();
        private ObservableCollection<Student> _filteredMembers = new ObservableCollection<Student>();


        public ObservableCollection<Student> EventMembers { get { return _eventMembers;  } }
        public ObservableCollection<Student> FilteredMembers { get { return _filteredMembers; } }


        public MembersPageViewModel(ObservableCollection<Student> members)
        {
            _eventMembers = new ObservableCollection<Student>(members);
            _filteredMembers = new ObservableCollection<Student>(members);
        }


    }
}
