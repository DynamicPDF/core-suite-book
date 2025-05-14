using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterTwo
{
    public class ViewerPrefExample
    {
        public static void Create(string outputPath)
        {
            Document myDoc = new();
            myDoc.Title = "DynamicPDF Ch2 Viewer Preferences Example";
            myDoc.ViewerPreferences.CenterWindow = true;
            myDoc.ViewerPreferences.HideMenubar = true;
            myDoc.ViewerPreferences.DisplayDocTitle = true;
            myDoc.ViewerPreferences.HideToolbar = true;
            myDoc.ViewerPreferences.FitWindow = true;

            Page myPg = new(PageSize.Postcard, PageOrientation.Landscape, 5F);
            Label myLabel = new("Viewer Preferences Example", 50, 50, 200, 50);
            myPg.Elements.Add(myLabel);
            myDoc.Pages.Add(myPg);
            myDoc.Draw(outputPath + "ch2-ViewerPrefExample-out.pdf");
        }
    }
}
