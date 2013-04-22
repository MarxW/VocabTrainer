using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace Marx.Wolfgang.VocabTrainer.Common.DataModel
{
    public class BasicClassRoom
    {
        [XmlElement("id")]
        public int Id { get; set; }
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("lessons")]
        public ObservableCollection<BasicLesson> Lessons { get; set; }
    }
}
