using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Imaging;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterSix
{
    public class JpegDataExample
    {

        //By Aaron Ruy Musa - Own work, CC BY-SA 4.0, https://commons.wikimedia.org/w/index.php?curid=134986047

        public static void Create(string resourcPath, string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter, PageOrientation.Landscape));

            JpegImageData jpgData = new(resourcPath);
            Image img = new Image(jpgData, 0, 0);
            
            doc.Pages[0].Elements.Add(img);

            Utility.AddGridLines.AddBackgroundColor(doc);

            doc.Draw(outputPath);
        }

    }
}
