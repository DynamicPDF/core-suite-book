using ChapterExamples.Chapters.ChapterFive;
using ChapterExamples.Utility;


namespace ChapterFive
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.CreatePath("output/ch5");
            CircleExample.Create(FileUtility.GetPath("output/ch5/circle-out.pdf"));

            LinesExample.Create(FileUtility.GetPath("output/ch5/line-out.pdf"));
            LinesExample.LineStyles(FileUtility.GetPath("output/ch5/line-style-out.pdf"));

            RectangleExample.Create(FileUtility.GetPath("output/ch5/rectangle-out.pdf"));
            PathExample.Create(FileUtility.GetPath("output/ch5/paths-out.pdf"));

            AutoLayoutShapesExample.Create(FileUtility.GetPath("output/ch5/autolayout-out.pdf"));
        }
    }
}
