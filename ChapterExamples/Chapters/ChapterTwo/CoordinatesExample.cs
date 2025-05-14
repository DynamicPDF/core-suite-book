using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterTwo
{
    public class CoordinatesExample
    {
        public static void Create(string resourcePath, string outputPath)
        {
            Document myDoc = new();
            Page myPg = new();
            myDoc.Pages.Add(myPg);
            float centerX = (myPg.Dimensions.Width - myPg.Dimensions.LeftMargin - myPg.Dimensions.RightMargin) / 2;
            float centerY = (myPg.Dimensions.Height - myPg.Dimensions.TopMargin - myPg.Dimensions.BottomMargin) / 2;
            Image image = new Image(resourcePath + "/idea.png", centerX, centerY);
            image.VAlign = VAlign.Center;
            image.Align = Align.Center;
            myPg.Elements.Add(image);
            myDoc.Draw(outputPath + "ch2-CoordinatesExample-out.pdf");
            Aside(resourcePath, outputPath);
        }

        public static void Aside(string resourcePath, string outputPath)
        {
            Document myDoc = new();
            Page myPg = new();
            myDoc.Pages.Add(myPg);
            Image image = new Image(resourcePath + "/idea.png", myPg.Dimensions.RightMargin * -1, myPg.Dimensions.TopMargin * -1);
            myPg.Elements.Add(image);
            myDoc.Draw(outputPath + "ch2-CoordinateExample-Aside-out.pdf");

            Document myDoc1 = new();
            Page myPg1 = new();
            myDoc1.Pages.Add(myPg1);
            Image image1 = new Image(resourcePath + "/idea.png",
              0, 0);
            myPg1.Elements.Add(image1);
            myDoc1.Draw(outputPath + "ch2-CoordinateExample-Aside-1-out.pdf");
        }

    }
}
