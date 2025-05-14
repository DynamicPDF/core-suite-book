

using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterTwentyTwo
{
    public class ExtractingText
    {
        public static void Modify(string resourcePath, string outputPath)
        {
            ExtractTextMergeDocument(resourcePath, outputPath);
            ExtractTextAreaMergeDocument(resourcePath, outputPath);
        }

        public static void ExtractTextMergeDocument(string resourcePath, string outputPath)
        {
            MergeDocument doc = new();
            PdfDocument pdf1 = new PdfDocument(resourcePath + "doc5.pdf");
            string txt = pdf1.Pages[0].GetText();
            Page page = new Page(PageSize.Letter);
            page.Elements.Add(new TextArea(txt, 0, 0, 700, 700));
            doc.Pages.Add(page);
            doc.Draw(outputPath + "extract-text1-output.pdf");
        }

        public static void ExtractTextAreaMergeDocument(string resourcePath, string outputPath)
        {
            MergeDocument doc = new();
            PdfDocument pdf1 = new PdfDocument(resourcePath + "doc5.pdf");
            string extractedText = pdf1.Pages[0].GetText(50, 50, 512, 692);
            Page page = new Page(PageSize.Letter);
            page.Elements.Add(new TextArea(extractedText, 50, 50, 612, 692));
            doc.Pages.Add(page);
            doc.Draw(outputPath + "extract-text2-output.pdf");
        }
    }
}
