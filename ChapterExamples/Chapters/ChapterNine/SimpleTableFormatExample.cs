using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterNine
{
    public class SimpleTableFormatExample
    {
        public static void Create(string outputPath)
        {
            Document myDoc = new();
            myDoc.Pages.Add(new Page(PageSize.Letter));

            float rowHeight = 50;

            Table2 table = new Table2(0, 0, 200, 200);

            Column2 column1 = table.Columns.Add(50);
            Column2 column2 = table.Columns.Add(50);

            Row2 row1 = table.Rows.Add(rowHeight, Font.TimesBold, 12, RgbColor.Red, RgbColor.Tan);
            Row2 row2 = table.Rows.Add(rowHeight);

            for (int i = 0; i < 4; i++)
            {
                row1.Cells.Add("R1C" + i);
                row2.Cells.Add("R2C" + i);
                row2.Cells[0].BackgroundColor = RgbColor.LightBlue;
            }

            myDoc.Pages[0].Elements.Add(table);
            myDoc.Draw(outputPath);
        }
    }
}
