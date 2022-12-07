using SokBotApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using MvvmCross.ViewModels;
using SokBotApp.Views;
using MvvmCross.Commands;
using Microsoft.EntityFrameworkCore;
using System.Windows.Data;
using System.Windows.Controls.Primitives;
using System.Windows;
using MvvmCross.Binding.Extensions;
using System.IO;
using SokBotApp.Entities;

namespace SokBotApp.ViewModels
{
    public class StudentsPageViewModel
    {
        /// <summary>
        /// students - Основной список студентов, который получаем при запросе в БД.
        /// filteredList - Отфильтрованный список, который всегда выводится в окно приложения.
        /// faculties - Список факультетов (используется для заполнения фильтра).
        /// gender - Список значений пола (используется для заполнения фильтра).
        /// isProfsouzeMember - Список значений участия в профсоюзе (используется для заполнения фильтра).
        /// </summary>
        private ObservableCollection<Student> _students  = new ObservableCollection<Student>();
        private ObservableCollection<Student> _filteredList { get; set; } = new ObservableCollection<Student>();
        private ObservableCollection<string> _faculties { get; set; } = new ObservableCollection<string>();
        private ObservableCollection<string> _gender { get; set; } = new ObservableCollection<string>();
        private ObservableCollection<string> _isProfsouzeMember { get; set; } = new ObservableCollection<string>();


        protected SortedList<string, int> GetFaculties()
        {
            var list = new SortedList<string, int>();


            list.Add("ФИТ", 0);
            list.Add("РТФ", 1);
            list.Add("РКФ", 2);
            list.Add("ФЭТ", 3);
            list.Add("ФСУ", 4);
            list.Add("ФВС", 5);
            list.Add("ГФ", 6);
            list.Add("ФБ", 7);
            list.Add("ЭФ", 8);
            list.Add("ЮФ", 9);
            list.Add("ЗАОЧНЫЙ", 10);

            //IList<string>  res = list.Keys;

            return list;
        }
        protected SortedList<string, int> GetGender()
        {
            var list = new SortedList<string, int>();


            list.Add("Мужской", 0);
            list.Add("Женский", 1);

            //IList<string>  res = list.Keys;

            return list;
        }
        protected SortedList<string, int> GetProfosouze()
        {
            var list = new SortedList<string, int>();


            list.Add("Не состоит", 0);
            list.Add("Состоит", 1);

            //IList<string>  res = list.Keys;

            return list;
        }


        public ObservableCollection<Student> Students { get { return _students; } }
        public ObservableCollection<Student> FilteredList { get { return _filteredList; } }
        public ObservableCollection<string> Faculties { get { return _faculties; } }
        public ObservableCollection<string> Gender { get { return _gender; } }
        public ObservableCollection<string> ProfSouze { get { return _isProfsouzeMember; } }


        public StudentsPageViewModel()
        {
            try
            {
                using (var data = new sokuser_databaseContext())
                {
                    _students = new ObservableCollection<Student>();
                    _faculties = new ObservableCollection<string>();
                    _gender = new ObservableCollection<string>();
                    _isProfsouzeMember = new ObservableCollection<string>();

                    foreach (var s in data.Students)
                    {
                        var a = s;
                        _students.Add(a);
                    }
                    foreach (var f in GetFaculties())
                    {
                        _faculties.Add(f.Key);
                    }
                    foreach (var f in GetGender())
                    {
                        _gender.Add(f.Key);
                    }
                    foreach (var f in GetProfosouze())
                    {
                        _isProfsouzeMember.Add(f.Key);
                    }

                }

                _filteredList = new ObservableCollection<Student>(_students);
            }
            catch
            {
                MessageBox.Show("Отказано в доступе. Выполните защищенное подключение и повторите попытку.");
            }
            

            

        }
        public virtual void filterStudentsList(List<string> filterValues, ObservableCollection<Student> studentsList, ObservableCollection<Student> filteredStudentList)
        {
            IEnumerable<Student> TempFacultyFilter; // Список студентов отфильтрованный по выбранному факультету.
            IEnumerable<Student> TempGenderFilter;  // Список студентов отфильтрованный по выбранному полу.
            IEnumerable<Student> TempProfFilter;    // Список студентов отфильтрованный по участию в профсоюзе.
            IEnumerable<Student> TempSearchFilter;  // Список студентов отфильрованный по ФИО.
            IEnumerable<Student> TempConcat;        // Список с пересекающимися элементами TempFacultyFilter и TempGenderFilter.
            IEnumerable<Student> ConcatFilters;     // Ссписок с пересекающимися элементами TempConcat и TempProfFilter.
            IEnumerable<Student> AllFilters;        // Объединенный список всех фильров.


            var fac = GetFaculties();   // Получаем список строк всех факультетов и их индексов в БД.
            var gen = GetGender();      // Получаем список строк всех значений пола и их индексов в БД.
            var prof = GetProfosouze(); // Получаем список строк всех значений профсоюза и их индексов в БД.


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

            if (prof.TryGetValue(filterValues[2], out var list2))
            {
                TempProfFilter = studentsList.Where(x => x.ProfSouze == Convert.ToBoolean(prof.GetValueOrDefault(filterValues[2])));
            }
            else
            {
                TempProfFilter = new ObservableCollection<Student>(studentsList);
            }

            TempSearchFilter = studentsList.Where( x => x.Fio.ToLower().Contains(filterValues[3].ToLower()));

            TempConcat = TempFacultyFilter.Intersect(TempGenderFilter);
            ConcatFilters = TempConcat.Intersect(TempProfFilter);
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

            //return filteredList;
            
        }
        public void filterStudentsList(string faculty, string gender, string profsouze, string search, MembersPageViewModel currentEvent)
        {
            IEnumerable<Student> TempFacultyFilter; // Список студентов отфильтрованный по выбранному факультету.
            IEnumerable<Student> TempGenderFilter;  // Список студентов отфильтрованный по выбранному полу.
            IEnumerable<Student> TempProfFilter;    // Список студентов отфильтрованный по участию в профсоюзе.
            IEnumerable<Student> TempSearchFilter;  // Список студентов отфильрованный по ФИО.
            IEnumerable<Student> TempConcat;        // Список с пересекающимися элементами TempFacultyFilter и TempGenderFilter.
            IEnumerable<Student> ConcatFilters;     // Ссписок с пересекающимися элементами TempConcat и TempProfFilter.
            IEnumerable<Student> AllFilters;        // Объединенный список всех фильров.


            var fac = GetFaculties();   // Получаем список строк всех факультетов и их индексов в БД.
            var gen = GetGender();      // Получаем список строк всех значений пола и их индексов в БД.
            var prof = GetProfosouze(); // Получаем список строк всех значений профсоюза и их индексов в БД.


            if (fac.TryGetValue(faculty, out var list))
            {
                TempFacultyFilter = currentEvent.EventMembers.Where(x => x.Faculty == fac.GetValueOrDefault(faculty));
            }
            else
            {
                TempFacultyFilter = new ObservableCollection<Student>(currentEvent.EventMembers);
            }

            if (gen.TryGetValue(gender, out var list1))
            {
                TempGenderFilter = currentEvent.EventMembers.Where(x => x.Sex == gen.GetValueOrDefault(gender));
            }
            else
            {
                TempGenderFilter = new ObservableCollection<Student>(currentEvent.EventMembers);
            }

            if (prof.TryGetValue(profsouze, out var list2))
            {
                TempProfFilter = currentEvent.EventMembers.Where(x => x.ProfSouze == Convert.ToBoolean(prof.GetValueOrDefault(profsouze)));
            }
            else
            {
                TempProfFilter = new ObservableCollection<Student>(currentEvent.EventMembers);
            }

            TempSearchFilter = currentEvent.EventMembers.Where(x => x.Fio.ToLower().Contains(search.ToLower()));

            TempConcat = TempFacultyFilter.Intersect(TempGenderFilter);
            ConcatFilters = TempConcat.Intersect(TempProfFilter);
            AllFilters = ConcatFilters.Intersect(TempSearchFilter);

            // Изменяем основной filteredList, который выводится в окно приложения.
            for (int i = currentEvent.FilteredMembers.Count - 1; i >= 0; i--)
            {
                var item = currentEvent.FilteredMembers[i];
                if (!AllFilters.Contains(item))
                {
                    currentEvent.FilteredMembers.Remove(item);
                }
            }

            foreach (var item in AllFilters)
            {
                if (!currentEvent.FilteredMembers.Contains(item))
                {
                    currentEvent.FilteredMembers.Add(item);
                }
            }

            for (int i = _filteredList.Count - 1; i >= 0; i--)
            {
                var item = _filteredList[i];
                if (!AllFilters.Contains(item))
                {
                    _filteredList.Remove(item);
                }
            }

            foreach (var item in AllFilters)
            {
                if (!_filteredList.Contains(item))
                {
                    _filteredList.Add(item);
                }
            }
        }
        public void RefreshStudentsList(List<string> filterValues, ObservableCollection<Student> studentsList, ObservableCollection<Student> filteredStudentList)
        {
            using (var data = new sokuser_databaseContext())
            {
                
                studentsList.Clear();

                foreach (var item in data.Students)
                {
                    studentsList.Add(item);
                }

                
            }
            
            filterStudentsList(filterValues, studentsList, filteredStudentList);
        }
        public void RefreshEventMembersList(List<string> filetrValues, object eventObject, ObservableCollection<Student> members, ObservableCollection<Student> filteredEventMembers)
        {
            using (var data = new sokuser_databaseContext())
            {

                string filepath = "";
                string filename = "";

                if (eventObject is DodPageViewModel dod)
                {
                    dod.DownloadEventFile(dod.EventFolderName);
                    filepath = dod.LocalPath;
                    filename = dod.EventFileName;
                    members.Clear();
                    dod.GetMembers(filename);

                    foreach (var member in dod.Members)
                    {
                        members.Add(member);
                    }
                }
                else if (eventObject is CupFirstCourse cup)
                {
                    cup.DownloadEventFile(cup.EventFolderName);
                    filepath = cup.LocalPath;
                    filename = cup.EventFileName;
                    members.Clear();
                    cup.GetMembers(filename);

                    foreach (var member in cup.Members)
                    {
                        members.Add(member);
                    }
                }
            }

            filterStudentsList(filetrValues, members, filteredEventMembers);
        }
    }    
}