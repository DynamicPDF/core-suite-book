using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapterExamples.Chapters.ChapterEleven
{
    public class DataLabelsExample
    {
        public static void Create(string outputPath)
        {
            LineExample(outputPath);
            Scatter(outputPath);
            PieChart(outputPath);
            BarChart(outputPath);
           

        }

        public static void BarChart(string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));
            Chart chart = new Chart(0, 0, 500, 500);

            DateTime100PercentStackedBarSeriesElement se = new DateTime100PercentStackedBarSeriesElement("A");
            se.Values.Add(5, new DateTime(2007, 1, 1));
            se.Values.Add(7, new DateTime(2007, 2, 1));
            se.Values.Add(9, new DateTime(2007, 3, 1));
            se.Values.Add(6, new DateTime(2007, 4, 1));
            DateTime100PercentStackedBarSeriesElement se2 = new DateTime100PercentStackedBarSeriesElement("B");
            se2.Values.Add(4, new DateTime(2007, 1, 1));
            se2.Values.Add(2, new DateTime(2007, 2, 1));
            se2.Values.Add(5, new DateTime(2007, 3, 1));
            se2.Values.Add(8, new DateTime(2007, 4, 1));
            DateTime100PercentStackedBarSeriesElement se3 = new DateTime100PercentStackedBarSeriesElement("C");
            se3.Values.Add(2, new DateTime(2007, 1, 1));
            se3.Values.Add(4, new DateTime(2007, 2, 1));
            se3.Values.Add(6, new DateTime(2007, 3, 1));
            se3.Values.Add(9, new DateTime(2007, 4, 1));

            DateTime100PercentStackedBarSeries stackedBarSeries = new DateTime100PercentStackedBarSeries();
            stackedBarSeries.Add(se);
            stackedBarSeries.Add(se2);
            stackedBarSeries.Add(se3);

            BarColumnPercentageDataLabel bcp = new(false);
            bcp.ShowPercentage = true;
            se.DataLabel = bcp;
            se2.DataLabel = bcp;
            se3.DataLabel = bcp;

            chart.PrimaryPlotArea.Series.Add(stackedBarSeries);


            stackedBarSeries.YAxis.LabelFormat = "D";
            doc.Pages[0].Elements.Add(chart);
            doc.Draw(outputPath + "datalabel-date-time-bar-stacked-100-chart-out.pdf");
        }

        public static void PieChart(string outputPath)
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
            ScalarDataLabel dataLbl = new ScalarDataLabel(true, true, true);
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
            doc.Draw(outputPath + "datalabel-pie-chart-out.pdf");
        }

        public static void Scatter(string outputPath)
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

            XYScatterDataLabel xdl = new(false,false,true);
            xys.DataLabel = xdl;
            xys2.DataLabel = xdl;

            chart.PrimaryPlotArea.Series.Add(xys);
            chart.PrimaryPlotArea.Series.Add(xys2);


            xys.YAxis.Titles.Add(new Title("Height in Inches"));
            xys.XAxis.Titles.Add(new Title("Width in Inches"));

            doc.Pages[0].Elements.Add(chart);

            doc.Draw(outputPath + "datalabel-scatter-chart-out.pdf");
        }


        public static void LineExample(string outputPath)
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

            ValuePositionDataLabel vpd = new(true);
            vpd.FontSize = 10;
            vpd.Color = RgbColor.Red;
            vpd.Padding = 10;
            vpd.Position = DataLabelPosition.Right;
            vpd.Prefix = "Item: ";

            ls.DataLabel = vpd;



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

            chart.PrimaryPlotArea.YAxes.DefaultNumericAxis.MajorTickMarks.Color = RgbColor.LightGrey;
            chart.PrimaryPlotArea.YAxes.DefaultNumericAxis.MinorTickMarks.Visible = false;
            chart.PrimaryPlotArea.XAxes.DefaultIndexedAxis.MajorTickMarks.Visible = false;




            Title title2 = new Title("Region");
            ls.XAxis.Titles.Add(title2);



            doc.Pages[0].Elements.Add(chart);

            doc.Draw(outputPath + "datalabel-out.pdf");
        }

    }
}
