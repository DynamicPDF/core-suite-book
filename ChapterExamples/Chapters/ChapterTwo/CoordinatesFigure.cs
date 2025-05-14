using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterTwo
{
    public class CoordinatesFigure
    {
        public static void Create(string resourcePath, string outputPath)
        {
            Document myDoc = new();
            Page myPg = new();
            myDoc.Pages.Add(myPg);
            float centerX = (myPg.Dimensions.Width - myPg.Dimensions.LeftMargin - myPg.Dimensions.RightMargin) / 2;
            float centerY = (myPg.Dimensions.Height - myPg.Dimensions.TopMargin - myPg.Dimensions.BottomMargin) / 2;
            AddLines(myPg, centerX, centerY);
            AddLabels(myPg, centerX, centerY);
            AddCenter(myPg, centerX, centerY);
            AddMargins(myPg);
            AddCircles(myPg, centerX, centerY);
            myDoc.Draw(outputPath + "ch2-CoordinatesFigure-out.pdf");
        }

        private static void AddMargins(Page pg)
        {
            Rectangle rec = new Rectangle(50, 50, pg.Dimensions.Width - pg.Dimensions.LeftMargin - pg.Dimensions.RightMargin - 100, pg.Dimensions.Height - pg.Dimensions.TopMargin - pg.Dimensions.BottomMargin - 100);
            rec.BorderColor = RgbColor.LightSlateGray;
            rec.BorderStyle = LineStyle.DashSmall;
            pg.Elements.Add(rec);
        }

        private static void AddLines(Page pg, float centerX, float centerY)
        {
            //y axis
            pg.Elements.Add(new Line(0, 0, 0, pg.Dimensions.Height-pg.Dimensions.BottomMargin - pg.Dimensions.TopMargin, 2, RgbColor.Blue, LineStyle.DashLarge));

            //x axis
            pg.Elements.Add(new Line(0, 0, pg.Dimensions.Width - pg.Dimensions.RightMargin - pg.Dimensions.LeftMargin, 0, 2,
           RgbColor.Blue, LineStyle.DashLarge));

    
            pg.Elements.Add(new Line(0, pg.Dimensions.Height - pg.Dimensions.BottomMargin - pg.Dimensions.TopMargin, pg.Dimensions.Width - pg.Dimensions.RightMargin - pg.Dimensions.LeftMargin, pg.Dimensions.Height - pg.Dimensions.BottomMargin - pg.Dimensions.TopMargin, 1, RgbColor.Gray, LineStyle.DashSmall));

            pg.Elements.Add(new Line(pg.Dimensions.Width - pg.Dimensions.RightMargin - pg.Dimensions.LeftMargin, 0, pg.Dimensions.Width - pg.Dimensions.RightMargin - pg.Dimensions.LeftMargin, pg.Dimensions.Height - pg.Dimensions.BottomMargin - pg.Dimensions.TopMargin, 1, RgbColor.Gray, LineStyle.DashSmall));


        }

        private static void AddCenter(Page pg, float centerX, float centerY)
        {
            pg.Elements.Add(new Line(centerX, 0, centerX, centerY, 2, RgbColor.LightBlue, LineStyle.DashSmall));
            pg.Elements.Add(new Line(0, centerY, centerX, centerY, 2, RgbColor.LightBlue, LineStyle.DashSmall));

            Circle circle = new(centerX, centerY, 2);
            circle.FillColor = RgbColor.Blue;
            pg.Elements.Add(circle);

        }

        private static void AddCircles(Page pg, float centerX, float centerY)
        {
            Circle c2 = new(centerX, 50, 2);
            c2.FillColor = RgbColor.Blue;
            pg.Elements.Add(c2);

            Label lb5 = new Label("(306,50)", centerX + 5, 25, 100, 100);
            lb5.TextColor = RgbColor.DarkGray;
            pg.Elements.Add(lb5);

            Circle c3 = new(50, centerY, 2);
            c3.FillColor = RgbColor.Blue;
            pg.Elements.Add(c3);

            Label lb6 = new Label("(50,396)", 55, centerY + 10, 100, 100);
            lb6.TextColor = RgbColor.DarkGray;
            pg.Elements.Add(lb6);
        }

        private static void AddLabels(Page pg, float centerX, float centerY)
        {
            Label lb = new Label("0,0", -25, -10, 100, 100);
            lb.TextColor = RgbColor.Blue;

            Label lb2 = new Label("792", -10, pg.Dimensions.Height - pg.Dimensions.TopMargin - pg.Dimensions.BottomMargin + 10, 100, 100);
            lb2.TextColor = RgbColor.Blue;

            Label lb3 = new Label("612", pg.Dimensions.Width + 10 - pg.Dimensions.RightMargin - pg.Dimensions.LeftMargin, -5, 100, 100);
            lb3.TextColor = RgbColor.Blue;

            Label lb4 = new Label("306,396", centerX + 10 , centerY-5, 100, 100);
            lb4.TextColor = RgbColor.Blue;

            Label lb5 = new Label("Margins", 50, 15, 100, 100);
            lb5.TextColor = RgbColor.DarkGray;


            pg.Elements.Add(lb);
            pg.Elements.Add(lb2);
            pg.Elements.Add(lb3);
            pg.Elements.Add(lb4);
            pg.Elements.Add(lb5);
        }


    }
}
