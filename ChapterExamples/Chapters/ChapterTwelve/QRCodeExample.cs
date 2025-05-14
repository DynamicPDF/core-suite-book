using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.BarCoding;

namespace ChapterExamples.Chapters.ChapterTwelve
{
    public class QRCodeExample
    {
        public static void Create(string ouputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter, PageOrientation.Portrait));
            QrCode qr = new("www.dynamicpdf.com", 100, 100);
            doc.Pages[0].Elements.Add(qr);
            doc.Draw(ouputPath + "qrcode-out.pdf");
        }
    }
}
