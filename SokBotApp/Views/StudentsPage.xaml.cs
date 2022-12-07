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
    /// Логика взаимодействия для StudentsPage.xaml
    /// </summary>
    public partial class StudentsPage : Page
    {

        public StudentsPage()
        {
            InitializeComponent();  
            DataContext = new StudentsPageViewModel();

            FlowDocument flow = new FlowDocument();
            Paragraph paragraph = new Paragraph();

            paragraph.Inlines.Add(((StudentsPageViewModel)DataContext).Students.Count.ToString());

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

        public void Filter_SelectionChanged(object sender, EventArgs e)
        {
            string search = "";
            string gender = "";
            string faculty = "";
            string prof = "";

            if (genderFilter != null) gender = genderFilter.SelectedValue.ToString()!;
            if (facultyFilter != null) faculty = facultyFilter.SelectedValue.ToString()!;
            if (profFilter != null) prof = profFilter.SelectedValue.ToString()!;
            if (searchByFio != null) search = searchByFio.Text;

            List<string> filterValues = new List<string>
            {
                faculty, gender, prof, search
            };

            var data = (StudentsPageViewModel)DataContext;
            if (data != null) data.filterStudentsList(filterValues, data.Students, data.FilteredList);
            
        }

        public void ListViewItem_MouseDoubleClick(object sender, EventArgs e)
        {
            var student = (dynamic)ListViewStudents.SelectedItems[0]!;

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

        public void LinkVk_Click1(object sender, EventArgs e)
        {


            /*
            var link = new ProcessStartInfo("https://vk.com/id" + student.IdVk.ToString())
            {
                UseShellExecute = true,
                Verb = "open"
            };

            Process.Start(link);*/
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

            List<string> filterValues = new List<string>
            {
                faculty, gender, prof, search
            };

            var data = (StudentsPageViewModel)DataContext;
            data.RefreshStudentsList(filterValues, data.Students, data.FilteredList);

            FlowDocument flow = new FlowDocument();
            Paragraph paragraph = new Paragraph();

            paragraph.Inlines.Add(data.Students.Count.ToString());

            flow.Blocks.Add(paragraph);
            studentsCount.Document = flow;
        }

            public void sendMessage_Click(object sender, EventArgs e)
        {
            var data = (StudentsPageViewModel)DataContext;
            //data.GetEventMembers("Cross", "23.10.2022", data);

            var members = data.FilteredList;
            var membersList = new SendMessages(members);
            NavigationService.Navigate(membersList);
        }
    }
}
