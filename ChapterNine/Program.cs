using ChapterExamples.Chapters.ChapterNine;
using ChapterExamples.Utility;

namespace ChapterNine
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.CreatePath("output/ch9");
            AutoLayoutTableExample.Create(FileUtility.GetPath("output/ch9/autolayout-out.pdf"));
            SimpleTableExample.Create(FileUtility.GetPath("output/ch9/simple-table-out.pdf"));
            SimpleTableFormatExample.Create(FileUtility.GetPath("output/ch9/simple-format-table-out.pdf"));
            TableOverflow.Create(FileUtility.GetPath("output/ch9/"));
            TableOneExample.Create(FileUtility.GetPath("output/ch9/table-one-out.pdf"));
            TableRowColSpanExample.Create(FileUtility.GetPath("output/ch9/table-col-row-out.pdf"));
            TableFormatOverrideExample.Create(FileUtility.GetPath("output/ch9/table-override-out.pdf"));
            TableBorderExample.Create(FileUtility.GetPath("output/ch9/table-border-out.pdf"));
            TablePageElementsExample.Create(FileUtility.GetPath("../ChapterExamples/resources/ch3/logo.png"), FileUtility.GetPath("output/ch9/table-page-elements-out.pdf"));

        }
    }
}
