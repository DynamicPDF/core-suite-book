
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterFour
{
    public class CombinedListExample
    {
        public static void Create(string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));

            OrderedList list = new OrderedList(50, 50, 300, 500);
            

            list.ListItemTopMargin = 5;
            list.ListItemBottomMargin = 5;

            list.BulletPrefix = "(";
            list.BulletSuffix = ")";

            ListItem item1 = list.Items.Add("Task One");
            ListItem item2 = list.Items.Add("Task Two");
            ListItem item3 = list.Items.Add("Task Three");

            UnorderedSubList ul = list.Items[0].SubLists.AddUnorderedSubList(UnorderedListStyle.Circle);
            ul.Items.Add("Item One");
            ul.Items.Add("Item Two");
            ul.Items.Add("Item Three");

            UnorderedSubList ul2 = list.Items[0].SubLists.AddUnorderedSubList(UnorderedListStyle.Disc);
            ul2.Items.Add("Sub Item One");
            ul2.Items.Add("Sub Item Two");
            ul2.Items.Add("Sub Item Three");

            OrderedSubList ol = ul2.Items[1].SubLists.AddOrderedSubList(NumberingStyle.Numeric);
            ol.Items.Add("Step One");
            ol.Items.Add("Step Two");
            ol.Items.Add("Step Three");

            doc.Pages[0].Elements.Add(list);

            AddGridLines.AddBackgroundColor(doc);

            doc.Draw(outputPath);

        }
    }
}
