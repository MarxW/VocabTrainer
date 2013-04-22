using Marx.Wolfgang.VocabTrainer.Common.DataModel;
using Marx.Wolfgang.VocabTrainer.Common.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marx.Wolfgang.VocabTrainer.Common.Helpers;

namespace Marx.Wolfgang.VocabTrainer.Common.ViewModel
{
    public class School : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler ClassroomsChanged;

        #region "Accessors"

        private IConectivity _conn;

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

        public School()
        {
            this._classRooms = new List<BasicClassRoom>();
        }

        public School(IConectivity conectivity)
        {
            this._classRooms = new List<BasicClassRoom>();
            this._conn = conectivity;
        }

        #endregion

        #region "Load Data"

        public async void LoadData()
        {
            if (this._conn != null)
            {
                await Task.Run(
                    () => { 
                        LoadData(this._conn);
                    });
            }
        }

        public async void LoadData(IConectivity conectivity)
        {
            if (null != conectivity)
            {
                Uri uri = new Uri(@"http://localhost/ClassRooms.xml");
                string data = await conectivity.GetRequestAsync(uri);
                dynamic objClassRooms = JsonConvert.DeserializeObject(data);
                foreach (dynamic objClassRoom in objClassRooms)
                {
                    BasicClassRoom classRoom = new BasicClassRoom()
                    {
                        Id = (int)objClassRoom["id"],
                        Title = (string)objClassRoom["title"],
                        Lessons = new ObservableCollection<BasicLesson>()
                    };
                    this._classRooms.AddOrUpdateKeyValue(classRoom);
                }
                NotifyPropertyChanged("ClassRooms");
                EnvokeClassroomsChanged(new EventArgs());
            }
        }

        #endregion

        #region "Events"

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
