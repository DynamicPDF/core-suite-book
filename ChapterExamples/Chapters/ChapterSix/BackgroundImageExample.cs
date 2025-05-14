using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterSix
{
    public class BackgroundImageExample
    {
        public static void Create(string resourcePath, string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            TextArea txt = new(TextGenerator.GenerateTextMultiple(3), 0, 0, 512, 692);
            BackgroundImage img = new(resourcePath);
          

            doc.Pages[0].Elements.Add(img);

            doc.Pages[0].Elements.Add(txt);
            doc.Draw(outputPath);
        }
    }
}
