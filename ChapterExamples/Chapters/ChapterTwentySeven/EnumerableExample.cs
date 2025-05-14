
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.Data;
using ChapterExamples.Chapters.ChapterTwentySeven.Data;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterTwentySeven
{
    public class EnumerableExample
    {
        public static void CreateReport(string resourcePath, string outputPath)
        {
            Data.Chapters chapters = new Data.Chapters();

            for (int i = 1; i < 15; i++)
                chapters.Add(new Chapter("Chapter " + i, "The summary of chapter " + i + "\n" + TextGenerator.GenerateShort()));


            DocumentLayout layout = new DocumentLayout(resourcePath + "enumerable-example.dlex");
            EnumerableReportData enumData = new(chapters);

             
            LayoutData data = new();
            data.Add("Chapters", enumData);

            Document doc = layout.Layout(data);
            doc.Draw(outputPath + "enumerable-report.pdf");
        }
    }
}
