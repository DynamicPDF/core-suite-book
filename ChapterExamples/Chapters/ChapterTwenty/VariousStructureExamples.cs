
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.Text;
using ceTe.DynamicPDF.Xmp;


namespace ChapterExamples.Chapters.ChapterTwenty
{
    public class VariousStructureExamples
    {

        public static void Create(string resourcePath, string outputPath)
        {
            //SimpleTest(outputPath);
            XmpMetaDataEmple(outputPath);
            EvenOddExample(resourcePath, outputPath);
            EvenOddExampleManual(resourcePath, outputPath);
            SimpleTemplateRaw(resourcePath, outputPath);
            SimpleTemplateTagged(resourcePath, outputPath);
            CircleExample(resourcePath, outputPath);
        }

        public static void SimpleTest(string outputPath)
        {
            Document document1 = new Document();
            document1.Tag = new TagOptions();
            Page page1 = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);
            document1.Pages.Add(page1);

            Artifact artifact = new Artifact();
            artifact.SetType(ArtifactType.None);
                        
            TextWatermark textWatermark = new TextWatermark("PROPOSED PAGE");
            textWatermark.Font = new OpenTypeFont(@"times.ttf");
            textWatermark.FontSize = 54;
            textWatermark.TextColor = RgbColor.LightGrey;
            textWatermark.Tag = artifact;

            document1.Pages[0].Elements.Add(textWatermark);

            document1.Draw(outputPath + "test-output.pdf"); // 

        }

        public static void MetaData(Document doc)
        {
            doc.Title = "My Document Title";
            doc.Creator = "VariousStructureExamples.cs";
            doc.Author = "James A Brannan";
            doc.Keywords = "simple csharp example";
            doc.Language = "en-us";
            doc.ViewerPreferences.DisplayDocTitle = true;
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

        public static void CircleExample(string resourcePath, string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));
            MetaData(doc);
            doc.Tag = new TagOptions(false);

            OpenTypeFont theFont = new OpenTypeFont(resourcePath + "/ch20/ARIAL.TTF");
            theFont.Embed = true;
            theFont.Subset = false;

            Label lbl = new("Three Circles", 0, 0, 200, 0);
            lbl.Font = theFont;
            lbl.FontSize = 32;


            StructureElement structureDocument = new StructureElement(TagType.Document);
            StructureElement structTitle = new StructureElement(TagType.HeadingLevel1);
            structTitle.Parent = structureDocument;
            structTitle.AlternateText = "A page showing three circles with different fill colors and outline styles.";
            structTitle.Order = 1;
            lbl.Tag = structTitle;

            Circle myCircle = new(150, 150, 60f);
            myCircle.IgnoreMargins = true;
            myCircle.BorderColor = RgbColor.Teal;
            myCircle.BorderWidth = 1f;
            myCircle.FillColor = RgbColor.Tan;


            StructureElement structCircle = new StructureElement(TagType.Figure);
            structCircle.AlternateText = "A tan circle with solid line and outline is teal.";
            structCircle.Parent = structureDocument;
            structCircle.Order = 2;

            myCircle.Tag = structCircle;

            Circle myCircle1 = new(200, 400, 50f);
            myCircle1.IgnoreMargins = true;
            myCircle1.BorderStyle = LineStyle.Dots;
            myCircle1.BorderColor = RgbColor.Navy;
            myCircle1.BorderWidth = 5f;
            myCircle1.FillColor = RgbColor.LightGreen;

            StructureElement structCircle1 = new StructureElement(TagType.Figure);
            structCircle1.AlternateText = "A light green circle who's line is dotted and outline is navy.";
            structCircle1.Parent = structureDocument;
            structCircle1.Order = 3;


            myCircle1.Tag = structCircle1;

            Circle myCircle2 = new(doc.Pages[0].Dimensions.Width / 2, doc.Pages[0].Dimensions.Height / 2, 25f);
            myCircle2.IgnoreMargins = true;
            myCircle2.BorderStyle = LineStyle.Dash;
            myCircle2.BorderColor = RgbColor.Red;
            myCircle2.BorderWidth = 2f;
            myCircle2.FillColor = RgbColor.PowderBlue;

            StructureElement structCircle2 = new StructureElement(TagType.Figure);
            structCircle2.AlternateText = "A powder blue circle who's line is dashed and outline is red.";
            structCircle2.Parent = structureDocument;
            structCircle2.Order = 4;


            myCircle2.Tag = structCircle2;

            doc.Pages[0].Elements.Add(lbl);
            doc.Pages[0].Elements.Add(myCircle);
            doc.Pages[0].Elements.Add(myCircle1);
            doc.Pages[0].Elements.Add(myCircle2);

            AddSchemas(doc);
            
            doc.Draw(outputPath + "tags-circle-output.pdf");
        }


        public static void XmpMetaDataEmple(string outputPath)
        {
            Document doc = new();
            MetaData(doc);
            doc.Tag = new TagOptions();
            doc.Pages.Add(new Page(PageSize.Letter));


            UnorderedList ul = new(50, 50, 300, 500);
            UnorderedListStyle uls = new("\u2022", Font.Helvetica);
            ul.BulletStyle = uls;
            ul.Items.Add("Paint");
            ul.Items.Add("Two Brushes");
            ul.Items.Add("Three Buckets");
            ul.Items.Add("Ten Cloths");

            UnorderedSubList ul2 = ul.Items[0].SubLists.AddUnorderedSubList();
            UnorderedListStyle uls2 = new("\u2022", Font.Helvetica);
            ul2.BulletStyle = uls2;
            ul2.Items.Add("One gallon red paint");
            ul2.Items.Add("Two gallons blue paint");
            ul2.Items.Add("Three gallons orange paint");

            doc.Pages[0].Elements.Add(ul);

            XmpMetadata xmp = new XmpMetadata();
            PdfUASchema customSchema = new PdfUASchema();
            xmp.AddSchema(customSchema);

            DublinCoreSchema dublinCoreSchema = xmp.DublinCore;
            dublinCoreSchema.Title.AddLang("en-us", "XMP");
            dublinCoreSchema.Title.DefaultText = "Title Text";
            doc.XmpMetadata = xmp;


            doc.Draw(outputPath + "xmp-metadata-tags-output.pdf");
        }

        public static void EvenOddExampleManual(string resourcePath, string outputPath)
        {
            Document doc = new();
            MetaData(doc);
            doc.Tag = new TagOptions(false);

            StructureElement structureDocument = new StructureElement(TagType.Document);
            StructureElement structPart = new StructureElement(TagType.Part);
            structPart.Order = 1;
            structPart.Parent = structureDocument;

            Artifact artifact = new Artifact();
            artifact.SetType(ArtifactType.None);

            EvenOddTemplate tmp = new EvenOddTemplate();
            tmp.EvenElements.Add(new PageNumberingLabel("%%SP%%  Even", 0, 0, 512, 12, Font.Helvetica, 12, TextAlign.Left));
            
            Image img = new(resourcePath + "/ch3/logo.png", 400, 0, .3F);
            img.AlternateText = "the logo image";
            tmp.EvenElements.Add(img);
            img.Tag = artifact;

  
            tmp.OddElements.Add(new PageNumberingLabel("Odd  %%SP%%", 0, 0, 500, 12, Font.Helvetica, 12, TextAlign.Right));
            Image img2 = new(resourcePath + "/ch3/tools.png", 0, 0, .3F);
            img2.AlternateText = "the tools image";
            img2.Tag = artifact;
            tmp.OddElements.Add(img2);
            doc.Template = tmp;


            for (int i = 0; i < 7; i++)
            {
                doc.Pages.Add(new Page(PageSize.Letter));
                string txt1 = "this is a test";
                TextArea txt = new(txt1, 0, 75, 512, 600, Font.TimesBold, 14);
                doc.Pages[i].Elements.Add(txt);

                StructureElement structureText = new StructureElement(TagType.Paragraph);
                structureText.Order = i;
                structureText.Parent = structPart;
                txt.Tag = structureText;
            }


            XmpMetadata xmp = new XmpMetadata();

            DublinCoreSchema dc = xmp.DublinCore;
            dc.Title.AddLang("en-us", "XMP");

            PdfUASchema customSchema = new PdfUASchema();
            xmp.AddSchema(customSchema);

            doc.XmpMetadata = xmp;


            doc.Draw(outputPath + "evenodd-manual-tags-output.pdf");
        }



        public static void EvenOddExample(string resourcePath, string outputPath)
        {
            Document doc = new();
            MetaData(doc);
            doc.Tag = new TagOptions();

            EvenOddTemplate tmp = new EvenOddTemplate();
            tmp.EvenElements.Add(new PageNumberingLabel("%%SP%%  James A Brannan", 0, 0, 512, 12, Font.Helvetica, 12, TextAlign.Left));
            Image img = new(resourcePath + "/ch3/logo.png", 400, 0, .3F);
            img.AlternateText = "the logo image";
            tmp.EvenElements.Add(img);

            tmp.OddElements.Add(new PageNumberingLabel("The DynamicPDF Core Suite by Example  %%SP%%", 0, 0, 500, 12, Font.Helvetica, 12, TextAlign.Right));
            Image img2 = new(resourcePath + "/ch3/tools.png", 0, 0, .3F);
            img2.AlternateText = "the tools image";
            tmp.OddElements.Add(img2);
            doc.Template = tmp;


            for (int i = 0; i < 7; i++)
            {
                doc.Pages.Add(new Page(PageSize.Letter));
                string txt1 = "this is a test"; // TextGenerator.GenerateTextMultiple(1);
                TextArea txt = new(txt1, 0, 75, 512, 600, Font.TimesBold, 14);
                doc.Pages[i].Elements.Add(txt);
            }

            doc.Draw(outputPath + "evenodd-tags-output.pdf");
        }


        public static void SimpleTemplateTagged(string resourcePath, string outputPath)
        {
            Document doc = new();
            doc.Tag = new TagOptions();
            MetaData(doc);

            doc.Pages.Add(new Page(PageSize.Letter));
            doc.Pages.Add(new Page(PageSize.Letter));


            OpenTypeFont theFont = new OpenTypeFont(resourcePath + "/ch20/ARIAL.TTF");
            theFont.Embed = true;
            theFont.Subset = false;

            //create cover page with title and page background

            StructureElement structureDocument = new StructureElement(TagType.Document);
            
            StructureElement structPart = new StructureElement(TagType.Part);
            structPart.Order = 1;
            structPart.Parent = structureDocument;

            StructureElement structArt = new StructureElement(TagType.Article);
            structArt.Order = 1;
            structArt.Parent = structPart;

            Artifact artifact = new Artifact();
            artifact.SetType(ArtifactType.None);

            Label lblTitle = new("Quarterly Report", 0, 350, 500, 0);
            lblTitle.Font = theFont;
            lblTitle.TextColor = RgbColor.Red;
            lblTitle.TextOutlineColor = RgbColor.Black;
            lblTitle.FontSize = 45;

            StructureElement strTitle = new StructureElement(TagType.HeadingLevel1);
            strTitle.Order = 1;
            strTitle.Parent = structArt;
            lblTitle.Tag = strTitle;

            Rectangle rec = new(0, 0, doc.Pages[0].Dimensions.Width, doc.Pages[0].Dimensions.Height);
            rec.FillColor = RgbColor.LightSkyBlue;
            rec.BorderStyle = LineStyle.None;
            rec.IgnoreMargins = true;
            rec.Tag = artifact;

            doc.Pages[0].Elements.Add(rec);
            doc.Pages[0].Elements.Add(lblTitle);

            // create template

            Template tmp = new();
            tmp.Elements.Add(new PageNumberingLabel("Quarterly Report  %%SP%%", 0, 0, 550, 12, theFont, 12, TextAlign.Right));

            Image img = new(resourcePath + "/ch3/logo.png", 0, 0, .3F);
            img.AlternateText = "the logo image";
            img.Tag = artifact;


            Label lblImp = new Label("La Historia Corporativa de Acme",100, 0, 400, 0);
            lblImp.FontSize = 12;
            lblImp.Font = theFont;
            lblImp.Tag = artifact;

            tmp.Elements.Add(img);
            tmp.Elements.Add(lblImp);


            //create page one of report

            StructureElement strPart1 = new StructureElement(TagType.Part);
            strPart1.Order = 2;
            strPart1.Parent = structureDocument;

            StructureElement strArt = new StructureElement(TagType.Article);
            strArt.Order = 1;
            strArt.Parent = strPart1;

            StructureElement strCvrSec1 = new StructureElement(TagType.Section);
            strCvrSec1.Order = 1;
            strCvrSec1.Parent = strArt;

            Circle myCircle2 = new(300, 350, 120f);
            myCircle2.IgnoreMargins = true;
            myCircle2.BorderColor = RgbColor.Teal;
            myCircle2.BorderWidth = 1f;
            myCircle2.FillColor = RgbColor.Tan;
            myCircle2.Tag = artifact;


            doc.Pages[1].Elements.Add(myCircle2);


            string txt1 = "La Historia Corporativa de Acme";
            TextArea txtA = new(txt1, 0, 325, 512, 600, theFont, 32);

            StructureElement strTxt1 = new StructureElement(TagType.Paragraph);
            strTxt1.Language = "es-mx";
            strTxt1.Order = 1;
            strTxt1.Parent = strCvrSec1;
            txtA.Tag = strTxt1;


            doc.Pages[1].Elements.Add(txtA);

            // create pages of report

            doc.Sections.Begin(NumberingStyle.Numeric, tmp);

            for (int i = 2; i < 5; i++)
            {
                doc.Pages.Add(new Page(PageSize.Letter));

                StructureElement strPg = new StructureElement(TagType.Section);
                strPg.Order = 1;
                strPg.Parent = strArt;


                TextArea txt = new("This is a test page or text.", 0, 75, 512, 600, theFont, 14);
                doc.Pages[i].Elements.Add(txt);

                StructureElement strTxt = new StructureElement(TagType.Paragraph);
                strTxt.Order = 2;
                strTxt.Parent = strPg;
                txt.Tag = strTxt;

            }

            AddSchemas(doc);

            doc.Draw(outputPath + "simple-template-tagged.pdf");

        }


        public static void SimpleTemplateRaw(string resourcePath, string outputPath)
        {
            Document doc = new();
            doc.Tag = new TagOptions();
            MetaData(doc);

            doc.Pages.Add(new Page(PageSize.Letter));
            doc.Pages.Add(new Page(PageSize.Letter));

            //create cover page with title and page background

            OpenTypeFont theFont = new OpenTypeFont(resourcePath + "/ch20/ARIAL.TTF");
            theFont.Embed = true;
            theFont.Subset = false;

            Label lblTitle = new("Quarterly Report", 0, 350, 500, 0);
            lblTitle.Font = theFont;
            lblTitle.TextColor = RgbColor.Red;
            lblTitle.TextOutlineColor = RgbColor.Black;
            lblTitle.FontSize = 45;


            Rectangle rec = new(0, 0, doc.Pages[0].Dimensions.Width, doc.Pages[0].Dimensions.Height);
            rec.FillColor = RgbColor.LightSkyBlue;
            rec.BorderStyle = LineStyle.None;
            rec.IgnoreMargins = true;

            doc.Pages[0].Elements.Add(rec);
            doc.Pages[0].Elements.Add(lblTitle);

            // create template

            Template tmp = new();
            tmp.Elements.Add(new PageNumberingLabel("Quarterly Report  %%SP%%", 0, 0, 550, 12, theFont, 12, TextAlign.Right));

            Image img = new(resourcePath + "/ch3/logo.png", 0, 0, .3F);
            img.AlternateText = "the logo image";


            Label lblImp = new Label("La Historia Corporativa de Acme", 100, 0, 400, 0);
            lblImp.FontSize = 12;
            lblImp.Font =theFont;

            tmp.Elements.Add(img);
            tmp.Elements.Add(lblImp);


            //create page one of report


            Circle myCircle2 = new(300, 350, 120f);
            myCircle2.IgnoreMargins = true;
            myCircle2.BorderColor = RgbColor.Teal;
            myCircle2.BorderWidth = 1f;
            myCircle2.FillColor = RgbColor.Tan;

            doc.Pages[1].Elements.Add(myCircle2);


            string txt1 = "La Historia Corporativa de Acme";
            TextArea txtA = new(txt1, 0, 325, 512, 600, theFont, 32);


            doc.Pages[1].Elements.Add(txtA);

            // create pages of report

            doc.Sections.Begin(NumberingStyle.Numeric, tmp);

            for (int i = 2; i < 5; i++)
            {
                doc.Pages.Add(new Page(PageSize.Letter));


                TextArea txt = new("This is a test page or text.", 0, 75, 512, 600, Font.TimesBold, 14);
                txt.Font = theFont;
                doc.Pages[i].Elements.Add(txt);

            }

            AddSchemas(doc);

            doc.Draw(outputPath + "simple-template-raw.pdf");
        }
    }
}
