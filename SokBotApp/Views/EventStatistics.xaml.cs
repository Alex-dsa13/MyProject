using Newtonsoft.Json.Linq;
using SokBotApp.Entities;
using SokBotApp.ViewModels;
using System;
using System.Collections.Generic;
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
using VkNet.Model.Results.Notifications;

namespace SokBotApp.Views
{
    /// <summary>
    /// Логика взаимодействия для EventStatistics.xaml
    /// </summary>
    public partial class EventStatistics : Page
    {
        public object currentEvent;
        public int teamsCountOnEvent;

        public bool teamsAreHostels;

        public EventStatistics(object typeEvent)
        {
            InitializeComponent();

            if (typeEvent is CupFirstCourse cup)
            {
                currentEvent = typeEvent;
                cup.DownloadEventFile(cup.EventFolderName);
                cup.GetMembers(cup.EventFileName);
                DataContext = new MembersPageViewModel(cup.Members);
                teamsCountOnEvent = cup.TeamsCount;
                teamsAreHostels = true;
            }

            GetEventData();
            GenerateTeamsControls(this);


        }


        public void GetEventData()
        {
            FlowDocument flow = new FlowDocument();
            Paragraph paragraph = new Paragraph();

            paragraph.Inlines.Add(((MembersPageViewModel)DataContext).EventMembers.Count.ToString());

            flow.Blocks.Add(paragraph);
            studentsCount.Document = flow;



            FlowDocument flow1 = new FlowDocument();
            Paragraph paragraph1 = new Paragraph();

            paragraph1.Inlines.Add(teamsCountOnEvent.ToString());

            flow1.Blocks.Add(paragraph1);
            teamsCount.Document = flow1;
        }

        public void GenerateTeamsControls(EventStatistics sender) // FontSize="18" FontWeight="Regular" Margin="30 0" MouseDoubleClick="GetTeamStats"
        {

            if (sender is EventStatistics e)
            {
                Label[] label = new Label[teamsCountOnEvent]; // LinkToMembers
                for (int i = 0; i < teamsCountOnEvent; i++)
                {
                    label[i] = new Label();
                    label[i].FontSize = 18.0;
                    label[i].FontWeight = FontWeights.Regular;
                    label[i].Margin = new Thickness(30.0, 0.0, 0.0, 0.0);
                    label[i].Content = $"{i + 3} Общежитие";
                    label[i].MouseDoubleClick += Label_MouseDoubleClick;
                    


                    e.teamsList.Children.Add(label[i]);
                }

                Label[] link = new Label[teamsCountOnEvent];
                for (int i = 0; i < teamsCountOnEvent; i++)
                {
                    label[i] = new Label();
                    label[i].FontSize = 18.0;
                    label[i].FontWeight = FontWeights.Regular;
                    label[i].Margin = new Thickness(30.0, 0.0, 0.0, 0.0);
                    label[i].Content = $"Участники {i + 3} общежития";
                    label[i].Name = $"Hostel{i + 3}";
                    label[i].MouseDoubleClick += Link_MouseDoubleClick;



                    e.LinkToMembers.Children.Add(label[i]);
                }

            }

            
        }

        private void Link_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            GoLink(sender);
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            GetTeamStats(sender);
        }


        public void GoLink(object sender)
        {
            var teamName = ((Label)sender).Name;
            

            if (teamName == "Hostel3")
            {
                var team = ((CupFirstCourse)currentEvent).TeamsList[0];
                var membersList = new TeamMembersPage(team);
                NavigationService.Navigate(membersList);
            }
            else if (teamName == "Hostel4")
            {
                var team = ((CupFirstCourse)currentEvent).TeamsList[1];
                var membersList = new TeamMembersPage(team);
                NavigationService.Navigate(membersList);
            }
            else if (teamName == "Hostel5")
            {
                var team = ((CupFirstCourse)currentEvent).TeamsList[2];
                var membersList = new TeamMembersPage(team);
                NavigationService.Navigate(membersList);
            }
            else if (teamName == "Hostel6")
            {
                var team = ((CupFirstCourse)currentEvent).TeamsList[3];
                var membersList = new TeamMembersPage(team);
                NavigationService.Navigate(membersList);
            }
        }
        

        public void GetTeamStats(Object sender, EventArgs? e = null)
        {
            var teamName = ((Label)sender).Content.ToString();

            if (teamName == "3 Общежитие")
            {
                var obj = ((CupFirstCourse)currentEvent).TeamsList[0];
                LoadTeamStatsToRichTextBox(obj);

            }
            else if (teamName == "4 Общежитие")
            {
                var obj = ((CupFirstCourse)currentEvent).TeamsList[1];
                LoadTeamStatsToRichTextBox(obj);
            }
            else if (teamName == "5 Общежитие")
            {
                var obj = ((CupFirstCourse)currentEvent).TeamsList[2];
                LoadTeamStatsToRichTextBox(obj);
            }
            else if (teamName == "6 Общежитие")
            {
                var obj = ((CupFirstCourse)currentEvent).TeamsList[3];
                LoadTeamStatsToRichTextBox(obj);
            }
        }

        public void LoadTeamStatsToRichTextBox(Team obj)
        {
            stats.Document.Blocks.Clear();

            FlowDocument flow = new FlowDocument();
            Paragraph paragraph = new Paragraph();

            var Basketball = $"Баскетбол: {obj.TeamStructure[(int)Team.Descipline.Basketball]}      из 6";
            var Volleyball = $"Волейбол: {obj.VolleyballGirls[(int)Team.Descipline.Volleyball]}Ж и {obj.VolleyballBoys[(int)Team.Descipline.Volleyball]}М       из 3Ж/5м";
            var Football = $"Футбол: {obj.TeamStructure[(int)Team.Descipline.Football]}     из 10";
            var Tennis = $"Теннис: {obj.TennisGirls[(int)Team.Descipline.Pingpong]}Ж и {obj.TennisBoys[(int)Team.Descipline.Pingpong]}М     из 2Ж/2М";
            var Chess = $"Шахматы: {obj.ChessGirls[(int)Team.Descipline.Chess]}Ж и {obj.ChessBoys[(int)Team.Descipline.Chess]}М     из 2Ж/2М";
            var PowerLifting_Low = $"Пауэрлифтинг(Легкая весовая): {obj.TeamStructure[(int)Team.Descipline.PowerLifting_Low]}       из 1";
            var PowerLifting_Medium = $"Пауэрлифтинг(Средняя весовая): {obj.TeamStructure[(int)Team.Descipline.PowerLifting_Medium]}        из 1";
            var PowerLifting_High = $"Пауэрлифтинг(Тяжелая весовая): {obj.TeamStructure[(int)Team.Descipline.PowerLifting_High]}        из 1";

            paragraph.Inlines.Add($"{obj.TeamNumber.ToString()} Общежитие \r\n\r\n");
            paragraph.Inlines.Add($"{Basketball} \r\n");
            paragraph.Inlines.Add($"{Volleyball} \r\n");
            paragraph.Inlines.Add($"{Football} \r\n");
            paragraph.Inlines.Add($"{Tennis} \r\n");
            paragraph.Inlines.Add($"{Chess} \r\n");
            paragraph.Inlines.Add($"{PowerLifting_Low} \r\n");
            paragraph.Inlines.Add($"{PowerLifting_Medium} \r\n");
            paragraph.Inlines.Add($"{PowerLifting_High} \r\n");

            flow.Blocks.Add(paragraph);
            stats.Document = flow;
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
