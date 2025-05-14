using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterNine
{
    public class TablePageElementsExample
    {
        public static void Create(string inputImage, string outputPath)
        {
            Document myDoc = new();
            myDoc.Pages.Add(new Page(PageSize.Letter, PageOrientation.Landscape));

            float rowHeight = 50;

            Table2 table = new Table2(0, 0, 400, 200);

            Column2 column1 = table.Columns.Add(100);
            Column2 column2 = table.Columns.Add(100);
            Column2 column3 = table.Columns.Add(100);
            Column2 column4 = table.Columns.Add(100);

            Row2 row1 = table.Rows.Add(rowHeight);
            Row2 row2 = table.Rows.Add(rowHeight);

            for (int i = 0; i < 4; i++)
            {
                Image img = new Image(inputImage, 0, 0);
                img.SetBounds(25, 25);
                if (i == 0)
                {
                    row1.Cells.Add(img);
                    row2.Cells.Add("R2C" + i);
                } 
                else if(i == 1)
                {
                    row1.Cells.Add("R2C" + i);
                    row2.Cells.Add(new Label("This is a label", 0, 0, 100, 0));
                }
                else if(i == 2)
                {
                    row1.Cells.Add("R1C" + i);
                    row2.Cells.Add(new Rectangle(0, 0, 50, 50, RgbColor.Red));
                }
                else if(i == 3)
                {
                    row1.Cells.Add(new TextArea("this is text area", 0, 0, 100, 100));
                    row2.Cells.Add("R2C" + i);
                }
                else
                {
                    row1.Cells.Add("R1C" + i);
                    row2.Cells.Add("R2C" + i);
                }
            }

            myDoc.Pages[0].Elements.Add(table);
            myDoc.Draw(outputPath);
        }
    }
}
