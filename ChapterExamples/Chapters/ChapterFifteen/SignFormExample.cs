using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Forms;

namespace ChapterExamples.Chapters.ChapterFifteen
{
    public class SignFormExample
    {
        public static void Create(string inputPath, string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));

            Label label = new("Final Report?", 0, 0, 100, 0);
            CheckBox checkBox = new("final_report", label.Width + 5, 0, 20, 20);
            checkBox.DefaultChecked = false;
            checkBox.ToolTip = "Check if this is final report.";
            doc.Pages[0].Elements.Add(label);
            doc.Pages[0].Elements.Add(checkBox);

            Label label2 = new("Signature:",0, 50, 100, 0);
            Signature signature = new("user_signature", 100, 50, 300, 100);
            signature.FullPanel.SetImage(inputPath + "signature.png");
            doc.Pages[0].Elements.Add(label2);
            doc.Pages[0].Elements.Add(signature);
            doc.Draw(outputPath + "signature-form-out.pdf");
        }
    }
}
