using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterTwentySix
{
    public class DocumentImportPageExample
    {

        public static void Create(string resourcePath, string outputPath)
        {
            AddSingleImportedPage(resourcePath, outputPath);
        }

        public static void AddSingleImportedPage(string resourcePath, string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));
            Label lbl = new("First Page", 0, 0, 200, 0);
            doc.Pages[0].Elements.Add(lbl);

            ImportedPage page = new ImportedPage(resourcePath + "doc4.pdf", 1);
            PageDimensions dimensions = new PageDimensions(PageSize.Letter, PageOrientation.Portrait);
            page.Dimensions = dimensions;

            ImportedPage page2 = new ImportedPage(resourcePath + "doc2.pdf", 3, 150);
            Label lbl2 = new("Margin 150", 0, 0, 200, 0);
            lbl2.TextColor = RgbColor.Red;
            lbl2.FontSize = 32;
            page2.Elements.Add(lbl2);
            doc.Pages.Add(page);
            doc.Pages.Add(page2);
            doc.Draw(outputPath + "document-imported-page.pdf");
        }


    }
}
