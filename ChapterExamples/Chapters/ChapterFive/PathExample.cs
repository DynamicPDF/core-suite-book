using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterFive
{
    public class PathExample
    {
        public static void Create(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            Path path = new Path(50, 150, RgbColor.Blue, RgbColor.Yellow,
                3, LineStyle.Solid, true);

            path.SubPaths.Add(new LineSubPath(300, 400));
            path.SubPaths.Add(new LineSubPath(300, 150));

            Path path1 = new Path(50, 250, RgbColor.Red, RgbColor.Teal,
                3, LineStyle.Solid, false);

            path1.SubPaths.Add(new LineSubPath(400, 300));
            path1.SubPaths.Add(new CurveFromSubPath(500, 350, 400, 80));
            path1.SubPaths.Add(new LineSubPath(50, 250));

            Path path2 = new Path(50, 450, RgbColor.FireBrick, RgbColor.LightCoral,
               3, LineStyle.Solid, false);

            path2.SubPaths.Add(new LineSubPath(60, 475));
            path2.SubPaths.Add(new CurveToSubPath(500, 350, 60, 535));
           


            LayoutGrid grid = new();
            grid.ShowTitle = false;

            doc.Pages[0].Elements.Add(grid);
            doc.Pages[0].Elements.Add(path);
           doc.Pages[0].Elements.Add(path1);
            doc.Pages[0].Elements.Add(path2);


            AddGridLines.AddBackgroundColor(doc);
            doc.Draw(outputPath);
        }
    }
}
