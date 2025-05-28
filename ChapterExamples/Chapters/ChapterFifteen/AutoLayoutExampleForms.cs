

using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Forms;

namespace ChapterExamples.Chapters.ChapterFifteen
{
    public class AutoLayoutExampleForms
    {
        public static void Create(string outputPath)
        {
            AutoLayout autoLayout = new AutoLayout(PageSize.Letter, PageOrientation.Portrait, 50);
            TextField textField = autoLayout.AddTextField("Description", 75, 150);
            textField.BorderStyle = BorderStyle.Solid;
            textField.MultiLine = true;
            ListBox listBox = autoLayout.AddListBox("Selected Days", 150, 100);
            listBox.Items.Add("Mon", true);
            listBox.Items.Add("Tue");
            listBox.Items.Add("Wed");
            listBox.BorderStyle = BorderStyle.Solid;

            Document document = autoLayout.GetDocument();
            document.Draw(outputPath + "autolayout-output.pdf");
        }
    }
}
