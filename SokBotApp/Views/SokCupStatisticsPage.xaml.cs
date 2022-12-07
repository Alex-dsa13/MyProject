using SokBotApp.Entities;
using SokBotApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;

namespace SokBotApp.Views
{
    /// <summary>
    /// Логика взаимодействия для SokCupStatisticsPage.xaml
    /// </summary>
    public partial class SokCupStatisticsPage : Page
    {

        public object currentEvent;
        public int teamsCountOnEvent;
        public List<Team> TeamsList;

        public bool teamsAreHostels;

        public SokCupStatisticsPage(object typeEvent)
        {
            InitializeComponent();

            if (typeEvent is SokCup cup)
            {
                currentEvent = typeEvent;
                cup.DownloadEventFile(cup.EventFolderName);
                cup.GetMembers(cup.EventFileName);
                TeamsList = cup.TeamsList;
                DataContext = new MembersPageViewModel(cup.Members);
                teamsCountOnEvent = cup.TeamsCount;
                teamsAreHostels = false;
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


        public void GenerateTeamsControls(SokCupStatisticsPage sender) // FontSize="18" FontWeight="Regular" Margin="30 0" MouseDoubleClick="GetTeamStats"
        {

            if (sender is SokCupStatisticsPage e)
            {
                Label[] label = new Label[teamsCountOnEvent]; // LinkToMembers
                for (int i = 0; i < teamsCountOnEvent; i++)
                {
                    label[i] = new Label();
                    label[i].FontSize = 18.0;
                    label[i].FontWeight = FontWeights.Regular;
                    label[i].Margin = new Thickness(30.0, 0.0, 0.0, 0.0);
                    label[i].Content = $"Команда {TeamsList[i].TeamName}";//$"{i+1} Команда {}";
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
                    label[i].Content = $"Участники {TeamsList[i].TeamName}";
                    label[i].Name = $"Team{i}";
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
            


            if (teamName == "Team0")
            {
                var team = ((SokCup)currentEvent).TeamsList[0];
                var membersList = new TeamMembersPage(team);
                NavigationService.Navigate(membersList);
            }
            else if (teamName == "Team1")
            {
                var team = ((SokCup)currentEvent).TeamsList[1];
                var membersList = new TeamMembersPage(team);
                NavigationService.Navigate(membersList);
            }
            else if (teamName == "Team2")
            {
                var team = ((SokCup)currentEvent).TeamsList[2];
                var membersList = new TeamMembersPage(team);
                NavigationService.Navigate(membersList);
            }
            else if (teamName == "Team3")
            {
                var team = ((SokCup)currentEvent).TeamsList[3];
                var membersList = new TeamMembersPage(team);
                NavigationService.Navigate(membersList);
            }
            if (teamName == "Team4")
            {
                var team = ((SokCup)currentEvent).TeamsList[4];
                var membersList = new TeamMembersPage(team);
                NavigationService.Navigate(membersList);
            }
            else if (teamName == "Team5")
            {
                var team = ((SokCup)currentEvent).TeamsList[5];
                var membersList = new TeamMembersPage(team);
                NavigationService.Navigate(membersList);
            }
            else if (teamName == "Team6")
            {
                var team = ((SokCup)currentEvent).TeamsList[6];
                var membersList = new TeamMembersPage(team);
                NavigationService.Navigate(membersList);
            }
            else if (teamName == "Team7")
            {
                var team = ((SokCup)currentEvent).TeamsList[7];
                var membersList = new TeamMembersPage(team);
                NavigationService.Navigate(membersList);
            }
            if (teamName == "Team8")
            {
                var team = ((SokCup)currentEvent).TeamsList[8];
                var membersList = new TeamMembersPage(team);
                NavigationService.Navigate(membersList);
            }
            else if (teamName == "Team9")
            {
                var team = ((SokCup)currentEvent).TeamsList[9];
                var membersList = new TeamMembersPage(team);
                NavigationService.Navigate(membersList);
            }
        }

        public void GetTeamStats(Object sender, EventArgs? e = null)
        {
            var teamName = ((Label)sender).Content.ToString();

            if (teamName == "Команда ФИТ")
            {
                var obj = ((SokCup)currentEvent).TeamsList[0];
                LoadTeamStatsToRichTextBox(obj);

            }
            else if (teamName == "Команда РТФ")
            {
                var obj = ((SokCup)currentEvent).TeamsList[1];
                LoadTeamStatsToRichTextBox(obj);
            }
            else if (teamName == "Команда РКФ")
            {
                var obj = ((SokCup)currentEvent).TeamsList[2];
                LoadTeamStatsToRichTextBox(obj);
            }
            else if (teamName == "Команда ФЭТ")
            {
                var obj = ((SokCup)currentEvent).TeamsList[3];
                LoadTeamStatsToRichTextBox(obj);
            }
            else if (teamName == "Команда ФСУ")
            {
                var obj = ((SokCup)currentEvent).TeamsList[4];
                LoadTeamStatsToRichTextBox(obj);
            }
            else if (teamName == "Команда ФВС")
            {
                var obj = ((SokCup)currentEvent).TeamsList[5];
                LoadTeamStatsToRichTextBox(obj);
            }
            else if (teamName == "Команда ГФ")
            {
                var obj = ((SokCup)currentEvent).TeamsList[6];
                LoadTeamStatsToRichTextBox(obj);
            }
            else if (teamName == "Команда ФБ")
            {
                var obj = ((SokCup)currentEvent).TeamsList[7];
                LoadTeamStatsToRichTextBox(obj);
            }
            else if (teamName == "Команда ЭФ")
            {
                var obj = ((SokCup)currentEvent).TeamsList[8];
                LoadTeamStatsToRichTextBox(obj);
            }
            else if (teamName == "Команда ЮФ")
            {
                var obj = ((SokCup)currentEvent).TeamsList[9];
                LoadTeamStatsToRichTextBox(obj);
            }
        }

        public void LoadTeamStatsToRichTextBox(Team obj)
        {
            stats.Document.Blocks.Clear();

            FlowDocument flow = new FlowDocument();
            Paragraph paragraph = new Paragraph();

            var Basketball = $"Баскетбол: {obj.TeamStructure[(int)Team.Descipline.Basketball]}      из 10";
            var Volleyball = $"Волейбол: {obj.VolleyballGirls[(int)Team.Descipline.Volleyball]}Ж и {obj.VolleyballBoys[(int)Team.Descipline.Volleyball]}М       из 3Ж/7м";
            var Football = $"ФИФА: {obj.FifaGirls[(int)Team.Descipline.Football]}Ж и {obj.FifaBoys[(int)Team.Descipline.Football]}М     из 2Ч";
            var Tennis = $"Теннис: {obj.TennisGirls[(int)Team.Descipline.Pingpong]}Ж и {obj.TennisBoys[(int)Team.Descipline.Pingpong]}М     из 2Ж/2М";
            var Chess = $"Шахматы: {obj.ChessGirls[(int)Team.Descipline.Chess]}Ж и {obj.ChessBoys[(int)Team.Descipline.Chess]}М     из 2Ж/2М";
            var PowerLifting_Low = $"Пауэрлифтинг(Легкая весовая): {obj.PowerLiftingGirls[(int)Team.Descipline.PowerLifting_Low]}Ж и {obj.PowerLiftingBoys[(int)Team.Descipline.PowerLifting_Low]}М       из 1Ж/1М";
            var PowerLifting_Medium = $"Пауэрлифтинг(Средняя весовая): {obj.PowerLiftingGirls[(int)Team.Descipline.PowerLifting_Medium]}Ж и {obj.PowerLiftingBoys[(int)Team.Descipline.PowerLifting_Medium]}М       из 1Ж/1М"; ;
            var PowerLifting_High = $"Пауэрлифтинг(Тяжелая весовая): {obj.PowerLiftingGirls[(int)Team.Descipline.PowerLifting_High]}Ж и {obj.PowerLiftingBoys[(int)Team.Descipline.PowerLifting_High]}М       из 1Ж/1М"; ;

            paragraph.Inlines.Add($"{obj.TeamName.ToString()} состав: \r\n\r\n");
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

        public void Print_Document(object sender, EventArgs e)
        {
            var obj = ((SokCup)currentEvent).TeamsList[3];
            var l = new ObservableCollection<Student>();

            foreach (var s in obj.students)
            {
                if (s.DesciplineString == "Баскетбол")
                {
                    l.Add(s);
                }
            }


            var doc = new Document("CupTemplate.docx", l);
            var c = doc.ChangeTemplateSokCup();

            if (c)
            {
                MessageBox.Show("Document created!");
            }
            else
            {
                MessageBox.Show("Error!!!");
            }
        }
    }
}
