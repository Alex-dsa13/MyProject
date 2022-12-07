using SokBotApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SokBotApp.Views
{
    /// <summary>
    /// Логика взаимодействия для SendMessages.xaml
    /// </summary>
    public partial class SendMessages : Page
    {
        public SendMessages( ObservableCollection<Student> members)
        {
            InitializeComponent();
            DataContext = new SendMessagesViewModel(members);
            var context = (SendMessagesViewModel)DataContext;
            var count = context.MembersToSend.Count();

            membersCount.Content = "Кол-во участников рассылки: " + count.ToString();

            
        }

        public void sendButton_Click(object sender, EventArgs e)
        {
            var message = messageTextBox.Text;
            var send = (SendMessagesViewModel)DataContext;
            var arr = new Dictionary<string, bool>();
            var sendedMessages = 0;
            
            arr = send.SendMessageToMembers(message, send.MembersToSend);

            FlowDocument flow = new FlowDocument();
            Paragraph paragraph = new Paragraph();
            paragraph.LineHeight = 30;

            foreach (var s in arr)
            {
                if (s.Value)
                {
                    paragraph.Inlines.Add(s.Key);
                    paragraph.Inlines.Last().Foreground = new SolidColorBrush(Colors.Green);
                    sendedMessages++;
                }
                else
                {
                    paragraph.Inlines.Add(s.Key);
                    paragraph.Inlines.Last().Foreground = new SolidColorBrush(Colors.Red);
                }
            }

            flow.Blocks.Add(paragraph);
            messageConsole.Document = flow;

            FlowDocument doccument = new FlowDocument();
            Paragraph paragraph1 = new Paragraph();
            paragraph1.Inlines.Add((new Run("Сообщения доставлены " + sendedMessages.ToString() + " участникам из " + arr.Count())));
            doccument.Blocks.Add(paragraph1);
            finalInfo.Document = doccument;
        }

        public void backButton_Click(object sender, RoutedEventArgs? e = null)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Нельзя вернуться назад.");
            }
        }
    }
}
