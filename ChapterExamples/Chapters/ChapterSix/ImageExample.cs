using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Imaging;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterSix
{
    public class ImageExample
    {
        public static void Create(string resourcePath, string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            Image img1 = new(resourcePath + "/ch2/egypt.jpg",100,100);
            img1.ScaleX = .25f;
            img1.ScaleY = .25f;

            Image img2 = new(resourcePath + "ch2/egypt.jpg", 100, 100);
            img2.SetDpi(12);
            img2.Width = 146;
            img2.Height = 206;

            Image img3 = new(resourcePath + "/ch2/egypt.jpg", 0, 0);
            img3.Width = 374;
            img3.Height = 543;


            Image img4 = new(resourcePath + "/ch2/egypt.jpg", 0, 0);
            img4.SetBounds(200, 200);

            doc.Pages[0].Elements.Add(img1);

            doc.Pages.Add(new Page(PageSize.Letter));
            doc.Pages[1].Elements.Add(img2);

            doc.Pages.Add(new Page(PageSize.Letter));
            doc.Pages[2].Elements.Add(img3);

            doc.Pages.Add(new Page(PageSize.Letter));
            doc.Pages[3].Elements.Add(img4);

            Utility.AddGridLines.AddBackgroundColor(doc);

            doc.Draw(outputPath);
        }

    }
}
