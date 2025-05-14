namespace ChapterExamples.Chapters.ChapterTwentySeven.Data
{
    public class Chapter
    {
        private string title;
        private string summary;

        public string Title { get => title; set => Title = value; }
        public string Summary { get => summary; set => Summary = value; }

        public Chapter(string Title, string Summary)
        {
            title = Title;
            summary = Summary;
        }
    }
}
