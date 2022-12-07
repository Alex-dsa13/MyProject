using SokBotApp.Models;
using System;
using System.Windows;
using System.Windows.Media;
using System.ComponentModel;
using System.Threading;
using System.Windows.Input;
using System.Threading.Tasks;
using Renci.SshNet;

namespace SokBotApp
{
    /// <summary>
    /// Логика взаимодействия для CheckConnectWindow.xaml
    /// </summary>
    public partial class CheckConnectWindow : Window
    {
        public bool isConnected = false;


        public CheckConnectWindow()
        {

            InitializeComponent();

            try
            {
                var client = new SshClient("195.2.74.154", 22, "root", "n6Rt2cqSxp3527V4");
                client.Connect();

                var port = new ForwardedPortLocal("127.0.0.1", 3307, "localhost", 3306);
                client.AddForwardedPort(port);

                port.Start();
            }
            catch
            {
                MessageBox.Show("Server is die(\r\n Please try later...");
            }

            using (var data = new sokuser_databaseContext())
            {
                if (data.Database.CanConnect())
                {
                    isConnectLabel.Content = "Защищенное соедиение установлено. ";
                    isConnectLabel.Foreground = Brushes.Green;
                    isConnectTextBlock.Text = "Нажмите кнопку 'Ok' и дождитесь загрузки данных.";
                    isConnected = true;
                }
                else
                {
                    isConnectLabel.Content = "Защищенное соедиение не установлено.";
                    isConnectLabel.Foreground = Brushes.Red;
                    isConnectTextBlock.Text = "Установите соединение и повторите попытку.";
                }
            }




        }

        public void btn_clicked(object sender, EventArgs e)
        {
            if (isConnected)
            {
                this.Cursor = Cursors.Wait;
                var window = new MainWindow();
                Close();
                window.Show();
            }
            else
            {
                Close();
            }
        }

         
    }
}
