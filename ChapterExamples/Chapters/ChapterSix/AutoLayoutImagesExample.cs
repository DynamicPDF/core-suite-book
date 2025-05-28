
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterSix
{
    public class AutoLayoutImagesExample
    {
        public static void Create(string resourcePath, string outputPath)
        {
            AutoLayout autoLayout = new AutoLayout(PageSize.Letter, PageOrientation.Portrait, 50);

            Image img1 = autoLayout.AddImage(resourcePath + "ch2/egypt.jpg");
            img1.X = 100;
            img1.Y = 100;
            img1.ScaleX = .25f;
            img1.ScaleY = .25f;


            Document document = autoLayout.GetDocument();
            document.Draw(outputPath);

        }
    }
}
