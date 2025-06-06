using ceTe.DynamicPDF.Cryptography;
using ceTe.DynamicPDF.Merger;

namespace ChapterExamples.Chapters.ChapterTwentyFour
{
    public class FormReadOnly
    {
        public static void Modify(string resourcePath, string outputPath)
        {
            ReadOnly(resourcePath, outputPath);
          
        }

        public static void ReadOnly(string resourcePath, string outputPath)
        {
            MergeDocument mergeDoc = new MergeDocument(resourcePath + "completed_form.pdf");
            mergeDoc.Form.IsReadOnly = true;
            Aes256Security security = new("owner", "user");
            security.AllowFormFilling = false;
            security.AllowUpdateAnnotsAndFields = false;
            security.AllowEdit = false;
            mergeDoc.Security = security;

            mergeDoc.Draw(outputPath + "read-only-completed_form.pdf");
        }

    }
}
