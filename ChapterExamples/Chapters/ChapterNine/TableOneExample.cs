using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterNine
{
    public class TableOneExample
    {
        public static void Create(string outputPath)
        {
            Document myDoc = new();
            myDoc.Pages.Add(new Page(PageSize.Letter, PageOrientation.Landscape));
            float width = myDoc.Pages[0].Dimensions.Width - myDoc.Pages[0].Dimensions.LeftMargin * 2;
            float height = myDoc.Pages[0].Dimensions.Height - myDoc.Pages[0].Dimensions.TopMargin * 2;

            Table2 table = new Table2(0, 0, width, height);

            Column2 column1 = table.Columns.Add(100);
            column1.CellDefault.Align = TextAlign.Center;
           
            for(int i = 0; i < 10; i++)
            {
                table.Columns.Add(50);
            }

            Row2 row1 = table.Rows.Add(20, Font.HelveticaBold, 12);
            row1.CellDefault.Align = TextAlign.Center;
            row1.CellDefault.VAlign = VAlign.Center;
            row1.Cells.Add("");
            row1.Cells[0].Border.LineStyle = LineStyle.None;
            row1.Cells[0].Border.Bottom.LineStyle = LineStyle.Solid;


            for (int i = 0; i < 10; i++)
            {
                Cell2 aCell = row1.Cells.Add("199" + i);
                aCell.Align = TextAlign.Center;
                aCell.Border.LineStyle = LineStyle.None;
                aCell.Border.Bottom.LineStyle = LineStyle.Solid;
            }


            Row2 row2 = table.Rows.Add(10, Font.Helvetica, 12);
            row2.Cells.Add("Red Widgets");
            row2.Cells[0].Border.LineStyle = LineStyle.None;

            for (int i = 0; i < 10; i++)
            {
                Cell2 aCell = row2.Cells.Add("1" + i);
                aCell.Border.LineStyle = LineStyle.None;
                aCell.Align = TextAlign.Center;
            }

            Row2 row3 = table.Rows.Add(10, Font.Helvetica, 12);
            row3.Cells.Add("Blue Widgets");
            row3.Cells[0].Border.LineStyle = LineStyle.None;

            for (int i = 0; i < 10; i++)
            {
                Cell2 aCell = row3.Cells.Add("3" + i);
                aCell.Align = TextAlign.Center;
                aCell.Border.LineStyle = LineStyle.None;
            }

            table.Border.Top.Color = RgbColor.Black;
            table.Border.Bottom.Color = RgbColor.Black;
            table.Border.Top.Width = 1;
            table.Border.Bottom.Width = 1;
            table.Border.Left.LineStyle = LineStyle.None;
            table.Border.Right.LineStyle = LineStyle.None;

            myDoc.Pages[0].Elements.Add(table);

            myDoc.Draw(outputPath);
        }
    }
}
