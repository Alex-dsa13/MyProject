using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents.DocumentStructures;
using SokBotApp.Models;
using VkNet.Model;

namespace SokBotApp
{

    


    public partial class Student
    {
        public Student()
        {
            
        }

        public long Id { get; set; }
        public string Fio { get; set; } = null!;
        public string Group { get; set; } = null!;
        public int Sex { get; set; }
        public int Faculty { get; set; }
        public string Course { get; set; } = null!;
        public long IdVk { get; set; }
        public bool ProfSouze { get; set; }
        public string PhoneNumber { get; set; } = null!;

        [NotMapped]
        public int? Descipline { get; set; } = null;

        [NotMapped]
        public string? GenderString
        {
            get
            {
                string s = "";
                if (Sex == 0) s = "М";
                else  s = "Ж";

                return s;
            }
        }

        [NotMapped]
        public string? ProfSouzeString
        {
            get
            {
                string s = "";
                if (ProfSouze) s = "Состоит";
                else s = "Не состоит";

                return s;
            }
        }

        [NotMapped]
        public string? FacultyString
        {
            get
            {
                var faclist = GetFaculties();

                if (faclist.TryGetValue(Faculty, out var list))
                {
                    return faclist.GetValueOrDefault(Faculty);
                }
                else
                {
                    return "Нет такого факультета";
                }

                
            }
        }

        [NotMapped]
        public string? DesciplineString
        {
            get
            {
                //var descipline = GetDescipline();

                if (StortsListSokCup[(int)Descipline] != null)
                {
                    return StortsListSokCup[(int)Descipline];
                }
                else
                {
                    return "Нет такого спорта";
                }


            }
        }

        [NotMapped]
        public string? DistanceString
        {
            get
            {
                //var descipline = GetDescipline();

                if (distanceCross[(int)Descipline] != null)
                {
                    return distanceCross[(int)Descipline];
                }
                else
                {
                    return "Нет такой дистанции";
                }


            }
        }

        public List<string> distanceCross = new List<string>()
        {
            "2 КМ", "4 КМ"
        };

        public List<string> StortsListSokCup = new List<string>()
        {
            "Баскетбол", "Волейбол", "Футбол", "Теннис", "Шахматы", "Пауэрлифтинг"
        };

        public SortedList<int, string> GetDescipline()
        {
            var list = new SortedList<int, string>();


            list.Add(0, "Баскетбол");
            list.Add(1, "Волейбол");
            list.Add(2, "Футбол");
            list.Add(3, "Теннис");
            list.Add(4, "Шахматы");
            list.Add(5, "Поверлифтинг");

            //IList<string>  res = list.Keys;

            return list;
        }

        public SortedList<int, string> GetFaculties()
        {
            var list = new SortedList<int, string>();


            list.Add(0, "ФИТ");
            list.Add(1, "РТФ");
            list.Add(2, "РКФ");
            list.Add(3, "ФЭТ");
            list.Add(4, "ФСУ");
            list.Add(5, "ФВС");
            list.Add(6, "ГФ");
            list.Add(7, "ФБ");
            list.Add(8, "ЭФ");
            list.Add(9, "ЮФ");
            list.Add(10, "ЗАОЧНЫЙ");

            //IList<string>  res = list.Keys;

            return list;
        }
        /*public void AddUser()
        {
            sokuser_databaseContext context = new sokuser_databaseContext();

            var n = new Student()
            {
                Fio = "Даниил Мальцев",
                Group = "429-1",
                Sex = 1,
                Faculty = 1,
                Course = "2",
                IdVk = 1234,
                ProfSouze = true,
                PhoneNumber = "=79039536255"
            };

            var n1 = new Student()
            {
                Fio = "Арина Муравьева",
                Group = "429-2",
                Sex = 1,
                Faculty = 5,
                Course = "1",
                IdVk = 1234444,
                ProfSouze = true,
                PhoneNumber = "=79539536255"
            };


            var n2 = new Student()
            {
                Fio = "Майк Тайсон",
                Group = "429-1",
                Sex = 1,
                Faculty = 7,
                Course = "4",
                IdVk = 1234231231,
                ProfSouze = true,
                PhoneNumber = "=79039136255"
            };



            var n3 = new Student()
            {
                Fio = "Путин Президент Мира",
                Group = "429-1",
                Sex = 1,
                Faculty = 2,
                Course = "3",
                IdVk = 12312321414,
                ProfSouze = true,
                PhoneNumber = "=79039538888"
            };



            var n4 = new Student()
            {
                Fio = "Гарик Харламов",
                Group = "429-2",
                Sex = 1,
                Faculty = 1,
                Course = "1",
                IdVk = 123665334,
                ProfSouze = true,
                PhoneNumber = "=77039536255"
            };

            var n5 = new Student()
            {
                Fio = "Тони Старк",
                Group = "400",
                Sex = 1,
                Faculty = 3,
                Course = "1",
                IdVk = 12343243243,
                ProfSouze = false,
                PhoneNumber = "=79039536255"
            };

            var n6 = new Student()
            {
                Fio = "Конор Месси",
                Group = "777",
                Sex = 1,
                Faculty = 8,
                Course = "1",
                IdVk = 1234444,
                ProfSouze = false,
                PhoneNumber = "=79539536255"
            };


            var n7 = new Student()
            {
                Fio = "Хасбик Хасбик",
                Group = "100-1",
                Sex = 0,
                Faculty = 7,
                Course = "2",
                IdVk = 123423421231,
                ProfSouze = false,
                PhoneNumber = "=79039136255"
            };



            var n8 = new Student()
            {
                Fio = "Хабиб Нурик",
                Group = "45-1",
                Sex = 1,
                Faculty = 8,
                Course = "3",
                IdVk = 1231236221414,
                ProfSouze = false,
                PhoneNumber = "=79039538888"
            };



            var n9 = new Student()
            {
                Fio = "Байден Гевин",
                Group = "300-3",
                Sex = 0,
                Faculty = 0,
                Course = "2",
                IdVk = 123642265334,
                ProfSouze = false,
                PhoneNumber = "=77039536255"
            };

            context.Add(n);
            context.Add(n1);
            context.Add(n2);
            context.Add(n3);
            context.Add(n4);
            context.Add(n5);
            context.Add(n6);
            context.Add(n7);
            context.Add(n8);
            context.Add(n9);
            context.SaveChanges();
        }*/
    }
}
