
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ChapterExamples.Chapters.ChapterTen
{
    public class AutoLayoutExampleChart
    {
        public static void Create(string outputPath)
        {
            AutoLayout autoLayout = new AutoLayout(PageSize.Letter, PageOrientation.Portrait, 50);
            
            Chart chart = autoLayout.AddChart(300, 350);
            PieSeries pieSeries = new PieSeries();
            ScalarDataLabel dataLabel = new ScalarDataLabel(true, false, false);
            pieSeries.DataLabel = dataLabel;
            PieSeriesElement pe1 = new(10, "A", RgbColor.Navy);
            PieSeriesElement pe2 = new(20, "B", RgbColor.Red);
            pieSeries.Elements.Add(pe1);
            pieSeries.Elements.Add(pe2);
            chart.PrimaryPlotArea.Series.Add(pieSeries);

            Document document = autoLayout.GetDocument();
            document.Draw(outputPath);

        }
    }
}
