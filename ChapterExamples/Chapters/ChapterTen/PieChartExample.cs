using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ChapterExamples.Chapters.ChapterTen
{
    public class PieChartExample
    {
        public static void Create(string outputPath)
        {
            AutoLayoutExample(outputPath);
            Simplest(outputPath);
        }

        public static void AutoLayoutExample(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter, PageOrientation.Landscape));

            float hght = doc.Pages[0].Dimensions.Height - doc.Pages[0].Dimensions.TopMargin * 2;
            float wdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.RightMargin * 2;

            Chart chart = new Chart(0, 0, wdth, hght);
            chart.BackgroundColor = RgbColor.LightBlue;

            PlotArea plotArea = chart.PrimaryPlotArea;
            plotArea.BackgroundColor = RgbColor.Tan;


            PieSeries pieSeries = new PieSeries();
            ScalarDataLabel dataLbl = new ScalarDataLabel(true, false, false);
            pieSeries.BorderColor = RgbColor.Red;
            pieSeries.BorderWidth = 1;
            pieSeries.DataLabel = dataLbl;

            plotArea.Series.Add(pieSeries);
            PieSeriesElement pe1 = new(10, "A", RgbColor.LightCoral);
            PieSeriesElement pe2 = new(20, "B", RgbColor.LightBlue);
            PieSeriesElement pe3 = new(13, "C", RgbColor.LightGoldenRodYellow);
            PieSeriesElement pe4 = new(17, "D", RgbColor.LightGreen);

            pieSeries.Elements.Add(pe1);
            pieSeries.Elements.Add(pe2);
            pieSeries.Elements.Add(pe3);
            pieSeries.Elements.Add(pe4);

            Legend legend1 = chart.Legends[0];
            legend1.BackgroundColor = RgbColor.LightGrey;
            legend1.BorderWidth = 1;
            legend1.BorderColor = RgbColor.Red;

            chart.Legends.Placement = LegendPlacement.BottomLeft;

            doc.Pages[0].Elements.Add(chart);
            doc.Draw(outputPath + "autolayout-pie-chart-out.pdf");
        }


        public static void Simplest(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter, PageOrientation.Landscape));

           
            Chart chart = new Chart(0, 0, 500, 500);

            PieSeries pieSeries = new PieSeries();
            ScalarDataLabel dataLbl = new ScalarDataLabel(true, false, false);
            pieSeries.DataLabel = dataLbl;

            chart.PrimaryPlotArea.Series.Add(pieSeries);

            PieSeriesElement pe1 = new(10, "A", RgbColor.Red);
            PieSeriesElement pe2 = new(20, "B", RgbColor.Blue);
            PieSeriesElement pe3 = new(13, "C", RgbColor.Yellow);
            PieSeriesElement pe4 = new(17, "D", RgbColor.Green);

            pieSeries.Elements.Add(pe1);
            pieSeries.Elements.Add(pe2);
            pieSeries.Elements.Add(pe3);
            pieSeries.Elements.Add(pe4);

            doc.Pages[0].Elements.Add(chart);


            doc.Draw(outputPath + "simplest-pie-chart-out.pdf");
        }

    }
}
