

using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;
using System;

namespace ChapterExamples.Chapters.ChapterTwentyTwo
{
    public class ExtractElements
    {
        public static void Modify(string resourcePath, string outputPath)
        {
            AddNewPageAndImage(resourcePath, outputPath);
            AddToExistingPageAndImage(resourcePath, outputPath);
            ExtractAllElements(resourcePath, outputPath);
        }

        public static void AddNewPageAndImage(string resourcePath, string outputPath)
        {
            Page page = new Page(PageSize.Letter);

            PdfDocument pdfDoc = new(resourcePath + "doc1.pdf");
            PdfDocument pdfDoc2 = new(resourcePath + "doc2.pdf");
            PdfDocument pdfDoc3 = new(resourcePath + "doc4.pdf");

            MergeOptions mergeOptions = new();
            mergeOptions.PageLabelsAndSections = false;
            mergeOptions.Outlines = false;

            MergeDocument mergedDoc = new();
            PdfPage pdfPage = pdfDoc3.GetPage(1);
            ImageInformation imageInfo = pdfPage.GetImages()[0];
            Image image = new Image(imageInfo.GetImage().Data, 0, 0, .5F);
            Label lbl = new Label("Combined Report", 10, 400, 600, 0);
            lbl.FontSize = 54;
            lbl.TextColor = RgbColor.Blue;
            lbl.TextOutlineColor = RgbColor.Black;
            lbl.TextOutlineWidth = 1;

            page.Elements.Add(image);
            page.Elements.Add(lbl);
            mergedDoc.Pages.Add(page);
            mergedDoc.Append(pdfDoc);
            mergedDoc.Append(pdfDoc2);
            mergedDoc.Draw(outputPath + "merge-addImage-new-page-out.pdf");
        }

        public static void AddToExistingPageAndImage(string resourcePath, string outputPath)
        {           
            MergeOptions mergeOptions = new();
            mergeOptions.PageLabelsAndSections = false;
            mergeOptions.Outlines = false;
            MergeDocument mergedDoc = new(resourcePath + "doc1.pdf", mergeOptions);

            PdfDocument pdfDoc2 = new(resourcePath + "doc4.pdf");
            PdfPage pdfPage = pdfDoc2.GetPage(1);
            ImageInformation imageInfo = pdfPage.GetImages()[0];
            Image image = new Image(imageInfo.GetImage().Data, 0, 0, .5F);
            Label lbl = new Label("Combined Report", 10, 400, 600, 0);
            lbl.FontSize = 54;
            lbl.TextColor = RgbColor.Blue;
            lbl.TextOutlineColor = RgbColor.Black;
            lbl.TextOutlineWidth = 1;

            
            mergedDoc.Pages[0].Elements.Add(image);
            mergedDoc.Pages[0].Elements.Add(lbl);

            mergedDoc.Draw(outputPath + "merge-addImage-existing-page-out.pdf");
        }

        public static void ExtractAllElements(string resourcePath, string outputPath)
        {
            PdfDocument pdfDoc = new(resourcePath + "doc7.pdf");
            PdfPage pdfPage = pdfDoc.Pages[0];
            ImportedPage impPage = new ImportedPage(pdfPage);
            Group group = impPage.Elements;
            

            foreach(Object obj in group)
            {
                Console.WriteLine(obj.GetType());
            }

          
        }

    }
}
