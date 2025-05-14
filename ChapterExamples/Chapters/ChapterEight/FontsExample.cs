using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.Text;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterEight
{
    public class FontsExample
    {
        public static void Create(string resourcPath, string outputPath)
        {
            Kerning(outputPath);
            CoreFonts(outputPath);
            OpenTypeExample(resourcPath, outputPath);
            EncodingExample(resourcPath, outputPath);
        }

        public static void Kerning(string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));


            string text = "This is a test of applying kerning.";
            TextArea textArea = new TextArea(text, 0, 0, 300, 50, Font.TimesRoman);
            textArea.KerningEnabled = true;
            textArea.GetKerningValues().Spacing[1] = (short)(textArea.GetKerningValues().Spacing[1] - 300);


            TextArea textArea2 = new TextArea(text, 0, 50, 300, 50, Font.TimesRoman);
            textArea2.KerningEnabled = true;

            KerningValues kernValues = textArea2.GetKerningValues();
           
            for (int i = 0; i < kernValues.Spacing.Length; i++)
            {
                kernValues.Spacing[i] = (short)(kernValues.Spacing[i] - 200);
            }

            doc.Pages[0].Elements.Add(textArea);
            doc.Pages[0].Elements.Add(textArea2);
            doc.Draw(outputPath + "kerning-fonts.pdf");

        }


        public static void EncodingExample(string resourcePath, string outputPath)
        {            
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            float pgWdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.LeftMargin * 2;
            float pgHeight = doc.Pages[0].Dimensions.Height - doc.Pages[0].Dimensions.TopMargin * 2;

            Font centralEuropeHelveticaFont = new Helvetica(Encoder.CentralEurope);

            TextArea txt = new TextArea("čárka nad písmenem, silný přízvuk", 0, 0, 200, 12, centralEuropeHelveticaFont, 12);

            Label lbl = new("čárka nad písmenem, silný přízvuk", 0, 100, 300, 0, Font.Helvetica, 12);
            Label lbl2 = new("comma above the letter, strong accent", 0, 125, 300, 0, Font.Helvetica, 12);
            Label lbl3 = new("čárka nad písmenem, silný přízvuk", 0, 150, 300, 0, centralEuropeHelveticaFont, 12);

            doc.Pages[0].Elements.Add(txt);
            doc.Pages[0].Elements.Add(lbl);
            doc.Pages[0].Elements.Add(lbl2);
            doc.Pages[0].Elements.Add(lbl3);

            AddGridLines.AddBackgroundColor(doc);
            doc.Draw(outputPath + "encoding-fonts.pdf");
        }


        public static void CoreFonts(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            float pgWdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.LeftMargin * 2;
            float pgHeight = doc.Pages[0].Dimensions.Height - doc.Pages[0].Dimensions.TopMargin * 2;

            Label lbl = new Label("Chapter One", 10, 10, 150, 50, Font.CourierBold, 22);

            string txt1 = Utility.TextGenerator.GenerateTextMultiple(1);
            TextArea txt = new(txt1, 0, doc.Pages[0].Dimensions.TopMargin, pgWdth, pgHeight, Font.TimesRoman, 14);

            Label lbl2 = new Label("Next Section", 10, pgHeight - 150, 150, 50);
            lbl2.Font = Font.HelveticaBoldOblique;
            lbl2.FontSize = 18;

            doc.Pages[0].Elements.Add(lbl);
            doc.Pages[0].Elements.Add(txt);
            doc.Pages[0].Elements.Add(lbl2);

            AddGridLines.AddBackgroundColor(doc);
            doc.Draw(outputPath + "core-fonts.pdf");
        }

        public static void OpenTypeExample(string resourcePath, string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            float pgWdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.LeftMargin * 2;
            float pgHeight = doc.Pages[0].Dimensions.Height - doc.Pages[0].Dimensions.TopMargin * 2;

            OpenTypeFont openType = new OpenTypeFont(resourcePath + "cnr.otf");

            Label lbl = new Label("Chapter One", 10, 10, 150, 50, openType, 22);

            string txt1 = Utility.TextGenerator.GenerateTextMultiple(1);
            TextArea txt = new(txt1, 0, doc.Pages[0].Dimensions.TopMargin, pgWdth, pgHeight, openType, 14);

            doc.Pages[0].Elements.Add(lbl);
            doc.Pages[0].Elements.Add(txt);

            AddGridLines.AddBackgroundColor(doc);
            doc.Draw(outputPath + "opentype-fonts.pdf");
        }
    }
}
