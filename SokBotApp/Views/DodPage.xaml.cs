using SokBotApp.Entities;
using SokBotApp.ViewModels;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace SokBotApp.Views
{
    /// <summary>
    /// Логика взаимодействия для DodPage.xaml
    /// </summary>
    public partial class DodPage : Page
    {
        public DodPage()
        {
            InitializeComponent();
            DataContext = new DodPageViewModel();

            System.Timers.Timer t = new System.Timers.Timer();

            t.Interval = 300000;
            t.Elapsed += (s, a) =>
            {
                Dispatcher.Invoke(() => reloadButton_Click(DataContext));
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

        public void Filter_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string gender = "";
            string faculty = "";
            string prof = "";
            string search = "";

            if (genderFilter != null) gender = genderFilter.SelectedValue.ToString()!;
            if (facultyFilter != null) faculty = facultyFilter.SelectedValue.ToString()!;
            if (profFilter != null) prof = profFilter.SelectedValue.ToString()!;
            if (searchByFio != null) search = searchByFio.Text;


            //var data = (MembersPageViewModel)DataContext;
            //if (data != null) data.filterStudentsList(faculty, gender, prof, search, data);

            
        }


        private void reloadButton_Click(object sender, RoutedEventArgs? e = null)
        {
            string search = "";
            string gender = "";
            string faculty = "";
            string prof = "";

            if (genderFilter != null) gender = genderFilter.SelectedValue.ToString()!;
            if (facultyFilter != null) faculty = facultyFilter.SelectedValue.ToString()!;
            if (profFilter != null) prof = profFilter.SelectedValue.ToString()!;
            if (searchByFio != null) search = searchByFio.Text;



            //var data = (MembersPageViewModel)DataContext;
            //data.RefreshStudentsList(faculty, gender, prof, search, data);
        }

        public void sendMessage_Click(object sender, RoutedEventArgs? e = null)
        {
            
            var data = (DodPageViewModel)DataContext;
            //data.GetEventMembers("Cross", "23.10.2022", data);

            //var members = data.FilteredMembers;
            //var membersList = new SendMessages(members);
            //NavigationService.Navigate(membersList);
        }

        public void printButton_Click(object sender, RoutedEventArgs? e = null)
        {
            var context = (DodPageViewModel)DataContext;
            var members = context.Members;
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
    }
}
