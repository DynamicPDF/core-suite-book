using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterFive
{
    public class CircleExample
    {
        public static void Create(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));


            Circle myCircle = new(doc.Pages[0].Dimensions.Width / 2, doc.Pages[0].Dimensions.Height / 2, 25f);
            myCircle.IgnoreMargins = true;
            myCircle.BorderStyle = LineStyle.Dash;
            myCircle.BorderColor = RgbColor.Red;
            myCircle.BorderWidth = 2f;
            myCircle.FillColor = RgbColor.PowderBlue;

            Circle myCircle1 = new(200, 400, 50f);
            myCircle1.IgnoreMargins = true;
            myCircle1.BorderStyle = LineStyle.Dots;
            myCircle1.BorderColor = RgbColor.Navy;
            myCircle1.BorderWidth = 5f;
            myCircle1.FillColor = RgbColor.LightGreen;

            Circle myCircle2 = new(150, 150, 60f);
            myCircle2.IgnoreMargins = true;
            myCircle2.BorderColor = RgbColor.Teal;
            myCircle2.BorderWidth = 1f;
            myCircle2.FillColor = RgbColor.Tan;


            doc.Pages[0].Elements.Add(myCircle);
            doc.Pages[0].Elements.Add(myCircle1);
            doc.Pages[0].Elements.Add(myCircle2);

            AddGridLines.AddBackgroundColor(doc);

            doc.Draw(outputPath);
        }
    }
}
