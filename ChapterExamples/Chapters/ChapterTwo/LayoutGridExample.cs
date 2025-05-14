using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterTwo
{
    public class LayoutGridExample
    {
        public static void Create(string outputPath)
        {
            Document myDoc = new();
            Page myPg = new();
            myDoc.Pages.Add(myPg);
            float centerX = (myPg.Dimensions.Width - myPg.Dimensions.LeftMargin - myPg.Dimensions.RightMargin) / 2;
            float centerY = (myPg.Dimensions.Height - myPg.Dimensions.TopMargin - myPg.Dimensions.BottomMargin) / 2;
            
            LayoutGrid layGrd = new();
            layGrd.Type = LayoutGrid.GridType.Standard;

            myPg.Elements.Add(layGrd);


            Rectangle rec = new(108, 108, 100, 80);
            rec.FillColor = RgbColor.White;

            myPg.Elements.Add(rec);
        


            Circle circle = new(centerX, centerY, 20,20);
            circle.BorderColor = RgbColor.Red;
            myPg.Elements.Add(circle);

           

            myDoc.Draw(outputPath + "ch2-LayoutGridExample-out.pdf");
        }
    }
}
