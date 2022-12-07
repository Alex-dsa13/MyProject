using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO; // Path
using System.Linq;
using System.Windows;
using System.Windows.Shapes; // Path
using Word = Microsoft.Office.Interop.Word;

namespace SokBotApp.Entities
{
    public class Document
    {
        //private string _localpath1 = @"..\..\..\documentTemplates\";
        private string _localpath = @"\documentTemplates\";
        private string _printfilename;
        private string _currentfaculty;
        private string _currentevent;
        private string _stuff;

        private List<string> _currentdescipline = new List<string>();
        private ObservableCollection<Student> _membersPrintList { get; set; }
        private FileInfo? _fileInfo;

        public Document(string filename, ObservableCollection<Student>? members = null)
        {
            _membersPrintList = new ObservableCollection<Student>(members);

            
            if (File.Exists(Environment.CurrentDirectory + _localpath + filename))
            {
                _fileInfo = new FileInfo(_localpath + filename);

            }
            else
            {
                MessageBox.Show("Файл не найден.");
            }

        }

        public Document(string filename, ObservableCollection<Student> members, string faculty, string currentevent, List<string> descipline, string stuff)
        {
            _membersPrintList = new ObservableCollection<Student>(members);
            _printfilename = filename;
            _currentfaculty = faculty;
            _currentevent = currentevent;
            _currentdescipline = descipline;
            _stuff = stuff;
        }


        Word._Application oWord = new Word.Application();

        public bool CreateDocument()
        {
            try
            {
                object missing = Type.Missing;
                var StudentsCount = _membersPrintList.Count;
                object file = _fileInfo!.FullName;
                object endDoc = "\\endofdoc";
                var ColumnCount = 5;
                int i1, j1;
                string[,] printList = new string[StudentsCount, ColumnCount];
                var StudentsArray = _membersPrintList.ToArray();


                for (i1 = 0; i1 < StudentsCount; i1++)
                {

                    for (j1 = 0; j1 < 5; j1++)
                    {
                        if (j1 == 0)
                        {
                            printList[i1, j1] = StudentsArray[i1].Fio;
                        }
                        else if (j1 == 1)
                        {
                            printList[i1, j1] = StudentsArray[i1].Group;
                        }
                        else if (j1 == 2)
                        {
                            printList[i1, j1] = StudentsArray[i1].PhoneNumber;
                        }
                        else if (j1 == 3)
                        {
                            if (StudentsArray[i1].ProfSouze)
                            {
                                printList[i1, j1] = "Состоит";
                            }
                            else
                            {
                                printList[i1, j1] = "Не состоит";
                            }

                        }
                        /*else if (j1 == 4)
                        {
                            printList[i1, j1] = t[i1].DistanceString!;
                        }*/
                    }

                }


                object template = _fileInfo.FullName;
                Word.Application app;
                Word._Document doc;
                app = new Word.Application();
                app.Visible = false;
                app.Documents.Open(file);


                doc = app.Documents.Add(template);

                Word.Table table;
                Word.Range wrdRng = doc.Bookmarks.get_Item(endDoc).Range;
                table = doc.Tables.Add(wrdRng, StudentsCount, ColumnCount, missing);

                int i, j;

                for (i = 1; i <= StudentsCount; i++)
                {
                    for (j = 1; j <= 5; j++)
                    {
                        var text = printList[i - 1, j - 1];
                        table.Cell(i, j).Range.Text = text;
                    }

                }

                table.Columns[1].Width = app.InchesToPoints(3);
                table.Columns[2].Width = app.InchesToPoints(0.7f);
                table.Columns[3].Width = app.InchesToPoints(1.2f);
                table.Columns[4].Width = app.InchesToPoints(1);
                //table.Columns[5].Width = app.InchesToPoints(0.5f);

                table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                table.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;

                object newFile = System.IO.Path.Combine(_fileInfo.DirectoryName, "Created.docx");


                app.ActiveDocument.SaveAs2(newFile);
                app.ActiveDocument.Close();

                
                app.Quit();
                return true;
            }
            catch
            {
                return false;
            }


        }

        public bool ChangeTemplateSokCup()
        {
            FindDocument();


            return true;
        }

        public void FindDocument()
        {
            OpenDocument();
        }

        public void OpenDocument()
        {
            // Считывает шаблон и сохраняет измененный в новом
            _Document oDoc = GetDoc(Environment.CurrentDirectory + _localpath + "CupTemplate.docx");
            oDoc.SaveAs(FileName: Environment.CurrentDirectory + _localpath + _printfilename);
            oDoc.Close();
            oWord.Quit();
        }

        public void GetDocumentLink()
        {
            GetDoc(_localpath);
        }

        public _Document GetDoc(string path)
        {
            //Console.WriteLine(path);
            _Document oDoc = oWord.Documents.Add(path);
            SetTemplate(oDoc);
            return oDoc;
        }

        private void SetTemplate(_Document oDoc)
        {

            int student_count = 1;

            oDoc.Bookmarks["SokStuff"].Range.Text = _stuff;
            oDoc.Bookmarks["Year"].Range.Text = " " + DateTime.Now.Year.ToString() + "\"";
            oDoc.Bookmarks["Descipline"].Range.Text = _currentdescipline[0];
            oDoc.Bookmarks["Faculty"].Range.Text = _currentfaculty;
            oDoc.Bookmarks["Event"].Range.Text = "\"" + _currentevent;
            oDoc.Bookmarks["Descipline_disklaimer"].Range.Text = _currentdescipline[1];

            foreach (var student in _membersPrintList)
            {
                var FioBookmark = $"Student{student_count}_Fio";
                var GroupBookmark = $"Student{student_count}_Group";
                var ProfBookmark = $"Student{student_count}_Prof";

                student_count++;

                oDoc.Bookmarks[FioBookmark].Range.Text = student.Fio;
                oDoc.Bookmarks[GroupBookmark].Range.Text = student.Group;
                oDoc.Bookmarks[ProfBookmark].Range.Text = student.ProfSouzeString;
            }

        }
    }
}
