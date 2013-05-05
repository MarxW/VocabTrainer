using Marx.Wolfgang.VocabTrainer.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace VocabTrainerPhoneApp.Interfaces
{
    class IVocabTrainerStorageImpl : IVocabTrainerStorage
    {
        public async void WriteData(string fileName, string content)
        {
            byte[] data = Encoding.UTF8.GetBytes(content);
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            using (Stream s = await file.OpenStreamForWriteAsync())
            {
                await s.WriteAsync(data, 0, data.Length);
            }
        }

        public async Task<string> ReadData(string fileName)
        {
            byte[] data;
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.GetFileAsync(fileName);
            using (Stream s = await file.OpenStreamForReadAsync())
            {
                data = new byte[s.Length];
                await s.ReadAsync(data, 0, (int)s.Length);
            }
            return Encoding.UTF8.GetString(data, 0, data.Length);
        }
    }
}
