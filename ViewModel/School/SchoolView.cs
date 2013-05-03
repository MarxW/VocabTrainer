using Marx.Wolfgang.VocabTrainer.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marx.Wolfgang.VocabTrainer.ViewModel.Helpers;

namespace Marx.Wolfgang.VocabTrainer.ViewModel.School
{
    public class SchoolView: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler ClassroomsChanged;
        public event EventHandler LoadingDataError;

        #region "Accessors"

        private ObservableCollection<BasicClassRoom> _classRooms;
        public ObservableCollection<BasicClassRoom> ClassRooms
        {
            get { return this._classRooms; }
            set
            {
                if (value != this._classRooms)
                {
                    this._classRooms = value;
                    NotifyPropertyChanged("ClassRooms");
                }
            }
        }

        #endregion

        #region "Constructors"

        public SchoolView()
        {
            this._classRooms = new ObservableCollection<BasicClassRoom>();
        }

        #endregion

        #region "Load Data"

        public async void FillViewData(BasicClassRoom[] rooms)
        {
            await Task.Run(() =>
            {
                foreach (BasicClassRoom room in rooms)
                {
                    _classRooms.AddOrUpdateKeyValue(room);
                }
            });
            NotifyPropertyChanged("ClassRooms");
        }

        public async void FillViewData(IEnumerable<BasicClassRoom> rooms)
        {
            await Task.Run(() =>
            {
                foreach (BasicClassRoom room in rooms)
                {
                    ClassRooms.Add(room);
                    //_classRooms.AddOrUpdateKeyValue(room);
                }
            });
            NotifyPropertyChanged("ClassRooms");
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

        private void EnvokeClassroomsChanged(EventArgs e)
        {
            if (ClassroomsChanged != null)
            {
                ClassroomsChanged(this, e);
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
