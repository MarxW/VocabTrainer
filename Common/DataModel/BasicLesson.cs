using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Marx.Wolfgang.VocabTrainer.Common.DataModel
{
    public class BasicLesson
    {
        [XmlElement("id")]
        public int Id { get; set; }
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("vocabularies")]
        public ObservableCollection<BasicVocabulary> Vocabularies { get; set; }
    }
}
