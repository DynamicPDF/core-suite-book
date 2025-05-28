
using ChapterExamples.Chapters.ChapterSix;
using ChapterExamples.Utility;

namespace ChapterSix
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.CreatePath("output/ch6");
            AutoLayoutImagesExample.Create(FileUtility.GetPath("../ChapterExamples/resources/"), FileUtility.GetPath("output/ch6/autolayout.pdf"));
            JpegDataExample.Create(FileUtility.GetPath("../ChapterExamples/resources/ch6/In_Motion.jpg"), FileUtility.GetPath("output/ch6/jpeg-out.pdf"));
            ImageExample.Create(FileUtility.GetPath("../ChapterExamples/resources/"), FileUtility.GetPath("output/ch6/image-out.pdf"));
            BackgroundImageExample.Create(FileUtility.GetPath("../ChapterExamples/resources/ch2/egypt.jpg"), FileUtility.GetPath("output/ch6/background-image-out.pdf"));
            ImageWatermarkExample.Create(FileUtility.GetPath("../ChapterExamples/resources/ch3/logo.png"), FileUtility.GetPath("output/ch6/imagewatermark-out.pdf"));
            Image3dExample.Create(FileUtility.GetPath("../ChapterExamples/resources/ch6/"), FileUtility.GetPath("output/ch6/image3d-out.pdf"));
            TiffExample.Create(FileUtility.GetPath("../ChapterExamples/resources/ch6/"), FileUtility.GetPath("output/ch6/"));

        }
    }
}
