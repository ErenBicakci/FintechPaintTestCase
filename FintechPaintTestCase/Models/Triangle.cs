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
            if (isSelected)
            {
                drawBackground(e);
            }
            using (Brush brush = new SolidBrush(this.getColor()))
            {
                e.Graphics.FillPolygon(brush, trianglePoints);
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
            trianglePoints[0].X = shapeX + (shapeWidth / 2);
            trianglePoints[1].X = shapeX;
            trianglePoints[2].X = shapeX + shapeWidth;

            trianglePoints[0].Y = shapeY;
            trianglePoints[1].Y = shapeY + shapeWidth;
            trianglePoints[2].Y = shapeY + shapeWidth;
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
