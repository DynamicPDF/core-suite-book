
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterSix
{
    class ImageDifferentTypesExample
    {
        public static void Create(string resourcePath, string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            

            Image img1 = new(resourcePath + "/ch2/egypt.jpg", 100, 100);
        }
    }
}
