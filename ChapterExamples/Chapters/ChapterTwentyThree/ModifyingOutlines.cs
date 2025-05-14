using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;

namespace ChapterExamples.Chapters.ChapterTwentyThree
{
    public class ModifyingOutlines
    {
        public static void Modify(string resourcePath, string outputPath)
        {
            AddOutline(resourcePath, outputPath);
            ModifyOutlineAdd(resourcePath, outputPath);
            ModifyOutlineInsert(resourcePath, outputPath);
            ReplaceOutline(resourcePath, outputPath);
            AddBookmarkExistingPage(resourcePath, outputPath);
            SimpleMerge(resourcePath, outputPath);
            SimpleManualMerge(resourcePath, outputPath);
            SimpleEasyManualMerge(resourcePath, outputPath);
            SimpleManualRevistMerge(resourcePath, outputPath);
        }

        public static void SimpleManualRevistMerge(string resourcePath, string outputPath)
        {
            MergeDocument mergeDoc = MergeDocument.Merge(resourcePath + "doc1b.pdf", MergeOptions.None, resourcePath + "doc2b.pdf", MergeOptions.None);

            PdfDocument doc1 = new(resourcePath + "doc1b.pdf");
            PdfDocument doc2 = new(resourcePath + "doc2b.pdf");

            PdfOutlineList doc1List = doc1.Outlines;
            PdfOutlineList doc2List = doc2.Outlines;
            Outline root = mergeDoc.Outlines.Add("Combined Outline");

            for (int i = 0; i < doc1List[0].ChildOutlines.Count; i++)
            {
                root.ChildOutlines.Add("Pg " + (i + 1), new XYDestination(i + 1, 0, 0));
            }

            int start = doc1.Pages.Count + 1;

            for (int i = 0; i < doc2List[0].ChildOutlines.Count; i++)
            {
                root.ChildOutlines.Add("Pg " + (i + start), new XYDestination(i + start, 0, 0));
            }

            mergeDoc.Draw(outputPath + "simple-manual-merge-revisit-outline-one-output.pdf");
        }

        public static void SimpleEasyManualMerge(string resourcePath, string outputPath)
        {
            MergeDocument mergeDoc = MergeDocument.Merge(resourcePath + "doc1b.pdf", MergeOptions.None, resourcePath + "doc2b.pdf", MergeOptions.None);

            PdfDocument doc1 = new(resourcePath + "doc1c.pdf");
            PdfDocument doc2 = new(resourcePath + "doc2b.pdf");

            mergeDoc.Outlines.Add(doc1.Outlines[0], true);
            mergeDoc.Outlines.Add(doc2.Outlines[0], true);

            mergeDoc.Draw(outputPath + "simple-easy-manual-merge-outline-one-output.pdf");
        }

         public static void SimpleManualMerge(string resourcePath, string outputPath)
        {
            MergeDocument mergeDoc = MergeDocument.Merge(resourcePath + "doc1b.pdf", MergeOptions.None, resourcePath + "doc2b.pdf", MergeOptions.None);

            PdfDocument doc1 = new(resourcePath + "doc1c.pdf");
            PdfDocument doc2 = new(resourcePath + "doc2b.pdf");

            PdfOutlineList doc1List = doc1.Outlines;
            PdfOutlineList doc2List = doc2.Outlines;
            Outline doc1Root = mergeDoc.Outlines.Add(doc1.Outlines[0], false);

            for (int i = 0; i < doc1List[0].ChildOutlines.Count; i++)
            {
                BuildOutline(doc1List[0].ChildOutlines[i], doc1Root);
            }

            mergeDoc.Outlines.Add(doc2.Outlines[0], true);

            mergeDoc.Draw(outputPath + "simple-manual-merge-outline-one-output.pdf");
        }


        private static void BuildOutline(PdfOutline outline, Outline parentOutline)
        {
            Outline buildOutline = parentOutline.ChildOutlines.Add(outline, false);

            for (int i = 0; i < outline.ChildOutlines.Count; i++)
            {
                BuildOutline(outline.ChildOutlines[i], buildOutline);
            }

        }

        public static void SimpleMerge(string resourcePath, string outputPath)
        {
            MergeDocument mergeDoc = MergeDocument.Merge(resourcePath + "doc1b.pdf", MergeOptions.All, resourcePath + "doc2b.pdf", MergeOptions.All);
            mergeDoc.Draw(outputPath + "simple-merge-outline-one-output.pdf");
        }

        public static void AddOutline(string resourcePath, string outputPath)
        {
            PdfDocument doc = new(resourcePath + "doc1.pdf");
            MergeDocument mergeDoc = new MergeDocument(doc, MergeOptions.All);
            mergeDoc.Append(resourcePath + "doc2.pdf", MergeOptions.None);
            Outline outline = mergeDoc.Outlines.Add("Doc2 Outline");
            int pg = doc.Pages.Count + 1;

            for (int i = pg; i <= mergeDoc.Pages.Count; i++)
            {
                Outline outline1 = outline.ChildOutlines.Add("Doc2 pg " +  i, new XYDestination(i, 0, 0));
            }

            mergeDoc.Draw(outputPath + "add-to-outline-one-output.pdf");

        }

        public static void ModifyOutlineInsert(string resourcePath, string outputPath)
        {
            PdfDocument doc2 = new(resourcePath + "doc2.pdf");
            PdfDocument doc1 = new(resourcePath + "doc1.pdf");
            PdfOutlineList pdfOut = doc1.Outlines;

            MergeDocument mergeDoc = new();
            mergeDoc.Append(doc2, MergeOptions.None);
            mergeDoc.Append(doc1, MergeOptions.None);
            
            //create a root outline by getting pdfOut's root outline's text: My Document

            Outline root = mergeDoc.Outlines.Add(pdfOut[0].Text);

            //add the url outline 

            root.ChildOutlines.Add("DynamicPDF API Site", new UrlAction("https://dpdf.io/"));

            for(int i = 1; i <= doc2.Pages.Count; i++)
            {
                root.ChildOutlines.Add("Pg" + i, new XYDestination(i, 0, 0));
            }

            //get the children of the root outline of pdfOut

            PdfOutlineList pdfOutKids = pdfOut[0].ChildOutlines;

            //iterate through the children of pdfOutKids

            for(int i = 1; i <= pdfOutKids.Count; i++)
            {
                // add the child outline, and preserve its children:
                // that preserves the Important Topics and Important Quotes

                root.ChildOutlines.Add(pdfOutKids[i-1], true);

                //we know if from doc1.pdf that if no children
                //then it is a page bookmark
                //so change label to actual page number

                if (pdfOutKids[i-1].ChildOutlines.Count == 0)
                {
                    root.ChildOutlines[i+doc2.Pages.Count].Text = "Pg" + (i + doc2.Pages.Count);
                }
            }

            mergeDoc.Draw(outputPath + "modify-outline-output.pdf");
        }

        public static void ModifyOutlineAdd(string resourcePath, string outputPath)
        {
            PdfDocument doc2 = new(resourcePath + "doc2.pdf");
            PdfDocument doc1 = new(resourcePath + "doc1.pdf");
            MergeDocument mergeDoc = new();
            mergeDoc.Append(doc2, MergeOptions.None);
            mergeDoc.Append(doc1, MergeOptions.All);
            OutlineList outList = mergeDoc.Outlines[0].ChildOutlines;
            outList[0].Text = "Pg5";
            outList[1].Text = "Pg6";
            outList[2].Text = "Pg7";
            outList[3].Text = "Pg8";
            mergeDoc.Draw(outputPath + "modified-add-outline-output.pdf");
        }

 
        public static void ReplaceOutline(string resourcePath, string outputPath)
        {
            MergeDocument mergeDoc = new MergeDocument(resourcePath + "doc1.pdf", MergeOptions.None);
            Outline outline = mergeDoc.Outlines.Add("Replaced Outline");
            
            for (int i = 1; i <= mergeDoc.Pages.Count; i++)
            {
                Outline outline1 = outline.ChildOutlines.Add("Page " + i, new XYDestination(i, 0, 0));
            }

            mergeDoc.Draw(outputPath + "replaced-outline-output.pdf");
        }

        public static void AddBookmarkExistingPage(string resourcePath, string outputPath)
        {
            MergeDocument mergeDoc = new();
            PdfDocument doc2 = new(resourcePath + "doc2.pdf");
            mergeDoc.Append(doc2, MergeOptions.None);

            Outline rootOutline = mergeDoc.Outlines.Add("Document 2");

            for(int i = 0; i < doc2.Pages.Count; i++)
            {
                mergeDoc.Pages[i].Elements.Add(new Bookmark("Page " + (i+1), 0, 0, rootOutline));
            }

            mergeDoc.Draw(outputPath + "add-bookmarks-existing-output.pdf");

        }

    }
}
