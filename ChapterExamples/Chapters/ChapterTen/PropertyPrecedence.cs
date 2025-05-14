using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ChapterExamples.Chapters.ChapterTen
{
    public class PropertyPrecedence
    {
        public static void Create(string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));

            Chart chart = new Chart(0, 0, 400, 230);
            chart.Font = Font.CourierBold;
            
            chart.HeaderTitles.Add(new Title("Chart Title"));

            IndexedBarSeries barSeries = new IndexedBarSeries("A");
            barSeries.Values.Add(new float[] { 4, 5, 8, 2 });
            IndexedBarSeries barSeries2 = new IndexedBarSeries("B");
            barSeries2.Values.Add(new float[] { 1, 9, 8, 5 });
            IndexedBarSeries barSeries3 = new IndexedBarSeries("C");
            barSeries3.Values.Add(new float[] { 2, 4, 8, 3 });

            chart.PrimaryPlotArea.Series.Add(barSeries);
            chart.PrimaryPlotArea.Series.Add(barSeries2);
            chart.PrimaryPlotArea.Series.Add(barSeries3);

            barSeries2.LegendLabel.Font = Font.ZapfDingbats;
            
            barSeries.YAxis.Labels.Add(new IndexedYAxisLabel("P1", 0));
            barSeries.YAxis.Labels.Add(new IndexedYAxisLabel("P2", 1));

            barSeries.YAxis.Labels[1].Font = Font.ZapfDingbats;

            barSeries.YAxis.Labels.Add(new IndexedYAxisLabel("P3", 2));
            barSeries.YAxis.Labels.Add(new IndexedYAxisLabel("P4", 3));

            doc.Pages[0].Elements.Add(chart);
            doc.Draw(outputPath + "property-precedence-chart-out.pdf");
        }
    }
}
