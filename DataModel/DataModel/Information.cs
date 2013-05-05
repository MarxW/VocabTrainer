using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Marx.Wolfgang.VocabTrainer.DataModel
{
    public class Information
    {
        [XmlAttribute("Key")]
        public string Key { get; set; }
        [XmlAttribute("Value")]
        public string Value { get; set; }
    }
}
