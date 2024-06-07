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
            if (isSelected)
            {
                drawBackground(e);
            }
            using (Brush brush = new SolidBrush(this.getColor()))
            {
                e.Graphics.FillPolygon(brush, hexagonPoints);
            }
        }

        public override void mouseMoveDraw(MouseEventArgs e)
        {
            int distance = getMaxDistanceToOrigin(e.X, e.Y);
            if (getPossibleMaxWidthAndHeight(getStartPoint().X, getStartPoint().Y) >= distance)
            {
                shapeConfig(getStartPoint().X - distance, getStartPoint().Y - distance, distance,distance);
            }
            else
            {
                shapeConfig(getStartPoint().X - getPossibleMaxWidthAndHeight(getStartPoint().X, getStartPoint().Y), getStartPoint().Y - getPossibleMaxWidthAndHeight(getStartPoint().X, getStartPoint().Y), getPossibleMaxWidthAndHeight(getStartPoint().X, getStartPoint().Y), getPossibleMaxWidthAndHeight(getStartPoint().X, getStartPoint().Y));
            }

        }
        protected override void shapeConfig(int x, int y, int width,int height)
        {
            shapeX = x;
            shapeY = y;
            shapeWidth = width * 2;
            shapeHeight = height * 2;
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

        public override void mouseMoveSelect(MouseEventArgs e)
        {
            int newXLocation = shapeX + (e.X - getLastSelectPoint().X);
            int newYLocation = shapeY + (e.Y - getLastSelectPoint().Y);
            if ((newXLocation >= 0 && newXLocation + shapeWidth <= Form1.panelWidth))
            {
                shapeConfig(newXLocation, shapeY, shapeWidth / 2, shapeHeight / 2);
            }
            if ((newYLocation >= 0 && newYLocation + shapeHeight <= Form1.panelHeight))
            {
                shapeConfig(shapeX, newYLocation, shapeWidth / 2, shapeHeight / 2);
            }
            setLastSelectPoint(e.X, e.Y);
        }
    }
}
