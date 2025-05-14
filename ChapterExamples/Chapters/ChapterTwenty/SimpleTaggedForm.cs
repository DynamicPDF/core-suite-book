using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Forms;
using ceTe.DynamicPDF.Text;
using ceTe.DynamicPDF.Xmp;

namespace ChapterExamples.Chapters.ChapterTwenty
{
    public class SimpleTaggedForm
    {

        public static void MetaData(Document doc)
        {
            doc.Title = "My Document Title";
            doc.Creator = "SimpleTaggedExample.cs";
            doc.Author = "James A Brannan";
            doc.Keywords = "simple csharp example";
            doc.Language = "en-us";
            doc.ViewerPreferences.DisplayDocTitle = true;
        }

        public static void Create(string resourcePath, string outputPath)
        {
            Document doc = new();
            MetaData(doc);
            doc.Tag = new TagOptions();
            doc.Pages.Add(new Page(PageSize.Letter));

            OpenTypeFont theFont = new OpenTypeFont(resourcePath + "/ch20/ARIAL.TTF");
            theFont.Embed = true;
            theFont.Subset = false;

            StructureElement structureDocument = new StructureElement(TagType.Document);

            Label label = new Label("Description:", 0, 0, 75, 0);
            label.Font = theFont;
            TextField textField = new TextField("description", 75, 0, 200, 200);
            textField.BorderStyle = BorderStyle.Solid;
            textField.ToolTip = "Enter description as text.";
            textField.MultiLine = true;
            textField.Font = theFont;

            doc.Pages[0].Elements.Add(label);
            doc.Pages[0].Elements.Add(textField);

            StructureElement structLbl = new StructureElement(TagType.Paragraph);
            structLbl.Order = 1;
            structLbl.Parent = structureDocument;
            label.Tag = structLbl;

            StructureElement structTxt = new StructureElement(TagType.Form);
            structTxt.Order = 2;
            structTxt.Parent = structureDocument;
            textField.Tag = structTxt;



            Label label2 = new("Favorite Color:", 0, 250, 100, 0);
            label2.Font = theFont;
            ComboBox comboBox = new ComboBox("favorite_color", 110, 250, 150, 25);
            comboBox.Items.Add("Red", true);
            comboBox.Items.Add("White");
            comboBox.Items.Add("Blue");
            comboBox.BorderStyle = BorderStyle.Solid;
            comboBox.Editable = true;
            comboBox.ToolTip = "Select favorite color.";
            comboBox.Font = theFont;

            doc.Pages[0].Elements.Add(label2);
            doc.Pages[0].Elements.Add(comboBox);

            StructureElement structLbl2 = new StructureElement(TagType.Paragraph);
            structLbl2.Order = 3;
            structLbl2.Parent = structureDocument;
            label2.Tag = structLbl2;

            StructureElement structCmb = new StructureElement(TagType.Form);
            structCmb.Order = 4;
            structCmb.Parent = structureDocument;
            comboBox.Tag = structCmb;

            Button button = new Button("reset", 50,325, 100, 20);
            button.BackgroundColor = RgbColor.Yellow;
            button.BorderStyle = BorderStyle.Beveled;
            button.Action = new ResetAction();
            button.Label = "Reset";
            button.ToolTip = "Reset button.";
            button.Font = theFont;

            StructureElement structBtn = new StructureElement(TagType.Form);
            structBtn.Order = 5;
            structBtn.Parent = structureDocument;
            button.Tag = structBtn;

            doc.Pages[0].Elements.Add(button);

            AddSchemas(doc);

            doc.Draw(outputPath + "tagged-simple-form-out.pdf");

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
