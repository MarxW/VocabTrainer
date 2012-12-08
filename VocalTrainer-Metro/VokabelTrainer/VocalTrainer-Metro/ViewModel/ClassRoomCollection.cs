using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocalTrainer_Metro.DataModel;
using VocalTrainer_Metro.Interfaces;

namespace VocalTrainer_Metro.ViewModel
{
    public class ClassRoomCollection : ObservableCollection<ClassRoom>
    {

        public ClassRoomCollection()
            : base()
        {
            ISchool school = new ISchoolImpl();
            List<ClassRoom> rooms = new List<ClassRoom>();
            school.LoadAllClassRooms(rooms);
            foreach (ClassRoom r in rooms)
            {
                Add(r);
            }
        }

    }
}
