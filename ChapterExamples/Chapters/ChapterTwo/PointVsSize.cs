using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapterExamples.Chapters.ChapterTwo
{
    public class PointVsSize
    {
        public static void Create(string resourcePath, string outputPath)
        {
            Document myDoc = new();
            Page myPg = new();

            ceTe.DynamicPDF.PageElements.Circle c2 = new(0, 0, 8);
            c2.FillColor = RgbColor.Blue;
            myPg.Elements.Add(c2);

            ceTe.DynamicPDF.PageElements.Circle c3 = new(myPg.Dimensions.Width - myPg.Dimensions.RightMargin, 0, 8);
            c3.FillColor = RgbColor.Red;
            myPg.Elements.Add(c3);

            ceTe.DynamicPDF.PageElements.Circle c4 = new((myPg.Dimensions.Width - myPg.Dimensions.RightMargin - myPg.Dimensions.LeftMargin)/2, (myPg.Dimensions.Height - myPg.Dimensions.BottomMargin - myPg.Dimensions.TopMargin)/2, 8);

            c4.FillColor = RgbColor.Green;
            myPg.Elements.Add(c4);

            LayoutGrid lg = new();
            lg.Type = LayoutGrid.GridType.Standard;
            lg.ShowTitle = false;
            lg.IgnoreMargins = true;
            myPg.Elements.Add(lg);
            
            LayoutGrid lg1 = new();
            lg1.Type = LayoutGrid.GridType.Standard;
            lg1.ShowTitle = false;
            myPg.Elements.Add(lg1);

            Label myLabel3 = new("(" + c4.X + "," + c4.Y + ")", c4.X + 20, c4.Y + 20, 100, 50);
            myLabel3.TextColor = RgbColor.Red;

            myPg.Elements.Add(myLabel3);

            Label myLabel = new(myPg.Dimensions.Width + " page width", myPg.Dimensions.Width - 140, -40, 100, 50);
            myLabel.TextColor = RgbColor.Red;

            myPg.Elements.Add(myLabel);

            Label myLabel2 = new(myPg.Dimensions.Height + " page height", -18, myPg.Dimensions.Height - myPg.Dimensions.TopMargin - myPg.Dimensions.BottomMargin + 18, 100, 50);
            myLabel2.TextColor = RgbColor.Red;
            myPg.Elements.Add(myLabel2);


            myPg.Elements.Add(new Line(myPg.Dimensions.RightMargin * -1, myPg.Dimensions.TopMargin * -1 +1, myPg.Dimensions.RightMargin * -1, myPg.Dimensions.Height - myPg.Dimensions.BottomMargin, 2, RgbColor.Red, LineStyle.DashLarge));

            //x axis
            myPg.Elements.Add(new Line(0-myPg.Dimensions.RightMargin, myPg.Dimensions.TopMargin*-1 +1, myPg.Dimensions.Width, myPg.Dimensions.TopMargin * -1, 2,
           RgbColor.Red, LineStyle.DashLarge));

            myDoc.Pages.Add(myPg);
            myDoc.Draw(outputPath + "ch2-PointVsSize-out.pdf");
        }
    }
}
