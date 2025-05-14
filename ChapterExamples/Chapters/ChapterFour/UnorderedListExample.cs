using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterFour
{
    public class UnorderedListExample
    {
        public static void Create(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            UnorderedList ul = new(50, 50, 300, 500);
            ul.Items.Add("Paint");
            ul.Items.Add("Two Brushes");
            ul.Items.Add("Three Buckets");
            ul.Items.Add("Ten Cloths");

            UnorderedSubList ul2 = ul.Items[0].SubLists.AddUnorderedSubList(UnorderedListStyle.Square);
            ul2.Items.Add("One gallon red paint");
            ul2.Items.Add("Two gallons blue paint");
            ul2.Items.Add("Three gallons orange paint");

            doc.Pages[0].Elements.Add(ul);

            AddGridLines.AddBackgroundColor(doc);
            AddGridLines.AddMargins(doc.Pages[0]);

            doc.Draw(outputPath);
        }
    }
}
