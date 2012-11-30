using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Net.WolfgangMarx.VocabTrainer.Model;
using System.Xml.Linq;
using Net.WolfgangMarx.VocabTrainer.Helpers;

namespace Net.WolfgangMarx.VocabTrainer.Interfaces
{
    class ClassRoomImpl : ClassRoom
    {
        private static string filePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Data\\Lessons.xml";
        
        public IEnumerable<Lesson> LoadLessons()
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Could not find the data file");
            }
            List<Lesson> lessons = new List<Lesson>();
            XDocument xmlDocument = XDocument.Load(filePath);

            return (from el in xmlDocument.Root.Elements("Lesson")
                    select el.ToLesson()).ToList().OrderBy(x => x.Name);
        }

        public Lesson LoadLesson(int lessonNumber)
        {
            return (from l in LoadLessons() where l.Number == lessonNumber select l).SingleOrDefault();
        }

        public MultipleChoiceTest LoadMultipleChoiceTestForLesson(int lessonNumber)
        {
            MultipleChoiceTest test = new MultipleChoiceTest();
            test.Questions = new List<MultipleChoiceQuestion>();
            Lesson lesson = LoadLesson(lessonNumber);

            foreach (Translation word in lesson.Translations)
            {
                MultipleChoiceQuestion question = new MultipleChoiceQuestion();
                question.PossibleAnswers = new List<MultipleChoiceAnswer>();
                question.Number = test.Questions.Count + 1;
                question.Question = string.Format("{0} heißt übersetzt auf English:", word.German);
                question.PossibleAnswers.Add(new MultipleChoiceAnswer() { Number = 1, Answer = word.English, IsCorrect = true });
                GenerateWrongMultipleChoiceAnswers(question, lesson, 4);
                test.Questions.Add(question);
            }

            return test;
        }

        public bool ValidLessonId(int lessonId)
        {
            XDocument xmlDocument = XDocument.Load(filePath);
            return (from el in xmlDocument.Root.Elements("Lesson") 
                    select el.ToLesson()).ToList().Where(x => x.Number == lessonId).Count() > 0;
        }

        #region "Private Methods"

        private void GenerateWrongMultipleChoiceAnswers(MultipleChoiceQuestion question, Lesson lesson, int totalNumberOfAnswers)
        {
            Random r = new Random();
            while (question.PossibleAnswers.Count < totalNumberOfAnswers)
            {
                int pos = r.Next(0, lesson.Translations.Count);
                Translation t = lesson.Translations[pos];
                if ((from a in question.PossibleAnswers where a.Answer.Equals(t.English) select a).Count() < 1)
                {
                    question.PossibleAnswers.Add(new MultipleChoiceAnswer() { Answer = t.English, IsCorrect = false, Number = question.PossibleAnswers.Count + 1 });
                }
            }
        }

        #endregion
    }
}
