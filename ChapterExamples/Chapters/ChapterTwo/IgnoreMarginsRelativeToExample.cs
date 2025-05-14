using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterTwo
{
    public class IgnoreMarginsRelativeToExample
    {

        public static void Create(string resourcePath, string outputPath)
        {
            Document myDoc = new();
            Page myPg = new();
            myDoc.Pages.Add(myPg);

            Image image = new Image(resourcePath + "/egypt.jpg", 0, 0);
            image.ScaleX = 0.15F;
            image.ScaleY = 0.15F;
            image.IgnoreMargins = true;
            myPg.Elements.Add(image);

            Image image2 = new Image(resourcePath + "/egypt.jpg", 0, 0);
            image2.ScaleX = 0.15F;
            image2.ScaleY = 0.15F;
            myPg.Elements.Add(image2);

            Image image3 = new Image(resourcePath + "/egypt.jpg", 0, 0);
            image3.ScaleX = 0.15F;
            image3.ScaleY = 0.15F;
            image3.RelativeTo = RelativeTo.BottomLeft;
            image3.Y = -image3.Height;
            myPg.Elements.Add(image3);

            LayoutGrid layGrd = new();
            layGrd.Type = LayoutGrid.GridType.Standard;
            layGrd.ShowTitle = false;
            myPg.Elements.Add(layGrd);


            myDoc.Draw(outputPath + "ch2-ignore-margins-out.pdf");
        }
    }
}
