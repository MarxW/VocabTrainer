using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net.WolfgangMarx.VocabTrainer.Model
{
    public class Lesson
    {
        public int Number;
        public string Name;
        public List<Translation> Translations;
    }

    public class Translation
    {
        public string German;
        public string English;
    }

    public class MultipleChoiceTest
    {
        public List<MultipleChoiceQuestion> Questions;
        public int MaxPoints;
        public int Points;
    }

    public class MultipleChoiceQuestion
    {
        public int Number;
        public string Question;
        public List<MultipleChoiceAnswer> PossibleAnswers;
        public MultipleChoiceAnswer ChosenAnswer;
    }

    public class MultipleChoiceAnswer
    {
        public int Number;
        public string Answer;
        public bool IsCorrect;
    }

}
