using ChapterExamples.Chapters.ChapterTwentyThree;
using ChapterExamples.Utility;

namespace ChapterTwentyThree
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.CreatePath("output/ch23");
            ModifyingOutlines.Modify(FileUtility.GetPath("../ChapterExamples/resources/ch22/"), FileUtility.GetPath("output/ch23/"));
        }
    }
}
