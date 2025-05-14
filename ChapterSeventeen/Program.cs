using ChapterExamples.Utility;
using ChapterExamples.Chapters.ChapterSeventeen;
using ChapterExamples.Chapters.ChapterFifteen;

namespace ChapterSeventeen
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.CreatePath("output/ch17");
            JavasScriptDomExample.Create(FileUtility.GetPath("output/ch17/"));
            JavaScriptActionExample.Create(FileUtility.GetPath("output/ch17/"));
        }
    }
}
