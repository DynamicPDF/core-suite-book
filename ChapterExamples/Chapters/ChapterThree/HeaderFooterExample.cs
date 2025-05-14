using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterThree
{
    public class HeaderFooterExample
    {
        public static void Create(string outputPath)
        {
            Document myDoc = new();
            DocumentExampleGenerator.Generate(myDoc);
            float x = myDoc.Pages[0].Dimensions.Width - myDoc.Pages[0].Dimensions.RightMargin * 2;
            float y = -myDoc.Pages[0].Dimensions.TopMargin;

            HeaderFooterTemplate header = new HeaderFooterTemplate();
            HeaderFooterText leftText = new HeaderFooterText("The DynamicPDF Core Suite by Example");
            leftText.Font = Font.Helvetica;
            leftText.FontSize = 12;
            header.HeaderLeft = leftText;
            header.FooterCenter = new HeaderFooterText("This is a draft...");
            PageNumberingLabel pglb = new("%%CP%% of %%TP%%", x, y, 100, 50, Font.Helvetica, 12, TextAlign.Left);
            pglb.VAlign = VAlign.Center;
            header.Elements.Add(pglb);
            myDoc.Template = header;
            myDoc.Draw(outputPath);
        }
    }
}
