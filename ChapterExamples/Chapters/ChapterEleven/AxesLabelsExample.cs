
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ChapterExamples.Chapters.ChapterEleven
{
    public class AxesLabelsExample
    {
        public static void Create(string resourcePath, string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter, PageOrientation.Landscape));

            float hght = doc.Pages[0].Dimensions.Height - doc.Pages[0].Dimensions.TopMargin * 2;
            float wdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.RightMargin * 2;

            Chart chart = new Chart(0, 0, wdth, hght);

            IndexedLineSeries ls = new IndexedLineSeries("A");
            ls.Values.Add(new float[] { 48, 83, 19, 23 });
            IndexedLineSeries ls2 = new IndexedLineSeries("B");
            ls2.Values.Add(new float[] { 52, 74, 9, 21 });
            IndexedLineSeries ls3 = new IndexedLineSeries("C");
            ls3.Values.Add(new float[] { 15, 43, 12, 8 });

            chart.PrimaryPlotArea.Series.Add(ls);
            chart.PrimaryPlotArea.Series.Add(ls2);
            chart.PrimaryPlotArea.Series.Add(ls3);


            Title title = new Title("Items");
            ls.YAxis.Titles.Add(title);

            ls.XAxis.Labels.Add(new IndexedXAxisLabel("NW", 0));
            ls.XAxis.Labels.Add(new IndexedXAxisLabel("SW", 1));
            ls.XAxis.Labels.Add(new IndexedXAxisLabel("SE", 2));
            ls.XAxis.Labels.Add(new IndexedXAxisLabel("NE", 3));

            
            chart.PrimaryPlotArea.XAxes.DefaultIndexedAxis.MajorGridLines = new XAxisGridLines();
            chart.PrimaryPlotArea.XAxes.DefaultIndexedAxis.MinorGridLines = new XAxisGridLines();
            chart.PrimaryPlotArea.YAxes.DefaultNumericAxis.MajorGridLines = new YAxisGridLines();

            chart.PrimaryPlotArea.YAxes.DefaultNumericAxis.MajorTickMarks = new YAxisTickMarks();
            chart.PrimaryPlotArea.YAxes.DefaultNumericAxis.MinorTickMarks = new YAxisTickMarks();

            chart.PrimaryPlotArea.XAxes.DefaultIndexedAxis.MajorTickMarks = new XAxisTickMarks();


            chart.PrimaryPlotArea.XAxes.DefaultIndexedAxis.MajorGridLines.Color = RgbColor.Navy;
            chart.PrimaryPlotArea.XAxes.DefaultIndexedAxis.MajorGridLines.LineStyle = LineStyle.DashLarge;
            chart.PrimaryPlotArea.XAxes.DefaultIndexedAxis.MinorGridLines.LineStyle = LineStyle.DashSmall;
            chart.PrimaryPlotArea.XAxes.DefaultIndexedAxis.MinorGridLines.Color = RgbColor.LightBlue;

            chart.PrimaryPlotArea.YAxes.DefaultNumericAxis.MajorGridLines.LineStyle = LineStyle.Solid;
            chart.PrimaryPlotArea.YAxes.DefaultNumericAxis.MajorGridLines.Color = RgbColor.LightGrey;

            chart.PrimaryPlotArea.YAxes.DefaultNumericAxis.MajorTickMarks.Visible = false;
            chart.PrimaryPlotArea.YAxes.DefaultNumericAxis.MinorTickMarks.Visible = false;
            chart.PrimaryPlotArea.XAxes.DefaultIndexedAxis.MajorTickMarks.Visible = false;

            Title title2 = new Title("Region");
            ls.XAxis.Titles.Add(title2);

            ls.XAxis.Labels.Angle = 45;
            ls.XAxis.LabelOffset = 5;
            ls.XAxis.Labels.TextColor = RgbColor.Navy;
            ls.XAxis.TitlePosition = XAxisTitlePosition.AboveXAxis;
            ls.XAxis.Titles[0].TextColor = RgbColor.Navy;

            ls.YAxis.LabelPosition = YAxisLabelPosition.RightOfPlotArea;
            ls.YAxis.LabelOffset = 5;
            ls.YAxis.Labels.TextColor = RgbColor.IndianRed;

            ls.Marker = Marker.GetCross(10);
            ls2.Marker = Marker.GetDiamond(10);
            ls3.Marker = Marker.GetCircle(10);

            doc.Pages[0].Elements.Add(chart);

            Image img = new(resourcePath + "logo.png", 25, 15, .20F);

            Label lb = new Label("Upward Trend", 90, 225, 100, 0);
            lb.TextColor = RgbColor.ForestGreen;
            lb.Angle = -30;
            //doc.Pages[0].Elements.Add(lb);
            //doc.Pages[0].Elements.Add(img);

            doc.Draw(outputPath + "axeslabels-out.pdf");
        }
    }
}
