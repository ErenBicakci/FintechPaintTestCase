﻿using FintechPaintTestCase.Models;
using System.Drawing;

namespace FintechCase
{
    internal class DrawOperations
    {
        private Boolean isDrag = false;
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

        public void changeSelectedShapeColor(Color color)
        {
            if (currentShape != null && menuOperations.selectPBStatus)
            {

                currentShape.setColor(color);
                drawingPanel.Invalidate();
            }

        }

        public void deleteCurrentShape()
        {
            if (currentShape != null && menuOperations.selectPBStatus)
            {
                            DialogResult result = MessageBox.Show(
                "Bu işlemi yapmak istediğinizden emin misiniz?",
                "ŞEKİL SİLME",
                MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) {
                    shapes.Remove(currentShape);
                    currentShape = null;
                    drawingPanel.Invalidate();

                }

            }
            else
            {
                MessageBox.Show("Önce Şekil Seçiniz !");
            }
        }
        public void loadShapes(List<Shape> shapes)
        {
            isDrawing = false;
            isDrag = false;
            currentShape = null;
            this.shapes = shapes;
            foreach (Shape shape in shapes) {
                if (shape.isSelected) { 
                    currentShape = shape;
                    isDrag = true;
                    menuOperations.setPBsSelectedShape(shape);
                }
            
            }
            drawingPanel.Invalidate();

        }
        public void deleteAllShapes()
        {
            shapes.Clear(); 
            drawingPanel.Invalidate();
        }

        public void removeCurrentBackground()
        {
            if (currentShape != null)
            {

                currentShape.isSelected = false;
                drawingPanel.Invalidate();
            }
        }

        private void selectShapeInPosition(int x, int y)
        {
            shapes.Reverse();
            int count = 0;
            foreach (var shape in shapes)
            {
                if (shape.inLocation(x, y))
                {
                    currentShape = shape;
                    currentShape.isSelected = true;
                    menuOperations.setPBsSelectedShape(currentShape);
                    drawingPanel.Invalidate();
                    break;
                }
                count++;
                if(count == shapes.Count())
                {
                    currentShape = null;
                    drawingPanel.Invalidate();

                }
            }
            shapes.Reverse();
        }


        public void drawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (menuOperations.selectPBStatus)
                {
                    if (currentShape != null)
                    {
                        currentShape.isSelected = false;

                    }
                    selectShapeInPosition(e.X, e.Y);
                    if (currentShape != null)
                    {
                        isDrag = true;
                        currentShape.setLastSelectPoint(e.X, e.Y);
                    }
                }
                else
                {
                    if(menuOperations.getLastShape() != null)
                    {
                        if (currentShape != null)
                        {
                            currentShape.isSelected = false;

                        }
                        isDrawing = true;
                        currentShape = menuOperations.getLastShape();
                        currentShape.setStartPoint(e.X, e.Y);
                    }
                    else
                    {
                        MessageBox.Show("Önce Çizmek İstediğiniz Şekli Seçiniz!","SEÇİM");
                    }


                }
            }


        }

        public void drawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isDrawing)
                {
                    currentShape.mouseMoveDraw(e);
                    drawingPanel.Invalidate();
                }
                else if (menuOperations.selectPBStatus && isDrag == true)
                {
                    if (currentShape != null)
                    {
                        currentShape.mouseMoveSelect(e);
                        drawingPanel.Invalidate();
                    }
                }

            }

        }

        public void DrawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDrag = false;
            if (isDrawing)
            {
                isDrawing = false;
                shapes.Add(currentShape);
                drawingPanel.Invalidate();
                currentShape = null;
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
