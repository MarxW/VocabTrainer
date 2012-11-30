using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Net.WolfgangMarx.VocabTrainer.Model;
using Net.WolfgangMarx.VocabTrainer.Interfaces;
using Net.WolfgangMarx.VocabTrainer.Helpers;

namespace Net.WolfgangMarx.VocabTrainer
{
    class Program
    {
        private static ClassRoom classroom = new ClassRoomImpl();

        static void Main(string[] args)
        {
            DisplaySelection();
        }

        private static void DisplaySelection()
        {
            Console.Clear();
            Console.WriteLine("Please select your lesson:");
            Console.WriteLine(string.Empty);
            foreach (Lesson lesson in classroom.LoadLessons())
            {
                Console.WriteLine("  {0} - {1}", lesson.Number.ToString("00"), lesson.Name);
            }
            Console.WriteLine(string.Empty);

            string selection = string.Empty;

            while (IsValidSelection(selection) == false)
            {
                Console.WriteLine("Please enter a valid lesson number:");
                selection = Console.ReadLine();
            }
            DoLesson(int.Parse(selection));
        }

        private static void DoLesson(int lessonNumber)
        {
            Console.Clear();
            Lesson lesson = classroom.LoadLesson(lessonNumber);
            Console.WriteLine(" {0} - {1}", lesson.Number.ToString("00"), lesson.Name);
            Console.WriteLine(string.Empty);
            Console.WriteLine("  press any key to display the next word.");
            Console.WriteLine(string.Empty);
            Console.WriteLine("|{0,15}|{1,15}|", "Deutsch".ToConsoleTableValue(15), "English".ToConsoleTableValue(15));
            
            foreach (Translation word in lesson.Translations)
            {
                Console.WriteLine("|{0,15}|{1,15}|", " ".ToConsoleTableValue(15), " ".ToConsoleTableValue(15));
                Console.WriteLine("|{0,15}|{1,15}|", word.German.ToConsoleTableValue(15), word.English.ToConsoleTableValue(15));
                Console.ReadKey(true);
            }

            Console.WriteLine(string.Empty);

            string yesno = string.Empty;

            while (IsValidYesNo(yesno) == false)
            {
                Console.WriteLine("Wollen wir einen Test starten (j/n)?");
                yesno = Console.ReadKey(true).Key.ToString();
            }

            DoMultipleChoiceTest(lessonNumber);
        }

        private static void DoMultipleChoiceTest(int lessonNumber)
        {
            Console.Clear();
            MultipleChoiceTest test = classroom.LoadMultipleChoiceTestForLesson(lessonNumber);



            foreach (MultipleChoiceQuestion question in test.Questions)
            {
                Console.WriteLine(" {0} - {1}", question.Number.ToString("00"), question.Question);
                foreach (MultipleChoiceAnswer answer in question.PossibleAnswers)
                {
                    Console.WriteLine("     {0} - {1}", answer.Number, answer.Answer);
                }
            }

            Console.ReadKey(true);
        }

        private static bool IsValidYesNo(string userInput)
        {
            if (userInput.ToLower().Equals("j") || userInput.ToLower().Equals("n"))
            {
                return true;
            }
            Console.Beep();
            return false;
        }

        private static bool IsValidSelection(string userInput)
        {
            int tmpId;
            bool isNumberic = int.TryParse(userInput, out tmpId);
            if (isNumberic)
            {
                return classroom.ValidLessonId(tmpId);
            }
            Console.Beep();
            return false;
        }
    }
}
