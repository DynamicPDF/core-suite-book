using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace ChapterExamples.Chapters.ChapterTwentyOne
{
    public class SimpleCustomElement: PageElement
    {

        public override void Draw(PageWriter writer)
        {
            Font font = Font.Helvetica;
            writer.SetTextMode();
            writer.SetFont(font, 18f);
            writer.Write_Tm(50, 200);
            string text = "Hello Custom Component.";
            writer.Write_SQuote(text.ToCharArray(), 0,text.Length, false);
        }
    }
}
