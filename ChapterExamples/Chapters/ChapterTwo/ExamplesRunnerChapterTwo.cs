using ChapterExamples.Chapters.ChapterTwo;
using ChapterExamples.Utility;

namespace ChapterTwo
{
    public class ExamplesRunnerChapterTwo
    {
        public static void RunAll()
        {
            FileUtility.CreatePath("output/ch2");
            HtmlLayoutExample.Create(FileUtility.GetPath("output/ch2/"));
            Alignment.Create(FileUtility.GetPath("output/ch2/"));
            DocumentPage.Create(FileUtility.GetPath("../ChapterExamples/resources/ch2/"), FileUtility.GetPath("output/ch2/"));
            DocPagePropsExample.Create(FileUtility.GetPath("output/ch2/"));
            PageLayoutExample.Create(FileUtility.GetPath("output/ch2/"));
            CoordinatesExample.Create(FileUtility.GetPath("../ChapterExamples/resources/ch2/"), FileUtility.GetPath("output/ch2/"));
            CoordinatesFigure.Create(FileUtility.GetPath("../ChapterExamples/resources/ch2/"), FileUtility.GetPath("output/ch2/"));
            IgnoreMarginsRelativeToExample.Create(FileUtility.GetPath("../ChapterExamples/resources/ch2/"), FileUtility.GetPath("output/ch2/"));
            LayoutGridExample.Create(FileUtility.GetPath("output/ch2/"));
            LayoutGridExampleTwo.Create(FileUtility.GetPath("../ChapterExamples/resources/ch2/"), FileUtility.GetPath("output/ch2/"));
            LayoutGridExampleThree.Create(FileUtility.GetPath("../ChapterExamples/resources/ch2/"), FileUtility.GetPath("output/ch2/"));

            PointVsSize.Create(FileUtility.GetPath("../ChapterExamples/resources/ch2/"), FileUtility.GetPath("output/ch2/"));

            ViewerPrefExample.Create(FileUtility.GetPath("output/ch2/"));
        }
    }
}
