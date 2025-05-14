using ChapterExamples.Chapters.ChapterTwentyEight;
using ChapterExamples.Utility;
using System;

namespace ChapterTwentyEight
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.CreatePath("output/ch28");
            SubreportExample.CreateReport(FileUtility.GetPath("../ChapterExamples/resources/ch28/"), FileUtility.GetPath("output/ch28/"));
            SubreportEventExample.CreateReport(FileUtility.GetPath("../ChapterExamples/resources/ch28/"), FileUtility.GetPath("output/ch28/"));
            PlaceHolderExample.CreateReport(FileUtility.GetPath("../ChapterExamples/resources/ch28/"), FileUtility.GetPath("output/ch28/"));
            SimplePlaceHolderExample.CreateReport(FileUtility.GetPath("../ChapterExamples/resources/ch28/"), FileUtility.GetPath("output/ch28/"));
        }
    }
}
