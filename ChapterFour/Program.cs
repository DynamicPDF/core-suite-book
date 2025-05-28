using ChapterExamples.Chapters.ChapterFour;
using ChapterExamples.Utility;

namespace ChapterFour
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.CreatePath("output/ch4");
            LinkExample.Create(FileUtility.GetPath("output/ch4/link-out.pdf"));
            PageNumberingLabelsExample.Create(FileUtility.GetPath("output/ch4/page-numbering-labels-out.pdf"));
            NotesExample.Create(FileUtility.GetPath("output/ch4/notes-out.pdf"));
            LabelExample.Create(FileUtility.GetPath("output/ch4/label-out.pdf"));
            TextAreaExample.Create(FileUtility.GetPath("output/ch4/textarea-out.pdf"));
            TextOverflowExample.Create(FileUtility.GetPath("output/ch4/textarea-overflow-out.pdf"));
            FormattedTextAreaExample.Create(FileUtility.GetPath("output/ch4/formatted-textarea-out.pdf"));
            HtmlAreaExample.Create(FileUtility.GetPath("output/ch4/html-area-out.pdf"));
            HtmlListExample.Create(FileUtility.GetPath("output/ch4/html-list-out.pdf"));
            OrderedListExample.Create(FileUtility.GetPath("output/ch4/ordered-list-out.pdf"));
            UnorderedListExample.Create(FileUtility.GetPath("output/ch4/unordered-list-out.pdf"));
            CombinedListExample.Create(FileUtility.GetPath("output/ch4/combined-list-out.pdf"));
            ListOverflowexample.Create(FileUtility.GetPath("output/ch4/overflow-list-out.pdf"));
            TextWatermarkExample.Create(FileUtility.GetPath("output/ch4/text-watermark-out.pdf"));
            AutoLayoutExample.Create(FileUtility.GetPath("output/ch4/autolayout-out.pdf"));
        }
    }
}
