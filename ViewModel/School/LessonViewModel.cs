using Marx.Wolfgang.VocabTrainer.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marx.Wolfgang.VocabTrainer.ViewModel.School
{
    public class LessonViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler LessonChanged;
        public event EventHandler LoadingDataError;

        #region "Accessors"

        private ObservableCollection<BasicVocabulary> _basicVocabulary;
        public ObservableCollection<BasicVocabulary> BasicVocabularys
        {
            get { return this._basicVocabulary; }
            set
            {
                if (value != this._basicVocabulary)
                {
                    this._basicVocabulary = value;
                    NotifyPropertyChanged("BasicVocabularys");
                }
            }
        }

        private string _lessonTitle;
        public string LessonTitle
        {
            get { return this._lessonTitle; }
            set
            {
                if (value != this._lessonTitle)
                {
                    this._lessonTitle = value;
                    NotifyPropertyChanged("LessonTitle");
                }
            }
        }

        private string _lessonDescription;
        public string LessonDescription
        {
            get { return this._lessonDescription; }
            set
            {
                if (value != this._lessonDescription)
                {
                    this._lessonDescription = value;
                    NotifyPropertyChanged("LessonDescription");
                }
            }
        }

        #endregion

        #region "Constructors"

        public LessonViewModel()
        {
            this._basicVocabulary = new ObservableCollection<BasicVocabulary>();
        }

        public LessonViewModel(BasicLesson lesson)
        {
            this._basicVocabulary = new ObservableCollection<BasicVocabulary>();
            foreach (BasicVocabulary vocab in lesson.BasicVocabularies)
            {
                this._basicVocabulary.Add(vocab);
            }
            NotifyPropertyChanged("BasicVocabularys");
            this.LessonTitle = lesson.Title;
            this.LessonDescription = lesson.Description;
        }

        #endregion

        #region "Events"

        private void EnvokeLoadingDataError(EventArgs e)
        {
            if (LoadingDataError != null)
            {
                LoadingDataError(this, e);
            }
        }

        private void EnvokeLessonChanged(EventArgs e)
        {
            if (LessonChanged != null)
            {
                LessonChanged(this, e);
            }
        }

        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #endregion
    }
}
