using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;
using System;

namespace ChapterExamples.Chapters.ChapterTen
{
    public class ColumnChartExample
    {
        public static void Create(string outputPath)
        {
            NormalIndexed(outputPath);
            StackedDateTime(outputPath);
        }

        public static void NormalIndexed(string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));
            Chart chart = new Chart(0, 0, 500, 500);

            IndexedColumnSeries cs = new IndexedColumnSeries("A");
            cs.Values.Add(new float[] { 5, 7, 9, 6 });
            IndexedColumnSeries cs2 = new IndexedColumnSeries("B");
            cs2.Values.Add(new float[] { 4, 2, 5, 8 });
            IndexedColumnSeries cs3 = new IndexedColumnSeries("C");
            cs3.Values.Add(new float[] { 2, 4, 6, 9 });


            chart.PrimaryPlotArea.Series.Add(cs);
            chart.PrimaryPlotArea.Series.Add(cs2);
            chart.PrimaryPlotArea.Series.Add(cs3);

            cs.XAxis.Labels.Add(new IndexedXAxisLabel("P1", 0));
            cs.XAxis.Labels.Add(new IndexedXAxisLabel("P2", 1));
            cs.XAxis.Labels.Add(new IndexedXAxisLabel("P3", 2));
            cs.XAxis.Labels.Add(new IndexedXAxisLabel("P4", 3));


            doc.Pages[0].Elements.Add(chart);
            doc.Draw(outputPath + "simple-column-chart-out.pdf");

        }

        public static void StackedDateTime(string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));
            Chart chart = new Chart(0, 0, 500, 500);


            DateTimeStackedColumnSeries stackedColumnSeries1 = new DateTimeStackedColumnSeries();

            DateTimeStackedColumnSeriesElement se = new DateTimeStackedColumnSeriesElement("A");
            se.Values.Add(5, new DateTime(2024, 1, 1));
            se.Values.Add(7, new DateTime(2023, 2, 1));
            se.Values.Add(9, new DateTime(2022, 3, 1));
            se.Values.Add(6, new DateTime(2021, 4, 1));

            DateTimeStackedColumnSeriesElement se2 = new DateTimeStackedColumnSeriesElement("B");
            se2.Values.Add(4, new DateTime(2024, 1, 1));
            se2.Values.Add(2, new DateTime(2023, 2, 1));
            se2.Values.Add(5, new DateTime(2022, 3, 1));
            se2.Values.Add(8, new DateTime(2021, 4, 1));

            DateTimeStackedColumnSeriesElement se3 = new DateTimeStackedColumnSeriesElement("C");
            se3.Values.Add(2, new DateTime(2024, 1, 1));
            se3.Values.Add(4, new DateTime(2023, 2, 1));
            se3.Values.Add(6, new DateTime(2022, 3, 1));
            se3.Values.Add(9, new DateTime(2021, 4, 1));

            stackedColumnSeries1.Add(se);
            stackedColumnSeries1.Add(se2);
            stackedColumnSeries1.Add(se3);

            chart.PrimaryPlotArea.Series.Add(stackedColumnSeries1);

            stackedColumnSeries1.XAxis.LabelFormat = "yyyy";

            doc.Pages[0].Elements.Add(chart);
            doc.Draw(outputPath + "column-stacked-date-chart-out.pdf");
        }
    }
}
