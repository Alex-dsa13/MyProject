using Microsoft.EntityFrameworkCore.Diagnostics;
using SokBotApp.Entities;
using SokBotApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SokBotApp.Views
{
    /// <summary>
    /// Логика взаимодействия для TeamMembersPage.xaml
    /// </summary>
    public partial class TeamMembersPage : Page
    {
        public object currentEvent;

        public TeamMembersPage(object typeEvent)
        {
            InitializeComponent();

            if (typeEvent is Team team)
            {
                currentEvent = typeEvent;
                DataContext = new TeamMembersPageViewModel(team.students);
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
            string sport = "";
            string search = "";

            if (genderFilter != null) gender = genderFilter.SelectedValue.ToString()!;
            if (facultyFilter != null) faculty = facultyFilter.SelectedValue.ToString()!;
            if (profFilter != null) sport = profFilter.SelectedValue.ToString()!;
            if (searchByFio != null) search = searchByFio.Text;


            List<string> filterValues = new List<string>
            {
                faculty, gender, sport, search
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
            if (profFilter != null) prof = profFilter.SelectedValue.ToString()!;
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
            

            Dictionary<int, string> FullFacultyString = new Dictionary<int, string>()
            {
                { 0, "Факультета инновационных технологий" },
                { 1, "Радиотехнического факультета" },
                { 2, "Радиоконструкторского факультета" },
                { 3, "Факультета электронной техники" },
                { 4, "Факультета систем управления" },
                { 5, "Факультета вычислительных систем" },
                { 6, "Гуманитарного факультета" },
                { 7, "Факультета безопасности" },
                { 8, "Экономического факультета" },
                { 9, "Юридического факультета" },
            };

            var AllDesciplineStrings = new List<List<string>>()
            {
                new List<string>{ "Баскетболу", "баскетбол" },
                new List<string>{ "Волейболу", "волейбол" },
                new List<string>{ "FIFA", "fifa" },
                new List<string>{ "Теннису", "теннис" },
                new List<string>{ "Шахматам", "шахматы" },
                new List<string>{ "Пауэрлифтингу", "пауэрлифтинг" },
                new List<string>{ "Пауэрлифтингу", "пауэрлифтинг" },
                new List<string>{ "Пауэрлифтингу", "пауэрлифтинг" }
            };


            Dictionary<int, string> AllSokStuff = new Dictionary<int, string>()
            {
                { 0, "Фатеев М.В. " },
                { 1, "Племяник Д.В. " },
                { 2, "Титов И.В. " },
                { 3, "Вайсблат А.Д. " },
                { 4, "Верповский С.В. " },
                { 5, "Хохлов Д.Т." },
                { 6, "Яценко Т.Е. " },
                { 7, "Лисовская И.А. " },
                { 8, "Волочий Д.К. " },
                { 9, "Демушева Е.И. " },
            };

            

            var obj = (Team)currentEvent; //TeamMembersPageViewModel(team.students)
            var StudentsBasketball = new ObservableCollection<Student>();
            var StudentsFootball = new ObservableCollection<Student>();
            var StudentsTennis = new ObservableCollection<Student>();
            var StudentsPowerLifting = new ObservableCollection<Student>();
            var StudentsVolleyball = new ObservableCollection<Student>();
            var StudentsChess = new ObservableCollection<Student>();
            var FacultyFromDB = -1;
            var DocIsGenerated = false;




            var AllCollectionsList = new List<ObservableCollection<Student>>()
            {
                { StudentsBasketball },
                { StudentsFootball },
                { StudentsTennis },
                { StudentsPowerLifting },
                { StudentsVolleyball },
                { StudentsChess },
            };

            foreach (var s in obj.students)
            {
                if (FacultyFromDB == -1)
                {
                    FacultyFromDB = s.Faculty;
                }


                if (s.DesciplineString == "Баскетбол")
                {
                    StudentsBasketball.Add(s);
                }
                else if (s.DesciplineString == "Футбол")
                {
                    StudentsFootball.Add(s);
                }
                else if (s.DesciplineString == "Теннис")
                {
                    StudentsTennis.Add(s);
                }
                
                else if (s.DesciplineString == "Волейбол")
                {
                    StudentsVolleyball.Add(s);
                }


                /*
                else if (s.DesciplineString == "Шахматы")
                {
                    StudentsChess.Add(s);
                }
                else if (s.DesciplineString == "Пауэрлифтинг")
                {
                    StudentsPowerLifting.Add(s);
                }
                */
            }


            foreach (var studentsList in AllCollectionsList)
            {

                if (studentsList.Count > 0)
                {
                    var fileName = $"{studentsList[0].FacultyString}_{studentsList[0].DesciplineString}.docx";

                    var doc = new Document(fileName, studentsList, FullFacultyString[FacultyFromDB], "Кубок СОК",
                        AllDesciplineStrings[studentsList[0].Descipline.Value], AllSokStuff[FacultyFromDB]);
                    var c = doc.ChangeTemplateSokCup();
                    DocIsGenerated = c;
                }
                


            }

            if (DocIsGenerated)
            {
                MessageBox.Show("Все заявки успешно сгенерированы!");
            }
            else
            {
                MessageBox.Show("Произошла ошибка во время генерации!");
            }


            //var doc = new Document("FB_Footbal.docx", StudentsBasketball, "Факультета безопасности", "Кубок СОК", Team.Descipline.Football.ToString());
            //var c = doc.ChangeTemplateSokCup();


            /*var context = (MembersPageViewModel)DataContext;
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
            }*/
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
