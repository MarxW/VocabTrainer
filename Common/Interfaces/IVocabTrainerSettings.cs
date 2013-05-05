using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marx.Wolfgang.VocabTrainer.Common.Interfaces
{
    public interface IVocabTrainerSettings
    {
        string GetUserIdetifier();
        DateTime GetLastDataUpdate();
        void SetLastDataUpdate(DateTime date);
    }
}
