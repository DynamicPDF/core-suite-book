
using ChapterExamples.Chapters.ChapterEleven;
using ChapterExamples.Utility;

namespace ChapterEleven
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.CreatePath("output/ch11");
            LineChartExample.Create(FileUtility.GetPath("output/ch11/"));
            XyScatterChartExample.Create(FileUtility.GetPath("output/ch11/"));
            AreaChartExample.Create(FileUtility.GetPath("output/ch11/"));
            GridLinesExample.Create(FileUtility.GetPath("output/ch11/"));
            MarkerExample.Create(FileUtility.GetPath("output/ch11/"));
            AxesLabelsExample.Create(FileUtility.GetPath("../ChapterExamples/resources/ch3/"), FileUtility.GetPath("output/ch11/"));
            DataLabelsExample.Create(FileUtility.GetPath(FileUtility.GetPath("output/ch11/")));
        }
    }
}
