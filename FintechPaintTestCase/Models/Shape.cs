using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FintechPaintTestCase.Models
{
    internal abstract class Shape
    {
        private Color color;
        public string name;
        private Point startPoint;
        private Point lastSelectPoint;
        
        public bool isSelected = false;
        protected int shapeX { get; set; }
        protected int shapeY { get; set; }
        protected int shapeWidth { get; set; }

        protected int shapeHeight { get; set; }

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

        public Point getLastSelectPoint()
        { return lastSelectPoint; }

        public void setLastSelectPoint(int x, int y)
        {
            lastSelectPoint.X = x;
            lastSelectPoint.Y = y;
        }


        public abstract void draw(PaintEventArgs e);
        public abstract void mouseMoveDraw(MouseEventArgs e);
        public abstract void mouseMoveSelect(MouseEventArgs e);

        protected abstract void drawingObjectConfig();
        protected abstract void shapeConfig(int x, int y, int width,int height);

        public bool inLocation(int x, int y)
        {
            if ((shapeX <= x && shapeX + shapeWidth >= x) && (shapeY <= y && shapeY + shapeHeight >= y))
            {
                return true;
            }

            return false;
        }

        protected void drawBackground(PaintEventArgs e)
        {
            using (Brush brush = new SolidBrush(Color.FromArgb(128, 192, 192, 192)))
            {
                Rectangle rectangle = new Rectangle(shapeX - 5, shapeY - 5, shapeWidth + 10, shapeHeight + 10);
                e.Graphics.FillRectangle(brush, rectangle);

            }
        }
        protected int getPossibleMaxWidthAndHeight(int x,int y)
        {
            return (getPossibleMaxWidth(x) < getPossibleMaxHeight(y)) ? getPossibleMaxWidth(x) : getPossibleMaxHeight(y);
        }

        protected int getPossibleMaxWidth(int x) {

            int distance0 = x;
            int distance1 = Math.Abs(x - Form1.panelWidth);

            return (distance0 < distance1) ? distance0 : distance1;
        }

        protected int getPossibleMaxHeight(int y)
        {

            int distance0 = y;
            int distance1 = Math.Abs(y - Form1.panelHeight);

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

        public JsonObject getJSONInfos()
        {
            JsonObject jsonObject = new JsonObject();
            jsonObject.Add("Name", name);
            jsonObject.Add("X", shapeX);
            jsonObject.Add("Y", shapeY);
            jsonObject.Add("Height", shapeHeight);
            jsonObject.Add("Width", shapeWidth);
            jsonObject.Add("Color", color.Name);
            jsonObject.Add("isSelected",isSelected);
            return jsonObject;
        }
    }
}
