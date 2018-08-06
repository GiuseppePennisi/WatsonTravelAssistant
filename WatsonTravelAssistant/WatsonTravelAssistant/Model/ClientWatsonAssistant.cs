using System;
using System.Collections.Generic;
using System.Text;
using IBM.WatsonDeveloperCloud.Conversation.v1;
using IBM.WatsonDeveloperCloud.Conversation.v1.Model;
using Newtonsoft.Json;

namespace WatsonTravelAssistant.utils
{
   public class ClientWatsonAssistant
    {
        private ConversationService _conversation;
        private string _workspaceID;
        private dynamic _questionContext = null;
        public ClientWatsonAssistant(string url, string username, string password, string workspaceId)
        {
            _conversation = new ConversationService(username, password, "2018-02-16");
            _conversation.SetEndpoint(url);
            _workspaceID = workspaceId;
            
        }
        public void CallConversation(string inputText)
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
                messageRequest.Context = new Context();
                messageRequest.Context.ConversationId = _questionContext.conversation_id;
                messageRequest.Context.System = _questionContext.system;
            }
            var result = JsonConvert.SerializeObject(_conversation.Message(_workspaceID, messageRequest), Formatting.Indented);
            
            Console.WriteLine(string.Format("result: {0}", result));
            
        }


    }
}
