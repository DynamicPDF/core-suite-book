using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterFour
{
    public class LabelExample
    {
        public static void Create(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));
            Label lbl = new("DynamicPDF Core Suite", 50, 100, 500, 50, Font.Courier, 32F, TextAlign.Center, RgbColor.Red);
            lbl.Angle = 45;
            lbl.TextOutlineColor = RgbColor.Black;
            lbl.TextOutlineWidth = 1F;
            doc.Pages[0].Elements.Add(lbl);
            
            AddGridLines.AddBackgroundColor(doc);
            AddGridLines.AddMargins(doc.Pages[0]);

            doc.Draw(outputPath);
        }
    }
}
