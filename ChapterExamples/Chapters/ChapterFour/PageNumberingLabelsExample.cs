
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterFour
{
    public class PageNumberingLabelsExample
    {
        public static void Create(string outputPath)
        {
            Document doc = new();

            PageNumberingLabel pglb = new("%%CP%% of %%TP%% numeric", 10, 10, 100, 50, Font.Helvetica, 12, TextAlign.Left);

            PageNumberingLabel pglb2 = new("%%CP(i)%% of %%TP(i)%% lowercase roman numeral", 10, 50, 200, 50, Font.Helvetica, 12, TextAlign.Left);


            PageNumberingLabel pglb3 = new("%%CP(I)%% of %%TP(I)%% uppercase roman numeral", 10, 100, 200, 50, Font.Helvetica, 12, TextAlign.Left);

            PageNumberingLabel pglb4 = new("%%CP(a)%% of %%TP(a)%% lowercase latin letters", 10, 150, 200, 50, Font.Helvetica, 12, TextAlign.Left);

            PageNumberingLabel pglb5 = new("%%CP(A)%% of %%TP(A)%% uppercase latin letters", 10, 200, 200, 50, Font.Helvetica, 12, TextAlign.Left);

            for (int i = 0; i < 10; i++)
            {
                doc.Pages.Add(new Page(PageSize.Letter));
                doc.Pages[i].Elements.Add(pglb);
                doc.Pages[i].Elements.Add(pglb2);
                doc.Pages[i].Elements.Add(pglb3);
                doc.Pages[i].Elements.Add(pglb4);
                doc.Pages[i].Elements.Add(pglb5);
            }

            AddGridLines.AddBackgroundColor(doc);
            doc.Draw(outputPath);
        }
    }
}
