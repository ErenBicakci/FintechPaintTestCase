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
            using (Brush brush = new SolidBrush(this.getColor()))
            {
                e.Graphics.FillEllipse(brush, rectangle);
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
            rectangle.X = shapeX;
            rectangle.Width = shapeWidth;
            rectangle.Y = shapeY;
            rectangle.Height = shapeWidth;
        }


    }
}
