
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ChapterExamples.Chapters.ChapterTen
{
    public class MultiplePlotAreas
    {

        public static void Create(string outputPath)
        {
            AutoLayoutExample(outputPath);
            ManualLayoutExample(outputPath);
        }

        public static void AutoLayoutExample(string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));

            float hght = doc.Pages[0].Dimensions.Height - doc.Pages[0].Dimensions.TopMargin * 2;
            float wdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.RightMargin * 2;

            Chart chart = new Chart(0, 0, wdth, hght);
            chart.BackgroundColor = RgbColor.Teal;

            Legend legend = chart.Legends.Add();
            legend.BorderColor = RgbColor.Black;
            legend.BackgroundColor = RgbColor.Tan;
            legend.BorderStyle = LineStyle.DashSmall;

            Legend legend2 = chart.Legends.Add();
            legend2.BackgroundColor = RgbColor.LightBlue;
            legend2.BorderColor = RgbColor.Black;
            legend2.BorderStyle = LineStyle.Solid;

            PlotArea plotArea = chart.PlotAreas.Add(0, 0, 100, 100);
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
            pe1.Legend = legend;

            pieSeries.Elements.Add(pe1);
            pieSeries.Elements.Add(pe2);
            pieSeries.Elements.Add(pe3);
            pieSeries.Elements.Add(pe4);

            
            PlotArea plotArea2 = chart.PlotAreas.Add(0, 200, 100, 100);
            plotArea2.BackgroundColor = RgbColor.LightGrey;

            IndexedBarSeries barSeries = new IndexedBarSeries("A");
            barSeries.Values.Add(new float[] { 4, 5, 8, 2 });
            barSeries.Legend = legend2;
            IndexedBarSeries barSeries2 = new IndexedBarSeries("B");
            barSeries2.Legend = legend2;
            barSeries2.Values.Add(new float[] { 1, 9, 8, 5 });
            IndexedBarSeries barSeries3 = new IndexedBarSeries("C");
            barSeries3.Legend = legend2;
            barSeries3.Values.Add(new float[] { 2, 4, 8, 3 });

            plotArea2.Series.Add(barSeries);
            plotArea2.Series.Add(barSeries2);
            plotArea2.Series.Add(barSeries3);

            barSeries.YAxis.Labels.Add(new IndexedYAxisLabel("P1", 0));
            barSeries.YAxis.Labels.Add(new IndexedYAxisLabel("P2", 1));
            barSeries.YAxis.Labels.Add(new IndexedYAxisLabel("P3", 2));
            barSeries.YAxis.Labels.Add(new IndexedYAxisLabel("P4", 3));

            

            doc.Pages[0].Elements.Add(chart);
            doc.Draw(outputPath + "multiplot-auto-chart-out.pdf");

        }

        public static void ManualLayoutExample(string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));

            float hght = doc.Pages[0].Dimensions.Height - doc.Pages[0].Dimensions.TopMargin * 2;
            float wdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.RightMargin * 2;

            Chart chart = new Chart(0, 0, wdth, hght);
            chart.BackgroundColor = RgbColor.Teal;

            Legend legend = chart.Legends.Add(50, 150, 50, 100);
            legend.BorderColor = RgbColor.Black;
            legend.BackgroundColor = RgbColor.Tan;
            legend.BorderStyle = LineStyle.DashSmall;

            Legend legend2 = chart.Legends.Add(50, 400, 50, 75);
            legend2.BackgroundColor = RgbColor.LightBlue;
            legend2.BorderColor = RgbColor.Black;
            legend2.BorderStyle = LineStyle.Solid;

            PlotArea plotArea = chart.PlotAreas.Add(150, 50, 300, 250);
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
            pe1.Legend = legend;

            pieSeries.Elements.Add(pe1);
            pieSeries.Elements.Add(pe2);
            pieSeries.Elements.Add(pe3);
            pieSeries.Elements.Add(pe4);


            PlotArea plotArea2 = chart.PlotAreas.Add(150, 350, 300, 250);
            plotArea2.BackgroundColor = RgbColor.LightGrey;

            IndexedBarSeries barSeries = new IndexedBarSeries("A");
            barSeries.Values.Add(new float[] { 4, 5, 8, 2 });
            barSeries.Legend = legend2;
            IndexedBarSeries barSeries2 = new IndexedBarSeries("B");
            barSeries2.Legend = legend2;
            barSeries2.Values.Add(new float[] { 1, 9, 8, 5 });
            IndexedBarSeries barSeries3 = new IndexedBarSeries("C");
            barSeries3.Legend = legend2;
            barSeries3.Values.Add(new float[] { 2, 4, 8, 3 });

            plotArea2.Series.Add(barSeries);
            plotArea2.Series.Add(barSeries2);
            plotArea2.Series.Add(barSeries3);

            barSeries.YAxis.Labels.Add(new IndexedYAxisLabel("P1", 0));
            barSeries.YAxis.Labels.Add(new IndexedYAxisLabel("P2", 1));
            barSeries.YAxis.Labels.Add(new IndexedYAxisLabel("P3", 2));
            barSeries.YAxis.Labels.Add(new IndexedYAxisLabel("P4", 3));

            chart.AutoLayout = false;


            doc.Pages[0].Elements.Add(chart);
            doc.Draw(outputPath + "multiplot-manual-chart-out.pdf");

        }
    }
}
