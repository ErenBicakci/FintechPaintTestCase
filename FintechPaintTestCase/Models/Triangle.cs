using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechPaintTestCase.Models
{
    internal class Triangle : Shape
    {
        private Point[] trianglePoints;
        public Triangle(Color color)
        {
            trianglePoints = new Point[3];
            setColor(color);
            this.name = "Triangle";
        }

        public override void draw(PaintEventArgs e)
        {
            using (Brush brush = new SolidBrush(this.getColor()))
            {
                e.Graphics.FillPolygon(brush, trianglePoints);
            }
        }

        public override void mouseMove(MouseEventArgs e)
        {
            setLastPoint(e.X, e.Y);
            int distance = getMaxDistanceToOrigin(e.X, e.Y);
            if (getMaxWidth() >= distance)
            {
                shapeConfig(distance);
            }
            else
            {
                shapeConfig(getMaxWidth());
            }

        }
        protected override void shapeConfig(int distance)
        {
            shapeX = getStartPoint().X - distance;
            shapeY = getStartPoint().Y - distance;
            shapeWidth = distance * 2;
            drawingObjectConfig();
        }

        protected override void drawingObjectConfig()
        {
            trianglePoints[0].X = shapeX + (shapeWidth / 2);
            trianglePoints[1].X = shapeX;
            trianglePoints[2].X = shapeX + shapeWidth;

            trianglePoints[0].Y = shapeY;
            trianglePoints[1].Y = shapeY + shapeWidth;
            trianglePoints[2].Y = shapeY + shapeWidth;
        }

    }
}
