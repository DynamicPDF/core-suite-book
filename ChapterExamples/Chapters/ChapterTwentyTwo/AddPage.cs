using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterTwentyTwo
{
    public class AddPage
    {
        public static void Modify(string resourcePath, string outputPath)
        {
            AddSinglePage(resourcePath, outputPath);
            AddMultiplePage(resourcePath, outputPath);
            AddSingleImportedPage(resourcePath, outputPath);
            ImportMultiplePages(resourcePath, outputPath);
        }

        public static void AddMultiplePage(string resourcePath, string outputPath)
        {
            MergeDocument mergedDoc = new();
            Page cvrPage = new Page(PageSize.Letter);
            Label lbl = new Label("Cover Page", 10, 400, 600, 0);
            lbl.FontSize = 54;

            cvrPage.Elements.Add(lbl);
            mergedDoc.Pages.Add(cvrPage);

            PdfDocument pdfDoc = new(resourcePath + "doc1.pdf");
            PdfDocument pdfDoc2 = new(resourcePath + "doc2.pdf");
            PdfDocument pdfDoc3 = new(resourcePath + "doc4.pdf");

            Page dvdrPage = new Page(PageSize.Letter);
            Label lbl2 = new Label("Divider Page", 100, 500, 600, 0);
            lbl2.FontSize = 54;
            dvdrPage.Elements.Add(lbl2);

            mergedDoc.Append(pdfDoc, 1, 1);
            mergedDoc.Pages.Insert(mergedDoc.Pages.Count, dvdrPage);
            mergedDoc.Append(pdfDoc2, 1, 1);
            mergedDoc.Pages.Insert(mergedDoc.Pages.Count, dvdrPage);
            mergedDoc.Append(pdfDoc3, 1, 1);
            mergedDoc.Draw(outputPath + "merge-multiple-pages-out.pdf");
        }

        public static void AddSinglePage(string resourcePath, string outputPath)
        {
            MergeDocument mergedDoc = new();
            Page page = new Page(PageSize.Letter);

            Label lbl = new Label("Cover Page", 10, 400, 600, 0);
            lbl.FontSize = 54;
            lbl.TextColor = RgbColor.Blue;
            lbl.TextOutlineColor = RgbColor.Black;
            lbl.TextOutlineWidth = 1;

            page.Elements.Add(lbl);
            mergedDoc.Pages.Add(page);
            mergedDoc.Draw(outputPath + "merge-single-page-out.pdf");
        }


        public static void AddSingleImportedPage(string resourcePath, string outputPath)
        {
            MergeDocument mergedDoc = new();
            ImportedPage page = new ImportedPage(resourcePath + "doc3.pdf", 1);

            Label lbl = new Label("Additional SubTitle", 30, 400, 600, 0);
            lbl.FontSize = 34;
            lbl.TextColor = RgbColor.Red;
            lbl.TextOutlineColor = RgbColor.Black;
            lbl.TextOutlineWidth = 1;

            page.Elements.Add(lbl);
            mergedDoc.Pages.Add(page);

            MergeOptions mergeOptions = new();
            mergeOptions.PageLabelsAndSections = false;
            mergeOptions.Outlines = false;

            mergedDoc.Append(resourcePath + "doc1.pdf", mergeOptions);
            mergedDoc.Draw(outputPath + "merge-single-page-importedpage-out.pdf");
        }

        public static void ImportMultiplePages(string resourcePath, string outputPath)
        {
            MergeDocument mergedDoc = new();
            ImportedPage page = new ImportedPage(resourcePath + "doc1.pdf", 1);
            PdfDocument pdfdoc = new PdfDocument(resourcePath + "doc2.pdf");
            ImportedPage page2 = new ImportedPage(pdfdoc.Pages[2]);
            mergedDoc.Pages.Add(page);
            mergedDoc.Pages.Add(page2);
            mergedDoc.Draw(outputPath + "merge-multiple-page-importedpage-out.pdf");
        }
    }
}
