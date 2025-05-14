using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.Text;
using ceTe.DynamicPDF.Xmp;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterTwenty
{
    public class FirstPass
    {

        public static void Create(string resourcePath, string outputPath)
        {
            BasicText(resourcePath, outputPath);

        }

        public static void MetaData(Document doc)
        {
            doc.Title = "My Document Title";
            doc.Creator = "FirstPass.cs";
            doc.Author = "James A Brannan";
            doc.Keywords = "simple csharp example";
            doc.Language = "en-us";
            doc.ViewerPreferences.DisplayDocTitle = true;
        }

        public static void BasicText(string resourcePath, string outputPath)
        {
            Document doc = new();
            doc.Tag = new TagOptions();
            MetaData(doc);
            doc.Pages.Add(new Page(PageSize.Letter));

            OpenTypeFont theFont = new OpenTypeFont(resourcePath + "/ch20/ARIAL.TTF");
            theFont.Embed = true;
            theFont.Subset = false;

            float pgWdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.LeftMargin * 2;
            float pgHeight = doc.Pages[0].Dimensions.Height - doc.Pages[0].Dimensions.TopMargin * 2;

            Image img1 = new(resourcePath + "/ch2/egypt.jpg", 100, 500);
            img1.ScaleX = .15f;
            img1.ScaleY = .15f;
            img1.AlternateText = "Imaged of an Egyptian pharoh.";

            Label lbl = new Label("Chapter One", 0, 0, 200, 0);
            lbl.Font = theFont;
            lbl.FontSize = 32;

            string txt1 = TextGenerator.GenerateTextMultiple(1);

            TextArea txt = new(txt1, 0, doc.Pages[0].Dimensions.TopMargin, pgWdth, pgHeight, theFont, 14);
            
            doc.Pages[0].Elements.Add(lbl);
            doc.Pages[0].Elements.Add(txt);
            doc.Pages[0].Elements.Add(img1);

            AddSchemas(doc);

            doc.Draw(outputPath + "basic-text-tags-output.pdf");
        }

        public static void AddSchemas(Document doc)
        {
            XmpMetadata xmp = new XmpMetadata();
            PdfUASchema customSchema = new PdfUASchema();
            xmp.AddSchema(customSchema);

            DublinCoreSchema dublinCoreSchema = xmp.DublinCore;
            dublinCoreSchema.Title.AddLang("en-us", "XMP");
            dublinCoreSchema.Title.DefaultText = "My Document Title";
            doc.XmpMetadata = xmp;
        }
    }
}
