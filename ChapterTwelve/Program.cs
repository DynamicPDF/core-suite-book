using ChapterExamples.Chapters.ChapterTwelve;
using ChapterExamples.Utility;

namespace ChapterTwelve
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.CreatePath("output/ch12");
            AutoLayoutExampleBarcode.Create(FileUtility.GetPath("output/ch12/autolayout-out.pdf"));
            UPCExamples.Create(FileUtility.GetPath("output/ch12/"));
            QRCodeExample.Create(FileUtility.GetPath("output/ch12/"));
            AztecExample.Create(FileUtility.GetPath("output/ch12/"));
            EANExample.Create(FileUtility.GetPath("output/ch12/"));

        }
    }
}
