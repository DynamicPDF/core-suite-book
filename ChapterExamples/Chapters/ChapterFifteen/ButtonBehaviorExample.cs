using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Imaging;
using ceTe.DynamicPDF.PageElements.Forms;

namespace ChapterExamples.Chapters.ChapterFifteen
{
    public class ButtonBehaviorExample
    {
        public static void Create(string inputPath, string outputPath)
        {

            Document doc = new Document();
            doc.Pages.Add(new Page(PageSize.Letter));
            Button button = new Button("Submit", 100, 625, 75, 25);
            button.BackgroundColor = RgbColor.LightBlue;
            button.BorderStyle = BorderStyle.Beveled;
            button.Image = ImageData.GetImage(inputPath + "/button.png");
            button.LabelImageLayout = LabelImageLayoutOptions.OverlayImage;
            button.ImageAppearance.FitToBounds = true;
            button.Behavior = Behavior.CreatePush("Down", "Rollover", ImageData.GetImage(inputPath + "/push-down.png"), ImageData.GetImage(inputPath + "/rollover.png"));
            button.Label = "Click Me";
            doc.Pages[0].Elements.Add(button);
            doc.Draw(outputPath + "button-behavior-out.pdf");
        }
    }
}
