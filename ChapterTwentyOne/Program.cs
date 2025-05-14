using ChapterExamples.Chapters.ChapterTwentyOne;
using ChapterExamples.Utility;

namespace ChapterTwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.CreatePath("output/ch21");
            SimplePdfAExample.Create(FileUtility.GetPath("../ChapterExamples/resources/"), FileUtility.GetPath("output/ch21/"));
            CustomPageElementExample.Modify(FileUtility.GetPath("output/ch21/"));
        }
    }
}
