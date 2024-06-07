using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechPaintTestCase.Models
{
    internal class Circle : Shape
    {
        private Rectangle rectangle;

        public Circle(Color color) 
        {
            this.setColor(color);
            rectangle = new Rectangle();
            this.name = "Circle";
        }
        public override void draw(PaintEventArgs e)
        {
            if (isSelected)
            {
                drawBackground(e);
            }
            using (Brush brush = new SolidBrush(this.getColor()))
            {
                e.Graphics.FillEllipse(brush, rectangle);
            }
        }

        public override void mouseMoveDraw(MouseEventArgs e)
        {
            int distance = getMaxDistanceToOrigin(e.X, e.Y);
            if (getPossibleMaxWidthAndHeight(getStartPoint().X,getStartPoint().Y) >= distance)
            {
                shapeConfig(getStartPoint().X-distance,getStartPoint().Y-distance, distance,distance);
            }
            else
            {
                shapeConfig(getStartPoint().X- getPossibleMaxWidthAndHeight(getStartPoint().X, getStartPoint().Y), getStartPoint().Y- getPossibleMaxWidthAndHeight(getStartPoint().X, getStartPoint().Y), getPossibleMaxWidthAndHeight(getStartPoint().X, getStartPoint().Y), getPossibleMaxWidthAndHeight(getStartPoint().X, getStartPoint().Y));
            }

        }
        protected override void shapeConfig(int x, int y,int width,int height)
        {
            shapeX = x ;
            shapeY = y ;
            shapeWidth = width * 2;
            shapeHeight = height * 2;
            drawingObjectConfig();
        }

        protected override void drawingObjectConfig()
        {
            rectangle.X = shapeX;
            rectangle.Width = shapeWidth;
            rectangle.Y = shapeY;
            rectangle.Height = shapeHeight;
            

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
