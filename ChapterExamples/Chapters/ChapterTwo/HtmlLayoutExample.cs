using ceTe.DynamicPDF;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterTwo
{
    public class HtmlLayoutExample
    {
        public static void Create(string outputPath)
        {
            PageInfo layoutPage = new(PageSize.Letter, PageOrientation.Portrait);
                        
            HtmlLayout html = new(TextGenerator.GenerateHtmlWithImg(), layoutPage);

            html.Header.Center.Text = "%%PR%%%%SP%% of %%ST%%";
            html.Header.Center.HasPageNumbers = true;
            html.Header.Center.Width = 200;

            html.Footer.Center.Text = "%%PR%%%%SP(A)%% of %%ST(B)%%";
            html.Footer.Center.HasPageNumbers = true;
            html.Footer.Center.Width = 200;


            Document myDoc = html.Layout();


            myDoc.Draw(outputPath + "ch2-HtmlLayoutExample-out.pdf");
        }
    }
}
