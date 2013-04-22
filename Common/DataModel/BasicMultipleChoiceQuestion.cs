using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marx.Wolfgang.VocabTrainer.Common.DataModel
{
    class BasicMultipleChoiceQuestion
    {
        BasicVocabulary VocabularyToQuestion { get; set; }
        List<BasicVocabulary> MultipleChoices { get; set; }
    }
}
