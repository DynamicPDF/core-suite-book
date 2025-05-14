using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterThirteen
{
    public class OutlineActions
    {
        public static void Create(string outputPath)
        {
            Document doc = new();

            for (int i = 0; i < 4; i++)
            {
                doc.Pages.Add(new Page(PageSize.Letter));
                doc.Pages[i].Elements.Add(new Label("page " + (i + 1), 50, 50, 100, 0));
                LayoutGrid grid = new LayoutGrid(LayoutGrid.GridType.Standard);
                grid.ShowTitle = false;
                doc.Pages[i].Elements.Add(grid);
            }

            Outline outline = doc.Outlines.Add("My Document");
            outline.ChildOutlines.Add("pg1", new XYDestination(1, 0, 0));
            outline.ChildOutlines.Add("pg2", new XYDestination(2, 400, 500));
            outline.ChildOutlines.Add("pg3", new ZoomDestination(3, PageZoom.FitPage));
            outline.ChildOutlines.Add("DynamicPDF Website", new UrlAction("https://www.dynamicpdf.com"));

            doc.Draw(outputPath);
        }
    }
}
