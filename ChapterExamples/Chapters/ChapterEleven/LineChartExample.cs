using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;
using System;

namespace ChapterExamples.Chapters.ChapterEleven
{
    public class LineChartExample
    {
        public static void Create(string outputPath)
        {
            Indexed(outputPath);
            DateTime(outputPath);
            IndexedStacked(outputPath);
            DateTimeStacked(outputPath);
            IndexedStacked100(outputPath);
            DateTimeStacked100(outputPath);
        }

        public static void Indexed(string outputPath)
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

            Title title2 = new Title("Region");
            ls.XAxis.Titles.Add(title2);

            doc.Pages[0].Elements.Add(chart);


            doc.Draw(outputPath + "line-chart-indexed-out.pdf");

        }

        public static void DateTime(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter, PageOrientation.Landscape));

            float hght = doc.Pages[0].Dimensions.Height - doc.Pages[0].Dimensions.TopMargin * 2;
            float wdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.RightMargin * 2;

            Chart chart = new Chart(0, 0, wdth, hght);

            DateTimeLineSeries ls = new DateTimeLineSeries("A");

            ls.Values.Add(5, new DateTime(2007, 1, 1));
            ls.Values.Add(7, new DateTime(2007, 2, 1));
            ls.Values.Add(9, new DateTime(2007, 3, 1));
            ls.Values.Add(6, new DateTime(2007, 4, 1));
            DateTimeLineSeries ls2 = new DateTimeLineSeries("B");
            ls2.Values.Add(4, new DateTime(2007, 1, 1));
            ls2.Values.Add(2, new DateTime(2007, 2, 1));
            ls2.Values.Add(5, new DateTime(2007, 3, 1));
            ls2.Values.Add(8, new DateTime(2007, 4, 1));

            
            chart.PrimaryPlotArea.Series.Add(ls);
            chart.PrimaryPlotArea.Series.Add(ls2);

            ls.YAxis.Titles.Add(new Title("Items Purchased"));

            ls.XAxis.LabelFormat = "MM/dd/yy";
            ls.XAxis.Titles.Add(new Title("Sales Date"));

            doc.Pages[0].Elements.Add(chart);
            doc.Draw(outputPath + "line-chart-datetime-out.pdf");
        }

        public static void IndexedStacked(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter, PageOrientation.Landscape));

            float hght = doc.Pages[0].Dimensions.Height - doc.Pages[0].Dimensions.TopMargin * 2;
            float wdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.RightMargin * 2;

            Chart chart = new Chart(0, 0, wdth, hght);

            IndexedStackedLineSeries ls = new IndexedStackedLineSeries();


            IndexedStackedLineSeriesElement se = new IndexedStackedLineSeriesElement("A");
            se.Values.Add(new float[] { 32, 17, 19, 6 });
            IndexedStackedLineSeriesElement se2 = new IndexedStackedLineSeriesElement("B");
            se2.Values.Add(new float[] { 24, 42, 5, 18 });
            

            ls.Add(se);
            ls.Add(se2);

          
            chart.PrimaryPlotArea.Series.Add(ls);

            ls.XAxis.Labels.Add(new IndexedXAxisLabel("NW", 0));
            ls.XAxis.Labels.Add(new IndexedXAxisLabel("SW", 1));
            ls.XAxis.Labels.Add(new IndexedXAxisLabel("SE", 2));
            ls.XAxis.Labels.Add(new IndexedXAxisLabel("NE", 3));

            ls.YAxis.Titles.Add(new Title("Items Purchased"));
            ls.XAxis.Titles.Add(new Title("Region"));

            doc.Pages[0].Elements.Add(chart);
            doc.Draw(outputPath + "line-chart-indexed-stacked-out.pdf");
        }

        public static void DateTimeStacked(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter, PageOrientation.Landscape));

            float hght = doc.Pages[0].Dimensions.Height - doc.Pages[0].Dimensions.TopMargin * 2;
            float wdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.RightMargin * 2;

            Chart chart = new Chart(0, 0, wdth, hght);
            
            DateTimeStackedLineSeries sls = new();


            DateTimeStackedLineSeriesElement se = new("A");
            se.Values.Add(5, new DateTime(2007, 1, 1));
            se.Values.Add(7, new DateTime(2007, 2, 1));
            se.Values.Add(9, new DateTime(2007, 3, 1));
            se.Values.Add(6, new DateTime(2007, 4, 1));

            DateTimeStackedLineSeriesElement se2 = new("B");
            se2.Values.Add(5, new DateTime(2007, 1, 1));
            se2.Values.Add(7, new DateTime(2007, 2, 1));
            se2.Values.Add(9, new DateTime(2007, 3, 1));
            se2.Values.Add(6, new DateTime(2007, 4, 1));
            
            sls.Add(se);
            sls.Add(se2);

            chart.PrimaryPlotArea.Series.Add(sls);

            sls.YAxis.Titles.Add(new Title("Items Purchased"));

            sls.XAxis.LabelFormat = "MM/dd/yy";
            sls.XAxis.Titles.Add(new Title("Sales Date"));

            doc.Pages[0].Elements.Add(chart);
            doc.Draw(outputPath + "line-chart-stacked-datetime-out.pdf");

        }

        public static void IndexedStacked100(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter, PageOrientation.Landscape));

            float hght = doc.Pages[0].Dimensions.Height - doc.Pages[0].Dimensions.TopMargin * 2;
            float wdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.RightMargin * 2;

            Chart chart = new Chart(0, 0, wdth, hght);

            Indexed100PercentStackedLineSeries ls = new Indexed100PercentStackedLineSeries();

            Indexed100PercentStackedLineSeriesElement se = new Indexed100PercentStackedLineSeriesElement("A");
            se.Values.Add(new float[] { 15, 37, 29, 21 });
            Indexed100PercentStackedLineSeriesElement se2 = new Indexed100PercentStackedLineSeriesElement("B");
            se2.Values.Add(new float[] { 23, 19, 25, 18 });
            Indexed100PercentStackedLineSeriesElement se3 = new Indexed100PercentStackedLineSeriesElement("C");
            se3.Values.Add(new float[] { 11, 29, 5, 4 });

            ls.Add(se);
            ls.Add(se2);
            ls.Add(se3);
            
            
           chart.PrimaryPlotArea.Series.Add(ls);

            ls.XAxis.Labels.Add(new IndexedXAxisLabel("NW", 0));
            ls.XAxis.Labels.Add(new IndexedXAxisLabel("SW", 1));
            ls.XAxis.Labels.Add(new IndexedXAxisLabel("SE", 2));
            ls.XAxis.Labels.Add(new IndexedXAxisLabel("NE", 3));

            ls.YAxis.Titles.Add(new Title("Items Purchased"));
            ls.XAxis.Titles.Add(new Title("Region"));

            doc.Pages[0].Elements.Add(chart);
            doc.Draw(outputPath + "line-chart-stacked-100-indexed-out.pdf");
        }


        public static void DateTimeStacked100(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter, PageOrientation.Landscape));

            float hght = doc.Pages[0].Dimensions.Height - doc.Pages[0].Dimensions.TopMargin * 2;
            float wdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.RightMargin * 2;

            Chart chart = new Chart(0, 0, wdth, hght);

            DateTime100PercentStackedLineSeries sls = new DateTime100PercentStackedLineSeries();

            DateTime100PercentStackedLineSeriesElement se = new DateTime100PercentStackedLineSeriesElement("A");

            se.Values.Add(5, new DateTime(2017, 1, 1));
            se.Values.Add(7, new DateTime(2017, 2, 1));
            se.Values.Add(9, new DateTime(2017, 3, 1));
            se.Values.Add(6, new DateTime(2017, 4, 1));

            DateTime100PercentStackedLineSeriesElement se2 = new DateTime100PercentStackedLineSeriesElement("B");

            se2.Values.Add(4, new DateTime(2017, 1, 1));
            se2.Values.Add(2, new DateTime(2017, 2, 1));
            se2.Values.Add(5, new DateTime(2017, 3, 1));
            se2.Values.Add(8, new DateTime(2017, 4, 1));

            DateTime100PercentStackedLineSeriesElement se3 = new DateTime100PercentStackedLineSeriesElement("B");

            se3.Values.Add(4, new DateTime(2017, 1, 1));
            se3.Values.Add(2, new DateTime(2017, 2, 1));
            se3.Values.Add(5, new DateTime(2017, 3, 1));
            se3.Values.Add(8, new DateTime(2017, 4, 1));

            sls.Add(se);
            sls.Add(se2);
            sls.Add(se3);

            chart.PrimaryPlotArea.Series.Add(sls);

            sls.YAxis.Titles.Add(new Title("Items Purchased"));

            sls.XAxis.LabelFormat = "MM/dd/yy";
            sls.XAxis.Titles.Add(new Title("Sales Date"));

            doc.Pages[0].Elements.Add(chart);
            doc.Draw(outputPath + "line-chart-stacked-100-datetime-out.pdf");
        }
    }
}