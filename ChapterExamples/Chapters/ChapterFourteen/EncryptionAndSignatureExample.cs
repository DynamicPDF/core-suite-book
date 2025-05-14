using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Cryptography;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterFourteen
{
    public class EncryptionAndSignatureExample
    {
        public static void Create(string outputPath)
        {
            Rc4128Example(outputPath);
            Rc440Example(outputPath);
            Aes256Example(outputPath);
            Aes128Example(outputPath);
        }


        public static void Rc4128Example(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));
            doc.Security = new RC4128Security("ownerpassword", "userpassword");
            doc.Draw(outputPath + "rc4128-sig-out.pdf");
        }



        public static void Rc440Example(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));
            doc.Security = new RC440Security("ownerpassword", "userpassword");
            doc.Security.AllowPrint = false;
            doc.Security.AllowEdit = false;
            doc.Draw(outputPath + "rc440-sig-out.pdf");
        }


        public static void Aes128Example(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));
            GenerateText(doc);
            doc.Security = new Aes128Security("ownerpassword", "userpassword");
            doc.Draw(outputPath + "aes128-sig-out.pdf");
        }

        public static void Aes256Example(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));
            GenerateText(doc);
            doc.Security = new Aes256Security("ownerpassword", "userpassword");
            doc.Security.AllowPrint = false;
            doc.Security.AllowEdit = false;
            doc.Security.AllowUpdateAnnotsAndFields = false;
            doc.Draw(outputPath + "aes256-sig-out.pdf");
        }

        private static void GenerateText(Document doc)
        {
            string txt1 = TextGenerator.GenerateText();

            float pgWdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.LeftMargin * 2;

            TextArea txtOne = new(txt1, 0, 0, pgWdth, 20, Font.TimesBold, 14);
            txtOne.Height = txtOne.GetRequiredHeight();
            txtOne.Align = TextAlign.Justify;

            doc.Pages[0].Elements.Add(txtOne);
        }


    }
}
