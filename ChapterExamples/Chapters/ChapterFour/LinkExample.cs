
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterFour
{
    public class LinkExample
    {
        public static void Create(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            string text = "A link to DynamicPDF API Website.";
            Label label = new(text, 50, 50, 400, 20);
            label.TextColor = RgbColor.Navy;
            label.Underline = true;

            UrlAction action = new UrlAction("https://dpdf.io");
            Link link = new (50, 50, label.Width, 20, action);

            doc.Pages[0].Elements.Add(label);
            doc.Pages[0].Elements.Add(link);

            // Save the PDF
            doc.Draw(outputPath);
        }
    }
}
