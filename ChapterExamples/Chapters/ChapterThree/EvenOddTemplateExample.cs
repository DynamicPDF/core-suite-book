using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterThree
{
    public class EvenOddTemplateExample
    {
        public static void Create(string outputPath)
        {
            Document myDoc = new();
            EvenOddTemplate tmp = new EvenOddTemplate();
            tmp.EvenElements.Add(new PageNumberingLabel("%%SP%%  James A Brannan", 0, 0, 512, 12, Font.Helvetica, 12, TextAlign.Left));
            tmp.OddElements.Add(new PageNumberingLabel("The DynamicPDF Core Suite by Example  %%SP%%", 0, 0, 500, 12, Font.Helvetica, 12, TextAlign.Right));
            myDoc.Template = tmp;

            for (int i = 0; i < 7; i++)
            {
                myDoc.Pages.Add(new Page(PageSize.Letter));
            }

            myDoc.Draw(outputPath);
        }
    }
}
