using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;
using System;

namespace ChapterExamples.Chapters.ChapterEleven
{
    public class AreaChartExample
    {

        public static void Create(string outputPath)
        {
            NormalIndexed(outputPath);
            DateTimeStacked(outputPath);
        }

        public static void NormalIndexed(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter, PageOrientation.Landscape));

            float hght = doc.Pages[0].Dimensions.Height - doc.Pages[0].Dimensions.TopMargin * 2;
            float wdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.RightMargin * 2;

            Chart chart = new Chart(0, 0, wdth, hght);

            IndexedAreaSeries as1 = new("A");
            as1.Values.Add(new float[] { 5, 7, 9, 6 });
            
            IndexedAreaSeries as2 = new("B");
            as2.Values.Add(new float[] { 4, 2, 5, 8 });

            chart.PrimaryPlotArea.Series.Add(as1);
            chart.PrimaryPlotArea.Series.Add(as2);

           
            as1.YAxis.Titles.Add(new Title("Items"));

            as1.XAxis.Labels.Add(new IndexedXAxisLabel("NW", 0));
            as1.XAxis.Labels.Add(new IndexedXAxisLabel("SW", 1));
            as1.XAxis.Labels.Add(new IndexedXAxisLabel("SE", 2));
            as1.XAxis.Labels.Add(new IndexedXAxisLabel("NE", 3));

            Title title2 = new Title("Region");
            as1.XAxis.Titles.Add(title2);


            doc.Pages[0].Elements.Add(chart);
            doc.Draw(outputPath + "area-indexed-chart-out.pdf");
        }

        public static void DateTimeStacked(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter, PageOrientation.Landscape));

            float hght = doc.Pages[0].Dimensions.Height - doc.Pages[0].Dimensions.TopMargin * 2;
            float wdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.RightMargin * 2;

            Chart chart = new Chart(0, 0, wdth, hght);

            DateTimeStackedAreaSeries sls = new();

            DateTimeStackedAreaSeriesElement se = new("A");
            se.Values.Add(5, new DateTime(2007, 1, 1));
            se.Values.Add(7, new DateTime(2007, 2, 1));
            se.Values.Add(9, new DateTime(2007, 3, 1));
            se.Values.Add(6, new DateTime(2007, 4, 1));

            DateTimeStackedAreaSeriesElement se2 = new("B");
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
            doc.Draw(outputPath + "area-datetime-chart-out.pdf");
        }

    }
}