
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterThirteen
{
    public class OutlineWithBookmarksExample
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

            Outline topicOutline = outline.ChildOutlines.Add("Important Topics");


            doc.Pages[1].Elements.Add(new Bookmark("Important Topic A", 0, 0, topicOutline));
            doc.Pages[3].Elements.Add(new Bookmark("Important Topic B", 0, 0, topicOutline));


            Outline quoteOutline = outline.ChildOutlines.Add("Important Quotes");


            doc.Pages[2].Elements.Add(new Bookmark("Quote One", 0, 0, quoteOutline));
            doc.Pages[3].Elements.Add(new Bookmark("Quote Two", 0, 0, quoteOutline));

            doc.Draw(outputPath);
        }

        public static void Create2(string outputPath)
        {
            Document doc = new();

            for (int i = 0; i < 4; i++)
            {
                CreatePage(doc, i);
            }

            Outline outline = doc.Outlines.Add("Root Outline");

            for (int j = 1; j <= doc.Pages.Count; j++)
            {
                outline.ChildOutlines.Add("Child Outline " + j, new XYDestination(j, 0, 0));
            }

            doc.Pages[1].Elements.Add(new Bookmark("Bookmark One (Root)", 0, 0, outline));


            Outline quoteOutline = outline.ChildOutlines.Add("Child Outline 5");

            doc.Pages.Add(new Page(PageSize.Letter));

            quoteOutline.ChildOutlines.Add("Child Outline 1", new XYDestination(4, 0, 0));

            doc.Pages[2].Elements.Add(new Bookmark("Bookmark One (Child Outline)", 0, 0, quoteOutline));
            doc.Pages[3].Elements.Add(new Bookmark("Bookmark Two (Child Outline)", 0, 0, quoteOutline));

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
