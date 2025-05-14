using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterThree
{
    public class OmitPageExample
    {
        public static void Create(string outputPath1, string outputPath2)
        {
            Create1(outputPath1);
            Create2(outputPath2);
        }

        public static void Create1(string outputPath)
        {
            Document doc = new Document();
            Template tmp = new Template();
            doc.Template = tmp;
            tmp.Elements.Add(new PageNumberingLabel("%%SP%% of %%ST%%", 0, 680, 512, 12, Font.Helvetica, 12, TextAlign.Center));
            doc.Pages.Add(new Page());
            doc.Pages.Add(new Page());
            doc.Pages[1].ApplyDocumentTemplate = false;
            doc.Pages.Add(new Page());
            doc.Draw(outputPath);
        }

        public static void Create2(string outputPath)
        {
            Document doc = new Document();
            Template tmp = new Template();
            tmp.Elements.Add(new PageNumberingLabel("%%SP%% of %%ST%%", 0, 680, 512, 12, Font.Helvetica, 12, TextAlign.Center));

            doc.Sections.Begin(NumberingStyle.Numeric, tmp);
            doc.Pages.Add(new Page());
            doc.Sections.Begin(NumberingStyle.Numeric, tmp);
            doc.Pages.Add(new Page());
            doc.Pages.Add(new Page());
            doc.Pages.Add(new Page());
            doc.Pages[2].ApplySectionTemplate = false;
            doc.Draw(outputPath);
        }
    }
}
