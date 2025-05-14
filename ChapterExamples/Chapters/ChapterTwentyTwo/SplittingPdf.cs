using ceTe.DynamicPDF.Merger;

namespace ChapterExamples.Chapters.ChapterTwentyTwo
{
    public class SplittingPdf
    {
        public static void Modify(string resourcePath, string outputPath)
        {
            MergeDocument mergedDocCover = new(resourcePath + "doc3.pdf", 1, 1);
            mergedDocCover.Draw(outputPath + "spit-pages-1-out.pdf");
             
            MergeDocument mergedDoc1 = new(resourcePath + "doc3.pdf", 2, 5);
            mergedDoc1.Draw(outputPath + "spit-pages-2-out.pdf");

            MergeDocument mergedDoc2 = new(resourcePath + "doc3.pdf", 7, 5);
            mergedDoc2.Draw(outputPath + "spit-pages-3-out.pdf");

            MergeDocument mergedDoc3 = new(resourcePath + "doc3.pdf", 12, 5);
            mergedDoc3.Draw(outputPath + "spit-pages-4-out.pdf");

        }
    }
}
