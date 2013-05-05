using Marx.Wolfgang.VocabTrainer.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabTrainerPhoneApp.Interfaces
{
    public class IVocabTrainerSettingsImpl : IVocabTrainerSettings
    {
        private IsolatedStorageSettings isolatedStore;
        private const string LastDataUpdateKeyName = "LastDataUpdate";

        public string GetUserIdetifier()
        {
            throw new NotImplementedException();
        }

        public DateTime GetLastDataUpdate()
        {
            return GetValueOrDefault<DateTime>(LastDataUpdateKeyName, DateTime.MinValue);
        }

        public void SetLastDataUpdate(DateTime date)
        {
            AddOrUpdateValue(LastDataUpdateKeyName, date);
            Save();
        }

        public IVocabTrainerSettingsImpl()
        {
            try
            {
                // Get the settings for this application.
                isolatedStore = IsolatedStorageSettings.ApplicationSettings;
            }
            catch (Exception e)
            {
                //Debug.WriteLine("Exception while using IsolatedStorageSettings: " + e.ToString());
            }
        }

        public bool AddOrUpdateValue(string Key, Object value)
        {
            bool valueChanged = false;
            if (isolatedStore.Contains(Key))
            {
                if (isolatedStore[Key] != value)
                {
                    isolatedStore[Key] = value;
                    valueChanged = true;
                }
            }
            else
            {
                isolatedStore.Add(Key, value);
                valueChanged = true;
            }
            return valueChanged;
        }

        public valueType GetValueOrDefault<valueType>(string Key, valueType defaultValue)
        {
            valueType value;
            if (isolatedStore.Contains(Key))
            {
                try
                {
                    value = (valueType)isolatedStore[Key];
                }
                catch
                {
                    value = defaultValue;
                }
            }
            else
            {
                value = defaultValue;
            }
            return value;
        }

        public void Save()
        {
            isolatedStore.Save();
        }
    }
}
