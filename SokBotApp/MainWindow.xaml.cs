using SokBotApp.Models;
using SokBotApp.ViewModels;
using SokBotApp.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SokBotApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            var link = new ProcessStartInfo(e.Uri.ToString())
            {
                UseShellExecute = true,
                Verb = "open"
            };

            Process.Start(link);
            
        }

        public void StudentsPage_Click(object sender, EventArgs e)
        {
            //var spage = new StudentsPage();
            //NavigationService.Navigate(new StudentsPage());
        }

        
    }
}
