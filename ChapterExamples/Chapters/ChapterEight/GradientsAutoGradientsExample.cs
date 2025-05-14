using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterEight
{
    public class GradientsAutoGradientsExample
    {
        public static void Create(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            LayoutGrid grid = new LayoutGrid();
            grid.ShowTitle = false;
            doc.Pages[0].Elements.Add(grid);

            Gradient gradient1 = new Gradient(0, 100, 50, 100, Grayscale.White, Grayscale.DarkGray);
            doc.Pages[0].Elements.Add(new Rectangle(0, 0, 100, 100, RgbColor.Black, gradient1));
            

            Gradient gradient2 = new Gradient(250, 150, 275, 175, RgbColor.ForestGreen, RgbColor.Red);
            doc.Pages[0].Elements.Add(new Circle(250, 150, 50, RgbColor.Black, gradient2));
            

            Gradient gradient3 = new Gradient(100, 300, 125, 325, CmykColor.AliceBlue, CmykColor.FireBrick);
            doc.Pages[0].Elements.Add(new Circle(100, 300, 50, Grayscale.Black, gradient3));
           

            Gradient gradient4 = new Gradient(50, 400, 150, 475, WebColor.ForestGreen, WebColor.GoldenRod);
            doc.Pages[0].Elements.Add(new Rectangle(50, 400, 100, 100, Grayscale.Silver, gradient4));
            

            AutoGradient autogradient1 = new AutoGradient(70.0f, CmykColor.Blue, CmykColor.Red);            
            doc.Pages[0].Elements.Add(new Rectangle(0, 550, 100, 100, autogradient1, autogradient1));
            

            AutoGradient autogradient2 = new AutoGradient(90.0f, CmykColor.Red, CmykColor.Blue);
            doc.Pages[0].Elements.Add(new Circle(250,300, 40, autogradient2, autogradient2));

            AddLabels(doc);

            doc.Draw(outputPath + "gradients.pdf");
           
        }

        public static void AddLabels(Document doc)
        {
            doc.Pages[0].Elements.Add(new Label("A", 45, 45, 10, 0));
            doc.Pages[0].Elements.Add(new Label("B", 250, 145, 10, 0));
            doc.Pages[0].Elements.Add(new Label("C", 95, 295, 10, 0));
            doc.Pages[0].Elements.Add(new Label("D", 95, 440, 10, 0));
            doc.Pages[0].Elements.Add(new Label("E", 45, 595, 10, 0));
            doc.Pages[0].Elements.Add(new Label("F", 245, 290, 10, 0));
        }
    }
}
