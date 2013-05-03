using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Marx.Wolfgang.VocabTrainer.DataModel
{
    public class BasicLesson
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }
        [XmlAttribute("Title")]
        public string Title { get; set; }
        [XmlAttribute("Description")]
        public string Description { get; set; }
        [XmlArray("ArrayOfBasicVocabulary")]
        [XmlArrayItem("BasicVocabulary")]
        public List<BasicVocabulary> BasicVocabularies { get; set; }
    }
}
