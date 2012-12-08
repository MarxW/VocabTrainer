using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocalTrainer_Metro.DataModel;

namespace VocalTrainer_Metro.Interfaces
{
    interface ISchool
    {
        void LoadAllClassRooms(List<ClassRoom> classrooms);


    }
}
