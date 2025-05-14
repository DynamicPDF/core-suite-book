using ChapterExamples.Chapters.ChapterThirteen;
using ChapterExamples.Utility;
using System;

namespace ChapterThirteen
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.CreatePath("output/ch13");
            OutlineExample.Create(FileUtility.GetPath("output/ch13/outline-out.pdf"));
            ChildOutlines.Create(FileUtility.GetPath("output/ch13/childoutlines-second-out.pdf"));
            MultipleOutlines.Create(FileUtility.GetPath("output/ch13/multipleoutlines-second-out.pdf"));
            OutlineActions.Create(FileUtility.GetPath("output/ch13/outlines-actions-out.pdf"));
            BookmarksExample.Create(FileUtility.GetPath("output/ch13/bookmarks-out.pdf"));
            OutlineWithBookmarksExample.Create(FileUtility.GetPath("output/ch13/outline-bookmarks-out.pdf"));
            OutlineWithBookmarksExample.Create2(FileUtility.GetPath("output/ch13/outline-bookmarks-two-out.pdf"));
        }
    }
}
