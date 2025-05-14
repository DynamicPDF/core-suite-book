
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.BarCoding;

namespace ChapterExamples.Chapters.ChapterTwelve
{
    public class EANExample
    {
        public static void Create(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter, PageOrientation.Portrait));
            EAN13(doc.Pages[0]);
            EAN132(doc.Pages[0]);
            EAN135(doc.Pages[0]);
            EAN8(doc.Pages[0]);
            EAN82(doc.Pages[0]);
            EAN85(doc.Pages[0]);
            doc.Draw(outputPath + "ean-out.pdf");
        }

        public static void EAN13(Page page)
        {
            Ean13 barCode = new Ean13("123456789012", 50, 0);
            page.Elements.Add(barCode);
            page.Elements.Add(new Label("EAN13", 0, 50, 100, 0));
        }

        public static void EAN132(Page page)
        {
            Ean13Sup2 barCode = new("12345678901299", 50, 100);
            page.Elements.Add(barCode);
            page.Elements.Add(new Label("EAN13-2", 0, 150, 100, 0));
        }

        public static void EAN135(Page page)
        {
            Ean13Sup5 barCode = new("12345678901299999", 50, 200);
            page.Elements.Add(barCode);
            page.Elements.Add(new Label("EAN13-5", 0, 220, 100, 0));
        }

        public static void EAN8(Page page)
        {
            Ean8 barCode = new("12345670", 100, 300);
            page.Elements.Add(barCode);
            page.Elements.Add(new Label("EAN8", 0, 350, 100, 0));
        }

        public static void EAN82(Page page)
        {
            Ean8Sup2 barCode = new("1234567199", 50, 400);
            page.Elements.Add(barCode);
            page.Elements.Add(new Label("EAN8-2", 0, 450, 100, 0));
        }

        public static void EAN85(Page page)
        {
            Ean8Sup5 barCode = new("123456799999", 50, 500);
            page.Elements.Add(barCode);
            page.Elements.Add(new Label("EAn8-5", 0, 550, 100, 0));
        }
    }
}
