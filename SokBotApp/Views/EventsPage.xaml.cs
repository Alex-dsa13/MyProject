using Microsoft.Office.Interop.Word;
using SokBotApp.Entities;
using SokBotApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Navigation;
using Page = System.Windows.Controls.Page;

namespace SokBotApp.Views
{
    /// <summary>
    /// Логика взаимодействия для EventsPage.xaml
    /// </summary>
    public partial class EventsPage : Page
    {
        public EventsPage()
        {

            InitializeComponent();
            DataContext = new EventsPageViewModel();

        }

        private void ViewEventMembers(object sender, EventArgs e)
        {

            
            var eventName = ((Label)sender).Name;
            object c = new object();

            Dictionary<string, Event> AllEvents = new Dictionary<string, Event>
            {
                { "Dod", new  DodPageViewModel() },
                { "CupFirstCourse", new  CupFirstCourse() },
                { "StatsFirstCourse", new  CupFirstCourseStatistics() },
                { "Cross", new  Cross() },
                { "MindGames", new  MindGames() },
                { "SokCup", new  SokCup() },
                { "StatsSokCup", new  SokCupStatistics() }
            };

            var currentEvent = AllEvents[eventName];
            currentEvent.SetNavigate((INavigate)currentEvent);
            var path = currentEvent.DoNavigate();
            NavigationService.Navigate(path);


            /*if (eventName == "Dod")
            {
                
                var dod = new DodPageViewModel();
                var membersList = new MembersPage(eventName, dod);
                NavigationService.Navigate(membersList);
            }
            else if (eventName == "CupFirstCourse")
            {
                var cup = new CupFirstCourse();
                var membersList = new MembersPage(eventName, cup);
                NavigationService.Navigate(membersList);
            }
            else if (eventName == "StatsFirstCourse") 
            {
                var cup = new CupFirstCourse();
                var membersList = new EventStatistics(eventName, cup);
                NavigationService.Navigate(membersList);
            }
            else if (eventName == "Cross")
            {
                var cross = new Cross();
                var membersList = new CrossPage(cross);
                NavigationService.Navigate(membersList);
            }
            else if (eventName == "MindGames")
            {
                var MindGames = new MindGames();
                var membersList = new MindGamesPage(MindGames);
                NavigationService.Navigate(membersList);

            }*/



        }
    }
}
