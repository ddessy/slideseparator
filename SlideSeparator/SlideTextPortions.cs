using System;
using System.Collections.Generic;

namespace SlideSeparator
{
    public class SlideTextPortions
    {
        private static short lineLenght = 50;
        private static short linesInSlide = 10;
        private static short slidesMaxNo = 40; //the max number of slides for one table in the room

        public string[] textSlidePortions;
        public short slidePortionsNo;
        public short currentSlideShown;

        public SlideTextPortions(string rawText)
        {
            SetSlidePortions(rawText);
        }

        private void SetSlidePortions(string rawText)
        {
            textSlidePortions = new string[slidesMaxNo];
            string[] textLines = GetTextLinesWithRequiredLength(rawText);

            int controlLineNumbers = 1;
            int textSlidePortionsNumber = 0;
            string bufferText = string.Empty;

            for (int i = 0; i < textLines.Length; i++)
            {
                if (controlLineNumbers == 10)
                {
                    textSlidePortions[textSlidePortionsNumber] = bufferText;
                    textSlidePortionsNumber++;

                    controlLineNumbers = 1;
                    bufferText = string.Empty;
                }

                DividerText dividerText = new DividerText(textLines[i], lineLenght);
                bufferText += dividerText.Quotient;

                if (i == textLines.Length - 1)
                {
                    textSlidePortions[textSlidePortionsNumber] = bufferText;
                }
                else
                {
                    if (dividerText.Remainder != null && dividerText.Remainder.Length > 0)
                    {
                        bufferText += dividerText.Remainder;
                    }

                    bufferText += Environment.NewLine;
                }

                controlLineNumbers++;
            }
        }

        private static string[] GetTextLinesWithRequiredLength(string rawText)
        {
            List<string> rawTextLines = new List<string>(rawText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None));
            List<string> result = new List<string>();
            foreach (string line in rawTextLines)
            {
                DividerText dividerText = new DividerText(line, lineLenght);
                result.Add(dividerText.Quotient);
                if (dividerText.Remainder != null && dividerText.Remainder.Length > 0)
                {
                    result.AddRange(GetTextLinesWithRequiredLength(dividerText.Remainder));
                }
            }

            return result.ToArray();
        }
    }
}
