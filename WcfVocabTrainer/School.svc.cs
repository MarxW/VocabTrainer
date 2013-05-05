using Marx.Wolfgang.VocabTrainer.DataModel;
using Marx.Wolfgang.VocabTrainer.Service.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfVocabTrainer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "School" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select School.svc or School.svc.cs at the Solution Explorer and start debugging.
    public class School : ISchool
    {
        public List<BasicClassRoom> GetClassRooms()
        {
            return ClassRoomHelper.LoadAllClassRoomsFromXML();
        }

        public DateTime GetLastDataUpdate()
        {
            string data = (from info in InformationHelper.LoadAllInfosFromXML() where info.Key == "LastDataUpdate" select info.Value).FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(data))
            {
                return DateTime.Parse(data);
            }
            return DateTime.MinValue;
        }

        public void DoWork()
        {
        }
    }
}
