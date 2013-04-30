using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Marx.Wolfgang.VocabTrainer.DataModel
{
    public class BasicVocabulary
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }
        [XmlAttribute("German")]
        public string German { get; set; }
        [XmlAttribute("English")]
        public string English { get; set; }
    }
}
