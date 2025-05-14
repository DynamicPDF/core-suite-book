using ChapterExamples.Chapters.ChapterSixteen;
using ChapterExamples.Utility;

namespace Chapter16
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.CreatePath("output/ch16");
            EventsExample.Create(FileUtility.GetPath("output/ch16/"));
            ActionsExample.Create(FileUtility.GetPath("../ChapterExamples/resources/ch1/merge-example.pdf"), FileUtility.GetPath("output/ch16/"));
   
        }
    }
}
