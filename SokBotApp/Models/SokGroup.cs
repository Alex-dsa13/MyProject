using SokApp;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SokBotApp.Models
{
    public partial class SokGroup
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;


        public void AddData(sokuser_databaseContext context)
        {
            var request = new GroupParse("https://timetable.tusur.ru/api/v2/raspisanie_vuzov");
            request.Run();

            var response = request.Response;

            var json = Newtonsoft.Json.Linq.JObject.Parse(response);
            var faculties = json["faculties"];

            if (faculties != null)
            {
                foreach (var faculty in faculties)
                {
                    var groups = faculty["groups"];

                    if (groups != null)
                    {
                        foreach (var group in groups)
                        {
                            string s = (string)group["name"]!;
                            var AddData = new SokGroup()
                            {
                                Name = s
                            };

                            context.SokGroups.Add(AddData);
                            Console.WriteLine("Запись успешно добавлена в контекст!");
                        }
                    }
                }
            }

            context.SaveChanges();
            Console.WriteLine("База обновлена!");
        }
    }


}
