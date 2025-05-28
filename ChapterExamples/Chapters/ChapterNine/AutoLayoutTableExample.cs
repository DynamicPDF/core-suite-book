
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterNine
{
    public class AutoLayoutTableExample
    {
        public static void Create(string outputPath)
        {
            AutoLayout autoLayout = new AutoLayout(PageSize.Letter, PageOrientation.Portrait, 50);
                     
            Table2 table = autoLayout.AddTable2();

            Column2 column1 = table.Columns.Add(50);
            Column2 column2 = table.Columns.Add(50);
            Column2 column3 = table.Columns.Add(50);
            Column2 column4 = table.Columns.Add(50);

            Row2 row1 = table.Rows.Add(200);
            Row2 row2 = table.Rows.Add(200);

            for (int i = 0; i < 4; i++)
            {
                row1.Cells.Add("R1C" + i);
                row2.Cells.Add("R2C" + i);
            }

            Document document = autoLayout.GetDocument();
            document.Draw(outputPath);

        }
    }
}
