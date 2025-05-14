using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Forms;

namespace ChapterExamples.Chapters.ChapterEighteen
{
    public class EmailingAForm
    {
        public static void Create(string outputPath)
        {
            MailSubmit(outputPath);  
        }

        public static void MailSubmit(string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));

            Label label = new Label("Full Name:", 0, 0, 75, 0);
            TextField textField = new TextField("full_name", 75, 0, 200, 25);
            textField.BorderStyle = BorderStyle.Solid;
            doc.Pages[0].Elements.Add(label);
            doc.Pages[0].Elements.Add(textField);


            string bodyMsg = "Thank you for your submission.";
            string javascriptString = "var cEmailURL = \"mailto:james@dynamicpdf.com?subject='Form Submission'&body='" + bodyMsg + "'\";";
            javascriptString += " this.submitForm({ cURL: encodeURI(cEmailURL), cSubmitAs: 'XML', cCharSet: 'utf-8'});";

            Button button = new Button("email", 0, 100, 100, 20);

            button.BackgroundColor = RgbColor.Yellow;
            button.BorderStyle = BorderStyle.Beveled;
            button.Action = new JavaScriptAction(javascriptString);
            button.Label = "Email";
            doc.Pages[0].Elements.Add(button);

            doc.Draw(outputPath + "form-email-out.pdf");
        }

    }
}
