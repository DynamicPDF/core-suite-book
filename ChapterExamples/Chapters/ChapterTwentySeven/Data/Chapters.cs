using System.Collections;
using System.Collections.Generic;
namespace ChapterExamples.Chapters.ChapterTwentySeven.Data
{
    public class Chapters : IEnumerable<Chapter>
    {
        private List<Chapter> values = new List<Chapter>();

        public void Add(Chapter chapter)
        {
           values.Add(chapter);
        }

        public IEnumerator<Chapter> GetEnumerator()
        {
            foreach (var chapter in values)
            {
                yield return chapter;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
