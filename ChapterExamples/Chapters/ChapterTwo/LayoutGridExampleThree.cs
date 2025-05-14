

using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterTwo
{
    public class LayoutGridExampleThree
    {
        public static void Create(string resourcePath, string outputPath)
        {
            Document myDoc = new();
            Page myPg = new();
            myDoc.Pages.Add(myPg);
            float centerX = (myPg.Dimensions.Width - myPg.Dimensions.LeftMargin - myPg.Dimensions.RightMargin) / 2;
            float centerY = (myPg.Dimensions.Height - myPg.Dimensions.TopMargin - myPg.Dimensions.BottomMargin) / 2;
            Image image = new Image(resourcePath + "/idea.png", centerX, centerY);

            LayoutGrid layGrd = new();
            layGrd.Type = LayoutGrid.GridType.Standard;
            layGrd.ShowTitle = false;

            myPg.Elements.Add(image);
            myPg.Elements.Add(layGrd);




            myPg.Elements.Add(new Line(centerX, 0, centerX, centerY, 2, RgbColor.Red, LineStyle.DashSmall));
            myPg.Elements.Add(new Line(0, centerY, centerX, centerY, 2, RgbColor.Red, LineStyle.DashSmall));

            Label lbl = new("(" + centerX + "," + centerY + ")", centerX-25, centerY-25, 60, 20);
            lbl.TextColor = RgbColor.Red;

            Rectangle rec = new(lbl.X-2, lbl.Y-2, lbl.Width, lbl.Height);
            rec.FillColor = RgbColor.White;

            myPg.Elements.Add(rec);
            myPg.Elements.Add(lbl);



            Circle circle = new(centerX, centerY, 2);
            circle.FillColor = RgbColor.Red;
            myPg.Elements.Add(circle);

            Circle c2 = new(centerX, 0, 20);
            c2.BorderColor = RgbColor.Red;
            myPg.Elements.Add(c2);

            myPg.Elements.Add(c2);

            Circle c3 = new(0, centerY, 20);
            c3.BorderColor = RgbColor.Red;
            myPg.Elements.Add(c3);

            myPg.Elements.Add(c3);

            myDoc.Draw(outputPath + "ch2-LayoutGridExampleThree-out.pdf");
        }
    }
}
