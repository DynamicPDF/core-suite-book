
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterFour
{
    public class AutoLayoutExample
    {
        public static void Create(string outputPath)
        {
            AutoLayout autoLayout = new AutoLayout(PageSize.Legal, PageOrientation.Landscape, 50);

            string txt1 = TextGenerator.GenerateText();
            TextArea txtOne = autoLayout.AddText(txt1);
            txtOne.Align = TextAlign.Justify;

            Note commentNote = autoLayout.AddNote("Hello DynamicPDF Core Suite.", 100);
            commentNote.NoteType = NoteType.Help;

            OrderedList list =autoLayout.AddOrderedList();
            list.ListItemTopMargin = 5;
            list.ListItemBottomMargin = 5;
            ListItem item1 = list.Items.Add("First Item");
            ListItem item2 = list.Items.Add("Second Item");
            ListItem item3 = list.Items.Add("Third Item");

            UnorderedList ul = autoLayout.AddUnorderedList();
            ul.Items.Add("One");
            ul.Items.Add("Two");
            ul.Items.Add("Three");

            UrlAction action = new UrlAction("https://dpdf.io");
            Link link = autoLayout.AddAutoLink("DynamicPDF API Website", action);

            Document document = autoLayout.GetDocument();
            document.Draw(outputPath);

        }

    }
}
