
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterThree
{
    public class DocumentSectionExample
    {
        public static void Create(string outputPath)
        {
            Document myDoc = new();


            Page myCvrPg = new();
            myDoc.Pages.Add(myCvrPg);
            Template tmpl = new Template();

            
            tmpl.Elements.Add(new PageNumberingLabel("%%SP%% of %%ST%%", 0, 680, 512, 12, Font.Helvetica, 12, TextAlign.Center));

            Label cvrLabel = new("Cover Page", 50, 50, 300, 50);
            cvrLabel.FontSize = 42;
            myCvrPg.Elements.Add(cvrLabel);

            for (int i = 0; i < 2; i++)
            {
                myDoc.Sections.Begin(NumberingStyle.Numeric, tmpl);

                for (int j = 0; j < 3; j++)
                {
                    Page myPg = new();
                    myDoc.Pages.Add(myPg);
                    Label myLabel = new("Section " + (i+1), 50, 50, 200, 50);
                    myLabel.FontSize = 42;
                    myPg.Elements.Add(myLabel);
                }
            }



            myDoc.Draw(outputPath);
        }
    }
}
