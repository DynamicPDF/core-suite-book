using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterFive
{
    public class LinesExample
    {
        public static void Create(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            Line myLine = new(150, 0, 150, 300);
            myLine.Color = RgbColor.Navy;
            myLine.Width = 4;
            myLine.Cap = LineCap.Butt;

            Line myLine2 = new(0, 0, 300, 0);
            myLine2.Color = RgbColor.Red;
            myLine2.Width = 10;
            myLine2.Cap = LineCap.Round;

            for (int i = 1; i < 20; i++)
            {
                Line aLine = new(0, 0, 200 + i * 30, 200);

                if (i % 2 == 0)
                {
                    aLine.Color = RgbColor.Green;
                    aLine.Style = LineStyle.DashSmall;
                } else
                {
                    aLine.Color = RgbColor.Orange;
                    aLine.Style = LineStyle.Dots;
                }
                
                aLine.Width = 2;
                
                doc.Pages[0].Elements.Add(aLine);
            }

            doc.Pages[0].Elements.Add(myLine);
            doc.Pages[0].Elements.Add(myLine2);

            AddGridLines.AddBackgroundColor(doc);

            doc.Draw(outputPath);
        }

        public static void LineStyles(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            Line myLine = new(0, 50, 150, 50);
            myLine.Color = RgbColor.Navy;
            myLine.Width = 4;
            myLine.Style = LineStyle.Dash;

            Line myLine2 = new(0, 100, 150, 100);
            myLine2.Color = RgbColor.Red;
            myLine2.Width = 4;
            myLine2.Style = LineStyle.DashLarge;

            Line myLine3 = new(0, 150, 150, 150);
            myLine3.Color = RgbColor.DarkGreen;
            myLine3.Width = 4;
            myLine3.Style = LineStyle.DashSmall;

            Line myLine4 = new(0, 200, 150, 200);
            myLine4.Color = RgbColor.Orange;
            myLine4.Width = 4;
            myLine4.Style = LineStyle.Solid;

            Line myLine5 = new(0, 250, 150, 250);
            myLine5.Color = RgbColor.Olive;
            myLine5.Width = 4;
            myLine5.Style = LineStyle.Dots;

            doc.Pages[0].Elements.Add(myLine);
            doc.Pages[0].Elements.Add(myLine2);
            doc.Pages[0].Elements.Add(myLine3);
            doc.Pages[0].Elements.Add(myLine4);
            doc.Pages[0].Elements.Add(myLine5);

            AddGridLines.AddBackgroundColor(doc);
            doc.Draw(outputPath);
        }
    }
}
