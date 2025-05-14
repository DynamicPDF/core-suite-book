using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterOne
{
    public class CreatePdf
    {
        public static void Create(string outputPath)
        {
            Document myDoc = new();
            Page myPg = new();
            myDoc.Pages.Add(myPg);
            Label myLabel = new("Hello DynamicPDF Core Suite.", 50, 50, 200, 50);
            myPg.Elements.Add(myLabel);
            myDoc.Draw(outputPath);
        }       
    }
}
