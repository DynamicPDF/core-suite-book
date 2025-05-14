using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ChapterExamples.Utility;

namespace ChapterExamples.Chapters.ChapterFour
{
    public class NotesExample
    {
        public static void Create(string outputPath)
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            Note commentNote = new Note("Hello DynamicPDF Core Suite.", 100, 100, 200, 50, NoteType.Comment, true);

            Note helpNote = new Note("DynamicPDF Core Suite Help", 100, 150, 200, 50, NoteType.Help, true);

            Note insertNote = new Note("DynamicPDF Core Suite Help", 100, 200, 200, 50, NoteType.Insert, true);

            Note keyNote = new Note("DynamicPDF Core Suite Help", 100, 250, 200, 50, NoteType.Key, true);

            Note newParNote = new Note("DynamicPDF Core Suite Help", 100, 300, 200, 50, NoteType.NewParagraph, true);

            Note parNote = new Note("DynamicPDF Core Suite Help", 100, 350, 200, 50, NoteType.Paragraph, true);

            Note noteNote = new Note("DynamicPDF Core Suite Help", 100, 400, 200, 50, NoteType.Note, true);

            commentNote.Color = RgbColor.Navy;
            helpNote.Color = RgbColor.Red;
            insertNote.Color = RgbColor.Yellow;
            keyNote.Color = RgbColor.LightGrey;
            newParNote.Color = RgbColor.Navy;
            parNote.Color = RgbColor.Navy;
            noteNote.Color = RgbColor.AliceBlue;

            doc.Pages[0].Elements.Add(commentNote);
            doc.Pages[0].Elements.Add(helpNote);
            doc.Pages[0].Elements.Add(insertNote);
            doc.Pages[0].Elements.Add(keyNote);
            doc.Pages[0].Elements.Add(newParNote);
            doc.Pages[0].Elements.Add(parNote);
            doc.Pages[0].Elements.Add(noteNote);

            AddGridLines.AddBackgroundColor(doc);
            doc.Draw(outputPath);
        }
    }
}
