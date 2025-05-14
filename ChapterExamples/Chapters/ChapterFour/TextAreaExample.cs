using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterFour
{
    public class TextAreaExample
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

            doc.Pages[0].Elements.Add(txtOne);

            TextArea txtTwo = new(txt1, 0, 0, pgWdth, 4020, Font.TimesBold, 14);
            txtTwo.Font = Font.HelveticaBold;
            txtTwo.TextColor = RgbColor.Navy;
            txtTwo.Y = txtOne.Y + txtOne.Height + 50;
            txtTwo.ParagraphIndent = 10;
            txtTwo.ParagraphSpacing = 10;
            txtTwo.Height = txtTwo.GetRequiredHeight(); 
            doc.Pages[0].Elements.Add(txtTwo);


            AddGridLines.AddBackgroundColor(doc);
            AddGridLines.AddMargins(doc.Pages[0]);

            doc.Draw(outputPath);
        }
    }
}
