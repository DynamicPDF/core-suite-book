using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Forms;
using TextField = ceTe.DynamicPDF.PageElements.Forms.TextField;

namespace ChapterExamples.Chapters.ChapterTwentyFour
{
    public class FormModificationExample
    {
        public static void Modify(string resourcePath, string outputPath)
        {
            RemoveField(resourcePath, outputPath);
            ReplaceField(resourcePath, outputPath);
            ReplaceTwoFields(resourcePath, outputPath);
            AddField(resourcePath, outputPath);
            MergeTwoForms(resourcePath, outputPath);
        }

        public static void AddField(string resourcePath, string outputPath)
        {
            MergeDocument mergeDoc = new MergeDocument(resourcePath + "form.pdf");
            PdfDocument pdfDoc = new(resourcePath + "form.pdf");

            float x = pdfDoc.Form.Fields["completed_book"].GetX(mergeDoc.Pages[0]);
            float y = pdfDoc.Form.Fields["completed_book"].GetY(mergeDoc.Pages[0]);

            Label lbl = new("Time to Complete", x + 175, y, 150,0);

            ListBox listBox = new ListBox("completion_time", x+300, y, 100, 100);
            listBox.Items.Add("short");
            listBox.Items.Add("moderate", true);
            listBox.Items.Add("long");
            listBox.Items.Add("very long");

            mergeDoc.Pages[0].Elements.Add(lbl);
            mergeDoc.Pages[0].Elements.Add(listBox);
            mergeDoc.Draw(outputPath + "addfield_form.pdf");
        }

        public static void RemoveField(string resourcePath, string outputPath)
        {
            MergeDocument mergeDoc = new MergeDocument(resourcePath + "form.pdf");
            PdfDocument pdfDoc = new(resourcePath + "form.pdf");
            float x = pdfDoc.Form.Fields["completed_book"].GetX(mergeDoc.Pages[0]);
            float y = pdfDoc.Form.Fields["completed_book"].GetY(mergeDoc.Pages[0]);
            mergeDoc.Form.Fields["completed_book"].Output = FormFieldOutput.Remove;
            Label lbl = new("Redacted", x, y, 75, 0);
            lbl.Font = Font.HelveticaOblique;
            mergeDoc.Pages[0].Elements.Add(lbl);
            mergeDoc.Draw(outputPath + "removefield_form.pdf");
        }

        public static void ReplaceField(string resourcePath, string outputPath)
        {
            MergeDocument mergeDoc = new MergeDocument(resourcePath + "form.pdf");
            PdfDocument pdfDoc = new(resourcePath + "form.pdf");
            float x = pdfDoc.Form.Fields["completed_book"].GetX(mergeDoc.Pages[0]);
            float y = pdfDoc.Form.Fields["completed_book"].GetY(mergeDoc.Pages[0]);
            mergeDoc.Form.Fields["completed_book"].Output = FormFieldOutput.Remove;
            TextField txtField = new ceTe.DynamicPDF.PageElements.Forms.TextField("comleted_book", x, y, 200, 20);
            mergeDoc.Pages[0].Elements.Add(txtField);
            mergeDoc.Draw(outputPath + "replaced_form.pdf");
        }

        public static void ReplaceTwoFields(string resourcePath, string outputPath)
        {
            MergeDocument mergeDoc = new MergeDocument(resourcePath + "form.pdf");
            PdfDocument pdfDoc = new(resourcePath + "form.pdf");
            pdfDoc.Form.Fields["completed_book"].CreateLabel(mergeDoc.Pages[0], "NA", Font.HelveticaOblique, 12);
            mergeDoc.Form.Fields["completed_book"].Output = FormFieldOutput.Remove;
            Rectangle rect = new Rectangle(0, 0, 200, 200);
            rect.FillColor = RgbColor.Orange;
            rect.BorderColor = RgbColor.Navy;
            mergeDoc.Pages[0].Elements.Add(rect);
            pdfDoc.Form.Fields["description"].PositionPageElement(rect, mergeDoc.Pages[0]);
            mergeDoc.Form.Fields["description"].Output = FormFieldOutput.Remove;
            mergeDoc.Draw(outputPath + "replaced_form_pdfform.pdf");
        }


        public static void MergeTwoForms(string resourcePath, string outputPath)
        {
            MergeOptions options1 = new MergeOptions(true, "form1");
            MergeOptions options2 = new MergeOptions(true, "form2");
            MergeDocument mergeDoc = new MergeDocument(resourcePath + "simpleform1.pdf", options1);
            mergeDoc.Append(resourcePath + "simpleform2.pdf", options2);
            mergeDoc.Draw(outputPath + "merged_form.pdf");
        }

    }
}
