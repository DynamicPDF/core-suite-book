using System.Collections.Generic;
using System.Text.Json;

namespace ChapterExamples.Chapters.ChapterTwentySeven.Data
{

    public class Book
    {
        private string title;
        private string author;
        private int publishDate;
        private string publisher;
        private string imagePath;
        private List<Chapter> chapters;

        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public int PublishDate { get => publishDate; set => publishDate = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public List<Chapter> Chapters { get => chapters; set => chapters = value; }
        public string ImagePath { get => imagePath; set => imagePath = value; }

        public string getJson()
        {
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            return json;
        }
    }
}
