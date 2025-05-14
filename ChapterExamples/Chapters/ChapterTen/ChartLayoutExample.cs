
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ChapterExamples.Chapters.ChapterTen
{
    public class ChartLayoutExample
    {
        public static void Create(string outputPath)
        {
            ManualLayoutExample(outputPath);
            ModifyLayoutExample(outputPath);
        }

        public static void ManualLayoutExample(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter, PageOrientation.Landscape));

            float hght = doc.Pages[0].Dimensions.Height - doc.Pages[0].Dimensions.TopMargin * 2;
            float wdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.RightMargin * 2;

            Chart chart = new Chart(0, 0, wdth, hght);
            chart.BackgroundColor = RgbColor.Teal;
            chart.AutoLayout = false;

            PlotArea plotArea = chart.PlotAreas.Add(100, 100, wdth / 2, hght * .75F);
            plotArea.BackgroundColor = RgbColor.Tan;

            Legend legend1 = chart.Legends.Add(470, 250, 40, 100);
            legend1.BackgroundColor = RgbColor.LightGrey;
            legend1.BorderWidth = 1;
            legend1.BorderColor = RgbColor.Red;

            PieSeries pieSeries = new PieSeries(legend1);
            ScalarDataLabel dataLbl = new ScalarDataLabel(true, false, false);
            pieSeries.BorderColor = RgbColor.Red;
            pieSeries.BorderWidth = 1;
            pieSeries.DataLabel = dataLbl;

            plotArea.Series.Add(pieSeries);

            PieSeriesElement pe1 = new(10, "A ", RgbColor.LightCoral);
            PieSeriesElement pe2 = new(20, "B ", RgbColor.LightBlue);
            PieSeriesElement pe3 = new(13, "C ", RgbColor.LightGoldenRodYellow);
            PieSeriesElement pe4 = new(17, "D ", RgbColor.LightGreen);

            pieSeries.Elements.Add(pe1);
            pieSeries.Elements.Add(pe2);
            pieSeries.Elements.Add(pe3);
            pieSeries.Elements.Add(pe4);

          
            doc.Pages[0].Elements.Add(chart);


            doc.Draw(outputPath + "manual-layout-pie-chart-out.pdf");
        }

        public static void ModifyLayoutExample(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter, PageOrientation.Landscape));

            float hght = doc.Pages[0].Dimensions.Height - doc.Pages[0].Dimensions.TopMargin * 2;
            float wdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.RightMargin * 2;

            Chart chart = new Chart(0, 0, wdth, hght);
            chart.BackgroundColor = RgbColor.Teal;
            

            chart.PrimaryPlotArea.BackgroundColor = RgbColor.Tan;
            

            PieSeries pieSeries = new PieSeries();
            ScalarDataLabel dataLbl = new ScalarDataLabel(true, false, false);
            pieSeries.BorderColor = RgbColor.Red;
            pieSeries.BorderWidth = 1;
            pieSeries.DataLabel = dataLbl;

            chart.PrimaryPlotArea.Series.Add(pieSeries);

            PieSeriesElement pe1 = new(10, "A ", RgbColor.LightCoral);
            PieSeriesElement pe2 = new(20, "B ", RgbColor.LightBlue);
            PieSeriesElement pe3 = new(13, "C ", RgbColor.LightGoldenRodYellow);
            PieSeriesElement pe4 = new(17, "D ", RgbColor.LightGreen);

            pieSeries.Elements.Add(pe1);
            pieSeries.Elements.Add(pe2);
            pieSeries.Elements.Add(pe3);
            pieSeries.Elements.Add(pe4);

            chart.Legends[0].BackgroundColor = RgbColor.LightGrey;
            chart.Legends[0].BorderWidth = 1;
            chart.Legends[0].BorderColor = RgbColor.Red;

            chart.AutoLayout = false;
            chart.Layout();

            chart.PrimaryPlotArea.X = 100;
            chart.PrimaryPlotArea.Y = 100;
            chart.PrimaryPlotArea.Width = wdth / 2;
            chart.PrimaryPlotArea.Height = hght * .75F;

            chart.Legends[0].X = 470;
            chart.Legends[0].Y = 250;
            



            doc.Pages[0].Elements.Add(chart);


            doc.Draw(outputPath + "modify-layout-pie-chart-out.pdf");
        }
    }
}
