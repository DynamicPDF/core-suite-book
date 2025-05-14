
using ceTe.DynamicPDF;

namespace ChapterExamples.Chapters.ChapterTwentyOne
{
    public class CustomPageElementExample
    {
        public static void Modify(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));
            StarCustomElement star = new StarCustomElement(4, 248, 296, 250, 75);
            doc.Pages[0].Elements.Add(star);

            ReadOnlyCustomLabel readOnly = new ReadOnlyCustomLabel(100, 200);
            doc.Pages[0].Elements.Add(readOnly);

            string text = Utility.TextGenerator.GenerateText();

            doc.Pages.Add(new Page(PageSize.Letter));

            TextAreaStrokeCustomElement textAreaCustom = new("this is a test", 0, 0, doc.Pages[0].Dimensions.Body.Width, doc.Pages[0].Dimensions.Body.Height);
            textAreaCustom.FontSize = 72;
            doc.Pages[1].Elements.Add(textAreaCustom);
            
            doc.Pages.Add(new Page(PageSize.Letter));

            SimpleCustomElement simpleElement = new();
            doc.Pages[2].Elements.Add(simpleElement);

            doc.Draw(outputPath + "custom-page-element-output.pdf");

        }
    }
}
