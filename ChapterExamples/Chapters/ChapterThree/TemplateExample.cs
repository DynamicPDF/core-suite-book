using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterThree
{
    public class TemplateExample
    {
        public static void Create(string resourcePath, string outputPath)
        {
            Document doc = new();
            DocumentExampleGenerator.Generate(doc);
            Template tmp = new();

            float hgt = doc.Pages[0].Dimensions.Height;
            float x = -doc.Pages[0].Dimensions.LeftMargin;
            float y = -doc.Pages[0].Dimensions.TopMargin;
            float wdt = doc.Pages[0].Dimensions.Width;

            Rectangle rec = new(x,y, 20, hgt);
            rec.FillColor = RgbColor.Navy;
            rec.BorderColor = RgbColor.Navy;

            Rectangle bkRec = new(x, y, wdt, hgt);
            bkRec.FillColor = RgbColor.LightSkyBlue;
            bkRec.BorderColor = RgbColor.LightSkyBlue;

            Image img = new(resourcePath + "logo.png", x+10, y+5, .3F);

            Label lbl = new("DRAFT", 125, 300, 350, 0);
            lbl.TextColor = RgbColor.Red;
            lbl.TextOutlineColor = RgbColor.Black;
            lbl.FontSize = 90;

            PageNumberingLabel pgNm = new PageNumberingLabel("%%CP%% of %%TP%%", 0, hgt+(y *2), wdt+(x*2), 50);
            pgNm.Align = TextAlign.Center;

            tmp.Elements.Add(bkRec);
            tmp.Elements.Add(rec);
            tmp.Elements.Add(img);
            tmp.Elements.Add(lbl);
            tmp.Elements.Add(pgNm);
            doc.Template = tmp;
            

            doc.Draw(outputPath);
        }
    }
}
