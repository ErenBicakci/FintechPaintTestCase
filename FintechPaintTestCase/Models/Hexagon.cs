using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechPaintTestCase.Models
{
    internal class Hexagon : Shape
    {
        private Point[] hexagonPoints;

        public Hexagon(Color color)
        {
            this.setColor(color);
            this.name = "Hexagon";
            hexagonPoints = new Point[6];
        }
        public override void draw(PaintEventArgs e)
        {
            using (Brush brush = new SolidBrush(this.getColor()))
            {
                e.Graphics.FillPolygon(brush, hexagonPoints);
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

            for (int i = 0; i < 6; i++)
            {
                double angle_deg = 60 * i - 30;
                double angle_rad = Math.PI / 180 * angle_deg;
                hexagonPoints[i].X = (int)(shapeX + (shapeWidth / 2) + shapeWidth / 2 * Math.Cos(angle_rad));
                hexagonPoints[i].Y = (int)(shapeY + (shapeWidth / 2) + shapeWidth / 2 * Math.Sin(angle_rad));

            }
        }
    }
}
