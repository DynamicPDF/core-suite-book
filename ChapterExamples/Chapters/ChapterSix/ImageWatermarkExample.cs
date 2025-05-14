using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterSix
{
    public class ImageWatermarkExample
    {
        public static void Create(string resourcePath, string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            TextArea txt = new(TextGenerator.GenerateTextMultiple(3), 0, 0, 512, 692);

            ImageWatermark watermark = new(resourcePath);

            doc.Pages[0].Elements.Add(txt);
            doc.Pages[0].Elements.Add(watermark);
            doc.Draw(outputPath);
        }
    }
}
