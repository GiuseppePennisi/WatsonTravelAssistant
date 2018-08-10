using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WatsonTravelAssistant.Model;
using WatsonTravelAssistant.utils;
using Xamarin.Forms;

namespace WatsonTravelAssistant.ModelView
{
    public class MainChatViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Message> Messages { get; }
        ClientWatsonAssistant messanger;
        string outgoingText = string.Empty;

        public string OutGoingText
        {
            get { return outgoingText; }
            set { SetProperty(ref outgoingText, value); }
        }

        public ICommand SendCommand { get; set; }

        public MainChatViewModel()
        {
            // Initialize with default values
            messanger = new ClientWatsonAssistant();



            Messages = new ObservableRangeCollection<Message>();

            SendCommand = new Command(() =>
            {
                var message = new Message
                {
                    Text = OutGoingText,
                    IsIncoming = false,
                    MessageDateTime = DateTime.Now
                };


                Messages.Add(message);

                var incomingMessage = new Message
                {
                    Text = messanger.CallConversation(message.Text),
                    IsIncoming = true,
                    MessageDateTime = DateTime.Now
                };
                Messages.Add(incomingMessage);

                OutGoingText = string.Empty;
            });




            if (messanger == null)
                return;

            messanger.MessageAdded = (message) =>
            {
                Messages.Add(message);
            };
        }


    }
}
