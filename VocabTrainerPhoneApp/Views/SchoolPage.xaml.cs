using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using VocabTrainerPhoneApp.Interfaces;
using Marx.Wolfgang.VocabTrainer.ViewModel.Helpers;
using Marx.Wolfgang.VocabTrainer.ViewModel.School;
using System.ServiceModel;
using VocabTrainerPhoneApp.VocabTrainerServiceReference;
using System.Threading.Tasks;
using Marx.Wolfgang.VocabTrainer.DataModel;

namespace VocabTrainerPhoneApp.Views
{
    public partial class SchoolPage : PhoneApplicationPage
    {
        //private IConectivity conn = new IConectivityWP8Impl();
        private App app = App.Current as App;
        private SchoolClient client;

        public SchoolPage()
        {
            InitializeComponent();
            client = GetVocabTrainerClient();
            client.GetClassRoomsCompleted += SchoolPage_GetClassRoomsCompleted;         
        }

        void SchoolPage_GetClassRoomsCompleted(object sender, GetClassRoomsCompletedEventArgs e)
        {
            Task.Run(() =>
            {
                Dispatcher.BeginInvoke(() =>
                {
                    app.School.FillViewData(e.Result);
                    this.DataContext = app.School;
                });
            });
        }

        private SchoolClient GetVocabTrainerClient()
        {
            SchoolClient client = new SchoolClient();
            return client;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (app.School.ClassRooms.Count < 1)
            {
                client.GetClassRoomsAsync();
            }
        }

        private void listBoxRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.listBoxRooms.SelectedIndex > -1)
            {
                BasicClassRoom room = (BasicClassRoom)this.listBoxRooms.SelectedItem as BasicClassRoom;
                NavigationService.Navigate(new Uri("/Views/ClassRoom/ClassRoomPage.xaml?classroom=" + room.Id, UriKind.Relative));
            }
        }
    }
}