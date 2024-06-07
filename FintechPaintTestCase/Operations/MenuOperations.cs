using FintechPaintTestCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FintechCase
{
    internal class MenuOperations
    {
        public Boolean selectionPBStatus = false;
        private PictureBox selectionPB = null;

        private PictureBox lastSelectedShapePB = null;
        private PictureBox lastSelectedColorPB = null;

        private List<PictureBox> shapePictureBoxs;
        private List<PictureBox> colorPictureBoxs;
        
        
        public Color lastColor = Color.White;
        

        public MenuOperations(List<PictureBox> shapePBs,List<PictureBox> colorPBs, PictureBox selectPB)
        {
            shapePictureBoxs = shapePBs;
            colorPictureBoxs = colorPBs;
            this.selectionPB = selectPB;
        }
       

        public Shape getLastShape()
        {

            switch (lastSelectedShapePB.Name)
            {
                case "circlePB":
                    return new Circle(lastColor);
                    break;
                case "squarePB":
                    return new Square(lastColor);
                    break;
                case "trianglePB":
                    return new Triangle(lastColor);
                    break;
                case "hexagonPB":
                    return new Hexagon(lastColor);
                    break;
                default:
                    return new Square(lastColor);

            }
        }


        public void selectShape(string pictureBoxName)
        {
            selectionPBStatus = false;
            selectionPB.Invalidate();


            PictureBox shapePB = findShapePictureBoxByName(pictureBoxName);
            if (lastSelectedShapePB == null)
            {
                lastSelectedShapePB = shapePB;
                drawBorder(shapePB);
            }
            else if (lastSelectedShapePB.Name != shapePB.Name)
            {
                lastSelectedShapePB.Invalidate();
                drawBorder(shapePB);
                lastSelectedShapePB = shapePB;
            }
            else
            {
                drawBorder(shapePB);
            }

        }

        public void selectColor(string pictureBoxName)
        {
            PictureBox colorPB = findColorPictureBoxByName(pictureBoxName);

            if (lastSelectedColorPB == null)
            {
                lastSelectedColorPB = colorPB;
                drawBorder(colorPB);
            }
            else if (lastSelectedColorPB.Name != colorPB.Name)
            {
                lastSelectedColorPB.Invalidate();
                drawBorder(colorPB);
                lastSelectedColorPB = colorPB;

            }
            lastColor = colorPB.BackColor;
        }

        public void clickSelectionPictureBox()
        {
            selectionPBStatus = true;
            drawBorder(selectionPB);
            if (lastSelectedShapePB != null)
            {
                lastSelectedShapePB.Invalidate();

            }
        }


        private void drawBorder(PictureBox pictureBox)
        {
            Graphics g = pictureBox.CreateGraphics();

            int borderThickness = 6;
            Color borderColor = Color.Gray;
            Rectangle rect = new Rectangle(0, 0, pictureBox.Width , pictureBox.Height );
            using (Pen pen = new Pen(borderColor, borderThickness))
            {
                g.DrawRectangle(pen, rect);
            }
            g.Dispose();
        }

       

        private PictureBox findShapePictureBoxByName(string name) {

            foreach (var item in shapePictureBoxs)
            {
                if(item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }

        private PictureBox findColorPictureBoxByName(string name)
        {
            foreach (var item in colorPictureBoxs)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }

        
    }
}
