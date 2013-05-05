using log4net;
using Marx.Wolfgang.VocabTrainer.DataModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml.Serialization;

namespace Marx.Wolfgang.VocabTrainer.Service.Helper
{
    public static class InformationHelper
    {
        public static List<Information> LoadAllInfosFromXML()
        {
            ILog Logger = LogManager.GetLogger(typeof(InformationHelper));
            List<Information> infos = new List<Information>();
            try
            {
                Logger.Info("Start: GetAllInfos");
                XmlSerializer deserializer = new XmlSerializer(typeof(List<Information>));
                string path = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, ConfigurationManager.AppSettings["INFO_DATA_FILE"]);
                TextReader textReader = new StreamReader(path);
                infos = (List<Information>)deserializer.Deserialize(textReader);
                textReader.Close();

            }
            catch (Exception e)
            {
                
                Logger.Error(e);
            }
            return infos;
        }
    }
}