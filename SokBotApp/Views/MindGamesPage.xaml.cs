using SokBotApp.Entities;
using SokBotApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;


namespace SokBotApp.Views
{
    /// <summary>
    /// Логика взаимодействия для MindGames.xaml
    /// </summary>
    public partial class MindGamesPage : Page
    {
        public object currentEvent;

        public MindGamesPage(object obj)
        {
            InitializeComponent();

            if (obj is MindGames mg)
            {
                currentEvent = obj;
                mg.DownloadEventFile(mg.EventFolderName + mg.UsersFile); //DownloadEventFile(_eventFolderName + _usersfile);
                mg.DownloadEventFile(mg.EventFolderName + mg.TeamsFile);
                mg.DownloadEventFile(mg.EventFolderName + mg.Registeredteams);
                mg.GetMembers(mg.Registeredteams);
                DataContext = new MembersPageViewModel(mg.Members);
            }

            FlowDocument flow = new FlowDocument();
            Paragraph paragraph = new Paragraph();

            paragraph.Inlines.Add(((MembersPageViewModel)DataContext).EventMembers.Count.ToString());

            flow.Blocks.Add(paragraph);
            studentsCount.Document = flow;




            System.Timers.Timer t = new System.Timers.Timer();

            t.Interval = 300000;
            t.Elapsed += (s, a) =>
            {
                //Dispatcher.Invoke(() => reloadButton_Click(DataContext));
            };

            t.Start();
        }


        public void ListViewItem_MouseDoubleClick(object sender, EventArgs e)
        {
            var student = (dynamic)ListViewMembers.SelectedItems[0]!;

            var link = new ProcessStartInfo("https://vk.com/id" + student.IdVk.ToString())
            {
                UseShellExecute = true,
                Verb = "open"
            };

            Process.Start(link);
        }

        public void LinkVk_Click(object sender, EventArgs e)
        {
            var context = (dynamic)sender;
            var vkLink = context.DataContext.IdVk.ToString();



            var link = new ProcessStartInfo("https://vk.com/id" + vkLink)
            {
                UseShellExecute = true,
                Verb = "open"
            };

            Process.Start(link);
        }

        public void Filter_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string gender = "";
            string faculty = "";
            string distance = "";
            string search = "";

            if (genderFilter != null) gender = genderFilter.SelectedValue.ToString()!;
            if (facultyFilter != null) faculty = facultyFilter.SelectedValue.ToString()!;
            //if (distanceFilter != null) distance = distanceFilter.SelectedValue.ToString()!;
            if (searchByFio != null) search = searchByFio.Text;


            List<string> filterValues = new List<string>
            {
                faculty, gender, distance, search
            };

            var data = (MembersPageViewModel)DataContext;
            if (data != null) data.filterStudentsList(filterValues, data.EventMembers, data.FilteredMembers);

        }


        private void reloadButton_Click(object sender, RoutedEventArgs? e = null)
        {

            string search = "";
            string gender = "";
            string faculty = "";
            string prof = "";

            if (genderFilter != null) gender = genderFilter.SelectedValue.ToString()!;
            if (facultyFilter != null) faculty = facultyFilter.SelectedValue.ToString()!;
            //if (distanceFilter != null) prof = distanceFilter.SelectedValue.ToString()!;
            if (searchByFio != null) search = searchByFio.Text;


            List<string> filterValues = new List<string>
            {
                faculty, gender, prof, search
            };

            var data = (MembersPageViewModel)DataContext;
            data.RefreshEventMembersList(filterValues, currentEvent, data.EventMembers, data.FilteredMembers);

            FlowDocument flow = new FlowDocument();
            Paragraph paragraph = new Paragraph();

            paragraph.Inlines.Add(data.EventMembers.Count.ToString());

            flow.Blocks.Add(paragraph);
            studentsCount.Document = flow;
        }

        public void sendMessage_Click(object sender, RoutedEventArgs? e = null)
        {

            var data = (MembersPageViewModel)DataContext;
            //data.GetEventMembers("Cross", "23.10.2022", data);

            var members = data.FilteredMembers;
            var membersList = new SendMessages(members);
            NavigationService.Navigate(membersList);
        }

        public void printButton_Click(object sender, RoutedEventArgs? e = null)
        {
            var context = (MembersPageViewModel)DataContext;
            var members = context.EventMembers;
            var print = new Document("test.docx", members);
            var isgenerated = print.CreateDocument();

            if (isgenerated)
            {
                MessageBox.Show("Документ сгенерирован.");
            }
            else
            {
                MessageBox.Show("Документ не сгенерирован.");
            }
        }

        public void backButton_Click(object sender, EventArgs? e = null)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Нельзя вернуться назад.");
            }
        }
    }
}
