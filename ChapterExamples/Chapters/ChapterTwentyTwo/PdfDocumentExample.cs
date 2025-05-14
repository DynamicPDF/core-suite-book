
using ceTe.DynamicPDF.Merger;

namespace ChapterExamples.Chapters.ChapterTwentyTwo
{
    class PdfDocumentExample
    {
        public static void Modify(string resourcePath, string outputPath)
        {

            PdfDocument pdfDoc = new(resourcePath + "doc1.pdf");
            PdfDocument pdfDoc2 = new(resourcePath + "doc3.pdf");
            PdfDocument pdfDoc3 = new(resourcePath + "doc3.pdf");

            MergeOptions mergeOptions = new();
            mergeOptions.PageLabelsAndSections = false;
            mergeOptions.Outlines = false;

            MergeDocument mergedDoc = MergeDocument.Merge(pdfDoc, pdfDoc2);
            mergedDoc.Append(pdfDoc3);

            mergedDoc.Draw(outputPath + "merge-pdfdoc-out.pdf");

        }
    }
}
