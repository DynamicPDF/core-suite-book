using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Forms;
using ChapterExamples.Chapters.ChapterFifteen;

namespace ChapterExamples.Chapters.ChapterSeventeen
{
    public class JavasScriptDomExample
    {

        public static void Create(string outputPath)
        {
            Console(outputPath);
            AlertOnLoad(outputPath);

        }

        public static void Console(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));
            doc.Pages.Add(new Page(PageSize.Letter));
            doc.Pages.Add(new Page(PageSize.Letter));

            string javascriptString = "console.println('Adobe Acrobat console.');";
            javascriptString += "console.println('page count from DynamicPdf " + doc.Pages.Count + "');";
            javascriptString += "console.println('page count from JavaScript ' + this.numPages);";

            JavaScriptAction action = new(javascriptString);
            doc.JavaScripts.Add(new DocumentJavaScript("on_load", javascriptString));

            doc.Draw(outputPath + "simple-dom-javascript-output.pdf");
        }

        public static void AlertOnLoad(string outputPath)
        {
            Document doc = FormFieldsExample.CreateRetDoc(outputPath, true);
            doc.Author = "John Doe";
            doc.JavaScripts.Add(new DocumentJavaScript("submit_alert", "app.alert({ cMsg:\"You must submit this form.\", nIcon:1, cTitle:\"Submit Warning\"});"));
            doc.JavaScripts.Add(new DocumentJavaScript("on_load", "console.println(\"Author \" + this.author)"));
            doc.Draw(outputPath + "alert-dom-javascript-output.pdf");
        }



    }
}
