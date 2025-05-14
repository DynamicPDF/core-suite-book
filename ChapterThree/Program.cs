using ChapterExamples.Chapters.ChapterThree;
using ChapterExamples.Utility;

namespace ChapterThree
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.CreatePath("output/ch3");
            OmitPageExample.Create(FileUtility.GetPath("output/ch3/omit-page-doc-out.pdf"), FileUtility.GetPath("output/ch3/omit-page-sec-out.pdf"));
            SimpleTemp.Create(FileUtility.GetPath("output/ch3/simple-out.pdf"));
            SectionDifferentTemp.Create(FileUtility.GetPath("../ChapterExamples/resources/ch3/"), FileUtility.GetPath("output/ch3/ch3-sect-temp-out.pdf"));
            TemplateExample.Create(FileUtility.GetPath("../ChapterExamples/resources/ch3/"), FileUtility.GetPath("output/ch3/ch3-tmp-out.pdf"));
            StampTemplateExample.Create(FileUtility.GetPath("../ChapterExamples/resources/ch3/"), FileUtility.GetPath("output/ch3/ch3-stmptmp-out.pdf"));
           HeaderFooterExample.Create(FileUtility.GetPath("output/ch3/ch3-hdrftr-out.pdf"));
            EvenOddTemplateExample.Create(FileUtility.GetPath("output/ch3/ch3-evodtmp-out.pdf"));
            DocumentSectionExample.Create(FileUtility.GetPath("output/ch3/ch3-docsecs-out.pdf"));

        }
    }
}
