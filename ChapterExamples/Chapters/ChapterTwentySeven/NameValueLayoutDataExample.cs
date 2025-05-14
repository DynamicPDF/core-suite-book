using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ChapterExamples.Chapters.ChapterTwentySeven.Data;

namespace ChapterExamples.Chapters.ChapterTwentySeven
{
    class NameValueLayoutDataExample
    {
        public static void CreateReport(string resourcePath, string outputPath)
        {
            UseObject(resourcePath, outputPath);
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
            NameValueLayoutData layoutData = new NameValueLayoutData();
            layoutData.Add("Title", aBook.Title);
            layoutData.Add("Author", aBook.Author);
            layoutData.Add("PublishDate", aBook.PublishDate);
            layoutData.Add("Publisher", aBook.Publisher);
            layoutData.Add("ImagePath", aBook.ImagePath);

            Document doc = layout.Layout(layoutData);
            doc.Draw(outputPath + "reportwriter-simple-object.pdf");
        }

    }
}
