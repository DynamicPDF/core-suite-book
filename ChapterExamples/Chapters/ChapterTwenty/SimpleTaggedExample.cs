using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.Text;
using ceTe.DynamicPDF.Xmp;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterTwenty
{
    public class SimpleTaggedExample
    {
        public static void Create(string resourcePath, string outputPath)
        {

            BasicTextTagged(resourcePath, outputPath);
            BasicTextAttributes(resourcePath, outputPath);
            SimpleFonts(resourcePath, outputPath);
            
        }

        public static void MetaData(Document doc)
        {
            doc.Title = "My Document Title";
            doc.Creator = "TagsExample.cs";
            doc.Author = "James A Brannan";
            doc.Keywords = "simple csharp example";
            doc.Language = "en-us";
            doc.ViewerPreferences.DisplayDocTitle = true;
        }


        public static void SimpleFonts(string resourcePath, string outputPath)
        {
            Document doc = new();

            doc.Tag = new TagOptions();
            MetaData(doc);
            doc.Pages.Add(new Page(PageSize.Letter));


            OpenTypeFont theFont = new OpenTypeFont(resourcePath + "/ch20/RobotoMono-Regular.ttf");
            theFont.Embed = true;
            theFont.Subset = false;


            Label lbl = new Label("Chapter One", 0, 0, 200, 50);
            lbl.Font = theFont;
            lbl.FontSize = 32;

            float pgWdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.LeftMargin * 2;
            float pgHeight = doc.Pages[0].Dimensions.Height - doc.Pages[0].Dimensions.TopMargin * 2;

            string txt1 = TextGenerator.GenerateTextMultiple(1);
            TextArea txt = new(txt1, 0, doc.Pages[0].Dimensions.TopMargin, pgWdth, pgHeight, theFont, 14);
            txt.ParagraphIndent = 5;

            doc.Pages[0].Elements.Add(lbl);
            doc.Pages[0].Elements.Add(txt);

            StructureElement structureDocument = new StructureElement(TagType.Document);
            StructureElement structArt = new StructureElement(TagType.Article);
            structArt.Order = 1;
            structArt.Parent = structureDocument;

            StructureElement structureChptrTitle = new StructureElement(TagType.HeadingLevel1);
            structureChptrTitle.Order = 1;
            structureChptrTitle.Parent = structArt;
            lbl.Tag = structureChptrTitle;

            StructureElement structureText = new StructureElement(TagType.Paragraph);
            structureText.Order = 2;
            structureText.Parent = structArt;
            txt.Tag = structureText;

            XmpMetadata xmp = new XmpMetadata();
            PdfUASchema customSchema = new PdfUASchema();
            xmp.AddSchema(customSchema);

            DublinCoreSchema dublinCoreSchema = xmp.DublinCore;
            dublinCoreSchema.Title.AddLang("en-us", "XMP");
            dublinCoreSchema.Title.DefaultText = "Title Text";
            doc.XmpMetadata = xmp;

            doc.Draw(outputPath + "simple-tags-font-output.pdf");

        }


        public static void BasicTextAttributes(string resourcePath, string outputPath)
        {
            Document doc = new();
            
            doc.Tag = new TagOptions();
            MetaData(doc);
            doc.Pages.Add(new Page(PageSize.Letter));
            doc.Pages.Add(new Page(PageSize.Letter));

            OpenTypeFont theFont = new OpenTypeFont(resourcePath + "/ch20/ARIAL.TTF");
            theFont.Embed = true;
            theFont.Subset = false;

            Label lblTitle = new Label("My Book Title", 100, 300, 200, 50);
            lblTitle.Font = theFont;
            lblTitle.FontSize = 32;



            Image img1 = new(resourcePath + "/ch2/egypt.jpg", 100, 500);
            img1.ScaleX = .15f;
            img1.ScaleY = .15f;
            img1.AlternateText = "Egyptian Pharoh image.";

           

            Label lbl = new Label("Chapter One", 0, 0, 200, 50);
            lbl.Font = theFont;
            lbl.FontSize = 32;

            float pgWdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.LeftMargin * 2;
            float pgHeight = doc.Pages[0].Dimensions.Height - doc.Pages[0].Dimensions.TopMargin * 2;

            string txt1 = TextGenerator.GenerateTextMultiple(1);
            TextArea txt = new(txt1, 0, doc.Pages[0].Dimensions.TopMargin, pgWdth, pgHeight, theFont, 14);
            txt.ParagraphIndent = 5;

            doc.Pages[0].Elements.Add(lblTitle);
            doc.Pages[1].Elements.Add(lbl);
            doc.Pages[1].Elements.Add(txt);
            doc.Pages[1].Elements.Add(img1);

            StructureElement structureDocument = new StructureElement(TagType.Document);
            StructureElement structArt = new StructureElement(TagType.Article);
            structArt.Order = 1;
            structArt.Parent = structureDocument;

            StructureElement structArt2 = new StructureElement(TagType.Article);
            structArt2.Order = 2;
            structArt2.Parent = structureDocument;
           
            AttributeObject attrObjLayout = new AttributeObject(AttributeOwner.Layout);
            attrObjLayout.SetPlacement(Placement.Block);
            structArt.AttributeLists.Add(attrObjLayout);


            StructureElement structureTitle = new StructureElement(TagType.HeadingLevel1);
            structureTitle.Order = 1;
            structureTitle.Parent = structArt;
            lblTitle.Tag = structureTitle;

            AttributeObject attrObjLayout1 = new AttributeObject(AttributeOwner.Layout);
            attrObjLayout1.SetPlacement(Placement.Block);
            attrObjLayout1.SetHeight(lblTitle.Height);
            structureTitle.AttributeLists.Add(attrObjLayout1);


            StructureElement structureChptrTitle = new StructureElement(TagType.HeadingLevel2);
            structureChptrTitle.Order = 1;
            structureChptrTitle.Parent = structArt2;
            lbl.Tag = structureChptrTitle;

            AttributeObject attrObjLayout2 = new AttributeObject(AttributeOwner.Layout);
            attrObjLayout2.SetPlacement(Placement.Block);
            attrObjLayout2.SetHeight(lbl.Height);
            structureChptrTitle.AttributeLists.Add(attrObjLayout1);

            StructureElement structureText = new StructureElement(TagType.Paragraph);
            structureText.Order = 2;
            structureText.Parent = structArt2;
            txt.Tag = structureText;

            AttributeObject attrObjLayout3 = new AttributeObject(AttributeOwner.Layout);
            attrObjLayout3.SetPlacement(Placement.Block);
            attrObjLayout3.SetHeight(txt.Height);
            attrObjLayout3.SetTextIndent(5);
            structureText.AttributeLists.Add(attrObjLayout1);

            StructureElement structureFig = new StructureElement(TagType.Figure);
            structureFig.Order = 3;
            structureFig.Parent = structArt2;
            img1.Tag = structureFig;


            AttributeObject attrObjLayout4 = new AttributeObject(AttributeOwner.Layout);
            attrObjLayout4.SetPlacement(Placement.Block);
            BoundingBox box = new BoundingBox(150, 62, 276, 242);
            attrObjLayout4.SetBoundingBox(box); ;
            structureFig.AttributeLists.Add(attrObjLayout4);

            AddSchemas(doc);


            doc.Draw(outputPath + "simple-tags-attributes-output.pdf");

        }

        public static void BasicTextTagged(string resourcePath, string outputPath)
        {

            Document doc = new();
            doc.Tag = new TagOptions();
            MetaData(doc);
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

            string txt1 = TextGenerator.GenerateTextMultiple(1);
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

            AddSchemas(doc);

            doc.Draw(outputPath + "basic-text-tagged-output.pdf");

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
