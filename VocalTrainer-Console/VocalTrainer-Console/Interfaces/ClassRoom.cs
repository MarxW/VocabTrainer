using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Net.WolfgangMarx.VocabTrainer.Model;

namespace Net.WolfgangMarx.VocabTrainer.Interfaces
{
    interface ClassRoom
    {
        IEnumerable<Lesson> LoadLessons();

        Lesson LoadLesson(int lessonNumber);

        MultipleChoiceTest LoadMultipleChoiceTestForLesson(int lessonNumber);

        bool ValidLessonId(int lessonId);
    }
}
