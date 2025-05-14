using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterSeven
{
    public class AreaGroupExample
    {
        public static void Create(string filePath, string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            AreaGroup group = new(400, 400);

            doc.Pages[0].Elements.Add(group);

            DrawOutline(group);

            Label lbl3 = new("A label", 0, 100, 100, 0);
            lbl3.TextColor = RgbColor.Navy;
            group.Add(lbl3);

            Image img = new(filePath, 0, 0, .25f);
            group.Add(img);

            doc.Draw(outputPath);
        }

        public static void DrawOutline(AreaGroup areaGroup)
        {
            Rectangle rec = new(0, 0, areaGroup.Width, areaGroup.Height, RgbColor.Navy, RgbColor.LightGrey, 1f, LineStyle.DashLarge);
            areaGroup.Add(rec);
        }
    }
}
