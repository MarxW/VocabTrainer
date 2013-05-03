using log4net;
using Marx.Wolfgang.VocabTrainer.DataModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Marx.Wolfgang.VocabTrainer.Service.Helper
{
    public static class ClassRoomHelper
    {
        /*
        public static List<BasicClassRoom> LoadAllClassRoomsFromXML()
        {
            List<BasicClassRoom> rooms = new List<BasicClassRoom>();
            XDocument xmlDocument = XDocument.Load(System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["SCHOOL_DATA_FILE"]));
            foreach (XElement xe in xmlDocument.Root.Element("BasicClassRooms").Elements("BasicClassRoom"))
            {
                BasicClassRoom room = new BasicClassRoom();
                room.Id = (int)xe.Attribute("Id");
                room.Title = (string)xe.Attribute("Title");

                rooms.Add(room);
            }
            return rooms;
        }
        */

        public static List<BasicClassRoom> LoadAllClassRoomsFromXML()
        {
            ILog Logger = LogManager.GetLogger(typeof(ClassRoomHelper));
            List<BasicClassRoom> rooms = new List<BasicClassRoom>();
            try
            {
                Logger.Info("Start: GetAllRooms");
                XmlSerializer deserializer = new XmlSerializer(typeof(List<BasicClassRoom>));
                string path = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, ConfigurationManager.AppSettings["SCHOOL_DATA_FILE"]);
                TextReader textReader = new StreamReader(path);
                rooms = (List<BasicClassRoom>)deserializer.Deserialize(textReader);
                textReader.Close();
                
            }
            catch (Exception e)
            {
                rooms.Add(new BasicClassRoom() { Title = ConfigurationManager.AppSettings["SCHOOL_DATA_FILE"].ToString() + Environment.NewLine +
                                                e.ToString(), Id = 999 });
                Logger.Error(e);
            }
            return rooms;
        }

        /*
        public static T FromXML<T>(this T obj, string xml) where T : class
        {

        }
        */
    }
}