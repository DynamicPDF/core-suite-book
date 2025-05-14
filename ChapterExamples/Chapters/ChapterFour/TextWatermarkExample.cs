
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterFour
{
    public class TextWatermarkExample
    {
        public static void Create(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            string txt1 = TextGenerator.GenerateText();

            float pgWdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.LeftMargin * 2;

            TextArea txtOne = new(txt1, 0, 0, pgWdth, 20, Font.TimesBold, 14);
            txtOne.Height = txtOne.GetRequiredHeight();
            txtOne.Align = TextAlign.Justify;

            TextWatermark textWatermark = new("ROUGH DRAFT");

            doc.Pages[0].Elements.Add(txtOne);
            doc.Pages[0].Elements.Add(textWatermark);

            doc.Draw(outputPath);
        }
    }
}
