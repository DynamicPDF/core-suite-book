
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;
using System;

namespace ChapterExamples.Chapters.ChapterTwentyEight
{
    public class SimplePlaceHolderExample
    {

        public static void CreateReport(string resourcePath, string outputPath)
        {
            DocumentLayout docLayout = new DocumentLayout(resourcePath + "simple-placeholder-example.dlex");
            PlaceHolder placeHolder = (PlaceHolder)docLayout.GetLayoutElementById("Placeholder1");
            placeHolder.LaidOut += PlaceHolder1_LaidOut;
            
            Document doc = docLayout.Layout(new LayoutData());
            doc.Draw(outputPath + "simple-placeholder-example-output.pdf");
        }

        private static void PlaceHolder1_LaidOut(object sender, PlaceHolderLaidOutEventArgs e)
        {
            float x = e.ContentArea.X;
            float y = e.ContentArea.Y;
            String txt = TextGenerator.GenerateShort();
            TextArea txtArea = new TextArea(txt, x, y, e.ContentArea.Width, e.ContentArea.Height);
            e.ContentArea.Add(txtArea);
        }
    }
}
