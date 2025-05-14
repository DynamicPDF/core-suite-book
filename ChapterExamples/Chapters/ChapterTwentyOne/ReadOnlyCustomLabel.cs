using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using System;

namespace ChapterExamples.Chapters.ChapterTwentyOne
{
    class ReadOnlyCustomLabel : Label
    {
        new public static string Text { get; private set; }
        new public Color TextOutlineColor { get; private set; }
        new public Color TextColor { get; private set; }
        new public Single TextOutlineWidth { get; private set; }
        new public Font Font{get; private set;}
        new public Single FontSize { get; private set; } 

        public ReadOnlyCustomLabel(float x, float y):base("READ ONLY", x, y, 300,  0)
        {
            base.TextOutlineColor = RgbColor.DarkRed;
            base.TextColor = RgbColor.ForestGreen;
            base.TextOutlineWidth = 1;
            base.Font = Font.Helvetica;
            base.FontSize = 42;
        }

    }
}
