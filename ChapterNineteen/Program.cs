using ChapterExamples.Chapters.ChapterNineteen;
using ChapterExamples.Utility;
using System;

namespace ChapterNineteen
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.CreatePath("output/ch19/");
            EmbeddingExample.Create(FileUtility.GetPath("../ChapterExamples/resources"), FileUtility.GetPath("output/ch19/"));
            PortfolioExample.Create(FileUtility.GetPath("../ChapterExamples/resources"), FileUtility.GetPath("output/ch19/"));
        }
    }
}
