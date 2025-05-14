
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterThirteen
{
    public class BookmarksExample
    {
        public static void Create(string outputPath)
        {
            Document doc = new();

            for (int i = 0; i < 4; i++)
            {
                CreatePage(doc, i);
            }

            Outline outline = doc.Outlines.Add("Important Pages");
            outline.Style = TextStyle.Bold;
            outline.Color = RgbColor.Navy;

            doc.Pages[1].Elements.Add(new Bookmark("Important Topic A", 0, 0, outline));
            doc.Pages[3].Elements.Add(new Bookmark("Important Topic B", 0, 0, outline));


            outline.ChildOutlines.Add("Important Quotes");


            doc.Pages[2].Elements.Add(new Bookmark("Quote One", 0, 0, outline.ChildOutlines[0]));
            doc.Pages[3].Elements.Add(new Bookmark("Quote Two", 0, 0, outline.ChildOutlines[0]));


            AddGridLines.AddBackgroundColor(doc);

            doc.Draw(outputPath);
        }

        private static void CreatePage(Document doc, int i)
        {
            string txt1 = TextGenerator.GenerateTextMultiple(4);
            FormattedTextAreaStyle style = new(FontFamily.Helvetica, 12, false);
            FormattedTextArea txtOne = new(txt1, 0, 0, 512, 0, style);
            txtOne.Height = txtOne.GetRequiredHeight();
            doc.Pages.Add(new Page(PageSize.Letter));
            doc.Pages[i].Elements.Add(txtOne);
        }
    }
}
