using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterFive
{
    public class RectangleExample
    {
        public static void Create(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            float wdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.LeftMargin * 2;
            float hgt = doc.Pages[0].Dimensions.Height - doc.Pages[0].Dimensions.TopMargin * 2;

            Rectangle rec = new(0, 0, wdth, hgt);
            rec.BorderColor = RgbColor.Red;

            Rectangle rec2 = new(50,50, 200, 100);
            rec2.BorderColor = RgbColor.Navy;
            rec2.FillColor = RgbColor.Teal;

            Rectangle rec3 = new(50, 250, 400, 100);
            rec3.BorderColor = RgbColor.Orange;
            rec3.FillColor = RgbColor.LightBlue;
            rec3.CornerRadius = 5f;

            Rectangle rec4 = new(250, 450, 150, 50);
            rec4.BorderColor = RgbColor.Brown;
            rec4.FillColor = RgbColor.Bisque;
            rec4.CornerRadius = 2f;
            rec4.Angle = 50f;

            doc.Pages[0].Elements.Add(rec);
            doc.Pages[0].Elements.Add(rec2);
            doc.Pages[0].Elements.Add(rec3);
            doc.Pages[0].Elements.Add(rec4);

            AddGridLines.AddBackgroundColor(doc);
            doc.Draw(outputPath);
        }
    }
}
