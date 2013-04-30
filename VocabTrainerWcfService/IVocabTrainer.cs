using Marx.Wolfgang.VocabTrainer.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace VocabTrainerWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IVocabTrainer" in both code and config file together.
    [ServiceContract]
    public interface IVocabTrainer
    {
        [OperationContract]
        List<BasicClassRoom> GetClassRooms();

        [OperationContract]
        void DoWork();
    }
}
