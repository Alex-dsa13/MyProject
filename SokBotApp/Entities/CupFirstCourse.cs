using SokBotApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SokBotApp.Entities
{
    public class CupFirstCourse : Event, INavigate
    {

        private string _eventFolderName = "CupFirstCourse/Cup" + DateTime.Now.Year.ToString() + ".json";
        private string _eventFileName = "Cup" + DateTime.Now.Year.ToString() + ".json";
        private int _teamsCount { get; set; }
        private List<Team> _teamsList { get; set; }


        public int TeamsCount { get { return _teamsCount; } }
        public List<Team> TeamsList { get { return _teamsList; } }
        public string EventFolderName { get { return _eventFolderName; } }
        public string EventFileName { get { return _eventFileName; } }


        public CupFirstCourse()
        {

            //DownloadEventFile(_eventFolderName);
            //GetMembers(_eventFileName);
        }
        public override void GetMembers(string nameFile)
        {
            using (StreamReader filestream = new StreamReader(_localpath + "/" + nameFile))
            {
                string json = filestream.ReadToEnd();

                var js = Newtonsoft.Json.Linq.JArray.Parse(json);
                var team1 = new Team(3);
                var team2 = new Team(4);
                var team3 = new Team(5);
                var team4 = new Team(6);

                _teamsList = new List<Team>
                    {
                        team1, team2, team3, team4
                    };

                _teamsCount = _teamsList.Count;

                foreach (var member in js)
                {
                    var id = int.Parse(member["Id"]!.ToString());
                    var hostel = int.Parse(member["HostelNumber"]!.ToString());
                    var descipline = int.Parse(member["Descipline"]!.ToString());

                    var student = Students.FirstOrDefault(x => x.Id == id);
                    if (student != null)
                    {
                        if (student.Descipline == null)
                        {

                            student.Descipline = descipline;

                            if (descipline >= 5)
                            {
                                student.Descipline = 5;
                            }
                        }
                        Members.Add(student);
                    }



                    foreach (var team in _teamsList)
                    {
                        if (team.TeamNumber == hostel)
                        {
                            team.students.Add(student!);
                            team.StudentsDescipline.Add($"{student.Fio}_{student.Descipline}", descipline);
                            for (int i = 0; i < team.TeamStructure.Count; i++)
                            {
                                if (team.TeamStructure.ElementAt(i).Key == descipline)
                                {
                                    var count = team.TeamStructure[i];
                                    count++;
                                    team.TeamStructure[i] = count;
                                }


                            }



                            if (descipline == 3)
                            {
                                if (student.Sex == 0)
                                {
                                    var count = team.TennisBoys[3];
                                    count++;
                                    team.TennisBoys[3] = count;
                                }
                                else
                                {
                                    var count = team.TennisGirls[3];
                                    count++;
                                    team.TennisGirls[3] = count;
                                }

                            }

                            if (descipline == 1)
                            {
                                if (student.Sex == 0)
                                {
                                    var count = team.VolleyballBoys[1];
                                    count++;
                                    team.VolleyballBoys[1] = count;
                                }
                                else
                                {
                                    var count = team.VolleyballGirls[1];
                                    count++;
                                    team.VolleyballGirls[1] = count;
                                }

                            }

                            if (descipline == 4)
                            {
                                if (student.Sex == 0)
                                {
                                    var count = team.ChessBoys[4];
                                    count++;
                                    team.ChessBoys[4] = count;
                                }
                                else
                                {
                                    var count = team.ChessGirls[4];
                                    count++;
                                    team.ChessGirls[4] = count;
                                }
                            }
                        }
                    }
                }
            }
        }

        public Page NavigateTo()
        {
            var nav = new MembersPage(this);
            return nav;
        }
    }
}
