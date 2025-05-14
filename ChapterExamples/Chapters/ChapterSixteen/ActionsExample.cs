
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Forms;

namespace ChapterExamples.Chapters.ChapterSixteen
{
    public class ActionsExample
    {

        public static void Create(string fileInput, string outputPath)
        {
            AnnotationShowHideActionExample(outputPath);
            GoToActionExample(outputPath);
            FileOpenActionExample(fileInput, outputPath);
            UrlActionExample(outputPath);
            ResetActionExample(outputPath);
            ChainActionExample(fileInput, outputPath);
            ImportFormDataExample(fileInput, outputPath);
        }

        public static void ImportFormDataExample(string fileInput, string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));

            Label label1 = new Label("Name:", 0, 0, 100, 30);
            TextField textField = new TextField("text_field", 50, 0, 200, 20);
            Label label2 = new Label("Completed:", 0, 50, 75, 0);
            CheckBox chkBox = new CheckBox("check_field", 75, 50, 20, 20);
            Button button = new Button("btn", 0, 100, 100, 30);
            button.Label = "Import Data";

            doc.Pages[0].Elements.Add(label1);
            doc.Pages[0].Elements.Add(label2);
            doc.Pages[0].Elements.Add(textField);
            doc.Pages[0].Elements.Add(chkBox);
            doc.Pages[0].Elements.Add(button);
            ImportFormDataAction action = new ImportFormDataAction("c:/temp/import-form-data-action-_data.fdf");
            button.ReaderEvents.MouseUp = action;

            doc.Draw(outputPath + "import-form-data-action-output.pdf");

        }

        public static void ChainActionExample(string inputPath, string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));
            doc.Pages.Add(new Page(PageSize.Letter));

            TextField textField = new TextField("text_field", 0, 50, 200, 20);
            textField.DefaultValue = "default text value";

            Button button = new Button("btn", 0, 150, 100, 30);
            button.Label = "Chain";

            doc.Pages[0].Elements.Add(new Label("Page 1", 0, 0, 100, 15));
            doc.Pages[1].Elements.Add(new Label("Page 2", 0, 0, 100, 15));

            doc.Pages[0].Elements.Add(textField);
            doc.Pages[0].Elements.Add(button);

            ResetAction action = new ResetAction();
            button.ReaderEvents.MouseUp = action;

            action.NextAction = new GoToAction(2, PageZoom.FitWidth);
            action.NextAction = new FileOpenAction(inputPath, FileLaunchMode.NewWindow);

            doc.Draw(outputPath + "chain-action-output.pdf");

        }

        public static void ResetActionExample(string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));

            Label label2 = new Label("Name:", 0, 50, 75, 0);
            TextField textField = new TextField("text_field", 75, 50, 200, 20);
            textField.DefaultValue = "default text value";
            doc.Pages[0].Elements.Add(label2);
            doc.Pages[0].Elements.Add(textField);


            Button button = new Button("btn", 50, 150, 100, 30);
            button.Label = "Reset";
            ResetAction action = new ResetAction();
            button.ReaderEvents.MouseUp = action;

            doc.Pages[0].Elements.Add(button);
            doc.Draw(outputPath + "reset-action-output.pdf");
        }

        public static void UrlActionExample(string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));

            string text = "This is a link to DynamicPDF API.";

            Label label = new Label(text, 50, 20, 215, 80);
            label.Underline = true;
            Link link = new(50, 20, 150, 20, new UrlAction("https://dpdf.io/"));

            UrlAction action = new UrlAction("http://www.dynamicpdf.com");
            Button button = new Button("btn", 50, 100, 100, 50);
            button.Label = "Click";
            button.Action = action;

            doc.Pages[0].Elements.Add(label);
            doc.Pages[0].Elements.Add(link);
            doc.Pages[0].Elements.Add(button);
            doc.Draw(outputPath + "url-navigate-action-output.pdf");
        }

        public static void AnnotationShowHideActionExample(string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));

            Label label2 = new Label("Name:", 0, 50, 75, 0);
            TextField textField = new TextField("Text1", 75, 50, 200, 20);
            textField.DefaultValue = "Text Field Value";
            doc.Pages[0].Elements.Add(label2);
            doc.Pages[0].Elements.Add(textField);


            Button button = new Button("btn", 50, 150, 100, 30);
            button.Label = "Hide";
          
            AnnotationShowHideAction action = new AnnotationShowHideAction("Text1");
            button.ReaderEvents.MouseDown = action;

            Button button2 = new Button("btn", 175, 150, 100, 30);
            button2.Label = "Show";

            AnnotationShowHideAction action2 = new AnnotationShowHideAction("Text1");
            action2.ShowField = true;
            button2.ReaderEvents.MouseDown = action2;

            doc.Pages[0].Elements.Add(button);
            doc.Pages[0].Elements.Add(button2);

            doc.Draw(outputPath + "annotation-show-hide-action-output.pdf");

        }

        public static void GoToActionExample(string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));
            doc.Pages.Add(new Page(PageSize.Letter));
            doc.Pages[0].Elements.Add(new Label("Page 1", 0, 0, 100, 15));
            doc.Pages[1].Elements.Add(new Label("Page 2", 0, 0, 100, 15));
            
            Button button = new Button("btn", 50, 150, 100, 30);
            button.Label = "Change Page";
            GoToAction action = new GoToAction(2, PageZoom.FitWidth);
            button.ReaderEvents.MouseUp = action;

            doc.Pages[0].Elements.Add(button);
            doc.Draw(outputPath + "go-to-action-output.pdf");
        }

        public static void FileOpenActionExample(string inputPath, string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));
         
            Button button = new Button("btn", 50, 150, 100, 30);
            button.Label = "Open File";
            FileOpenAction action = new FileOpenAction(inputPath, FileLaunchMode.NewWindow);
            button.ReaderEvents.MouseUp = action;

            doc.Pages[0].Elements.Add(button);
            doc.Draw(outputPath + "file-open-action-output.pdf");
        }

    }
}
