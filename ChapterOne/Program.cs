using ChapterExamples.Chapters.ChapterOne;
using ChapterExamples.Utility;

namespace ChapterOne
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.CreatePath("output/ch1");
            CreatePdf.Create(FileUtility.GetPath("output/ch1/ch1-create-out.pdf"));
            SimpleMerge.Modify(FileUtility.GetPath("../ChapterExamples/resources/ch22/"), FileUtility.GetPath("output/ch1/"));
        }
    }
}
