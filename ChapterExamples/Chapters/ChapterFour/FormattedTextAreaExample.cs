using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterFour
{
    public class FormattedTextAreaExample
    {
        public static void Create(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            string txt1 = TextGenerator.GenerateSimple();

            float pgWdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.LeftMargin * 2;

            FormattedTextAreaStyle style = new(FontFamily.Helvetica, 12, false);

            FormattedTextArea txtOne = new(txt1, 0, 0, pgWdth, 0, style);
            txtOne.Height = txtOne.GetRequiredHeight();
            
            doc.Pages[0].Elements.Add(txtOne);

            AddGridLines.AddBackgroundColor(doc);
            AddGridLines.AddMargins(doc.Pages[0]);

            doc.Draw(outputPath);
        }
    }
}
