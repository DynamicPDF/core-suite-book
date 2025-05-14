using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterOne
{
    public class SimpleMerge
    {

        public static void Modify(string resourcePath, string outputPath)
        {
            MergeDocument mergedDoc = MergeDocument.Merge(resourcePath + "doc1.pdf", resourcePath + "doc2.pdf");
            mergedDoc.Append(resourcePath + "doc3.pdf");
            Page page = new Page(PageSize.Letter);
            page.Elements.Add(new Label("Hello Modified PDF", 10, 50, 150, 0));
            mergedDoc.Pages.Insert(0, page);
            mergedDoc.Draw(outputPath + "simple-merge-out.pdf");
        }
    }
}
