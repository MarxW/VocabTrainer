using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace VocabTrainerPhoneApp.Views.Lesson
{
    public partial class LessonPage : PhoneApplicationPage
    {
        public LessonPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            int classroomId = int.Parse(NavigationContext.QueryString["classroom"]);
            int lessonId = int.Parse(NavigationContext.QueryString["lesson"]);
            
        }
    }
}