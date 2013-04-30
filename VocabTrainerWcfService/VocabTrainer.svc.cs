using Marx.Wolfgang.VocabTrainer.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace VocabTrainerWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "VocabTrainer" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select VocabTrainer.svc or VocabTrainer.svc.cs at the Solution Explorer and start debugging.
    public class VocabTrainer : IVocabTrainer
    {
        public List<BasicClassRoom> GetClassRooms()
        {
            List<BasicClassRoom> allRooms = new List<BasicClassRoom>();
            allRooms.Add(new BasicClassRoom() { Id = 1, Title = "Lesson 1", BasicLessons = new ObservableCollection<BasicLesson>() });
            return allRooms;
        }

        public void DoWork()
        {
        }
    }
}
