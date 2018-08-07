using System;
using System.Collections.Generic;
using System.Text;

namespace WatsonTravelAssistant.Model
{
    public class Input
    {
        public string text { get; set; }
    }

    public class Intent
    {
        public string intent { get; set; }
        public float confidence { get; set; }
    }

    public class DialogStack
    {
        public string dialog_node { get; set; }
        public string state { get; set; }
    }

    public class NodeOutputMap
    {
        public List<int> handler_1_1533475189260 { get; set; }
    }

    public class System
    {
        public List<DialogStack> dialog_stack { get; set; }
        public int dialog_turn_counter { get; set; }
        public int dialog_request_counter { get; set; }
        public NodeOutputMap _node_output_map { get; set; }
    }

    public class Context
    {
        public string conversation_id { get; set; }
        public System system { get; set; }
    }

    public class LogMessage
    {
        public string level { get; set; }
        public string msg { get; set; }
        public string node_id { get; set; }
        public string node_title { get; set; }
    }

    public class Output
    {
        public List<string> text { get; set; }
        public List<string> nodes_visited { get; set; }
        public string warning { get; set; }
        public List<LogMessage> log_messages { get; set; }
    }

    public class ResponseWatson
    {
        public Input input { get; set; }
        public List<Intent> intents { get; set; }
        public List<object> entities { get; set; }
        public bool alternate_intents { get; set; }
        public Context context { get; set; }
        public Output output { get; set; }
    }
}
