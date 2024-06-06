using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FintechPaintTestCase.Models
{
    internal abstract class Shape
    {
        private Color color;
        public string name;
        private Point startPoint;
        private Point lastPoint;

        protected int shapeX { get; set; }
        protected int shapeY { get; set; }
        protected int shapeWidth { get; set; }

        public void setColor(Color color)
        {
            this.color = color;
        }

        public Color getColor()
        {
            return color;
        }

        public Point getStartPoint()
        { return startPoint; }

        public void setStartPoint(int x, int y)
        {
            startPoint.X = x;
            startPoint.Y = y;
        }

        public Point getLastPoint()
        { return lastPoint; }

        public void setLastPoint(int x, int y)
        {
            lastPoint.X = x;
            lastPoint.Y = y;
        }

        public abstract void draw(PaintEventArgs e);
        public abstract void mouseMove(MouseEventArgs e);
        protected abstract void drawingObjectConfig();
        protected abstract void shapeConfig(int distance);


        protected int getMaxWidth()
        {
            return (getMaxX() < getMaxY()) ? getMaxX() : getMaxY();
        }

        private int getMaxX() {

            int distance0 = this.getStartPoint().X;
            int distance1 = Math.Abs(this.getStartPoint().X - 870);

            return (distance0 < distance1) ? distance0 : distance1;
        }

        private int getMaxY()
        {

            int distance0 = this.getStartPoint().Y;
            int distance1 = Math.Abs(this.getStartPoint().Y - 623);

            return (distance0 < distance1) ? distance0 : distance1;
        }

        protected int getMaxDistanceToOrigin(int x, int y) {

            int distance;
            if (Math.Abs(this.getStartPoint().X - x) > Math.Abs(this.getStartPoint().Y - y))
            {
                distance = Math.Abs(this.getStartPoint().X - x);
            }
            else
            {
                distance = Math.Abs(this.getStartPoint().Y - y);
            }
            return distance;
        } 
    }
}
