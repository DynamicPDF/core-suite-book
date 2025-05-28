
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterFive
{
    public class AutoLayoutShapesExample
    {
        public static void Create(string outputPath)
        {
            AutoLayout autoLayout = new AutoLayout(PageSize.Letter, PageOrientation.Portrait, 50);

            Circle myCircle1 = autoLayout.AddCircle(20);
            myCircle1.IgnoreMargins = true;
            myCircle1.BorderStyle = LineStyle.Dots;
            myCircle1.BorderColor = RgbColor.Navy;
            myCircle1.BorderWidth = 5f;
            myCircle1.FillColor = RgbColor.LightGreen;

            Line myLine = autoLayout.AddLine(150, 0, 150, 300);
            myLine.Color = RgbColor.Navy;
            myLine.Width = 4;
            myLine.Cap = LineCap.Butt;

            Rectangle rec2 = autoLayout.AddRectangle(200, 100);
            rec2.BorderColor = RgbColor.Navy;
            rec2.FillColor = RgbColor.Teal;


            Document document = autoLayout.GetDocument();
            document.Draw(outputPath);

        }
    }
}
