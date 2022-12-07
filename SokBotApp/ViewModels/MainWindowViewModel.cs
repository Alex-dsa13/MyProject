using MvvmCross.Commands;
using MvvmCross.ViewModels;
using SokBotApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SokBotApp.ViewModels
{
    public class MainWindowViewModel : MvxViewModel
    {
        private Page _currentPage;
        private Page _studentsPage;
        private Page _startPage;
        private Page _eventsPage;


        public Page CurrentPage
        {
            get => _currentPage;
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    RaisePropertyChanged(() => CurrentPage);
                }
            }
        }
        public Page StudentsPage { get => _studentsPage; }
        public Page StartPage { get => _startPage; }
        public Page EventsPage { get => _eventsPage; }
        public MainWindowViewModel()
        {
            
            _startPage = new StartPage();
            //_studentsPage = new StudentsPage();
            _eventsPage = new EventsPage();
            //_dodPage = new DodPage();

            _currentPage = _startPage;
        }
        public IMvxCommand ChangePageCommand => new MvxCommand<Page>(ChangePage);
        public IMvxCommand ChangePageCommand1 => new MvxCommand<Page>(GetStudentsPage);
        public IMvxCommand ChangePageCommand2 => new MvxCommand<Page>(GetDodPage);
        public void GetStudentsPage(Page page)
        {
            _studentsPage = new StudentsPage();
            ChangePage(_studentsPage);
        }
        public void GetDodPage(Page page)
        {
            _studentsPage = new DodPage();
            ChangePage(_studentsPage);
        }
        public void ChangePage(Page page)
        {
            CurrentPage = page;
        }

        public void Window_Closing(object sender, EventArgs e)
        {

        }
    }
}
