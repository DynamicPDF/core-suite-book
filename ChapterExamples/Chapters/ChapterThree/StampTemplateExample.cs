using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterThree
{
    public class StampTemplateExample
    {
        public static void Create(string resourcePath, string outputPath)
        {
            Document doc = new();
            DocumentExampleGenerator.Generate(doc);
            Template tmp = new();

            float hgt = doc.Pages[0].Dimensions.Height/3;
            float wdt = doc.Pages[0].Dimensions.Width;
            float x = -doc.Pages[0].Dimensions.LeftMargin;
            float y = -doc.Pages[0].Dimensions.TopMargin;

            Rectangle rec = new(x, y, 20, hgt);
            rec.FillColor = RgbColor.Navy;
            rec.BorderColor = RgbColor.Navy;

            Rectangle bkRec = new(x, y, wdt, hgt);
            bkRec.FillColor = RgbColor.LightSkyBlue;
            bkRec.BorderColor = RgbColor.LightSkyBlue;

            Label lbl = new("Test.", 200, 300, 200, 0);
            lbl.TextColor = RgbColor.Red;
            lbl.TextOutlineColor = RgbColor.Black;
            lbl.FontSize = 90;

            Image img = new(resourcePath + "logo.png", x + 10, y + 5, .3F);

            tmp.Elements.Add(bkRec);
            tmp.Elements.Add(rec);
            tmp.Elements.Add(img);
            tmp.Elements.Add(lbl);
            doc.StampTemplate = tmp;
                       
            doc.Draw(outputPath);
        }
    }
}
