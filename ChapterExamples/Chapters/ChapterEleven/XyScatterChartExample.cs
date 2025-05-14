
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ChapterExamples.Chapters.ChapterEleven
{
    public class XyScatterChartExample
    {

        public static void Create(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter, PageOrientation.Landscape));

            float hght = doc.Pages[0].Dimensions.Height - doc.Pages[0].Dimensions.TopMargin * 2;
            float wdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.RightMargin * 2;

            Chart chart = new Chart(0, 0, wdth, hght);

            XYScatterSeries xys = new XYScatterSeries("A");
            xys.Values.Add(110, 55);
            xys.Values.Add(230, 60);
            xys.Values.Add(450, 68);
            xys.Values.Add(590, 73);
            xys.Values.Add(720, 22);
            XYScatterSeries xys2 = new XYScatterSeries("B");
            xys2.Values.Add(380, 24);
            xys2.Values.Add(218, 34);
            xys2.Values.Add(240, 70);
            xys2.Values.Add(355, 45);
            xys2.Values.Add(170, 50);

            chart.PrimaryPlotArea.Series.Add(xys);
            chart.PrimaryPlotArea.Series.Add(xys2);

   
            xys.YAxis.Titles.Add(new Title("Height in Inches"));
            xys.XAxis.Titles.Add(new Title("Width in Inches"));

            doc.Pages[0].Elements.Add(chart);

            doc.Draw(outputPath + "scatter-chart-out.pdf");

        }


    }
}
