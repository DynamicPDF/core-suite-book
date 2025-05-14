using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapterExamples.Utility
{
    class AddGridLines
    {
        public static void AddMargins(Page pg)
        {
            Rectangle rec = new Rectangle(0, 0, pg.Dimensions.Width - pg.Dimensions.LeftMargin - pg.Dimensions.RightMargin, pg.Dimensions.Height - pg.Dimensions.TopMargin - pg.Dimensions.BottomMargin);
            rec.BorderColor = RgbColor.LightSlateGray;
            rec.BorderStyle = LineStyle.DashSmall;
            pg.Elements.Add(rec);
        }

        public static void AddBackgroundColor(Document doc)
        {
            Template tmp = new();
            Rectangle rec = new(0, 0, doc.Pages[0].Dimensions.Width, doc.Pages[0].Dimensions.Height);
            rec.FillColor = RgbColor.GhostWhite;
            rec.BorderStyle = LineStyle.None;
            rec.IgnoreMargins = true;
            tmp.Elements.Add(rec);
            doc.Template = tmp;
        }
    }
}
