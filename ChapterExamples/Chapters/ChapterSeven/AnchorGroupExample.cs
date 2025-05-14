
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterSeven
{
    public class AnchorGroupExample
    {

        public static void Create(string filePath, string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));
            
            AnchorGroup aGrp = new(200, 200, Align.Left, VAlign.Top);
            aGrp.AnchorTo = AnchorTo.Margins;
            
            AnchorGroupExample.drawOutline(aGrp);

            Circle myCircle = new(50, 50, 5, RgbColor.FireBrick, RgbColor.Tan, 2, LineStyle.Dash);
            aGrp.Add(myCircle);

            Label lbl = new("Align Left", 50, 75, 100,0);
            lbl.TextColor = RgbColor.Navy;
            aGrp.Add(lbl);
                       
            doc.Pages[0].Elements.Add(aGrp);
                        
            AnchorGroup aGrp2 = new(150, 200, Align.Right, VAlign.Bottom);
            aGrp2.AnchorTo = AnchorTo.Margins;

            AnchorGroupExample.drawOutline(aGrp2);

            Label lbl2 = new("Align Right", 30, 60, 100, 0);
            lbl2.TextColor = RgbColor.Navy;
            aGrp2.Add(lbl2);

            Image img = new(filePath, 0, 0, .25f);
            aGrp2.Add(img);

           


            doc.Pages[0].Elements.Add(aGrp2);


            AnchorGroup aGrp3 = new(200, 90, Align.Left, VAlign.Center);
            aGrp3.AnchorTo = AnchorTo.Edges;
            AnchorGroupExample.drawOutline(aGrp3);

            Label lbl3 = new("Align Left", 5, 5, 100, 0);
            lbl3.TextColor = RgbColor.Navy;
            aGrp3.Add(lbl3);

            

            doc.Pages[0].Elements.Add(aGrp3);

            LayoutGrid layGrd = new();
            layGrd.ShowTitle = false;
            doc.Pages[0].Elements.Add(layGrd);

            doc.Draw(outputPath);

        }

        public static void drawOutline(AnchorGroup anchorGroup)
        {
            Rectangle rec = new(0, 0, anchorGroup.Width, anchorGroup.Height, RgbColor.Navy, RgbColor.LightGrey, 1f, LineStyle.DashLarge);
            anchorGroup.Add(rec);
        }
    }
}
