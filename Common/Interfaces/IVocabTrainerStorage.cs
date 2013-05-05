using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marx.Wolfgang.VocabTrainer.Common.Interfaces
{
    public interface IVocabTrainerStorage
    {
        void WriteData(string fileName, string content);
        Task<string> ReadData(string fileName);
    }
}
