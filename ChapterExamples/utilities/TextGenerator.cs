using System;
using System.IO;

namespace ChapterExamples.Utility
{
    public class TextGenerator
    {
        public static string Generate()
        {
            return File.ReadAllText(FileUtility.GetPath("../ChapterExamples/resources/pglatin.html"));
        }

        public static string GenerateShort()
        {
            return File.ReadAllText(FileUtility.GetPath("../ChapterExamples/resources/pglatin-short.txt"));
        }

        public static string GenerateHtmlWithImg()
        {
            return File.ReadAllText(FileUtility.GetPath("../ChapterExamples/resources/pglatin-img.html"));
        }

        public static string GenerateText()
        {
            string txt = File.ReadAllText(FileUtility.GetPath("../ChapterExamples/resources/pglatin.txt"));
            return txt.Replace("\\n", Environment.NewLine).Replace("  ", " ");
        }

        public static string GenerateTextMultiple(int repeat)
        {
            string txt = GenerateText();

            for (int i = 0; i < repeat; i++)
            {
                txt += GenerateText();
            }

            return txt;
        }

        public static string GenerateSimple()
        {
            return File.ReadAllText(FileUtility.GetPath("../ChapterExamples/resources/pglatin-simple.html"));
        }
    }
}
