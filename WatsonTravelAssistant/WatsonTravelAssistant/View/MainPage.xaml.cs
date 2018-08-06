using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatsonTravelAssistant.ModelView;
using WatsonTravelAssistant.utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WatsonTravelAssistant
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
	{
        MainChatViewModel vm;
        public MainPage()
        {
            InitializeComponent();
            Title = "#general";
            BindingContext = Vm = new MainChatViewModel();


            Vm.Messages.CollectionChanged += (sender, e) =>
            {
                var target = Vm.Messages[Vm.Messages.Count - 1];
                MessagesListView.ScrollTo(target, ScrollToPosition.End, true);
            };

        }

        internal MainChatViewModel Vm { get => vm; set => vm = value; }

        void MyListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MessagesListView.SelectedItem = null;
        }

        void MyListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            MessagesListView.SelectedItem = null;

        }
    }


}
