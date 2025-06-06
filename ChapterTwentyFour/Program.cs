using ChapterExamples.Chapters.ChapterTwentyFour;
using ChapterExamples.Utility;
using System;

namespace ChapterTwentyFour
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.CreatePath("output/ch24");
            ObtainingFieldLocations.Modify(FileUtility.GetPath("../ChapterExamples/resources/Ch24/"), FileUtility.GetPath("output/ch24/"));
            ReadingFormExample.Modify(FileUtility.GetPath("../ChapterExamples/resources/Ch24/"), FileUtility.GetPath("output/ch24/"));
            FormFillingExample.Modify(FileUtility.GetPath("../ChapterExamples/resources/Ch24/"), FileUtility.GetPath("output/ch24/"));
            FormModificationExample.Modify(FileUtility.GetPath("../ChapterExamples/resources/Ch24/"), FileUtility.GetPath("output/ch24/"));
            FormFlattening.Modify(FileUtility.GetPath("../ChapterExamples/resources/Ch24/"), FileUtility.GetPath("output/ch24/"));
            FormReadOnly.Modify(FileUtility.GetPath("../ChapterExamples/resources/Ch24/"), FileUtility.GetPath("output/ch24/"));
        }
    }
}
