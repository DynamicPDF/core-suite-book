using ceTe.DynamicPDF;
using ChapterExamples.Utility;
using ceTe.DynamicPDF.PageElements.Html;

namespace ChapterExamples.Chapters.ChapterFour
{
    public class HtmlAreaExample
    {
        public static void Create(string outputPath)
        {
            Document doc = new();
           
            string txt1 = TextGenerator.GenerateHtmlWithImg();

            HtmlArea htmlArea = new(txt1, 0, 0, 512, 692);

            do
            {
                Page page = new Page(PageSize.Letter);
                page.Elements.Add(htmlArea);
                doc.Pages.Add(page);
                htmlArea = htmlArea.GetOverflowHtmlArea();
            } while (htmlArea != null);


            AddGridLines.AddBackgroundColor(doc);
            AddGridLines.AddMargins(doc.Pages[0]);

            doc.Draw(outputPath);
        }
    }
}
