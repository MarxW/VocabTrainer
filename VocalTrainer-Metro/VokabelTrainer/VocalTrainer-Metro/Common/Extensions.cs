using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VocalTrainer_Metro.DataModel;

namespace VocalTrainer_Metro.Common
{
    public static class Extensions
    {

        public static ClassRoom ToClassRoom(this XElement xmlLesson)
        {
            ClassRoom lesson = new ClassRoom();
            lesson.Translations = new List<Translation>();
            lesson.UniqueId = (string)xmlLesson.Attribute("uniqueId");
            lesson.Title = (string)xmlLesson.Attribute("title");
            lesson.Description = (string)xmlLesson.Attribute("description");
            lesson.Subtitle = (string)xmlLesson.Attribute("subtitle");
            lesson.SetImage("Assets/MediumGray.png");
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

    }
}
