using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ChapterExamples.Chapters.ChapterTen
{
    public class SimpleLegendExample
    {
        public static void Create(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            float hght = doc.Pages[0].Dimensions.Height - doc.Pages[0].Dimensions.TopMargin * 2;
            float wdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.RightMargin * 2;

            Chart chart = new Chart(0, 0, wdth, hght);
            chart.BackgroundColor = RgbColor.LightBlue;

            chart.HeaderTitles.Add(new Title("Acme Corporation Item Report"));
            chart.HeaderTitles.Add(new Title("For Calendar Year 2021"));
            chart.HeaderTitles[1].FontSize = 10;
            chart.FooterTitles.Add(new Title("Copyright 2024"));
            chart.FooterTitles[0].FontSize = 8;

            AddPlot(chart, wdth, hght);
            CustomizeLegend(chart, (PieSeries)chart.PrimaryPlotArea.Series[0]);

            doc.Pages[0].Elements.Add(chart);


            doc.Draw(outputPath + "simple-chart-legend-out.pdf");
        }

        private static void CustomizeLegend(Chart chart, PieSeries series)
        {
            chart.Legends.Placement = LegendPlacement.BottomLeft;
            chart.Legends[0].LegendLabelList[0].Text += " Value";
            chart.Legends[0].LegendLabelList[1].FontSize = 24;
        }

        private static void AddPlot(Chart chart, float wdth, float hght)
        {

            chart.PrimaryPlotArea.BackgroundColor = RgbColor.Tan;

            chart.PrimaryPlotArea.TopTitles.Add(new Title("The Plot Area Top"));
            chart.PrimaryPlotArea.BottomTitles.Add(new Title("The Plot Area Bottom"));


            PieSeries pieSeries = new PieSeries();
            ScalarDataLabel dataLabel = new ScalarDataLabel(true, false, false);
            pieSeries.DataLabel = dataLabel;

            PieSeriesElement pe1 = new(10, "A", RgbColor.Navy);
            PieSeriesElement pe2 = new(20, "B", RgbColor.Red);

            pieSeries.Elements.Add(pe1);
            pieSeries.Elements.Add(pe2);

            chart.PrimaryPlotArea.Series.Add(pieSeries);
                       
        }
    }
}
