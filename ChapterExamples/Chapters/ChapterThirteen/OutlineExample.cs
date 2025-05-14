using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterThirteen
{
    public class OutlineExample
    {
        public static void Create(string outputPath)
        {
            Document doc = new();

            for (int i = 0; i < 4; i++)
            {
                CreatePage(doc, i);
            }

            Outline outline = doc.Outlines.Add("My Document");
            outline.Style = TextStyle.Bold;
            outline.Color = RgbColor.Navy;

            for (int j = 1; j <= doc.Pages.Count; j++)
            {
                outline.ChildOutlines.Add("pg" + j, new XYDestination(j, 0, 0));
            }

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
