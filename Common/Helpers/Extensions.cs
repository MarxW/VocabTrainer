using Marx.Wolfgang.VocabTrainer.Common.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marx.Wolfgang.VocabTrainer.Common.Helpers
{
    public static class Extensions
    {
        public static void AddOrUpdateKeyValue(this ObservableCollection<BasicClassRoom> collection, BasicClassRoom classroom)
        {
            var foundItem = (from item in collection where classroom.Title.Equals(item.Title) select item).FirstOrDefault();
            if (null == foundItem)
            {
                collection.Add(classroom);
            }
        }

        public static ObservableCollection<T> RemoveAll<T>(this ObservableCollection<T> coll, Func<T, bool> condition)
        {
            var itemsToRemove = coll.Where(condition).ToList();

            foreach (var itemToRemove in itemsToRemove)
            {
                coll.Remove(itemToRemove);
            }

            return coll;
        }

    }
}
