using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Marx.Wolfgang.VocabTrainer.Common.DataModel
{
    class BasicLesson
    {
        [XmlElement("id")]
        public int Id { get; set; }
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("vocabularies")]
        public List<BasicVocabulary> Vocabularies { get; set; }
    }
}
