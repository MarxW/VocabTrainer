using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Marx.Wolfgang.VocabTrainer.Common.Helpers
{
    public static class SerializerHelper
    {
        public static T DeserializeAsXML<T>(this XDocument xmlDocument)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (XmlReader reader = xmlDocument.CreateReader())
            {
                return (T)xmlSerializer.Deserialize(reader);
            }
        }

        public static string ToXML<T>(this T item)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            StringBuilder sb = new StringBuilder();
            XmlWriter wr = XmlWriter.Create(sb);
            xmlSerializer.Serialize(wr, item);
            return sb.ToString();
        }

        public static T DeserializeAsDataContract<T>(this XDocument xmlDocument)
        {
            DataContractSerializer dcSerializer = new DataContractSerializer(typeof(T));
            using (XmlReader reader = xmlDocument.CreateReader())
            {
                return (T)dcSerializer.ReadObject(reader);
            }
        }

        public static string ToDataContract<T>(this T item)
        {
            DataContractSerializer dcSerializer = new DataContractSerializer(typeof(T));
            using (var stream = new System.IO.MemoryStream())
            {
                dcSerializer.WriteObject(stream, item);
                var sr = new StreamReader(stream);
                return sr.ReadToEnd();
            }
        }
    }
}
