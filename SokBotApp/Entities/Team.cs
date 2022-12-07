using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokBotApp.Entities
{
    public class Team
    {

        public enum Descipline
        {
            Basketball,
            Volleyball,
            Football,
            Pingpong,
            Chess,
            PowerLifting_Low,
            PowerLifting_Medium,
            PowerLifting_High,
        }

        public Dictionary<int, int> TeamStructure { get; set; }
        public Dictionary<string, int> StudentsDescipline { get; set; }
        public ObservableCollection<Student> students { get; set; }

        public Dictionary<int, int> TennisBoys { get; set; }
        public Dictionary<int, int> TennisGirls { get; set; }
        public Dictionary<int, int> VolleyballBoys { get; set; }
        public Dictionary<int, int> VolleyballGirls { get; set; }
        public Dictionary<int, int> ChessBoys { get; set; }
        public Dictionary<int, int> ChessGirls { get; set; }
        public Dictionary<int, int> FifaBoys { get; set; }
        public Dictionary<int, int> FifaGirls { get; set; }
        public Dictionary<int, int> PowerLiftingGirls { get; set; }
        public Dictionary<int, int> PowerLiftingBoys { get; set; }




        public int TeamNumber { get; set; }
        public string TeamName { get; set; }

        public Team(int teamNuber, string? name = null)
        {
            TeamNumber = teamNuber;
            TeamName = name;
            StudentsDescipline = new Dictionary<string, int>();
            students = new ObservableCollection<Student>();

            TeamStructure = new Dictionary<int, int>()
            {
                {0, 0},
                {1, 0},
                {2, 0},
                {3, 0},
                {4, 0},
                {5, 0},
                {6, 0},
                {7, 0}
            };

            TennisBoys = new Dictionary<int, int>()
            {
                { 3, 0 }
            };

            TennisGirls = new Dictionary<int, int>()
            {
                { 3, 0 }
            };

            VolleyballBoys = new Dictionary<int, int>()
            {
                { 1, 0 }
            };

            VolleyballGirls = new Dictionary<int, int>()
            {
                { 1, 0 }
            };

            ChessBoys = new Dictionary<int, int>()
            {
                { 4, 0 }
            };

            ChessGirls = new Dictionary<int, int>()
            {
                { 4, 0 }
            };

            FifaBoys = new Dictionary<int, int>()
            {
                { 2, 0 }
            };

            FifaGirls = new Dictionary<int, int>()
            {
                { 2, 0 }
            };

            PowerLiftingBoys = new Dictionary<int, int>()
            {
                { 5, 0 },
                { 6, 0 },
                { 7, 0 }
            };

            PowerLiftingGirls = new Dictionary<int, int>()
            {
                { 5, 0 },
                { 6, 0 },
                { 7, 0 }
            };


        }



    }
}
