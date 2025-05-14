
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.BarCoding;

namespace ChapterExamples.Chapters.ChapterTwelve
{
    public class UPCExamples
    {
        public static void Create(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter, PageOrientation.Portrait));
            UPCA(doc.Pages[0]);
            UPCA2(doc.Pages[0]);
            UPCA5(doc.Pages[0]);
            UPCE(doc.Pages[0]);
            UPCE2(doc.Pages[0]);
            UPCE5(doc.Pages[0]);
            doc.Draw(outputPath + "barcodes-out.pdf");
        }

        public static void UPCA(Page page)
        {
            UpcVersionA barCode = new UpcVersionA("12345678901", 50, 0);
            page.Elements.Add(barCode);
            page.Elements.Add(new Label("UPC-A", 0, 50, 100, 0));
        } 

        public static void UPCA2(Page page)
        {
            UpcVersionASup2 barCode = new("1234567890199", 50, 100);
            page.Elements.Add(barCode);
            page.Elements.Add(new Label("UPC-A2", 0, 150, 100, 0));
        }

        public static void UPCA5(Page page) {         
            UpcVersionASup5 barCode = new("1234567890199999", 50, 200);
            page.Elements.Add(barCode);
            page.Elements.Add(new Label("UPC-A5", 0, 220, 100, 0));
        }

        public static void UPCE(Page page)
        {
            UpcVersionE barCode = new("1234567", 100, 300);
            page.Elements.Add(barCode);
            page.Elements.Add(new Label("UPC-E", 0, 350, 100, 0));
        }

        public static void UPCE2(Page page)
        {
            UpcVersionESup2 barCode = new("123456799", 50, 400);
            page.Elements.Add(barCode);
            page.Elements.Add(new Label("UPC-E2", 0, 450, 100, 0));
        }

        public static void UPCE5(Page page)
        {
            UpcVersionESup5 barCode = new("123456799999", 50, 500);
            page.Elements.Add(barCode);
            page.Elements.Add(new Label("UPC-E5", 0, 550, 100, 0));
        }

    }
}
