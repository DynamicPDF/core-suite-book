
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Forms;

namespace ChapterExamples.Chapters.ChapterFourteen
{
    public class DigitalSignatureExample
    {

        public static void Create(string inputPath, string outputPath)
        {
            VisibleCertify(inputPath, outputPath);
            SignVisible(inputPath, outputPath);
            SignInVisible(inputPath, outputPath);
            SignTimestampVisible(inputPath, outputPath);
            SignVisibleWithImage(inputPath, outputPath);
        }

        public static void VisibleCertify(string inputPath, string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));
            Signature signature = new("signature_field", 50, 10, 400, 100);
            doc.Pages[0].Elements.Add(signature);
            Certificate certificate = new Certificate(inputPath + "JohnDoe.pfx", "password");

            doc.Certify("signature_field", certificate, CertifyingPermission.NoChangesAllowed);
            doc.Draw(outputPath + "vis-dig-cert-out.pdf");
        }

        public static void SignVisible(string inputPath, string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            doc.Pages[0].Elements.Add(new Label("Signed By: ", 0, 100, 75, 0));

            Signature signature = new("signature_field", 75, 100, 100, 50);

            signature.BorderStyle = BorderStyle.Solid;

            doc.Pages[0].Elements.Add(signature);

            Certificate certificate = new Certificate(inputPath + "JohnDoe.pfx", "password");
            doc.Sign("signature_field", certificate);
            doc.Draw(outputPath + "vis-dig-sig-out.pdf");
        }

        public static void SignInVisible(string inputPath, string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            Certificate certificate = new Certificate(inputPath + "JohnDoe.pfx", "password");
            doc.Sign("signature_field", certificate);
            doc.Draw(outputPath + "invis-dig-sig-out.pdf");
        }


        public static void SignTimestampVisible(string inputPath, string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));
            doc.Pages[0].Elements.Add(new Label("Signed By: ", 0, 100, 75, 0));

            Signature signature = new("signature_field", 75, 100, 100, 50);
            doc.Pages[0].Elements.Add(signature);
            TimestampServer timestampServer = new TimestampServer("http://timestamp.digicert.com/");
            Certificate certificate = new Certificate(inputPath + "JohnDoe.pfx", "password");
            doc.Sign("signature_field", certificate, timestampServer);
            doc.Draw(outputPath + "vis-timestamp-dig-sig-out.pdf");
        }

        public static void SignVisibleWithImage(string inputPath, string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));
            doc.Pages[0].Elements.Add(new Label("Signed By: ", 0, 100, 75, 0));

            Signature signature = new("signature_field", 75,50, 200, 85);
            signature.FullPanel.SetImage(inputPath + "signature.png");
            signature.RightPanel.TextColor = RgbColor.LightGrey;
            signature.LeftPanel.HideAllText();
            signature.RightPanel.HideAllText();
            doc.Pages[0].Elements.Add(signature);

            Certificate certificate = new Certificate(inputPath + "JohnDoe.pfx", "password");
            doc.Sign("signature_field", certificate);
            doc.Draw(outputPath + "vis-dig-sig-img-out.pdf");
        }

    }
}
