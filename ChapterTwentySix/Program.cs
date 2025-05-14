using ChapterExamples.Chapters.ChapterTwentySix;
using ChapterExamples.Utility;
using System;

namespace ChapterTwentySix
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.CreatePath("output/ch26");
            DocumentImportPageExample.Create(FileUtility.GetPath("../ChapterExamples/resources/ch22/"), FileUtility.GetPath("output/ch26/"));
        }
    }
}
