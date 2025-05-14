using ChapterExamples.Chapters.ChapterEighteen;
using ChapterExamples.Utility;

namespace ChapterEighteen
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.CreatePath("output/ch18");
            EmailingAForm.Create(FileUtility.GetPath("output/ch18/"));
            SubmittingAForm.Create(FileUtility.GetPath("output/ch18/"));
        }
        
    }
}
