using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ChapterExamples.Chapters.ChapterTwentySeven.Data;
using System.IO;
using System.Text.Json;

namespace ChapterExamples.Chapters.ChapterTwentySeven
{
    public class SimpleObjectExample
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

            DocumentLayout layout = new DocumentLayout(resourcePath + "simple-data-example.dlex");
            LayoutData layoutData = new LayoutData();
            layoutData.Add("Title", aBook.Title);
            layoutData.Add("Author", aBook.Author);
            layoutData.Add("PublishDate", aBook.PublishDate);
            layoutData.Add("Publisher", aBook.Publisher);
            layoutData.Add("ImagePath", aBook.ImagePath);

            Document doc = layout.Layout(layoutData);
            doc.Draw(outputPath + "reportwriter-simple-object.pdf");
        }

        public static void UseJson(string resourcePath, string outputPath)
        {
            DocumentLayout layout = new DocumentLayout(resourcePath + "simple-data-example.dlex");
            string json = File.ReadAllText(resourcePath + "simple-data-example.json");
            LayoutData layoutData = new LayoutData(JsonSerializer.Deserialize<Book>(json));
            Document doc = layout.Layout(layoutData);
            doc.Draw(outputPath + "reportwriter-json-object.pdf");
        }
    }
}
