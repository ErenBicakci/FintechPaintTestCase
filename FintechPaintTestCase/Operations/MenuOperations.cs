using FintechPaintTestCase.Models;

namespace FintechCase
{
    internal class MenuOperations
    {

        private PictureBox selectPB = null;
        public Boolean selectPBStatus = false;



        private PictureBox lastSelectedShapePB = null;
        private PictureBox lastSelectedColorPB = null;

        private List<PictureBox> shapePictureBoxs;
        private List<PictureBox> colorPictureBoxs;


        public Color lastColor = Color.White;


        public MenuOperations(List<PictureBox> shapePBs, List<PictureBox> colorPBs, PictureBox selectPB)
        {
            shapePictureBoxs = shapePBs;
            colorPictureBoxs = colorPBs;
            this.selectPB = selectPB;
        }


        public Shape getLastShape()
        {
            if (lastSelectedShapePB == null)
            {
                return null;
            }

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

        private void removePreviousMenuSelections()
        {
            if (selectPBStatus)
            {
                selectPBStatus = false;
                selectPB.Invalidate();
                selectPB.Refresh();
            }
            foreach (var shapePictureBox in shapePictureBoxs)
            {
                shapePictureBox.Invalidate();
                shapePictureBox.Refresh();
            }
            lastSelectedShapePB = null;

        }

        public void selectShape(string pictureBoxName)
        {
            removePreviousMenuSelections();
            lastSelectedShapePB = findShapePictureBoxByName(pictureBoxName);
            drawBorder(lastSelectedShapePB);


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
            removePreviousMenuSelections();
            selectPBStatus = true;
            drawBorder(selectPB);
        }


        public void setPBsSelectedShape(Shape shape)
        {
            clickSelectionPictureBox();
            selectColor(shape.getColor().Name.ToLower() + "PB");
            drawBorder(findShapePictureBoxByName(shape.name + "PB"));
            findShapePictureBoxByName(shape.name);


        }



        private void drawBorder(PictureBox pictureBox)
        {
            Graphics g = pictureBox.CreateGraphics();

            int borderThickness = 6;
            Color borderColor = Color.Gray;
            Rectangle rect = new Rectangle(0, 0, pictureBox.Width, pictureBox.Height);
            using (Pen pen = new Pen(borderColor, borderThickness))
            {
                g.DrawRectangle(pen, rect);
            }
            g.Dispose();
        }



        private PictureBox findShapePictureBoxByName(string name)
        {

            foreach (var item in shapePictureBoxs)
            {
                if (item.Name == name)
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
