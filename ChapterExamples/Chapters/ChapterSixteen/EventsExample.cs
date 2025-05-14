
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Forms;

namespace ChapterExamples.Chapters.ChapterSixteen
{
    public class EventsExample
    {
        public static void Create(string outputPath)
        {
            DocumentReaderEvents(outputPath);
            PageReaderEvents(outputPath);
            AnnotationReaderEvents(outputPath);
        }

        public static void DocumentReaderEvents(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));
            
            JavaScriptAction action = new JavaScriptAction("app.alert(\"WillSave\")");
            doc.ReaderEvents.WillSave = action;
            JavaScriptAction action2 = new JavaScriptAction("app.alert(\"WillClose\")");
            doc.ReaderEvents.WillClose = action2;
            JavaScriptAction action3 = new JavaScriptAction("app.alert(\"WillPrint\")");
            doc.ReaderEvents.WillPrint = action3;

            JavaScriptAction action4 = new JavaScriptAction("app.alert(\"DidSave\")");
            doc.ReaderEvents.DidSave = action;
            JavaScriptAction action5 = new JavaScriptAction("app.alert(\"DidPrint\")");
            doc.ReaderEvents.DidPrint = action5;

            doc.Draw(outputPath + "document-readerevent-out.pdf");

        }

        public static void PageReaderEvents(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));
            doc.Pages.Add(new Page(PageSize.Letter));
            
            JavaScriptAction action = new JavaScriptAction("app.alert(\"Open\")");
            doc.Pages[1].ReaderEvents.Open = action;

            JavaScriptAction action2 = new JavaScriptAction("app.alert(\"Close\")");
            doc.Pages[1].ReaderEvents.Close = action2;
            doc.Draw(outputPath + "page-readerevents-out.pdf");

        }

        public static void AnnotationReaderEvents(string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));

            Label label = new Label("Check Box:", 0, 10, 100, 0);
            CheckBox checkBox = new CheckBox("check_box_nm", 110, 7, 50, 50);
            
            JavaScriptAction action = new JavaScriptAction("app.alert(\"mouse-down\")");
            checkBox.ReaderEvents.MouseDown = action;

            JavaScriptAction action2 = new JavaScriptAction("app.alert(\"mouse-up\")");
            checkBox.ReaderEvents.MouseUp = action2;

            doc.Pages[0].Elements.Add(label);
            doc.Pages[0].Elements.Add(checkBox);

            doc.Draw(outputPath + "/form-readerevents-output.pdf");
        }

    }
}
