using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterNineteen
{
    public class EmbeddingExample
    {
        public static void Create(string inputPath, string outputPath)
        {
            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));
            Label label = new Label("Document containing embedded files.", 50, 20, 215, 0);
            doc.Pages[0].Elements.Add(label);
            string fileOne = inputPath + "/ch2/egypt.jpg";
            string fileTwo = inputPath + "/ch1/merge-example.pdf";
            string fileThree = inputPath + "/ch6/model.u3d";
            string fileFour = inputPath + "/ch4/list.html";

            EmbeddedFile embeddedFile1 = new EmbeddedFile(fileOne);
            EmbeddedFile embeddedFile2 = new EmbeddedFile(fileTwo);
            EmbeddedFile embeddedFile3 = new EmbeddedFile(fileThree);
            EmbeddedFile embeddedFile4 = new EmbeddedFile(fileFour);

            embeddedFile1.MimeType = "image/jpg";
            embeddedFile2.MimeType = "application/pdf";
            embeddedFile3.MimeType = "model/u3d";
            embeddedFile4.MimeType = "text/html";

            embeddedFile1.Relation = EmbeddedFileRelation.Source;
            embeddedFile2.Relation = EmbeddedFileRelation.Source;
            embeddedFile3.Relation = EmbeddedFileRelation.Source;
            embeddedFile4.Relation = EmbeddedFileRelation.Source;

            doc.EmbeddedFiles.Add(embeddedFile1);
            doc.EmbeddedFiles.Add(embeddedFile2);
            doc.EmbeddedFiles.Add(embeddedFile3);
            doc.EmbeddedFiles.Add(embeddedFile4);

            doc.InitialPageMode = PageMode.ShowAttachments;

            doc.Draw(outputPath + "embedding-files.pdf");
        }
    }
}
