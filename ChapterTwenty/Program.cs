using ChapterExamples.Chapters.ChapterTwenty;
using ChapterExamples.Utility;
using System;

namespace ChapterTwenty
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.CreatePath("output/ch20");
            TaggedFormExample.Create(FileUtility.GetPath("output/ch20/"));
            FirstPass.Create(FileUtility.GetPath("../ChapterExamples/resources/"), FileUtility.GetPath("output/ch20/"));
            SimpleTaggedExample.Create(FileUtility.GetPath("../ChapterExamples/resources/"), FileUtility.GetPath(FileUtility.GetPath("output/ch20/")));
            VariousStructureExamples.Create(FileUtility.GetPath("../ChapterExamples/resources/"), FileUtility.GetPath(FileUtility.GetPath("output/ch20/")));
            SimpleTaggedForm.Create(FileUtility.GetPath("../ChapterExamples/resources/"), FileUtility.GetPath("output/ch20/"));
        }
    }
}
