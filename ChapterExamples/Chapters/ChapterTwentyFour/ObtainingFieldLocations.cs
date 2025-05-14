using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterTwentyFour
{
    public class ObtainingFieldLocations
    {
        public static void Modify(string resourcePath, string outputPath)
        {
            PdfDocument pdfDoc = new(resourcePath + "completed_form.pdf");
            MergeDocument mergeDoc = new(resourcePath + "completed_form.pdf");

            float x1 = pdfDoc.Form.Fields["description"].GetX(mergeDoc.Pages[0]);
            float y1 = pdfDoc.Form.Fields["description"].GetY(mergeDoc.Pages[0]);
            float hgt = pdfDoc.Form.Fields["description"].Height;
            float wdth = pdfDoc.Form.Fields["description"].Width;

            Label lbl = new("Dimensions description field: " + x1 + ", " + y1 + " height: " + hgt + " width: " + wdth, 200, 10, 350, 0);
           
            mergeDoc.Pages[0].Elements.Add(lbl);
            mergeDoc.Draw(outputPath + "position_form.pdf");
        }
    }
}
