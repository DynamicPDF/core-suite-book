using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterEight
{
    public class ColorsExample
    {

        public static void Create(string outputPath)
        {
            CreateColors(outputPath);
            CreateSpotColor(outputPath);
        }

        public static void CreateColors(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            CmykColor cmykColor = new CmykColor(0f, .26f, .66f, .39f);
            doc.Pages[0].Elements.Add(new Circle(50, 50, 40, CmykColor.Black, cmykColor));
            doc.Pages[0].Elements.Add(new Circle(150, 50, 40, CmykColor.Black, CmykColor.SandyBrown));

            RgbColor rgbColor = new RgbColor(146, 0, 1);
            doc.Pages[0].Elements.Add(new Rectangle(50, 100, 100, 100, RgbColor.Black, rgbColor));
            doc.Pages[0].Elements.Add(new Circle(250, 150, 50, RgbColor.Black, RgbColor.SeaGreen));

            
            WebColor webColor = new WebColor("#FF0000");
            WebColor webColor2 = new WebColor("navy");
            doc.Pages[0].Elements.Add(new Line(500, 300, 150, 55, 5, webColor, LineStyle.Solid));

            Label lbl = new("Color Examples", 10, 300, 200, 0);
            lbl.TextColor = webColor2;
            lbl.TextOutlineWidth = 3;
            lbl.TextOutlineColor = webColor;
            lbl.FontSize = 72;
            doc.Pages[0].Elements.Add(lbl);

            Grayscale grayscale = new Grayscale(.5f);
            doc.Pages[0].Elements.Add(new Circle(100, 500, 40, Grayscale.Black, grayscale));
            doc.Pages[0].Elements.Add(new Circle(250, 500, 40, Grayscale.Silver, Grayscale.White)); 

            doc.Draw(outputPath + "colors.pdf");
        }

        public static void CreateSpotColor(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));
            SpotColorInk ink = new SpotColorInk("PeachPuff",CmykColor.PeachPuff);
            SpotColor spotColor = new(1, ink);
            SpotColor spotColor1 = new(0.5f, ink);

            doc.Pages[0].Elements.Add(new Rectangle(50, 100, 100, 100, RgbColor.Black, spotColor));
            doc.Pages[0].Elements.Add(new Circle(250, 150, 50, RgbColor.Black, spotColor1));

            doc.Draw(outputPath + "spot-colors.pdf");
        }
    }
}
