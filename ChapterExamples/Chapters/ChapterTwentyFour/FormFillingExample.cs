using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.Merger;

namespace ChapterExamples.Chapters.ChapterTwentyFour
{
    public class FormFillingExample
    {
        public static void Modify(string resourcePath, string outputPath)
        {
            CompletingForm(resourcePath, outputPath);
            CompletingTwoForms(resourcePath, outputPath);
        }

        public static void CompletingForm(string resourcePath, string outputPath)
        {
            MergeDocument mergeDoc = new MergeDocument(resourcePath + "form.pdf");
            mergeDoc.Form.Fields["completed_book"].Value = "Yes";
            mergeDoc.Form.Fields["position"].Value = "yellow";
            mergeDoc.Form.Fields["full_name"].Value = "John Doe";
            mergeDoc.Form.Fields["description"].Value = "This is a description.";
            ((ListBoxField)mergeDoc.Form.Fields["selected_days"]).SetValues(new string[] { "Mon", "Wed", "Fri" });
            mergeDoc.Form.Fields["favorite_color"].Value = "White";
            mergeDoc.Draw(outputPath + "completed_form.pdf");
        }

        public static void CompletingTwoForms(string resourcePath, string outputPath)
        {
            MergeDocument mergeDoc = new(resourcePath + "simpleform1.pdf", new MergeOptions(true, "form1"));
            MergeOptions options = new(true, "form2");
            mergeDoc.Append(resourcePath + "simpleform2.pdf", options);

            mergeDoc.Form.Fields["form1.first_name"].Value = "John";
            mergeDoc.Form.Fields["form1.last_name"].Value = "Doe";
            mergeDoc.Form.Fields["form1.description"].Value = "Favorite food is pizza.";
            mergeDoc.Form.Fields["form2.full_name"].Value = "John Doe";
            mergeDoc.Form.Fields["form2.description"].Value = "Too much pepper on pizza.";

            mergeDoc.Draw(outputPath + "readvalues_combined_form.pdf");

        }
    }
}
