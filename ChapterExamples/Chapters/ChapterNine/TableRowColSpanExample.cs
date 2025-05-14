using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterNine
{
    public class TableRowColSpanExample
    {
        public static void Create(string outputPath)
        {
            Document myDoc = new();
            myDoc.Pages.Add(new Page(PageSize.Letter, PageOrientation.Landscape));

            float colWidth = 50;
            float rowHeight = 20;
            float tblWidth = 50 * 10;
            float tblHeight = rowHeight*3;

            Table2 table = new Table2(0, 0, tblWidth, tblHeight);

           
            for (int i = 0; i < 10; i++)
            {
                table.Columns.Add(colWidth);
            }

            Row2 row1 = table.Rows.Add(rowHeight);
            Row2 row2 = table.Rows.Add(rowHeight);
            Row2 row3 = table.Rows.Add(rowHeight);

            for (int i = 0; i < 10; i++)
            {
                if (i == 9)
                {
                    Cell2 aCell = row1.Cells.Add("cell" + (i + 1));
                    aCell.RowSpan = 3;
                }
                else if (i == 3)
                {
                    Cell2 aCell = row1.Cells.Add("cell" + (i + 1));
                    aCell.ColumnSpan = 3;
                }
                else if (i < 3 || i > 5)
                {
                        Cell2 aCell = row1.Cells.Add("cell" + (i + 1));
                }

                if (i != 9)
                {
                    Cell2 aCell2 = row2.Cells.Add("cell" + (i + 11));
                    Cell2 aCell3 = row3.Cells.Add("cell" + (i + 21));
                }
            }

            myDoc.Pages[0].Elements.Add(table);
            myDoc.Draw(outputPath);
        }
    }
}
