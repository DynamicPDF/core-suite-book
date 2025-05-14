using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterNine
{
    public class TableFormatOverrideExample
    {
        public static void Create(string outputPath)
        {
            Document myDoc = new();
            myDoc.Pages.Add(new Page(PageSize.Letter, PageOrientation.Landscape));

            float tblWidth = 50 * 4;
            float rowHeight = 20;
            float tblHeight = rowHeight * 3;

            Table2 table = new Table2(0, 200, tblWidth, 60, Font.ZapfDingbats, 11);
            table.BackgroundColor = RgbColor.AliceBlue;
            table.Angle = -35;

            Column2 column1 = table.Columns.Add(50);
            Column2 column2 = table.Columns.Add(50);
            Column2 column3 = table.Columns.Add(50);
            Column2 column4 = table.Columns.Add(50);

            Row2 row1 = table.Rows.Add(rowHeight);
            Row2 row2 = table.Rows.Add(rowHeight, Font.CourierBoldOblique, 8, RgbColor.Green, RgbColor.LightCoral);
            Row2 row3 = table.Rows.Add(rowHeight);

            for (int i = 0; i < 4; i++)
            {
                row1.Cells.Add("R1C" + i);
                row2.Cells.Add("R2C" + i);
                row3.Cells.Add("R3C" + i);

                if (i % 2 == 0)
                {
                    row3.Cells[i].Font = Font.Helvetica;
                    row3.Cells[i].BackgroundColor = RgbColor.LightGrey;
                }
            }

            myDoc.Pages[0].Elements.Add(table);
            myDoc.Draw(outputPath);
        }
    }
}
