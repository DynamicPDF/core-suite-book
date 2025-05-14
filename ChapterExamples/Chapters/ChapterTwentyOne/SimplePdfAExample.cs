using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.Text;
using ceTe.DynamicPDF.Xmp;

namespace ChapterExamples.Chapters.ChapterTwentyOne
{
    public class SimplePdfAExample
    {

        public static void Create(string resourcePath, string outputPath)
        {
            BasicTextTagged(resourcePath, outputPath, "PDF_A_1a_2005");
            BasicTextTagged(resourcePath, outputPath, "PdfA2a");
            BasicTextTagged(resourcePath, outputPath, "PdfA3a");

        }

        public static void MetaData(Document doc)
        {
            doc.Title = "Simple Example";
            doc.Creator = "TagsExample.cs";
            doc.Author = "James A Brannan";
            doc.Creator = "SimplePdfAExample.cs";
            doc.Keywords = "simple csharp example";
            doc.Language = "en-us";
            doc.ViewerPreferences.DisplayDocTitle = true;
        }

        public static void AttachSchema(Document doc, string profile, string resourcePath)
        {
            XmpMetadata xmp = new XmpMetadata();
            PdfASchema pdfaSchema = null;

            if (profile.Equals("PDF_A_1a_2005")){
                pdfaSchema = new PdfASchema(PdfAStandard.PDF_A_1a_2005);
            } else if (profile.Equals("PdfA2a"))
            {
                pdfaSchema = new PdfASchema(PdfAStandard.PdfA2a);
            } else if (profile.Equals("PdfA3a"))
            {
                pdfaSchema = new PdfASchema(PdfAStandard.PdfA3a);
                AddAttachments(resourcePath, doc);
            }
                        
            xmp.AddSchema(pdfaSchema);
            DublinCoreSchema dublinCoreSchema = xmp.DublinCore;
            dublinCoreSchema.Title.AddLang("en-us", "PDF Document");
            dublinCoreSchema.Title.DefaultText = "Simple Example";
            dublinCoreSchema.Description.DefaultText = "A simple example PDF document illustrating PDF/A compliance.";
            dublinCoreSchema.Type.Add("pdf_example");
            doc.XmpMetadata = xmp;
        }

        public static void AddAttachments(string resourcePath, Document doc)
        {
            string fileOne = resourcePath + "/ch2/egypt.jpg";
            string fileTwo = resourcePath + "/ch1/doc1.pdf";
            string fileThree = resourcePath + "/ch6/model.u3d";
            string fileFour = resourcePath + "/ch4/list.html";

            EmbeddedFile embeddedFile1 = new EmbeddedFile(fileOne);
            EmbeddedFile embeddedFile2 = new EmbeddedFile(fileTwo);
            EmbeddedFile embeddedFile3 = new EmbeddedFile(fileThree);
            EmbeddedFile embeddedFile4 = new EmbeddedFile(fileFour);

            embeddedFile1.MimeType = "image/jpg";
            embeddedFile2.MimeType = "application/pdf";
            embeddedFile3.MimeType = "model/u3d";
            embeddedFile4.MimeType = "text/html";

            embeddedFile1.Relation = EmbeddedFileRelation.Source;
            embeddedFile2.Relation = EmbeddedFileRelation.Source;
            embeddedFile3.Relation = EmbeddedFileRelation.Source;
            embeddedFile4.Relation = EmbeddedFileRelation.Source;

            doc.EmbeddedFiles.Add(embeddedFile1);
            doc.EmbeddedFiles.Add(embeddedFile2);
            doc.EmbeddedFiles.Add(embeddedFile3);
            doc.EmbeddedFiles.Add(embeddedFile4);
        }
  
        public static void BasicTextTagged(string resourcePath, string outputPath, string profile)
        {

            Document doc = new();
            doc.Tag = new TagOptions();
            MetaData(doc);
            AttachSchema(doc, profile, resourcePath);
                        
            IccProfile iccProfile = new IccProfile(resourcePath + "ch21/sRGB2014.icc");
            OutputIntent outputIntents = new OutputIntent("", "IEC 61966-2.1 Default RGB colour space - sRGB 1 ", "http://www.color.org", "sRGB2014.icc", iccProfile);
            outputIntents.Version = OutputIntentVersion.PDF_A;
            doc.OutputIntents.Add(outputIntents);



            doc.Pages.Add(new Page(PageSize.Letter));

            float pgWdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.LeftMargin * 2;
            float pgHeight = doc.Pages[0].Dimensions.Height - doc.Pages[0].Dimensions.TopMargin * 2;

            OpenTypeFont theFont = new OpenTypeFont(resourcePath + "/ch20/ARIAL.TTF");
            theFont.Embed = true;
            theFont.Subset = false;

            Image img1 = new(resourcePath + "/ch2/egypt.jpg", 100, 500);
            img1.ScaleX = .15f;
            img1.ScaleY = .15f;
            img1.AlternateText = "Egyptian Pharoh image.";

            Label lbl = new Label("Chapter One", 0, 0, 200, 0);
            lbl.Font = theFont;
            lbl.FontSize = 32;

            string txt1 = Utility.TextGenerator.GenerateTextMultiple(1);
            TextArea txt = new(txt1, 0, doc.Pages[0].Dimensions.TopMargin, pgWdth, pgHeight, theFont, 14);

            doc.Pages[0].Elements.Add(lbl);
            doc.Pages[0].Elements.Add(txt);
            doc.Pages[0].Elements.Add(img1);

            StructureElement structureDocument = new StructureElement(TagType.Document);
            StructureElement structArt = new StructureElement(TagType.Article);
            structArt.Order = 1;
            structArt.Parent = structureDocument;


            StructureElement structureTitle = new StructureElement(TagType.HeadingLevel1);
            structureTitle.Order = 1;
            structureTitle.Parent = structArt;
            lbl.Tag = structureTitle;


            StructureElement structureText = new StructureElement(TagType.Paragraph);
            structureText.Order = 2;
            structureText.Parent = structArt;
            txt.Tag = structureText;

            StructureElement structureFig = new StructureElement(TagType.Figure);
            structureFig.Order = 3;
            structureFig.Parent = structArt;
            img1.Tag = structureFig;

            doc.Draw(outputPath + "basic-text-archive-" + profile + "-tagged-output.pdf");
        }
    }
}
