using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Xml.Linq;
using System.Reflection.Metadata;

namespace SokApp
{
    internal class GenegateDocument
    {



        public void getbuttonDocument()
        {
            buttonDocument();
        }

        public void getDoc()
        {
            GetDoc(Environment.CurrentDirectory);
        }


        // Определение переменной oWord
        Word._Application oWord = new Word.Application();

        // 
        private void buttonDocument()
        {
            // Считывает шаблон и сохраняет измененный в новом
            _Document oDoc = GetDoc(Environment.CurrentDirectory + "\\test.docx");
            oDoc.SaveAs(FileName: Environment.CurrentDirectory + "\\For_print.docx");
            oDoc.Close();
            oWord.Quit();
        }

        private _Document GetDoc(string path)
        {
            _Document oDoc = oWord.Documents.Add(path);
            SetTemplate(oDoc);
            return oDoc;
        }
        // Замена закладки SECONDNAME на данные введенные в textBox
        private void SetTemplate(_Document oDoc)
        {


            Console.WriteLine("Введите ФИО");
            string Name = Console.ReadLine();
            oDoc.Bookmarks["fio"].Range.Text = Name;
            oDoc.Bookmarks["year"].Range.Text = "2022";

            // если нужно заменять другие закладки, тогда копируем верхнюю строку изменяя на нужные параметры 

        }

    }
}
