using ChapterExamples.Chapters.ChapterFourteen;
using ChapterExamples.Utility;

namespace ChapterFourteen
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.CreatePath("output/ch14");
            EncryptionAndSignatureExample.Create(FileUtility.GetPath("output/ch14/"));
            DigitalCertificateExample.Create(FileUtility.GetPath("../ChapterExamples/resources/ch14/JohnDoe.pfx"), FileUtility.GetPath("output/ch14/"));
            DigitalSignatureExample.Create(FileUtility.GetPath("../ChapterExamples/resources/ch14/"), FileUtility.GetPath("output/ch14/"));
        }
    }
}
