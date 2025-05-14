

using ceTe.DynamicPDF.Merger;

namespace ChapterExamples.Chapters.ChapterTwentyTwo
{
    public class MergingExample
    {
        public static void Modify(string resourcePath, string outputPath)
        {
            SimpleMerge(resourcePath, outputPath);
            SimpleAppend(resourcePath, outputPath);
            SimpleAppendPages(resourcePath, outputPath);
            SimpleAppendTwoPages(resourcePath, outputPath);
            MergeOptionsExample(resourcePath, outputPath);
            MergeOptionsStaticExample(resourcePath, outputPath);
        }

        public static void SimpleMerge(string resourcePath, string outputPath)
        {
            MergeDocument mergedDoc = MergeDocument.Merge(resourcePath + "doc1.pdf", resourcePath + "doc2.pdf");
            mergedDoc.Draw(outputPath + "simple-merge-out.pdf");
        }

        public static void SimpleAppend(string resourcePath, string outputPath)
        {
            MergeDocument mergedDoc = MergeDocument.Merge(resourcePath + "doc1.pdf", resourcePath + "doc2.pdf");
            mergedDoc.Append(resourcePath + "doc3.pdf");
            mergedDoc.Draw(outputPath + "append-merge-out.pdf");
        }

        public static void SimpleAppendTwo(string resourcePath, string outputPath)
        {
            MergeDocument mergedDoc = new(resourcePath + "doc1.pdf");
            mergedDoc.Append(resourcePath + "doc2.pdf");
            mergedDoc.Append(resourcePath + "doc3.pdf");
            mergedDoc.Draw(outputPath + "append-merge-two-out.pdf");
        }

        public static void SimpleAppendTwoPages(string resourcePath, string outputPath)
        {
            MergeDocument mergedDoc = new(resourcePath + "doc1.pdf", 1,3);
            mergedDoc.Append(resourcePath + "doc2.pdf", 3, 1);
            mergedDoc.Append(resourcePath + "doc3.pdf", 2,1);
            mergedDoc.Draw(outputPath + "append-merge-pages-two-out.pdf");
        }

        public static void SimpleAppendPages(string resourcePath, string outputPath)
        {
            PdfDocument pdfDoc1 = new(resourcePath + "doc1.pdf");
            PdfDocument pdfDoc2 = new(resourcePath + "doc2.pdf");
            MergeDocument mergedDoc = MergeDocument.Merge(pdfDoc1, pdfDoc2);
            mergedDoc.Append(resourcePath + "doc3.pdf", 1, 2);
            mergedDoc.Draw(outputPath + "append-pages-merge-out.pdf");
        }

        public static void MergeOptionsExample(string resourcePath, string outputPath)
        {
            MergeOptions mergeOptions = new();
            mergeOptions.PageLabelsAndSections = false;
            mergeOptions.Outlines = false;
            MergeDocument mergedDoc = MergeDocument.Merge(resourcePath + "doc1.pdf", mergeOptions, resourcePath + "doc2.pdf", mergeOptions);
            mergedDoc.Append(resourcePath + "doc3.pdf", mergeOptions);

            mergedDoc.Draw(outputPath + "merge-options-merge-out.pdf");
        }

        public static void MergeOptionsStaticExample(string resourcePath, string outputPath)
        {
            MergeDocument mergedDoc = MergeDocument.Merge(resourcePath + "doc1.pdf", MergeOptions.None, resourcePath + "doc2.pdf", MergeOptions.None);
            mergedDoc.Append(resourcePath + "doc6.pdf", MergeOptions.All);
            mergedDoc.Draw(outputPath + "merge-options-static-merge-out.pdf");
        }

    }
}
