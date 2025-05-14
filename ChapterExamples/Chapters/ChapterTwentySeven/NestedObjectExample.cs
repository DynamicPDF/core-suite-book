using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ChapterExamples.Chapters.ChapterTwentySeven.Data;
using ChapterExamples.Utility;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ChapterExamples.Chapters.ChapterTwentySeven
{
    public class NestedObjectExample
    {
        public static void CreateReport(string resourcePath, string outputPath)
        {
            UseObject(resourcePath, outputPath);
            UseJson(resourcePath, outputPath);
        }

        public static void UseObject(string resourcePath, string outputPath)
        {
            Book aBook = new Book();
            aBook.Title = "The DynamicPDF Core Suite By Example";
            aBook.Author = "James A Brannan";
            aBook.PublishDate = 2025;
            aBook.Publisher = "Undetermined";
            aBook.ImagePath = resourcePath + "cover-image.png";

            DocumentLayout layout = new DocumentLayout(resourcePath + "nested-data-example.dlex");
            LayoutData layoutData = new LayoutData();
            layoutData.Add("Title", aBook.Title);
            layoutData.Add("Author", aBook.Author);
            layoutData.Add("PublishDate", aBook.PublishDate);
            layoutData.Add("Publisher", aBook.Publisher);
            layoutData.Add("ImagePath", aBook.ImagePath);

            aBook.Chapters = new List<Chapter>();
            aBook.Chapters.Add(new Chapter("Introduction", "An introduction."));


            for (int i = 1; i < 15; i++)
                aBook.Chapters.Add(new Chapter("Chapter " + i, "The summary of chapter " + i + "\n" + TextGenerator.GenerateShort()));


            layoutData.Add("Chapters", aBook.Chapters);

            Document doc = layout.Layout(layoutData);
            doc.Draw(outputPath + "reportwriter-nested-object.pdf");
        }

        public static void UseJson(string resourcePath, string outputPath)
        {
            DocumentLayout layout = new DocumentLayout(resourcePath + "nested-data-example.dlex");
            string json = File.ReadAllText(resourcePath + "nested-data-example.json");
            LayoutData layoutData = new LayoutData(JsonSerializer.Deserialize<Book>(json));
            Document doc = layout.Layout(layoutData);
            doc.Draw(outputPath + "reportwriter-json-nested-object.pdf");
        }
    }
}
