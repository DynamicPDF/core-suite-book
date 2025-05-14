using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;
using System;

namespace ChapterExamples.Chapters.ChapterTwentyOne
{
    class StarCustomElement: TaggablePageElement
    {

        private float borderWidth = 5f;
        private Color fillColor = RgbColor.Navy;
        private Color borderColor = RgbColor.DarkRed;
        private LineStyle borderStyle = LineStyle.Solid;

        private class Point
        {
            public float x;
            public float y;

            public Point(float x, float y)
            {
                this.x = x;
                this.y = y;
            }

        }

        private Point[] points;


        public StarCustomElement(int numPoints, float centerX, float centerY, float outerRadius, float innerRadius )
        {
            points = new Point[numPoints * 2];
            double angleStep = Math.PI / numPoints;

            for (int i = 0; i < numPoints * 2; i++)
            {
                double angle = i * angleStep - Math.PI / 2;
                float radius = (i % 2 == 0) ? outerRadius : innerRadius;
                points[i] = new Point(
                    centerX + (float)(radius * Math.Cos(angle)),
                    centerY + (float)(radius * Math.Sin(angle))
                );
            }
        }


        public override void Draw(PageWriter writer)
        {
            writer.SetRelativeToState(base.RelativeTo, base.IgnoreMargins);
            writer.SetGraphicsMode();
            writer.SetLineWidth(borderWidth);
            writer.SetStrokeColor(borderColor);
            writer.SetLineStyle(borderStyle);
            writer.SetLineCap(LineCap.Butt);
            writer.SetFillColor(fillColor);
            writer.Write_m_(points[0].x, points[0].y);
            for (int i = 1; i < points.Length; i++)
            {
                writer.Write_l_(points[i].x, points[i].y);
            }

            writer.Write_l_(points[0].x, points[0].y);
            writer.Write_b_();
        }
    }
}
