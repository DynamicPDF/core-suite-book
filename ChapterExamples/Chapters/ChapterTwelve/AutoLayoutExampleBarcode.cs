using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.BarCoding;

namespace ChapterExamples.Chapters.ChapterTwelve
{
    public class AutoLayoutExampleBarcode
    {
        public static void Create(string outputPath)
        {
            AutoLayout autoLayout = new AutoLayout(PageSize.Letter, PageOrientation.Portrait, 50);
            Aztec az = autoLayout.AddAztec("www.dynamicpdf.com", AztecSymbolSize.Full);
            Document document = autoLayout.GetDocument();
            document.Draw(outputPath);
        }
    }
}
