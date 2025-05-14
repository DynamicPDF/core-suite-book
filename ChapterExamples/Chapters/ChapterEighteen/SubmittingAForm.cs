
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Forms;
using ChapterExamples.Chapters.ChapterFifteen;

namespace ChapterExamples.Chapters.ChapterEighteen
{
    public class SubmittingAForm
    {
        public static void Create(string outputPath)
        {
            Document doc = FormFieldsExample.CreateRetDoc(outputPath, false);
            Button button = new Button("submit", 0, 650, 100, 20);
            button.BackgroundColor = RgbColor.Blue;
            button.TextColor = RgbColor.White;
            button.BorderStyle = BorderStyle.Beveled;
            button.Action = new SubmitAction("http://localhost:8000/test.php", FormExportFormat.HtmlPost);
            button.Label = "Submit";
            doc.Pages[0].Elements.Add(button);
            doc.Draw(outputPath + "form-submit-post-out.pdf");
        }
    }
}
