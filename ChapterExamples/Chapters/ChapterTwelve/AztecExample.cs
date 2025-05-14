using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.BarCoding;

namespace ChapterExamples.Chapters.ChapterTwelve
{
    public class AztecExample
    {
        public static void Create(string ouputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter, PageOrientation.Portrait));
            Aztec az = new("www.dynamicpdf.com", 100, 100, AztecSymbolSize.Full, 5);
            doc.Pages[0].Elements.Add(az);
            doc.Draw(ouputPath + "azcode-out.pdf");
        }
    }
}