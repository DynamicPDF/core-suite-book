using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterThree
{
    public class SimpleTemp
    {
        public static void Create(string outputPath)
        {
            Document doc = new Document();
            Template tmp = new Template();
           // tmp.Elements.Add(new PageNumberingLabel("%%CP%% of %%TP%%", 0, 680, 512, 12, Font.Helvetica, 12, //TextAlign.Center));
            tmp.Elements.Add(new PageNumberingLabel("%%SP%% of %%ST%%", 0, 680, 512, 12, Font.Helvetica, 12, TextAlign.Center));

            doc.Sections.Begin(NumberingStyle.RomanLowerCase);
            doc.Pages.Add(new Page()); 
            doc.Sections.Begin(NumberingStyle.Numeric, tmp);
            doc.Pages.Add(new Page());
            doc.Pages.Add(new Page());
            doc.Sections.Begin(NumberingStyle.RomanLowerCase, "Last Section - ", tmp);
            doc.Pages.Add(new Page());
            doc.Pages.Add(new Page());
            doc.Draw(outputPath);
        }
    }
}
