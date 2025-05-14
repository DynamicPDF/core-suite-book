

using ChapterExamples.Chapters.ChapterTwentyTwo;
using ChapterExamples.Utility;

namespace ChapterTwentyTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.CreatePath("output/ch22");
            MergingExample.Modify(FileUtility.GetPath("../ChapterExamples/resources/ch22/"), FileUtility.GetPath("output/ch22/"));
            AddPage.Modify(FileUtility.GetPath("../ChapterExamples/resources/ch22/"), FileUtility.GetPath("output/ch22/"));
            SplittingPdf.Modify(FileUtility.GetPath("../ChapterExamples/resources/ch22/"), FileUtility.GetPath("output/ch22/"));
            ExtractElements.Modify(FileUtility.GetPath("../ChapterExamples/resources/ch22/"), FileUtility.GetPath("output/ch22/"));
            ExtractingText.Modify(FileUtility.GetPath("../ChapterExamples/resources/ch22/"), FileUtility.GetPath("output/ch22/"));
            ImportingPages.Modify(FileUtility.GetPath("../ChapterExamples/resources/ch22/"), FileUtility.GetPath("output/ch22/"));

        }
    }
}
