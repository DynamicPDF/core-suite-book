

using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterSeven
{
    public class ContentAreaExample
    {
        public static void Create(string filePath, string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            ContentArea contentArea = new(200, 200, 200, 200);

            doc.Pages[0].Elements.Add(contentArea);

            DrawOutline(contentArea);

            Label lbl3 = new("A label", 0, 100, 100, 0);
            lbl3.TextColor = RgbColor.Navy;
            contentArea.Add(lbl3);

            Image img = new(filePath, 0, 0, .25f);
            contentArea.Add(img);

            doc.Draw(outputPath);
        }

        public static void DrawOutline(ContentArea contentArea)
        {
            Rectangle rec = new(0, 0, contentArea.Width, contentArea.Height, RgbColor.Navy, RgbColor.LightGrey, 1f, LineStyle.DashLarge);
            contentArea.Add(rec);
        }
    }
}
