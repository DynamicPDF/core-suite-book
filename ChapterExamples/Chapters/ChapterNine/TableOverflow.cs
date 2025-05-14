using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterNine
{
    public class TableOverflow
    {
        public static void Create(string outputPath)
        {
            TableOverflow.RowOverflow(outputPath);
            TableOverflow.ColumnOverflow(outputPath);
        }

        public static void RowOverflow(string outputPath)
        {
            Document myDoc = new Document();

            Table2 table = new Table2(0, 0, 300, 700);
            table.Columns.Add(100);
            table.Columns.Add(100);
            table.Columns.Add(100);


            for (int i = 1; i <= 500; i++)
            {
                Row2 row = table.Rows.Add(10);
                row.Cells.Add("R" + i + "C1");
                row.Cells.Add("R" + i + "C2");
                row.Cells.Add("R" + i + "C3");
            }

            do
            {
                Page page = new Page();
                myDoc.Pages.Add(page);
                page.Elements.Add(table);
                table = table.GetOverflowRows();
            } while (table != null);

            myDoc.Draw(outputPath + "table-overflow-out.pdf");
        }


        public static void ColumnOverflow(string outputPath)
        {
            Document myDoc = new Document();

            Table2 table = new Table2(0, 0, 500, 50);
      
            Row2 row1 = table.Rows.Add(20);
            Row2 row2 = table.Rows.Add(20);
            
            for (int i = 0; i <= 50; i++)
            {
                table.Columns.Add(50);
                for (int j = 0; j <= 50; j++)
                {
                    row1.Cells.Add("R1" + "C" + j);
                    row2.Cells.Add("R2" + "C" + j);
                }
            }

            do
            {
                Page page = new Page();
                myDoc.Pages.Add(page);
                page.Elements.Add(table);
                table = table.GetOverflowColumns();
            } while (table != null);

            myDoc.Draw(outputPath + "table-column-overflow-out.pdf");
        }

    }
}
