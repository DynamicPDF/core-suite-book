using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterSeven
{
    public class TransformationGroupExample
    {
        public static void Create(string filePath, string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            TransformationGroup objTgroup = new(300, 300, 100, 200);
            objTgroup.Angle = 90f;
            objTgroup.ScaleX = .75f;
            objTgroup.ScaleY = .75f;

            Image img = new(filePath, 0, 0);
            objTgroup.Add(img);

            TextArea txt = new(TextGenerator.GenerateTextMultiple(1), 0, 100, 512, 692);
            objTgroup.Add(txt);

            Circle cir = new(0, 50, 25);
            cir.FillColor = RgbColor.Navy;
            doc.Pages[0].Elements.Add(cir);

            doc.Pages[0].Elements.Add(objTgroup);

            doc.Draw(outputPath);
        }
    }
}
