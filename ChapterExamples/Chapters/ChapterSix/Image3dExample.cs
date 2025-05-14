
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Imaging;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterSix
{
    public class Image3dExample
    {
        public static void Create(string inputPath, string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));
            

            Image3D image3D = new Image3D(inputPath + "model.u3d", 0, 0, 500, 500);
            float[] front = new float[] {1f,0f,0f,0f,1f,0f,0f,0f,-1f, 0f, 0f,0f};

            image3D.Views.Default.TransformationMatrix = front;
            image3D.Views.Default.CenterOfOrbit = 1f;
            image3D.Views.Default.OrthographicScaling = .95f;
            image3D.Views.Default.BackgroundColor = RgbColor.LightBlue;
            image3D.Views.Default.LightingScheme = Lighting3DScheme.Day;

            image3D.Views.Front.BackgroundColor = RgbColor.LightSeaGreen;
            image3D.Views.Front.LightingScheme = Lighting3DScheme.Day;
            image3D.Views.Front.TransformationMatrix = front;
            image3D.Views.Front.CenterOfOrbit = 1f;
            image3D.Views.Front.OrthographicScaling = .95f;

            float[] back = new float[] {1f,0f,0f,0f,1f,0f,0f,0f,1f,0f,0f,0f};

            image3D.Views.Back.BackgroundColor = RgbColor.LightGreen;
            image3D.Views.Back.LightingScheme = Lighting3DScheme.Day;
            image3D.Views.Back.TransformationMatrix = back;
            image3D.Views.Back.CenterOfOrbit = 1f;
            image3D.Views.Back.OrthographicScaling = .95f;



            ImageData imgDt = ImageData.GetImage(inputPath + "model.png");
            image3D.PosterImage = imgDt;

            doc.Pages[0].Elements.Add(image3D);
            doc.Draw(outputPath);
        }
    }
}
