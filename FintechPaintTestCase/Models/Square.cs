using System.Drawing;

namespace FintechPaintTestCase.Models
{
    internal class Square : Shape
    {
        private Rectangle rectangle;

        public Square(Color color)
        {
            this.setColor(color);
            rectangle = new Rectangle();
            this.name = "Square";
        }
        public override void draw(PaintEventArgs e)
        {
            if (isSelected)
            {
                drawBackground(e);
            }
            using (Brush brush = new SolidBrush(this.getColor()))
            {

                e.Graphics.FillRectangle(brush, rectangle);
            }
        }

        public override void mouseMoveDraw(MouseEventArgs e)
        {
            int width = Math.Abs(getStartPoint().X - e.X);
            int xLocation = getStartPoint().X - width;

            if (xLocation >= 0 && xLocation + width*2 <= Form1.panelWidth)
            {
                shapeConfig(xLocation, shapeY, width, shapeHeight/2);

            }
            else
            {
                shapeConfig(shapeX+shapeWidth/2-getPossibleMaxWidth(getStartPoint().X),shapeY, getPossibleMaxWidth(getStartPoint().X),shapeHeight/2);
            }
            int height = Math.Abs(getStartPoint().Y - e.Y);

            int yLocation = getStartPoint().Y - height;
            if (yLocation >= 0 && yLocation + height*2 <= Form1.panelHeight)
            {
                shapeConfig(shapeX, yLocation, shapeWidth/2,height);

            }
            else
            {
                shapeConfig(shapeX, shapeY+shapeHeight/2-getPossibleMaxHeight(getStartPoint().Y), shapeWidth/2, getPossibleMaxHeight(getStartPoint().Y));

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
                shapeConfig(newXLocation, shapeY, shapeWidth / 2, shapeHeight/2);
            }
            if ((newYLocation >= 0 && newYLocation + shapeHeight <= Form1.panelHeight))
            {
                shapeConfig(shapeX, newYLocation, shapeWidth / 2, shapeHeight/2);
            }
            setLastSelectPoint(e.X, e.Y);
        }
    }
}
