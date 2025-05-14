

using ChapterExamples.Chapters.ChapterFifteen;
using ChapterExamples.Utility;

namespace ChapterFifteen
{
    class Program
    {
        static void Main(string[] args)
        {

            FileUtility.CreatePath("output/ch15");
            FormFieldsExample.Create(FileUtility.GetPath("output/ch15/"));
            SignFormExample.Create(FileUtility.GetPath("../ChapterExamples/resources/ch14/"), FileUtility.GetPath("output/ch15/"));
            ButtonBehaviorExample.Create(FileUtility.GetPath("../ChapterExamples/resources/ch15"), FileUtility.GetPath("output/ch15/"));
        }
    }
}
