
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.Merger;

namespace ChapterExamples.Chapters.ChapterTwentyFour
{
    public class FormFlattening
    {
        public static void Modify(string resourcePath, string outputPath)
        {
            RemoveAllFields(resourcePath, outputPath);
            FlattenAllField(resourcePath, outputPath);
            FlattenAndRmoveIndividualField(resourcePath, outputPath);
        }


        public static void FlattenIndividualFields(string resourcePath, string outputPath)
        {
           
        }

        public static void FlattenAllField(string resourcePath, string outputPath)
        {
            MergeDocument mergeDoc = new MergeDocument(resourcePath + "completed_form.pdf");
            mergeDoc.Form.Output = FormOutput.Flatten;
            mergeDoc.Draw(outputPath + "allfields_flattened_form.pdf");
        }

        public static void RemoveAllFields(string resourcePath, string outputPath)
        {
            MergeDocument mergeDoc = new MergeDocument(resourcePath + "form.pdf");
            mergeDoc.Form.Output = FormOutput.Remove;
            mergeDoc.Draw(outputPath + "allfields_removed_form.pdf");
        }

        public static void FlattenAndRmoveIndividualField(string resourcePath, string outputPath)
        {
            MergeDocument mergeDoc = new MergeDocument(resourcePath + "form.pdf");
            mergeDoc.Form.Fields[0].Output = FormFieldOutput.Flatten;
            mergeDoc.Form.Fields[1].Output = FormFieldOutput.Remove;
            mergeDoc.Draw(outputPath + "individual_fields_flattened_form.pdf");
        }

    }
}
