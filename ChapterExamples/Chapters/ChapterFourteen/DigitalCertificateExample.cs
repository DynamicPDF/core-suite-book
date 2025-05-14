
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Forms;

namespace ChapterExamples.Chapters.ChapterFourteen
{
    public class DigitalCertificateExample
    {

        public static void Create(string inputPath, string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            Certificate certificate = new Certificate(inputPath, "password");

            doc.Certify("signature_field", certificate, CertifyingPermission.NoChangesAllowed);
            doc.Draw(outputPath + "invis-dig-cert-out.pdf");
        }

    }
}
