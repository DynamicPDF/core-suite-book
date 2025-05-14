using ceTe.DynamicPDF;

namespace ChapterExamples.Chapters.ChapterTwo
{
    public class DocumentPage
    {
        public static void Create(string resourcePath, string outputPath)
        {
            Document myDoc = new();
            Page myPg = new();
            Page myPg2 = new();
            myDoc.Pages.Add(myPg);
            myDoc.Pages.Add(myPg2);
            myDoc.Draw(outputPath + "ch2-DocumentPage-out.pdf");
        }
    }
}
