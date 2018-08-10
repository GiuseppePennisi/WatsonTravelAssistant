using System;
using System.Collections.Generic;
using System.Text;
using IBM.WatsonDeveloperCloud.Conversation.v1;
using IBM.WatsonDeveloperCloud.Conversation.v1.Model;
using Newtonsoft.Json;
using WatsonTravelAssistant.Model;

namespace WatsonTravelAssistant.utils
{
   public class ClientWatsonAssistant
    {
        private ConversationService _conversation;
        private string _workspaceID;
        private dynamic _questionContext = null;
        public ClientWatsonAssistant()
        {
            _conversation = new ConversationService("afcea3f6-1a23-4f95-aa62-51304447f1a2", "p0nzObAmUj42", "2018-02-16");
            _conversation.SetEndpoint("https://gateway.watsonplatform.net/assistant/api");
            _workspaceID = "56e7c413-006c-42b5-b618-c87f1c549966";
            
        }

       public Action<Message> MessageAdded { get; set; }

        public string CallConversation(string inputText)
        {
            MessageRequest messageRequest = new MessageRequest()
            {
                Input = new InputData()
                {
                    Text = inputText
                },
                AlternateIntents = true
            };

            if (_questionContext != null)
            {
                messageRequest.Context = new IBM.WatsonDeveloperCloud.Conversation.v1.Model.Context();
                messageRequest.Context.ConversationId = _questionContext.conversation_id;
                messageRequest.Context.System = _questionContext.system;
            }
            
            var result = JsonConvert.SerializeObject(_conversation.Message(_workspaceID, messageRequest), Formatting.Indented);
            ResponseWatson response = JsonConvert.DeserializeObject<ResponseWatson>(result);
            return response.output.text[0];
            // Console.WriteLine("Output"+ response.output.text[0]);
            
        }


    }
}
