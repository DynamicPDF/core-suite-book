using ChapterExamples.Chapters.ChapterTen;
using ChapterExamples.Utility;

namespace ChapterTen
{
    class Program
    {
        public static void Main()
        {
            FileUtility.CreatePath("output/ch10");
            SimpleChartExample.Create(FileUtility.GetPath("output/ch10/"));
            PieChartExample.Create(FileUtility.GetPath("output/ch10/"));
            SimpleLegendExample.Create(FileUtility.GetPath("output/ch10/"));
            BarchartExample.Create(FileUtility.GetPath("output/ch10/"));
            ColumnChartExample.Create(FileUtility.GetPath("output/ch10/"));
            PropertyPrecedence.Create(FileUtility.GetPath("output/ch10/"));
            MultiplePlotAreas.Create(FileUtility.GetPath("output/ch10/"));
            ChartLayoutExample.Create(FileUtility.GetPath("output/ch10/"));
        }
    }
}