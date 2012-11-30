using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Net.WolfgangMarx.VocabTrainer.Model;
using System.Xml.Linq;

namespace Net.WolfgangMarx.VocabTrainer.Helpers
{
    public static class Extensions
    {

        public static Lesson ToLesson(this XElement xmlLesson)
        {
            Lesson lesson = new Lesson();
            lesson.Translations = new List<Translation>();
            lesson.Number = (int)xmlLesson.Attribute("id");
            lesson.Name = (string)xmlLesson.Attribute("name");
            foreach (XElement child in xmlLesson.Elements("Word"))
            {
                lesson.Translations.Add(new Translation() 
                            { 
                                English = (string)child.Attribute("english"),
                                German = (string)child.Attribute("german")
                            });
            }
            return lesson;
        }

        public static string ToConsoleTableValue(this string value, int cellWidth)
        {
            while (value.Length < cellWidth)
            {
                value += " ";
            }
            return value;
        }
    
    }

}
