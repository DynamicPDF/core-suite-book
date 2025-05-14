using ceTe.DynamicPDF;
using System;

namespace ChapterExamples.Chapters.ChapterTwo
{
    public class PageLayoutExample
    {
        public static void Create(string outputPath)
        {
            Document myDoc = new();

            PageDimensions myPgDm = new(PageSize.Legal, PageOrientation.Landscape);
            myPgDm.BottomMargin = 50;
            myPgDm.TopMargin = 50;
            myPgDm.LeftMargin = 100;
            myPgDm.RightMargin = 100;

            Page myPg = new();
            myDoc.Pages.Add(myPg);
            myPg.Dimensions = myPgDm;

            Console.WriteLine("Width: {0} Height: {1} LeftMargin: {2} RightMargin: {3} TopMargin: {4} BottomMargin: {5}", myPg.Dimensions.Width, myPg.Dimensions.Height, myPg.Dimensions.LeftMargin, myPg.Dimensions.RightMargin, myPg.Dimensions.TopMargin, myPg.Dimensions.BottomMargin);

            Page myPg2 = new(myPgDm);
            myDoc.Pages.Add(myPg2);


            Page myPg3 = new(PageSize.Postcard, PageOrientation.Landscape, 5F);
            myDoc.Pages.Add(myPg3);

            Page myPg4 = new(55, 90);
            myDoc.Pages.Add(myPg4);

            Page myPg5 = new(PageSize.Envelope10, PageOrientation.Landscape);
            myDoc.Pages.Add(myPg5);
            
            myDoc.Draw(outputPath + "ch2-PageLayoutExample-out.pdf");
        }
    }
}
