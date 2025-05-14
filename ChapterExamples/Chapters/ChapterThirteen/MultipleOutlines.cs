
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterThirteen
{
    public class MultipleOutlines
    {
        public static void Create(string outputPath)
        {
            Document doc = new();

            for (int i = 0; i < 15; i++)
            {
                doc.Pages.Add(new Page(PageSize.Letter));
                doc.Pages[i].Elements.Add(new Label("page " + (i + 1), 50, 50, 100, 0));
            }

            Outline outline = doc.Outlines.Add("First Report");
            outline.Expanded = true;

            outline.ChildOutlines.Add("A (pg-1)", new XYDestination(1, 0, 0));
            outline.ChildOutlines.Add("B (pg-10)", new XYDestination(10, 0, 0));

            foreach (Outline childOutline in outline.ChildOutlines)
            {
                childOutline.Expanded = false;
            }

            Outline outline2 = doc.Outlines.Add("Second Report");
            outline.Expanded = true;

            outline2.ChildOutlines.Add("I (pg-11)", new XYDestination(11, 0, 0));
            outline2.ChildOutlines.Add("II (pg-13)", new XYDestination(13, 0, 0));

            foreach (Outline childOutline in outline2.ChildOutlines)
            {
                childOutline.Expanded = false;
            }


            doc.Draw(outputPath);
        }
    }
}