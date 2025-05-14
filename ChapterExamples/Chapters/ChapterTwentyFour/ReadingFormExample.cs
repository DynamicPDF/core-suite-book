
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.Merger.Forms;
using System;

namespace ChapterExamples.Chapters.ChapterTwentyFour
{
    public class ReadingFormExample
    {

        public static void Modify(string resourcePath, string outputPath)
        {
            ReadingAField(resourcePath, outputPath);
            ReadingForm(resourcePath, outputPath);
            ReadingTwoForms(resourcePath, outputPath);
        }

        public static void ReadingAField(string resourcePath, string outputPath)
        {
            PdfDocument pdfDoc = new(resourcePath + "completed_form.pdf");
            MergeDocument mergeDoc = new(resourcePath + "completed_form.pdf");

            PdfFormField pdfFormField = pdfDoc.Form.Fields["description"];
            FormField mergeDocFormField = mergeDoc.Form.Fields["description"];

            string val = pdfFormField.GetValue() + " | " + mergeDocFormField.Value;
            string val2 = "\n" + pdfFormField.FontSize + " | " + mergeDocFormField.FontSize;
            string val3 = "\n " + pdfFormField.GetType().ToString() + " | " + mergeDocFormField.GetType().ToString();
            string val4 = "\n" + pdfFormField.ToString() + " | " + mergeDocFormField.ToString();

            Console.WriteLine(val + val2 + val3 + val4);

        }

        public static void ReadingForm(string resourcePath, string outputPath)
        {
            PdfDocument pdfDoc = new(resourcePath + "completed_form.pdf");
            MergeDocument mergeDoc = new(resourcePath + "completed_form.pdf");

            string val1 = pdfDoc.Form.Fields["completed_book"].GetValue();
            string val2 = pdfDoc.Form.Fields["position"].GetValue();
            string val3 = mergeDoc.Form.Fields["full_name"].Value;
            string val4 = mergeDoc.Form.Fields["description"].Value;
            string val5 = mergeDoc.Form.Fields["selected_days"].Value;
            string val6 = mergeDoc.Form.Fields["favorite_color"].Value;

            Console.WriteLine(val1 + " " + val2 + " " + val3 + " " + val4 + " " + val5 + " " + val6);
        }


        public static void ReadingTwoForms(string resourcePath, string outputPath)
        {
            MergeDocument mergeDoc = new(resourcePath + "simpleform1_completed.pdf", new MergeOptions(true, "form1"));
            MergeOptions options = new();
            options.FormFields = true;
            options.RootFormField = "form2";
            mergeDoc.Append(resourcePath + "simpleform2_completed.pdf", options);

            string val1 = mergeDoc.Form.Fields["form1.first_name"].Value;
            string val2 = mergeDoc.Form.Fields["form1.last_name"].Value;
            string val3 = mergeDoc.Form.Fields["form1.description"].Value;
            string val4 = mergeDoc.Form.Fields["form2.full_name"].Value;
            string val5 = mergeDoc.Form.Fields["form2.description"].Value;

            Console.WriteLine(val1 + " " + val2 + " " + val3 + " " + val4 + " " + val5);

        }

        public static void ReadingTwoForms2(string resourcePath, string outputPath)
        {
            PdfDocument doc1 = new(resourcePath + "simpleform1_completed.pdf");
            PdfDocument doc2 = new(resourcePath + "simpleform2_completed.pdf");

            string val1 = doc1.Form.Fields["first_name"].GetValue();
            string val2 = doc1.Form.Fields["last_name"].GetValue();
            string val3 = doc1.Form.Fields["description"].GetValue();
            string val4 = doc2.Form.Fields["full_name"].GetValue();
            string val5 = doc2.Form.Fields["description"].GetValue();

            Console.WriteLine(val1 + " " + val2 + " " + val3 + " " + val4 + " " + val5);

        }

    }
}
