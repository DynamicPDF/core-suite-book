using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterFour
{
    public class OrderedListExample
    {
        public static void Create(string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));
            
            OrderedList list = new OrderedList(50, 50, 300, 500);
            

            list.ListItemTopMargin = 5;
            list.ListItemBottomMargin = 5;

            ListItem item1 = list.Items.Add("Paint Kitchen");
            ListItem item2 = list.Items.Add("Paint Living Room");
            ListItem item3 = list.Items.Add("Paint Dining Room");

            OrderedSubList subList1 = item1.SubLists.AddOrderedSubList(NumberingStyle.RomanUpperCase);
            ListItem item5 = subList1.Items.Add("Paint Ceiling");
            ListItem item6 = subList1.Items.Add("Paint Walls");

            AddGridLines.AddBackgroundColor(doc);
            AddGridLines.AddMargins(doc.Pages[0]);

            doc.Pages[0].Elements.Add(list);

            doc.Draw(outputPath);

        }
    }
}
