using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.Text;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterEight
{
    public class GoogleFontsExample
    {
        public static void Create(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            float pgWdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.LeftMargin * 2;
            float pgHeight = doc.Pages[0].Dimensions.Height - doc.Pages[0].Dimensions.TopMargin * 2;

            GoogleFont googleFont = Font.Google("Modak", false, false);
            

            Label lbl = new Label("Chapter One", 10, 10, 150, 50, googleFont, 22);

            string txt1 = Utility.TextGenerator.GenerateTextMultiple(1);
            TextArea txt = new(txt1, 0, doc.Pages[0].Dimensions.TopMargin, pgWdth, pgHeight, Font.Google("Caveat", true, false), 14);

            Label lbl2 = new Label("Next Section", 10, pgHeight - 150, 150, 50);
            lbl2.Font = Font.Google("Roboto", 100, true);
            lbl2.FontSize = 18;

            doc.Pages[0].Elements.Add(lbl);
            doc.Pages[0].Elements.Add(txt);
            doc.Pages[0].Elements.Add(lbl2);

            AddGridLines.AddBackgroundColor(doc);
            doc.Draw(outputPath + "google-fonts.pdf");
        }
    }
}
