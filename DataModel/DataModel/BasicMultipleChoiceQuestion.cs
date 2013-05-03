using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Marx.Wolfgang.VocabTrainer.DataModel
{
    public class BasicMultipleChoiceQuestion
    {
        BasicVocabulary VocabularyToQuestion { get; set; }
        List<BasicVocabulary> MultipleChoices { get; set; }
    }
}
