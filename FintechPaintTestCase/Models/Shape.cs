using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        protected int shapeHeight { get; set; }
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

    }
}
