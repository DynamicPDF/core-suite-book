using ChapterExamples.Chapters.ChapterEight;
using ChapterExamples.Utility;

namespace ChapterEight
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.CreatePath("output/ch8");
            FontsExample.Create(FileUtility.GetPath("../ChapterExamples/resources/ch8/"), FileUtility.GetPath("output/ch8/"));
            GoogleFontsExample.Create(FileUtility.GetPath("output/ch8/"));
            ColorsExample.Create(FileUtility.GetPath("output/ch8/"));
            GradientsAutoGradientsExample.Create(FileUtility.GetPath("output/ch8/"));
        }
    }
}
