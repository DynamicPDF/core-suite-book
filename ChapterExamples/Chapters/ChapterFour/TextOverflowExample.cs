using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterFour
{
    public class TextOverflowExample
    {
        public static void Create(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            float pgWdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.LeftMargin * 2;
            float pgHeight = doc.Pages[0].Dimensions.Height - doc.Pages[0].Dimensions.TopMargin * 2;

            string txt1 = TextGenerator.GenerateTextMultiple(10);

            TextArea txt = new(txt1, 0, 0, pgWdth, pgHeight, Font.TimesBold, 14);
            txt.ParagraphIndent = 10;
            txt.ParagraphSpacing = 10;
            doc.Pages[0].Elements.Add(txt);

            while (txt.HasOverflowText())
            {
                txt = txt.GetOverflowTextArea();
                Page pg = new(PageSize.Letter);
                doc.Pages.Add(pg);
                pg.Elements.Add(txt);
            } ;

            AddGridLines.AddBackgroundColor(doc);
            AddGridLines.AddMargins(doc.Pages[0]);

            AddHeader(doc);
            doc.Draw(outputPath);
        }

        private static void AddHeader(Document myDoc)
        {
            float x = myDoc.Pages[0].Dimensions.Width - myDoc.Pages[0].Dimensions.RightMargin * 2;
            float y = -myDoc.Pages[0].Dimensions.TopMargin;

            HeaderFooterTemplate header = new HeaderFooterTemplate();
            HeaderFooterText leftText = new HeaderFooterText("The DynamicPDF Core Suite by Example");
            leftText.Font = Font.Helvetica;
            leftText.FontSize = 12;
            header.HeaderLeft = leftText;
            header.FooterCenter = new HeaderFooterText("Text overflow example...");
            PageNumberingLabel pglb = new("%%CP%% of %%TP%%", x, y, 100, 50, Font.Helvetica, 12, TextAlign.Left);
            pglb.VAlign = VAlign.Center;
            header.Elements.Add(pglb);
            myDoc.Template = header;
        }
    } 
}