using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace Marx.Wolfgang.VocabTrainer.DataModel
{

    public class BasicClassRoom
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }
        [XmlAttribute("Title")]
        public string Title { get; set; }
        [XmlAttribute("Description")]
        public string Description { get; set; }
        [XmlArray("ArrayOfBasicLesson")]
        [XmlArrayItem("BasicLesson")]
        public List<BasicLesson> BasicLessons { get; set; }
    }
}
