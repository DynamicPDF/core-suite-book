
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using System;

namespace ChapterExamples.Chapters.ChapterTwo
{
    public class Alignment
    {
        public static void Create(string outputPath)
        {
            Document myDoc = new();
            Page myPg = new();
            myDoc.Pages.Add(myPg);

            LayoutGrid layGrd = new();
            layGrd.Type = LayoutGrid.GridType.Standard;
            layGrd.ShowTitle = false;

            myPg.Elements.Add(layGrd);

            Label myLabel = new("This is a label.", 100, 100, 400, 0, Font.HelveticaBold, 22, RgbColor.FireBrick);


            myPg.Elements.Add(myLabel);

            //y axis
            myPg.Elements.Add(new Line(0, 100, 100, 100, 2, RgbColor.Red, LineStyle.DashSmall));

            //x axis
            myPg.Elements.Add(new Line(100, 0, 100, 100, 2,
           RgbColor.Red, LineStyle.DashSmall));

            myDoc.Draw(outputPath + "ch2-Alignment-out.pdf");
        }
    }
}
