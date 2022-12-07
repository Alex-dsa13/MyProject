using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokBotApp.ViewModels
{
    public class TeamMembersPageViewModel : MembersPageViewModel
    {
        private ObservableCollection<string> _sportsList  = new ObservableCollection<string>();
        private SortedList<string, int> GetDescipline()
        {
            var list = new SortedList<string, int>();

            list.Add("Баскетбол", 0);
            list.Add("Волейбол", 1);
            list.Add("Футбол", 2);
            list.Add("Теннис", 3);
            list.Add("Шахматы", 4);
            list.Add("Пауэрлифтинг", 5);

            //IList<string>  res = list.Keys;

            return list;
        }

        public ObservableCollection<string> SportsList { get { return _sportsList; } }


        public TeamMembersPageViewModel(ObservableCollection<Student> members) : base(members)
        {
            _sportsList = new ObservableCollection<string>();


            foreach (var s in GetDescipline())
            {
                _sportsList.Add(s.Key);
            }
        }
        public override void filterStudentsList(List<string> filterValues, ObservableCollection<Student> studentsList, ObservableCollection<Student> filteredStudentList)
        {
            IEnumerable<Student> TempFacultyFilter; // Список студентов отфильтрованный по выбранному факультету.
            IEnumerable<Student> TempGenderFilter;  // Список студентов отфильтрованный по выбранному полу.
            IEnumerable<Student> TempSportFilter;    // Список студентов отфильтрованный по участию в профсоюзе.
            IEnumerable<Student> TempSearchFilter;  // Список студентов отфильрованный по ФИО.
            IEnumerable<Student> TempConcat;        // Список с пересекающимися элементами TempFacultyFilter и TempGenderFilter.
            IEnumerable<Student> ConcatFilters;     // Ссписок с пересекающимися элементами TempConcat и TempProfFilter.
            IEnumerable<Student> AllFilters;        // Объединенный список всех фильров.


            var fac = GetFaculties();   // Получаем список строк всех факультетов и их индексов в БД.
            var gen = GetGender();      // Получаем список строк всех значений пола и их индексов в БД.
            var sport = GetDescipline(); // Получаем список строк всех значений спорта и их индексов в БД.


            if (fac.TryGetValue(filterValues[0], out var list))
            {
                TempFacultyFilter = studentsList.Where(x => x.Faculty == fac.GetValueOrDefault(filterValues[0]));
            }
            else
            {
                TempFacultyFilter = new ObservableCollection<Student>(studentsList);
            }

            if (gen.TryGetValue(filterValues[1], out var list1))
            {
                TempGenderFilter = studentsList.Where(x => x.Sex == gen.GetValueOrDefault(filterValues[1]));
            }
            else
            {
                TempGenderFilter = new ObservableCollection<Student>(studentsList);
            }

            if (sport.TryGetValue(filterValues[2], out var list2))
            {
                TempSportFilter = studentsList.Where(x => x.Descipline == Convert.ToInt32(sport.GetValueOrDefault(filterValues[2])));
            }
            else
            {
                TempSportFilter = new ObservableCollection<Student>(studentsList);
            }

            TempSearchFilter = studentsList.Where(x => x.Fio.ToLower().Contains(filterValues[3].ToLower()));

            TempConcat = TempFacultyFilter.Intersect(TempGenderFilter);
            ConcatFilters = TempConcat.Intersect(TempSportFilter);
            AllFilters = ConcatFilters.Intersect(TempSearchFilter);

            // Изменяем основной filteredList, который выводится в окно приложения.
            for (int i = filteredStudentList.Count - 1; i >= 0; i--)
            {
                var item = filteredStudentList[i];
                if (!AllFilters.Contains(item))
                {
                    filteredStudentList.Remove(item);
                }
            }

            foreach (var item in AllFilters)
            {
                if (!filteredStudentList.Contains(item))
                {
                    filteredStudentList.Add(item);
                }
            }
        }
    }
}
