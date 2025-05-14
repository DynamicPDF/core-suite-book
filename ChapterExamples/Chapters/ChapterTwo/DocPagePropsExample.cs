using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterTwo
{
    public class DocPagePropsExample
    {
        public static void Create(string outputPath)
        {
            Document myDoc = new();
            myDoc.Title = "DynamicPDF Ch2 Properties Example";
            myDoc.Author = "James Brannan";
            myDoc.Creator = "James Brannan";
            myDoc.Subject = "DynamicpDF Core Suite by Example";
            myDoc.Keywords = "DynamicPDF Book Example";
            myDoc.CustomProperties.Add("A Custom Property", "A custom value");
            Page myPg = new();
            Label myLabel = new("Document Properties Example", 50, 50, 200, 50);
            myPg.Elements.Add(myLabel);
            myDoc.Pages.Add(myPg);
            myDoc.Draw(outputPath + "ch2-DocsPagePropsExample-out.pdf");
        }
    }
}
