
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Html;
using ChapterExamples.Utility;
using System.IO;

namespace ChapterExamples.Chapters.ChapterFour
{
    public class HtmlListExample
    {
        public static void Create(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            string txt1 = File.ReadAllText(FileUtility.GetPath("../ChapterExamples/resources/ch4/list.html"));

            float pgWdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.LeftMargin * 2;

            HtmlArea html = new(txt1, 0, 0, pgWdth, 0);

            html.Height = html.GetRequiredHeight();

            doc.Pages[0].Elements.Add(html);

            AddGridLines.AddBackgroundColor(doc);
            AddGridLines.AddMargins(doc.Pages[0]);

            doc.Draw(outputPath);
        }
    }
}
