using Renci.SshNet;
using SokBotApp.Entities;
using SokBotApp.Models;
using SokBotApp.ViewModels;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace SokBotApp.Views
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public string currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString(2);
        public string path = "/root/SokBotApp/SokBotApp.exe";
        public string exename = AppDomain.CurrentDomain.FriendlyName;
        public string exepath = Environment.CurrentDirectory;
        public string path1 = Assembly.GetEntryAssembly().Location;
        public string namefile = "SokBotApp.exe";


        public StartPage()
        {
            InitializeComponent();

            version.Content = "Версия программы: " + currentVersion;

            /*
            using (var groups = new sokuser_databaseContext())
            {
                var g = new SokGroup();
                g.AddData(groups);
            }*/




            using (WebClient wc = new WebClient())
            {
                if (InternetConnection.OK())
                {
                    string actualVersion = "";
                    /*
                    using (var data = new sokuser_databaseContext())
                    {
                        actualVersion = data.SoftVersions.FirstOrDefault(x => x.Name == "SokBotApp")!.ActualVersion;
                    }


                    if(Convert.ToDouble(currentVersion, CultureInfo.InvariantCulture) == Convert.ToDouble(actualVersion, CultureInfo.InvariantCulture))
                    {
                        UpdateButton.Visibility = System.Windows.Visibility.Hidden;
                    }
                    else
                    {
                        UpdateButton.Visibility = System.Windows.Visibility.Visible;
                        
                    }*/
                }
                else
                {
                    MessageBox.Show("No internet connection!");
                }
            }
        }

        public void DownloadUpdateFile()
        {
            var connect = new ServerConnectConfig();
            using (SftpClient sftp = new SftpClient(connect.Host, connect.Port, connect.Username, connect.Password))
            {
                try
                {
                    sftp.Connect();
                    try
                    {
                        var file = sftp.Get(path);
                        var downloadpath = exepath + "/" + "new.exe";

                        
                        
                        using (Stream filestream = File.OpenWrite(downloadpath))
                        {
                            sftp.DownloadFile(file.FullName, filestream);
                            CMD($"taskkill /f /im \"{namefile}\" && timeout /t 1 && del \"{namefile}\" && ren new.exe \"{namefile}\" && \"{namefile}\"");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось найти файл обновления.");
                    }

                }
                catch
                {
                    MessageBox.Show("Не удалось подключиться к удаленному серверу.");
                }
            }
        }

        public void UpdateButton_Click(object sender, EventArgs e)
        {
            DownloadUpdateFile();
            
            
        }


        public void CMD(string line)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = $"/c {line})",
                WindowStyle = ProcessWindowStyle.Hidden
            });

        }
    }
}
