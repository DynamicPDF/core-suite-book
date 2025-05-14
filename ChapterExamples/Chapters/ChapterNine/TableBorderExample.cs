using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterNine
{
    public class TableBorderExample
    {
        public static void Create(string outputPath)
        {
            Document myDoc = new();
            myDoc.Pages.Add(new Page(PageSize.Letter, PageOrientation.Landscape));

            float rowHeight = 50;

            Table2 table = new Table2(0, 0, 200, 200);
            table.Border.Color = RgbColor.Red;
            table.Border.Right.Color = RgbColor.ForestGreen;

            Column2 column1 = table.Columns.Add(50);
            Column2 column2 = table.Columns.Add(50);
            Column2 column3 = table.Columns.Add(50);
            Column2 column4 = table.Columns.Add(50);

            Row2 row1 = table.Rows.Add(rowHeight);
            Row2 row2 = table.Rows.Add(rowHeight);

            for (int i = 0; i < 4; i++)
            {
                row1.Cells.Add("R1C" + i);
                row1.Cells[i].Border.LineStyle = LineStyle.None;
                row2.Cells.Add("R2C" + i);

                if(i == 3)
                {
                    row2.Cells[i].Border.Top.LineStyle = LineStyle.None;
                    row2.Cells[i].Border.Left.Color = RgbColor.HotPink;
                    row2.Cells[i - 1].Border.Right.Color = RgbColor.LightGrey;
                }
            }

            myDoc.Pages[0].Elements.Add(table);
            myDoc.Draw(outputPath);
        }
    }
}
