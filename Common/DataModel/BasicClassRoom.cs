using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Marx.Wolfgang.VocabTrainer.Common.DataModel
{
    class BasicClassRoom
    {
        [XmlElement("id")]
        public int Id { get; set; }
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("lessons")]
        public List<BasicLesson> Lessons { get; set; }
    }
}
