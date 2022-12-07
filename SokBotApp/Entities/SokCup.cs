using SokBotApp.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SokBotApp.Entities
{
    public class SokCup : Event, INavigate
    {

        private string _eventFolderName = "SokCup/Cup" + DateTime.Now.Year.ToString() + ".json";
        private string _eventFileName = "Cup" + DateTime.Now.Year.ToString() + ".json";
        private int _teamsCount { get; set; }
        private List<Team> _teamsList { get; set; } 


        public int TeamsCount { get { return _teamsCount; } }
        public List<Team> TeamsList { get { return _teamsList; } }
        public string EventFolderName { get { return _eventFolderName; } }
        public string EventFileName { get { return _eventFileName; } }

        
        public override void GetMembers(string nameFile)
        {
            int cc = 0;
            var d = 0;
            var dd = 0;

            using (StreamReader filestream = new StreamReader(_localpath + "/" + nameFile))
            {
                string json = filestream.ReadToEnd();

                var js = Newtonsoft.Json.Linq.JArray.Parse(json);
                var team1 = new Team(0, "ФИТ");
                var team2 = new Team(1, "РТФ");
                var team3 = new Team(2, "РКФ");
                var team4 = new Team(3, "ФЭТ");
                var team5 = new Team(4, "ФСУ");
                var team6 = new Team(5, "ФВС");
                var team7 = new Team(6, "ГФ");
                var team8 = new Team(7, "ФБ");
                var team9 = new Team(8, "ЭФ");
                var team10 = new Team(9, "ЮФ");

                

                _teamsList = new List<Team>
                    {
                        team1, team2, team3, team4, team5, team6, team7, team8, team9, team10
                    };

                _teamsCount = _teamsList.Count;

                foreach (var member in js)
                {
                    var id = int.Parse(member["Id"]!.ToString());
                    var descipline = int.Parse(member["Descipline"]!.ToString());

                    var student = Students.FirstOrDefault(x => x.Id == id);
                    var faculty = student.Faculty;

                    
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
                        if (team.TeamNumber == faculty)
                        {

                            if (!team.students.Contains(student!))
                            {
                                team.students.Add(student!);

                            }
                            else
                            {
                                
                                var st = new Student();
                                st.Fio = student.Fio;
                                st.Course = student.Course;
                                st.Faculty = student.Faculty;
                                st.ProfSouze = student.ProfSouze;
                                st.Sex = student.Sex;
                                st.Descipline = descipline;
                                st.PhoneNumber = student.PhoneNumber;
                                st.Group = student.Group;
                                team.students.Add(st);

                                if (descipline >= 5)
                                {
                                    st.Descipline = 5;
                                }
                            }
                            //team.students.Add(student!);
                            //team.StudentsDescipline.Add($"{student.Fio}_{student.Descipline}", descipline);
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

                            if (descipline == 2)
                            {
                                if (student.Sex == 0)
                                {
                                    var count = team.FifaBoys[2];
                                    count++;
                                    team.FifaBoys[2] = count;
                                }
                                else
                                {
                                    var count = team.FifaGirls[2];
                                    count++;
                                    team.FifaGirls[2] = count;
                                }
                            }

                            if (descipline > 4)
                            {
                                if (student.Sex == 0)
                                {
                                    var count = team.PowerLiftingBoys[descipline];
                                    count++;
                                    team.PowerLiftingBoys[descipline] = count;
                                }
                                else
                                {
                                    var count = team.PowerLiftingGirls[descipline];
                                    count++;
                                    team.PowerLiftingGirls[descipline] = count;
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
