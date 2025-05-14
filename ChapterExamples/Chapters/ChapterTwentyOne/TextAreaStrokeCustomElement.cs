
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterTwentyOne
{
    class TextAreaStrokeCustomElement:TextArea
    {

        public TextAreaStrokeCustomElement(string text, float x, float y, float width, float height) : base(text, x, y, width, height)
        { }

        public override void Draw(PageWriter writer)
        {
            Font font = Font.CourierBold;
            writer.SetTextMode();
            writer.SetFont(font, 25f);
            writer.SetTextRenderingMode(TextRenderingMode.FillAndStroke);
            writer.SetStrokeColor(RgbColor.Red);
            writer.SetFillColor(RgbColor.Navy);
            writer.SetLeading(font.GetDefaultLeading(12));
            writer.Write_Tm(base.X, base.Y);
            writer.Write_SQuote(base.Text.ToCharArray(), 0, base.Text.Length, false);
        }
    }
}
