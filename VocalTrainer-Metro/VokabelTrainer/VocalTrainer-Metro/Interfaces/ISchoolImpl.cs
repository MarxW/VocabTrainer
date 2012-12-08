using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VocalTrainer_Metro.DataModel;
using Windows.Storage;
using VocalTrainer_Metro.Common;
using System.Collections.ObjectModel;

namespace VocalTrainer_Metro.Interfaces
{
    class ISchoolImpl : ISchool
    {
        private const string CLASSROOM_FILE = "classroom.xml";
        private const string DATA_FOLDER = "VocabTrainerData";

        public void LoadAllClassRooms(List<ClassRoom> classrooms)
        {
            
            //StorageFile file = await this.GetConfigFile();
            
            //string contents = string.Empty;

            //string text = await Windows.Storage.FileIO.ReadTextAsync(file);

            //XDocument xmlDocument = XDocument.Parse(text);

            XDocument xmlDocument = XDocument.Load("School.xml");

            IEnumerable<ClassRoom> loadedLessons = (from el in xmlDocument.Root.Elements("ClassRoom")
                                    select el.ToClassRoom()).ToList().OrderBy(x => x.Title);
            foreach (ClassRoom l in loadedLessons)
            {
                classrooms.Add(l);
            }
        }


        #region "Virtual Methods"

        public virtual async Task<StorageFile> GetConfigFile()
        {
            StorageFile file = null;
            try
            {
                StorageFolder sf = Windows.Storage.ApplicationData.Current.RoamingFolder;
                file = await sf.GetFileAsync(CLASSROOM_FILE);
            }
            catch (Exception)
            {

            }
            if (null == file)
            {
                return await this.CreateConfigFile();
            }
            return file;
        }

        #endregion

        #region "Private Methods"

        private async Task<StorageFile> CreateConfigFile()
        {
            StorageFolder sf = Windows.Storage.ApplicationData.Current.RoamingFolder; //KnownFolders.DocumentsLibrary;
            StorageFile file = await sf.CreateFileAsync(CLASSROOM_FILE, CreationCollisionOption.ReplaceExisting);

            XDocument xmlDocument = new XDocument();

            XElement root = new XElement("VocabTrainer");

            XElement element = new XElement("ClassRoom",
                                new XAttribute("uniqueId", Guid.NewGuid().ToString()),
                                new XAttribute("title", "MBS 6f"),
                                new XAttribute("subtitle", "English vocab für die MBS 6f."),
                                new XAttribute("imagePath", string.Empty),
                                new XAttribute("description", "English vocab für die MBS 6f."));
            root.Add(element);

            element = new XElement("ClassRoom",
                                new XAttribute("uniqueId", Guid.NewGuid().ToString()),
                                new XAttribute("title", "MBS 6a"),
                                new XAttribute("subtitle", "English vocab für die MBS 6a."),
                                new XAttribute("imagePath", string.Empty),
                                new XAttribute("description", "English vocab für die MBS 6a."));
            root.Add(element);

            xmlDocument.Add(root);

            await FileIO.WriteTextAsync(file, xmlDocument.ToString());

            return file;
        }

        #endregion

    }
}
