using System;
using System.Collections.Generic;
using System.Text;
using WatsonTravelAssistant.ModelView;
using Xamarin.Forms;

namespace WatsonTravelAssistant
{
    public class App :Application
    {
        public App()
        {

            // The root page of your application
            MainPage = new NavigationPage(new MainPage())
            {

            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }

    public static class ViewModelLocator
    {
        static MainChatViewModel chatVM;
        public static MainChatViewModel MainChatViewModel
        {
            get
            {
                if (chatVM == null)
                {
                    chatVM = new MainChatViewModel();
                    
                }
                return chatVM;

            }
        }

    }
}

