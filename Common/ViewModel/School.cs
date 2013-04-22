using Marx.Wolfgang.VocabTrainer.Common.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marx.Wolfgang.VocabTrainer.Common.ViewModel
{
    class School : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region "Constructors"

        #endregion

        #region "Accessors"

        private List<BasicClassRoom> _classRooms;
        public List<BasicClassRoom> ClassRooms
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

        #region "Events"

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
