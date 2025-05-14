using ChapterExamples.Chapters.ChapterTwentySeven;
using ChapterExamples.Chapters.ChapterTwentySeven.Data;
using ChapterExamples.Utility;
using System;
using System.Collections.Generic;

namespace ChapterTwentySeven
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(CreateABook());
            FileUtility.CreatePath("output/ch27");
            SimpleObjectExample.CreateReport(FileUtility.GetPath("../ChapterExamples/resources/ch27/"), FileUtility.GetPath("output/ch27/"));
            NestedObjectExample.CreateReport(FileUtility.GetPath("../ChapterExamples/resources/ch27/"), FileUtility.GetPath("output/ch27/"));
            DataTableReportDataExample.CreateReport(FileUtility.GetPath("../ChapterExamples/resources/ch27/"), FileUtility.GetPath("output/ch27/"));
            DataReaderReportDataExample.CreateReport(FileUtility.GetPath("../ChapterExamples/resources/ch27/"), FileUtility.GetPath("output/ch27/"));
            EnumerableExample.CreateReport(FileUtility.GetPath("../ChapterExamples/resources/ch27/"), FileUtility.GetPath("output/ch27/"));
        }

        private static string CreateABook()
        {
            Book aBook = new Book();
            aBook.Title = "The DynamicPDF Core Suite By Example";
            aBook.Author = "James A Brannan";
            aBook.PublishDate = 2025;
            aBook.Publisher = "Undetermined";
            aBook.ImagePath = "cover-image.png";
            aBook.Chapters = new List<Chapter>();
            aBook.Chapters.Add(new Chapter("Introducion", "An introduction."));

            for (int i = 1; i < 15; i++)
                aBook.Chapters.Add(new Chapter("Chapter " + i, "The summary of chapter " + i + "\n" + TextGenerator.GenerateShort()));

            return aBook.getJson();

        }
    }
}
