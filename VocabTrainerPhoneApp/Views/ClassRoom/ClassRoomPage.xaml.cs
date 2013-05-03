using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Marx.Wolfgang.VocabTrainer.DataModel;

namespace VocabTrainerPhoneApp.Views.ClassRoom
{
    public partial class ClassRoomPage : PhoneApplicationPage
    {
        private BasicClassRoom classroom;
        private App app = App.Current as App;

        public ClassRoomPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            int id = int.Parse(NavigationContext.QueryString["classroom"]);
            classroom = (from c in app.School.ClassRooms where c.Id == id select c).FirstOrDefault();
            this.DataContext = classroom;
        }

        private void ButtonLearn_Click(object sender, RoutedEventArgs e)
        {
            string id = ((Button)sender).CommandParameter.ToString();
            string uri = string.Format("/Views/Lesson/LessonPage.xaml?classroom={0}&lesson={1}", classroom.Id, id);
            NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }

        private void ButtonTest_Click(object sender, RoutedEventArgs e)
        {
            string id = ((Button)sender).CommandParameter.ToString();
            Console.WriteLine(id);
        }

        
    }
}