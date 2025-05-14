using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterThirteen
{
    public class ChildOutlines
    {
        public static void Create(string outputPath)
        {
            Document doc = new();

            for (int i = 0; i < 16; i++)
            {
                CreatePage(doc, i);
            }

            Outline outline = doc.Outlines.Add("My Document One");
            outline.Expanded = true;
            outline.ChildOutlines.Add("Preface", new XYDestination(2, 0, 0));
            outline.ChildOutlines.Add("Forward", new XYDestination(4, 0, 0));


            Outline childOutline1 = outline.ChildOutlines.Add("Chapter One", new XYDestination(5, 0, 0));
            childOutline1.Expanded = false;
            childOutline1.ChildOutlines.Add("Section One", new XYDestination(7, 0, 0));
            childOutline1.ChildOutlines.Add("Section Two", new XYDestination(9, 0, 0));

            outline.ChildOutlines.Add("Chapter Two", new XYDestination(10, 0, 0));

            foreach (Outline childOutline in outline.ChildOutlines)
            {
                childOutline.Expanded = false;
            }

            doc.Draw(outputPath);
        }

        
        private static void CreatePage(Document doc, int i)
        {
            string txt1 = TextGenerator.GenerateTextMultiple(4);
            
            FormattedTextAreaStyle style = new(FontFamily.Helvetica, 12, false);
            FormattedTextArea txtOne = new(txt1, 0, 0, 512, 0, style);
            txtOne.Height = txtOne.GetRequiredHeight();
            doc.Pages.Add(new Page(PageSize.Letter));
            doc.Pages[i].Elements.Add(txtOne);
        }
    }
}
