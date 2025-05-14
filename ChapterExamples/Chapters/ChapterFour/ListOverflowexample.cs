using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterFour
{
    public class ListOverflowexample
    {
        public static void Create(string outputPath)
        {
            Document doc = new Document();
           
            OrderedList list = new OrderedList(50, 50, 300, 500);

            list.ListItemTopMargin = 5;
            list.ListItemBottomMargin = 5;

            for(int i = 0; i < 10; i++)
            {
                ListItem item1 = list.Items.Add("Item " + i);

                if (i % 3 == 0)
                {
                    OrderedSubList subList = item1.SubLists.AddOrderedSubList(NumberingStyle.AlphabeticLowerCase);

                    for (int j = 0; j< 5;j++)
                    {
                        ListItem subItem = subList.Items.Add("Sub Item " + j);
                    }
                }
            }
                       
            do
            {
                Page page = new Page();
                page.Elements.Add(list);
                doc.Pages.Add(page);
                list = list.GetOverFlowList();
            } while (list != null);

            AddGridLines.AddBackgroundColor(doc);
            doc.Draw(outputPath);

        }
    }
}
