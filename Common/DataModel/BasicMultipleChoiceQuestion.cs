﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Marx.Wolfgang.VocabTrainer.Common.DataModel
{
    public class BasicMultipleChoiceQuestion
    {
        BasicVocabulary VocabularyToQuestion { get; set; }
        ObservableCollection<BasicVocabulary> MultipleChoices { get; set; }
    }
}
