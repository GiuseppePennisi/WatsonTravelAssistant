using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatsonTravelAssistant.utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WatsonTravelAssistant
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
	{
        ClientWatsonAssistant client = new ClientWatsonAssistant("https://gateway.watsonplatform.net/assistant/api", "afcea3f6-1a23-4f95-aa62-51304447f1a2", "p0nzObAmUj42", "56e7c413-006c-42b5-b618-c87f1c549966");
		public MainPage()
		{
			InitializeComponent();

		}

        private void onRequest(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(EntryUrl.Text)) { 
                client.CallConversation(EntryUrl.Text);

            }
        }
    }


}
