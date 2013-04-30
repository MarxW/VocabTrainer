using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace Marx.Wolfgang.VocabTrainer.DataModel
{
    public class BasicClassRoom
    {
        [XmlElement("Id")]
        public int Id { get; set; }
        [XmlElement("Title")]
        public string Title { get; set; }
        [XmlElement("BasicLessons")]
        public ObservableCollection<BasicLesson> BasicLessons { get; set; }
    }
}
