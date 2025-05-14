
using ChapterExamples.Chapters.ChapterSeven;
using ChapterExamples.Utility;

namespace ChapterSeven
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.CreatePath("output/ch7");

            AnchorGroupExample.Create(FileUtility.GetPath("../ChapterExamples/resources/ch3/logo.png"), FileUtility.GetPath("output/ch7/anchor-group-out.pdf"));
            TransparencyGroupExample.Create(FileUtility.GetPath("../ChapterExamples/resources/ch3/logo.png"), FileUtility.GetPath("output/ch7/transparency-group-out.pdf"));
            TransformationGroupExample.Create(FileUtility.GetPath("../ChapterExamples/resources/ch3/logo.png"), FileUtility.GetPath("output/ch7/transformation-group-out.pdf"));

            AreaGroupExample.Create(FileUtility.GetPath("../ChapterExamples/resources/ch3/logo.png"), FileUtility.GetPath("output/ch7/area-group-out.pdf"));

            ContentAreaExample.Create(FileUtility.GetPath("../ChapterExamples/resources/ch3/logo.png"), FileUtility.GetPath("output/ch7/content-area-out.pdf"));
        }
    }
}
