using FintechPaintTestCase.Models;

namespace FintechCase
{
    internal class DrawOperations
    {
        private Boolean isDrawing = false;
        private List<Shape> shapes;
        private Shape currentShape;
        private Panel drawingPanel;
        private MenuOperations menuOperations;

        public List<Shape> getShapes()
        {
            return shapes;
        }


        public DrawOperations(Panel panel, MenuOperations menuOperations)
        {
            shapes = new List<Shape>();
            drawingPanel = panel;
            this.menuOperations = menuOperations;
        }


        public void drawingPanel_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {

                isDrawing = true;
                currentShape = menuOperations.getLastShape();
                currentShape.setStartPoint(e.X, e.Y);

            }
        }

        public void drawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                currentShape.mouseMove(e);
                drawingPanel.Invalidate();
            }
        }

        public void DrawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                isDrawing = false;
                shapes.Add(currentShape);
                drawingPanel.Invalidate();
            }

        }

        public void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in shapes)
            {

                shape.draw(e);
            }
            if (isDrawing)
            {
                currentShape.draw(e);
            }
        }
    }
}
