

using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterTwentyTwo
{
    public class ImportingPages
    {
        public static void Modify(string resourcePath, string outputPath)
        {
            AddSingleImportedPage(resourcePath, outputPath);
            AddImportPageData(resourcePath, outputPath);
            AddAndClipImportedPage(resourcePath, outputPath);
            AddingContent(resourcePath, outputPath);
            ImportedPageContentsExample(resourcePath, outputPath);
            ImportedPageContentTemplates(resourcePath, outputPath);
        }

        public static void AddingContent(string resourcePath, string outputPath)
        {
            MergeDocument mergedDoc = new MergeDocument();
            ImportedPage page = new ImportedPage(resourcePath + "doc1.pdf", 1);
            page.Elements.Add(new Image(resourcePath + "../ch2/egypt.jpg", 100, 175, .5f));
            Label lbl = new Label("Label Text", 50, 75, 200, 12);
            lbl.FontSize = 72;
            lbl.TextColor = RgbColor.White;
            lbl.TextOutlineColor = RgbColor.Red;
            lbl.TextOutlineWidth = 3;
            page.Elements.Add(lbl);
            Rectangle rec = new Rectangle(10, 50, 250, 500, RgbColor.Black, RgbColor.DarkRed);
            page.BackgroundElements.Add(rec);
            mergedDoc.Pages.Add(page);
            mergedDoc.Draw(outputPath + "import-page-adding-content-out.pdf");
        }

        public static void AddSingleImportedPage(string resourcePath, string outputPath)
        {
            MergeDocument mergedDoc = new(resourcePath + "doc5.pdf", MergeOptions.None);
            ImportedPage page = new ImportedPage(resourcePath + "doc4.pdf", 1);
            PageDimensions dimensions = new PageDimensions(PageSize.Letter, PageOrientation.Portrait);
            page.Dimensions = dimensions;

            ImportedPage page2 = new ImportedPage(resourcePath + "doc2.pdf", 3, 150);
            Label lbl = new("Margin 150", 0, 0, 200, 0);
            lbl.TextColor = RgbColor.Red;
            lbl.FontSize = 32;
            page2.Elements.Add(lbl);
            mergedDoc.Pages.Add(page);
            mergedDoc.Pages.Add(page2);
            mergedDoc.Draw(outputPath + "import-page-out.pdf");
        }

        public static void AddImportPageData(string resourcePath, string outputPath)
        {
            MergeDocument mergedDoc = new();
            Page page = new Page(PageSize.Tabloid, PageOrientation.Landscape);
            page.Elements.Add(new ImportedPageData(resourcePath + "doc3.pdf", 1, -306, 0, .75F));
            ImportedPageData ipd = new ImportedPageData(resourcePath + "doc4.pdf", 1, 306, 0);
            ipd.Angle = -90;
            page.Elements.Add(ipd);
            mergedDoc.Pages.Add(page);
            mergedDoc.Draw(outputPath + "import-page-data-out.pdf");
        }

        public static void AddAndClipImportedPage(string resourcePath, string outputPath)
        {
            MergeDocument mergedDoc = new();
            Page page = new Page(PageSize.Legal, PageOrientation.Landscape);
            ImportedPageArea importedPageArea = new ImportedPageArea(resourcePath + "doc3.pdf", 1, 0, 0, .5f);
            importedPageArea.Contents.ClipLeft = 0;
            importedPageArea.Contents.ClipTop = 50;
            importedPageArea.Contents.ClipRight = 100;
            importedPageArea.Contents.ClipBottom = 5;
            page.Elements.Add(importedPageArea);
            mergedDoc.Pages.Add(page);
            
            Page page2 = new Page(PageSize.Legal, PageOrientation.Landscape);
            ImportedPageArea importedPageArea2 = new ImportedPageArea(resourcePath + "doc4.pdf", 1, 0, 0, 1f);
            importedPageArea2.SetBounds(300, 300);
            page2.Elements.Add(importedPageArea2);
            mergedDoc.Pages.Add(page2);
            mergedDoc.Draw(outputPath + "import-page-clipped-out.pdf");
        }

        public static void ImportedPageContentsExample(string resourcePath, string outputPath)
        {
            MergeDocument mergedDoc = new();
            ImportedPageArea importedPageArea = new ImportedPageArea(resourcePath + "doc4.pdf", 1, 0, 0, .25f);
            importedPageArea.SetBounds(100, 100);
            ImportedPageContents importedPageContents = importedPageArea.Contents;
            Page page = new Page(PageSize.Legal, PageOrientation.Landscape);

            for (int i = 0; i < 10; i++)
            {    
                ImportedPageArea area = new ImportedPageArea(importedPageContents, i * 50, i * 50);
                area.SetBounds(100, 100);
                page.Elements.Add(area);

            }

            mergedDoc.Pages.Add(page);
            mergedDoc.Draw(outputPath + "import-page-content-out.pdf");
        }

        public static void ImportedPageContentTemplates(string resourcePath, string outputPath)
        {
            MergeDocument mergedDoc = new();
            ImportedPage importedPage = new ImportedPage(resourcePath + "doc3.pdf", 2);
            importedPage.ApplySectionTemplate = false;
            
            mergedDoc.Pages.Add(importedPage);
            mergedDoc.Draw(outputPath + "import-page-template-out.pdf");
        }

    }
}
