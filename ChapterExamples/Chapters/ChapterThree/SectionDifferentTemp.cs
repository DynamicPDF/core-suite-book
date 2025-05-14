using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterThree
{
    public class SectionDifferentTemp
    {
        public static void Create(string resourcePath, string outputPath)
        {
            Document myDoc = new();
            myDoc.Tag = new TagOptions();
            Page myCvrPg = new();
           
            Template tmpCvr = SectionDifferentTemp.CreateCoverTemplate(resourcePath, myCvrPg);

            myDoc.Sections.Begin(NumberingStyle.None, "Worker's Handbook", tmpCvr);
            myDoc.Pages.Add(myCvrPg);

            Template tmpOne = SectionDifferentTemp.CreateTemplate(resourcePath, myCvrPg);
              
            myDoc.Sections.Begin(NumberingStyle.Numeric, "Toolkit - ", tmpOne);
            DocumentExampleGenerator.Generate(myDoc);

            Template tmpTwo = SectionDifferentTemp.CreateTemplateTwo(resourcePath, myCvrPg);

            myDoc.Sections.Begin(NumberingStyle.Numeric, "Worker's Rights - ", tmpTwo);

            DocumentExampleGenerator.Generate(myDoc);

            Template tmpThree = SectionDifferentTemp.CreateDisclaimerTemplate(resourcePath, myCvrPg);

            myDoc.Sections.Begin(NumberingStyle.RomanUpperCase, "Disclaimer - ", tmpThree);

            DocumentExampleGenerator.Generate(myDoc);

            myDoc.Draw(outputPath);
        }

        private static Template CreateTemplate(string resourcePath, Page pg)
        {
            Template tmp = new();
            

            float hgt = pg.Dimensions.Height;
            float x = -pg.Dimensions.LeftMargin;
            float y = -pg.Dimensions.TopMargin;
            float wdt = pg.Dimensions.Width;
            float x2 = pg.Dimensions.Width - pg.Dimensions.LeftMargin * 2;

            Rectangle rec = new(x, y, 20, hgt);
            rec.FillColor = RgbColor.Navy;
            rec.BorderColor = RgbColor.Navy;

            Rectangle bkRec = new(x, y, wdt, hgt);
            bkRec.FillColor = RgbColor.LightSkyBlue;
            bkRec.BorderColor = RgbColor.LightSkyBlue;

            Image img = new(resourcePath + "logo.png", x + 10, y + 5, .3F);
            Image img2 = new(resourcePath + "tools.png", x2-45, y + 5, .3F);

            Label lbl = new("Workers Toolkit", x2 - pg.Dimensions.RightMargin - 120, y, 200, 40);
            lbl.FontSize = 18;
            lbl.TextColor = RgbColor.Red;
            lbl.TextOutlineColor = RgbColor.Black;
            lbl.TextOutlineWidth = .5F;
            lbl.Align = TextAlign.Left;
            lbl.VAlign = VAlign.Bottom;
            tmp.Elements.Add(lbl);

            PageNumberingLabel pgNm = new PageNumberingLabel("%%CP%% of %%TP%%", 0, hgt + (y * 2), wdt + (x * 2), 50);
            pgNm.Align = TextAlign.Center;

            tmp.Elements.Add(bkRec);
            tmp.Elements.Add(rec);
            tmp.Elements.Add(img);
            tmp.Elements.Add(img2);
            tmp.Elements.Add(pgNm);
            tmp.Elements.Add(lbl);

            return tmp;

        }

        private static Template CreateTemplateTwo(string resourcePath, Page pg)
        {
            Template tmp = new();

            float hgt = pg.Dimensions.Height;
            float x = -pg.Dimensions.LeftMargin;
            float y = -pg.Dimensions.TopMargin;
            float wdt = pg.Dimensions.Width;
            float x2 = pg.Dimensions.Width - pg.Dimensions.LeftMargin *2;

            Rectangle rec = new(x, y, 20, hgt);
            rec.FillColor = RgbColor.Navy;
            rec.BorderColor = RgbColor.Navy;

            Rectangle bkRec = new(x, y, wdt, hgt);
            bkRec.FillColor = RgbColor.LightSkyBlue;
            bkRec.BorderColor = RgbColor.LightSkyBlue;

            Image img = new(resourcePath + "logo.png", x + 10, y + 5, .3F);
            Image img2 = new(resourcePath + "carp-img.png", x2, y + 5, .3F);

            Label lbl = new("Worker's Rights", x2 - pg.Dimensions.RightMargin - 120, y, 200, 40);
            lbl.FontSize = 18;
            lbl.TextColor = RgbColor.Red;
            lbl.TextOutlineColor = RgbColor.Black;
            lbl.TextOutlineWidth = .5F;
            lbl.Align = TextAlign.Left;
            lbl.VAlign = VAlign.Bottom;
            tmp.Elements.Add(lbl);

            PageNumberingLabel pgNm = new PageNumberingLabel("%%CP%% of %%TP%%", 0, hgt + (y * 2), wdt + (x * 2), 50);
            pgNm.Align = TextAlign.Center;

            tmp.Elements.Add(bkRec);
            tmp.Elements.Add(rec);
            tmp.Elements.Add(img);
            tmp.Elements.Add(img2);
            tmp.Elements.Add(pgNm);
            tmp.Elements.Add(lbl);

            return tmp;

        }

        private static Template CreateCoverTemplate(string resourcePath, Page pg)
        {
            Template tmp = new();


            float hgt = pg.Dimensions.Height;
            float x = -pg.Dimensions.LeftMargin;
            float y = -pg.Dimensions.TopMargin;
            float wdt = pg.Dimensions.Width;
            float x2 = pg.Dimensions.Width - pg.Dimensions.LeftMargin * 2;

            float centerX = (pg.Dimensions.Width - pg.Dimensions.LeftMargin - pg.Dimensions.RightMargin) / 2;
            float centerY = (pg.Dimensions.Height - pg.Dimensions.TopMargin - pg.Dimensions.BottomMargin) / 2;

            Rectangle rec = new(x, y, 20, hgt);
            rec.FillColor = RgbColor.Navy;
            rec.BorderColor = RgbColor.Navy;

            Rectangle bkRec = new(x, y, wdt, hgt);
            bkRec.FillColor = RgbColor.LightSkyBlue;
            bkRec.BorderColor = RgbColor.LightSkyBlue;

            Image img = new(resourcePath + "logo.png", x + 10, y + 5, .3F);
            Image img2 = new(resourcePath + "carp-img.png", centerX, centerY);
            Image img3 = new(resourcePath + "tools.png", x2, y + 5, .3F);



            Label cvrLabel = new("Worker's Handbook", centerX - 200, centerY-100, 500, 50);
            cvrLabel.TextColor = RgbColor.Red;
            cvrLabel.TextOutlineColor = RgbColor.Black;
            cvrLabel.TextOutlineWidth = .5F;
            cvrLabel.FontSize = 40;

            tmp.Elements.Add(bkRec);
            tmp.Elements.Add(rec);
            tmp.Elements.Add(img);
            tmp.Elements.Add(img2);
            tmp.Elements.Add(cvrLabel);

            return tmp;

        }

        private static Template CreateDisclaimerTemplate(string resourcePath, Page pg)
        {
            Template tmp = new();
           
            float hgt = pg.Dimensions.Height;
            float x = -pg.Dimensions.LeftMargin;
            float y = -pg.Dimensions.TopMargin;
            float wdt = pg.Dimensions.Width;
            float x2 = pg.Dimensions.Width - pg.Dimensions.LeftMargin * 2;

            float centerX = (pg.Dimensions.Width - pg.Dimensions.LeftMargin - pg.Dimensions.RightMargin) / 2;
            float centerY = (pg.Dimensions.Height - pg.Dimensions.TopMargin - pg.Dimensions.BottomMargin) / 2;

            Rectangle rec = new(x, y, 20, hgt);
            rec.FillColor = RgbColor.Navy;
            rec.BorderColor = RgbColor.Navy;

            Image img = new(resourcePath + "logo.png", x + 10, y + 5, .3F);

            Rectangle bkRec = new(x, y, wdt, hgt);
            bkRec.FillColor = RgbColor.LightSkyBlue;
            bkRec.BorderColor = RgbColor.LightSkyBlue;

            Label lbl1 = new("Disclaimer", 0, 0, pg.Dimensions.Width, pg.Dimensions.TopMargin);
            lbl1.IgnoreMargins = true;
            lbl1.FontSize = 18;
            lbl1.Align = TextAlign.Center;
            lbl1.VAlign = VAlign.Center;

            PageNumberingLabel pgNm = new PageNumberingLabel("%%SP(I)%% of %%ST(I)%%", 0, hgt + (y * 2), wdt + (x * 2), 50);
            pgNm.Align = TextAlign.Center;
       

            tmp.Elements.Add(bkRec);
            tmp.Elements.Add(rec);
            tmp.Elements.Add(img);
            tmp.Elements.Add(pgNm);
            tmp.Elements.Add(lbl1);

            return tmp;

        }

    }
}
