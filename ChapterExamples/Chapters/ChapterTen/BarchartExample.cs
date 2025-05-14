using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;
using ceTe.DynamicPDF.PageElements.Charting.Values;
using System;

namespace ChapterExamples.Chapters.ChapterTen
{
    public class BarchartExample
    {
        public static void Create(string outputPath)
        {
            CreateIndexedNormal(outputPath);
            CreateDateTimeNormal(outputPath);
            CreateDateTimeNormalByYear(outputPath);
            IndexedStackedSeriesExample(outputPath);
            DateTimeStackedSeriesExample(outputPath);
            IndexedStacked100Example(outputPath);
            DateTimeStacked100Example(outputPath);
            IndexedStackedSeriesMultipleExample(outputPath);
        }

        public static void CreateDateTimeNormal(string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));

            Chart chart = new Chart(0, 0, 500, 400);

            DateTimeBarSeries barSeries = new DateTimeBarSeries("A");
            barSeries.Values.Add(5, new DateTime(2012, 1, 1));
            barSeries.Values.Add(7, new DateTime(2013, 2, 9));
            barSeries.Values.Add(9, new DateTime(2014, 3, 7));

            DateTimeBarValue value = new(6, new DateTime(2015, 4, 1));
            barSeries.Values.Add(value);

            DateTimeBarSeries barSeries2 = new DateTimeBarSeries("B");

            DateTimeBarValue dateTimeBarValue1 = new(4, new DateTime(2012, 1, 1));
            barSeries2.Values.Add(dateTimeBarValue1);

            barSeries2.Values.Add(2, new DateTime(2013, 2, 9));
            barSeries2.Values.Add(5, new DateTime(2014, 3, 7));
            barSeries2.Values.Add(8, new DateTime(2015, 4, 1));
            
            
            DateTimeBarSeries barSeries3 = new DateTimeBarSeries("C");
            barSeries3.Values.Add(2, new DateTime(2012, 1, 1));
            barSeries3.Values.Add(4, new DateTime(2013, 2, 9));
            barSeries3.Values.Add(6, new DateTime(2014, 3, 7));
            barSeries3.Values.Add(9, new DateTime(2015, 4, 1));


            chart.PrimaryPlotArea.Series.Add(barSeries);
            chart.PrimaryPlotArea.Series.Add(barSeries2);
            chart.PrimaryPlotArea.Series.Add(barSeries3);

           
            barSeries.YAxis.LabelFormat = "D";

            Title title3 = new Title("Items");
            barSeries.XAxis.Titles.Add(title3);


            doc.Pages[0].Elements.Add(chart);
            doc.Draw(outputPath + "simple-bar-date-time-chart-out.pdf");
        }

        public static void CreateIndexedNormal(string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));

            Chart chart = new Chart(0, 0, 400, 230);
            IndexedBarSeries barSeries = new IndexedBarSeries("A");
            barSeries.Values.Add(new float[] { 4, 5, 8, 2 });
            IndexedBarSeries barSeries2 = new IndexedBarSeries("B");
            barSeries2.Values.Add(new float[] { 1, 9, 8, 5 });
            IndexedBarSeries barSeries3 = new IndexedBarSeries("C");
            barSeries3.Values.Add(new float[] { 2, 4, 8, 3 });

            chart.PrimaryPlotArea.Series.Add(barSeries);
            chart.PrimaryPlotArea.Series.Add(barSeries2);
            chart.PrimaryPlotArea.Series.Add(barSeries3);

            barSeries.YAxis.Labels.Add(new IndexedYAxisLabel("P1", 0));
            barSeries.YAxis.Labels.Add(new IndexedYAxisLabel("P2", 1));
            barSeries.YAxis.Labels.Add(new IndexedYAxisLabel("P3", 2));
            barSeries.YAxis.Labels.Add(new IndexedYAxisLabel("P4", 3));

            doc.Pages[0].Elements.Add(chart);
            doc.Draw(outputPath + "simple-bar-chart-out.pdf");
        }



            public static void CreateDateTimeNormalByYear(string outputPath)
            {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));

            Chart chart = new Chart(0, 0, 500, 400);

            DateTimeBarSeries barSeries = new DateTimeBarSeries("A");
            barSeries.Values.Add(5, new DateTime(2012, 1, 1));
            barSeries.Values.Add(7, new DateTime(2013, 2, 9));
            barSeries.Values.Add(9, new DateTime(2014, 3, 7));
            barSeries.Values.Add(6, new DateTime(2015, 4, 1));
            DateTimeBarSeries barSeries2 = new DateTimeBarSeries("B");

            DateTimeBarValue dateTimeBarValue1 = new(4, new DateTime(2012, 1, 1));
            barSeries2.Values.Add(dateTimeBarValue1);

            barSeries2.Values.Add(2, new DateTime(2013, 2, 9));
            barSeries2.Values.Add(5, new DateTime(2014, 3, 7));
            barSeries2.Values.Add(8, new DateTime(2015, 4, 1));


            DateTimeBarSeries barSeries3 = new DateTimeBarSeries("C");
            barSeries3.Values.Add(2, new DateTime(2012, 1, 1));
            barSeries3.Values.Add(4, new DateTime(2013, 2, 9));
            barSeries3.Values.Add(6, new DateTime(2014, 3, 7));
            barSeries3.Values.Add(9, new DateTime(2015, 4, 1));


            chart.PrimaryPlotArea.Series.Add(barSeries);
            chart.PrimaryPlotArea.Series.Add(barSeries2);
            chart.PrimaryPlotArea.Series.Add(barSeries3);

            barSeries.YAxis.DateTimeType = DateTimeType.Year;

            Title title3 = new Title("Items");
            barSeries.XAxis.Titles.Add(title3);


            doc.Pages[0].Elements.Add(chart);
            doc.Draw(outputPath + "simple-bar-date-time-by-year-chart-out.pdf");
        }

        public static void IndexedStackedSeriesExample(string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));
            Chart chart = new Chart(0, 0, 500, 400);

            IndexedStackedBarSeriesElement se = new IndexedStackedBarSeriesElement("A");
            IndexedStackedBarValue sbv = new(5, 0);
            se.Values.Add(sbv);
            se.Values.Add(new float[] {7, 9, 6 });
            IndexedStackedBarSeriesElement se2 = new IndexedStackedBarSeriesElement("B");
            se2.Values.Add(new float[] { 4, 2, 5, 8 });
            IndexedStackedBarSeriesElement se3 = new IndexedStackedBarSeriesElement("C");
            se3.Values.Add(new float[] { 2, 4, 6, 9 });

            IndexedStackedBarSeries stackedBarSeries = new IndexedStackedBarSeries();
            stackedBarSeries.Add(se);
            stackedBarSeries.Add(se2);
            stackedBarSeries.Add(se3);

            chart.PrimaryPlotArea.Series.Add(stackedBarSeries);


            stackedBarSeries.YAxis.Labels.Add(new IndexedYAxisLabel("P1", 0));
            stackedBarSeries.YAxis.Labels.Add(new IndexedYAxisLabel("P2", 1));
            stackedBarSeries.YAxis.Labels.Add(new IndexedYAxisLabel("P3", 2));
            stackedBarSeries.YAxis.Labels.Add(new IndexedYAxisLabel("P4", 3));

            
            doc.Pages[0].Elements.Add(chart);

            doc.Draw(outputPath + "simple-bar-indexed-stacked-chart-out.pdf");
        }

        public static void DateTimeStackedSeriesExample(string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));
            Chart chart = new Chart(0, 0, 500, 500);

            DateTimeStackedBarSeries stackedBarSeries = new DateTimeStackedBarSeries();

            DateTimeStackedBarSeriesElement se = new DateTimeStackedBarSeriesElement("A");
            DateTimeStackedBarValue stbv = new(5, new DateTime(2012, 1, 1));
            se.Values.Add(stbv);
            se.Values.Add(7, new DateTime(2013, 2, 9));
            se.Values.Add(9, new DateTime(2014, 3, 7));
            se.Values.Add(6, new DateTime(2015, 4, 1));

            DateTimeStackedBarSeriesElement se2 = new DateTimeStackedBarSeriesElement("B");

            se2.Values.Add(4, new DateTime(2012, 1, 1));
            se2.Values.Add(2, new DateTime(2013, 2, 9));
            se2.Values.Add(5, new DateTime(2014, 3, 7));
            se2.Values.Add(8, new DateTime(2015, 4, 1));


            DateTimeStackedBarSeriesElement se3 = new DateTimeStackedBarSeriesElement("C");
            se3.Values.Add(2, new DateTime(2012, 1, 1));
            se3.Values.Add(4, new DateTime(2013, 2, 9));
            se3.Values.Add(6, new DateTime(2014, 3, 7));
            se3.Values.Add(9, new DateTime(2015, 4, 1));


            stackedBarSeries.Add(se);
            stackedBarSeries.Add(se2);
            stackedBarSeries.Add(se3);
                        
            chart.PrimaryPlotArea.Series.Add(stackedBarSeries);

            stackedBarSeries.YAxis.LabelFormat = "D";


            doc.Pages[0].Elements.Add(chart);

            doc.Draw(outputPath + "date-time-bar-stacked-chart-out.pdf");

        }

        public static void IndexedStacked100Example(string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));
            Chart chart = new Chart(0, 0, 500, 500);

            Indexed100PercentStackedBarSeries stackedBarSeries = new Indexed100PercentStackedBarSeries();

            Indexed100PercentStackedBarSeriesElement se = new Indexed100PercentStackedBarSeriesElement("A");
            se.Values.Add(new float[] { 3, 5, 9, 4 });
            Indexed100PercentStackedBarSeriesElement se2 = new Indexed100PercentStackedBarSeriesElement("B");
            se2.Values.Add(new float[] { 1, 2, 7, 4 });
            Indexed100PercentStackedBarSeriesElement se3 = new Indexed100PercentStackedBarSeriesElement("C");
            se3.Values.Add(new float[] { 6, 3, 1, 9 });

          
            stackedBarSeries.Add(se);
            stackedBarSeries.Add(se2);
            stackedBarSeries.Add(se3);

            chart.PrimaryPlotArea.Series.Add(stackedBarSeries);

            stackedBarSeries.YAxis.Labels.Add(new IndexedYAxisLabel("P1", 0));
            stackedBarSeries.YAxis.Labels.Add(new IndexedYAxisLabel("P2", 1));
            stackedBarSeries.YAxis.Labels.Add(new IndexedYAxisLabel("P3", 2));
            stackedBarSeries.YAxis.Labels.Add(new IndexedYAxisLabel("P4", 3));

            doc.Pages[0].Elements.Add(chart);
            doc.Draw(outputPath + "indexed-bar-stacked-100-chart-out.pdf");
        }

        public static void DateTimeStacked100Example(string outputPath)
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

            chart.PrimaryPlotArea.Series.Add(stackedBarSeries);

            stackedBarSeries.YAxis.LabelFormat = "D";
            doc.Pages[0].Elements.Add(chart);
            doc.Draw(outputPath + "date-time-bar-stacked-100-chart-out.pdf");
        }

        public static void IndexedStackedSeriesMultipleExample(string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));
            Chart chart = new Chart(0, 0, 500, 400);





            doc.Pages[0].Elements.Add(chart);

            doc.Draw(outputPath + "simple-bar-indexed-stacked-multiple-chart-out.pdf");
        }

    }
}
