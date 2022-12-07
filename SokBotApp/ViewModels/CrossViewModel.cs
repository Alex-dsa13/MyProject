using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokBotApp.ViewModels
{
    public class CrossViewModel : MembersPageViewModel
    {
        private ObservableCollection<string> _disnaceList = new ObservableCollection<string>();


        protected SortedList<string, int> GetDistances()
        {
            var list = new SortedList<string, int>();

            list.Add("2 КМ", 0);
            list.Add("4 КМ", 1);

            //IList<string>  res = list.Keys;

            return list;
        }


        public ObservableCollection<string> DisnaceList { get { return _disnaceList; } }



        public CrossViewModel(ObservableCollection<Student> members) : base(members)
        {
            //EventMembers = new ObservableCollection<Student>(members);
            //FilteredMembers = new ObservableCollection<Student>(members);
            _disnaceList = new ObservableCollection<string>();

            foreach (var s in GetDistances())
            {
                _disnaceList.Add(s.Key);
            }
        }
        public override void filterStudentsList(List<string> filterValues, ObservableCollection<Student> studentsList, ObservableCollection<Student> filteredStudentList)
        {
            IEnumerable<Student> TempFacultyFilter; // Список студентов отфильтрованный по выбранному факультету.
            IEnumerable<Student> TempGenderFilter;  // Список студентов отфильтрованный по выбранному полу.
            IEnumerable<Student> TempDistanceFilter;    // Список студентов отфильтрованный по участию в профсоюзе.
            IEnumerable<Student> TempSearchFilter;  // Список студентов отфильрованный по ФИО.
            IEnumerable<Student> TempConcat;        // Список с пересекающимися элементами TempFacultyFilter и TempGenderFilter.
            IEnumerable<Student> ConcatFilters;     // Ссписок с пересекающимися элементами TempConcat и TempProfFilter.
            IEnumerable<Student> AllFilters;        // Объединенный список всех фильров.


            var fac = GetFaculties();   // Получаем список строк всех факультетов и их индексов в БД.
            var gen = GetGender();      // Получаем список строк всех значений пола и их индексов в БД.
            var distance = GetDistances(); // Получаем список строк всех значений спорта и их индексов в БД.


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

            if (distance.TryGetValue(filterValues[2], out var list2))
            {
                TempDistanceFilter = studentsList.Where(x => x.Descipline == Convert.ToInt32(distance.GetValueOrDefault(filterValues[2])));
            }
            else
            {
                TempDistanceFilter = new ObservableCollection<Student>(studentsList);
            }

            TempSearchFilter = studentsList.Where(x => x.Fio.ToLower().Contains(filterValues[3].ToLower()));

            TempConcat = TempFacultyFilter.Intersect(TempGenderFilter);
            ConcatFilters = TempConcat.Intersect(TempDistanceFilter);
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
