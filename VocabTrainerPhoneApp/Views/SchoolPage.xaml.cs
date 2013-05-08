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
using Marx.Wolfgang.VocabTrainer.Common.Interfaces;
using Marx.Wolfgang.VocabTrainer.Common.Helpers;
using System.Xml.Linq;
using System.Collections.ObjectModel;

namespace VocabTrainerPhoneApp.Views
{
    public partial class SchoolPage : PhoneApplicationPage
    {
        //private IConectivity conn = new IConectivityWP8Impl();
        private App app = App.Current as App;
        private SchoolClient client;
        private IVocabTrainerStorage vocabTrainerStorage = new IVocabTrainerStorageImpl();
        private IVocabTrainerSettings settings = new IVocabTrainerSettingsImpl();
        private string schoolFile = "school.xml";

        public SchoolPage()
        {
            InitializeComponent();
            client = GetVocabTrainerClient();
            client.GetClassRoomsCompleted += Client_GetClassRoomsCompleted;
            client.GetLastDataUpdateCompleted += Client_GetLastDataUpdateCompleted;
        }

        void Client_GetLastDataUpdateCompleted(object sender, GetLastDataUpdateCompletedEventArgs e)
        {
            if (settings.GetLastDataUpdate() < e.Result)
            {
                MessageBoxResult result = MessageBox.Show("Update avalable", "Updates", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    client.GetClassRoomsAsync();
                }
            }
        }

        void Client_GetClassRoomsCompleted(object sender, GetClassRoomsCompletedEventArgs e)
        {
            Task.Run(() =>
            {
                Dispatcher.BeginInvoke(() =>
                {
                    app.School.FillViewData(e.Result);
                    this.DataContext = app.School;
                    vocabTrainerStorage.WriteData(schoolFile, e.Result.ToXML());
                    settings.SetLastDataUpdate(DateTime.Now);
                });
            });
        }

        private SchoolClient GetVocabTrainerClient()
        {
            SchoolClient client = new SchoolClient();
            return client;
        }

        private  void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (app.School.ClassRooms.Count < 1)
            {
                try
                {
                    string data = vocabTrainerStorage.ReadData(schoolFile).Result;
                    XDocument doc = XDocument.Parse(data);
                    var obj = doc.DeserializeAsXML<ObservableCollection<BasicClassRoom>>();
                    Dispatcher.BeginInvoke(() =>
                    {
                        app.School.FillViewData(obj);
                        this.DataContext = app.School;
                        client.GetLastDataUpdateAsync();
                    });
                }
                catch (Exception ex)
                {
                    client.GetClassRoomsAsync();
                }
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