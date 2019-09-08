using System;

namespace SlideSeparator
{
    class Program
    {
        static void Main(string[] args)
        {
            string testText = GetTestText();
            SlideTextPortions slideSeparator = new SlideTextPortions(testText);
            var result = slideSeparator.textSlidePortions;

            Console.WriteLine(result[0]);
            Console.ReadKey();
        }

        private static string GetTestText()
        {
            return @"ДОБРЕ ДОШЛИ 1
в първата игра по средновековна история на България, създадена с платформата за генериране на сериозни игри за обучение по проект APOGEE 
(http://www.apogee.online/).
             ДОБРЕ ДОШЛИ 2
в първата игра по средновековна история на България, създадена с платформата за генериране на сериозни игри за обучение по проект APOGEE (http://www.apogee.online/).
             ДОБРЕ ДОШЛИ 3
в първата игра по средновековна история на България, създадена с платформата за
генериране на сериозни игри за обучение по проект APOGEE (http://www.apogee.online/).
             ДОБРЕ ДОШЛИ 4
в първата игра по средновековна история на България, създадена с платформата за
генериране на сериозни игри за обучение по проект APOGEE (http://www.apogee.online/).";
        }
    }
}
