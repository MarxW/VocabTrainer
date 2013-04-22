using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Marx.Wolfgang.VocabTrainer.Common.DataModel
{
    class BasicVocabulary
    {
        [XmlElement("id")]
        public int Id { get; set; }
        [XmlElement("german")]
        public string German { get; set; }
        [XmlElement("english")]
        public string English { get; set; }
    }
}
