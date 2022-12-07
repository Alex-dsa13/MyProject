using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using VkNet;
using VkNet.Abstractions;
using VkNet.Model;



namespace SokBotApp.ViewModels
{
    public class SendMessagesViewModel
    {

        private VkApi _api { get; set; } = new VkApi();
        private int _rnd { get; set; }
        private ObservableCollection<Student> _membersToSend = new ObservableCollection<Student>();


        public ObservableCollection<Student> MembersToSend { get { return _membersToSend; } private set { } }
        public SendMessagesViewModel(ObservableCollection<Student> members)
        {
            try
            {
                _api = this.VkAuth();
                _membersToSend = new ObservableCollection<Student>();
                _membersToSend = members;
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к боту.");
            }

            Random random = new Random();
            _rnd = random.Next(0, 1000000);

        }
        public VkApi VkAuth()
        {
            VkApi vkApi = new VkApi();

            vkApi.Authorize(new ApiAuthParams
            {
                AccessToken = "003facf222b2119cde1a0c3292e14bd9966f35907255be963868dfa903b67c1a70a725a736a428a3ecea0",
                Settings = VkNet.Enums.Filters.Settings.All
            });
            

            return vkApi;
        }
        public Dictionary<string, bool> SendMessageToMembers(string message, ObservableCollection<Student> members)
        {
            int i = 1;
            var arr = new Dictionary<string, bool>();
            

            foreach (var member in members)
            {
                bool isSended = false;
                var peer_id = member.IdVk;

                try
                {
                    var message_id = _api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
                    {
                        PeerId = peer_id,
                        UserId = peer_id,
                        Message = message,
                        RandomId = peer_id + _rnd
                    });

                    
                    isSended = true;
                    string s = i.ToString() + ". " +  "Сообщение для " + member.Fio + " доставлено. \r\n";
                    arr.Add(s, isSended);
                    Thread.Sleep(1000);
                }
                catch
                {
                    string s = i.ToString() + ". " + "Сообщение для " + member.Fio + " не доставлено. \r\n";
                    arr.Add(s, isSended);
                }
                i++;
            }

            return arr;
        }

    }
}
