
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Imaging;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterSix
{
    public class TiffExample
    {
        public static void Create(string resourcePath, string outputPath)
        {
            CreateNewDoc(resourcePath, outputPath);
            AddTiffToDoc(resourcePath, outputPath);
            MultiPageAddTiffToDoc(resourcePath, outputPath);
            CreateNewDocMultipage(resourcePath, outputPath);
        }

        public static void CreateNewDoc(string resourcePath, string outputPath)
        {
            TiffFile myTiff = new TiffFile(resourcePath + "model.tif");
            Document doc = myTiff.GetDocument();
            doc.Draw(outputPath + "tiff-doc-out.pdf");

            myTiff.Close();
        }

        public static void CreateNewDocMultipage(string resourcePath, string outputPath)
        {
            TiffFile myTiff = new TiffFile(resourcePath + "multipage.tiff");
            Document doc = myTiff.GetDocument();
            doc.Draw(outputPath + "tiff-doc-multi-out.pdf");

            myTiff.Close();
        }

        public static void AddTiffToDoc(string resourcePath, string outputPath) {

            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));
     
            TiffFile myTiff = new TiffFile(resourcePath + "model.tif");
            doc.Pages[0].Elements.Add(new Image(myTiff.Images[0], 0, 0, .5f));

            doc.Pages.Add(new Page(PageSize.Letter));

            Utility.AddGridLines.AddBackgroundColor(doc);

            doc.Draw(outputPath + "tiff-added-to-page-out.pdf");

            myTiff.Close();
        }

        public static void MultiPageAddTiffToDoc(string resourcePath, string outputPath)
        {

            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));
            doc.Pages.Add(new Page(PageSize.Letter));

            TiffFile myTiff = new TiffFile(resourcePath + "multipage.tiff");
            doc.Pages[0].Elements.Add(new Image(myTiff.Images[0], 0, 0, .25f));
            doc.Pages[1].Elements.Add(new Image(myTiff.Images[1], 0, 0, .25f));
           
            Utility.AddGridLines.AddBackgroundColor(doc);

            doc.Draw(outputPath + "tiff-multipage-added-to-page-out.pdf");

            myTiff.Close();
        }

    }
}
