using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Marx.Wolfgang.VocabTrainer.ViewModel.School;
using Marx.Wolfgang.VocabTrainer.DataModel;

namespace VocabTrainerPhoneApp.Views.Lesson
{
    public partial class LessonPage : PhoneApplicationPage
    {
        private LessonViewModel lessonViewModel;
        private App app = App.Current as App;
        private int curentIndex = 0;
        private bool isCompleted = false;

        public LessonPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            int classroomId = int.Parse(NavigationContext.QueryString["classroom"]);
            int lessonId = int.Parse(NavigationContext.QueryString["lesson"]);
            BasicLesson lesson = app.School.ClassRooms.Where(r => r.Id == classroomId).FirstOrDefault().BasicLessons.Where(l => l.Id == lessonId).FirstOrDefault();
            lessonViewModel = new LessonViewModel(lesson);
            this.DataContext = lessonViewModel;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            DisplayVocab();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (curentIndex == 0)
            {
                curentIndex = lessonViewModel.BasicVocabularys.Count - 1;
            }
            else
            {
                curentIndex--;
            }
            DisplayVocab();
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            if (curentIndex < lessonViewModel.BasicVocabularys.Count - 1)
            {
                curentIndex++;
            }
            else
            {
                curentIndex = 0;
            }
            DisplayVocab();
        }

        private void DisplayVocab()
        {
            if (curentIndex == 0)
            {
                this.buttonBack.IsEnabled = false;
            }
            else
            {
                this.buttonBack.IsEnabled = true;
            }
            if (curentIndex == lessonViewModel.BasicVocabularys.Count - 1)
            {
                this.buttonNext.IsEnabled = false;
                isCompleted = true;
            }
            else
            {
                this.buttonNext.IsEnabled = true;
            }
            this.textBlockEnglish.Text = lessonViewModel.BasicVocabularys[curentIndex].English;
            this.textBlockGerman.Text = lessonViewModel.BasicVocabularys[curentIndex].German;
        }
    }
}