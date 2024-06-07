using FintechCase;

namespace FintechPaintTestCase
{
    public partial class Form1 : Form
    {
        public static readonly int panelWidth = 870;
        public static readonly int panelHeight = 623;

        private MenuOperations menuOperations;
        private DrawOperations drawOperations;
        public Form1()
        {
            InitializeComponent();
            List<PictureBox> shapePictureBoxs = this.shapeGroupBox.Controls.OfType<PictureBox>().ToList();
            List<PictureBox> colorPictureBoxs = this.colorGroupBox.Controls.OfType<PictureBox>().ToList();
            menuOperations = new MenuOperations(shapePictureBoxs, colorPictureBoxs, selectionPB);
            drawOperations = new DrawOperations(panel1, menuOperations);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            drawOperations.DrawingPanel_Paint(sender, e);
        }

        private void purplePB_Click(object sender, EventArgs e)
        {

        }
        private void clickShapePB(object sender, EventArgs e)
        {
            menuOperations.selectShape(((System.Windows.Forms.PictureBox)sender).Name);
            drawOperations.removeCurrentBackground();
        }

        private void clickColorPB(object sender, EventArgs e)
        {
            menuOperations.selectColor(((System.Windows.Forms.PictureBox)sender).Name);
            drawOperations.changeSelectedShapeColor(((System.Windows.Forms.PictureBox)sender).BackColor);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drawOperations.drawingPanel_MouseDown(sender, e);

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            drawOperations.drawingPanel_MouseMove(sender, e);

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drawOperations.DrawingPanel_MouseUp(sender, e);

        }

        private void selectPB_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void selectionPB_Click(object sender, EventArgs e)
        {
            menuOperations.clickSelectionPictureBox();
        }

        private void deletePB_Click(object sender, EventArgs e)
        {
            drawOperations.deleteCurrentShape();
        }

        private void clearPB_Click(object sender, EventArgs e)
        {
            drawOperations.deleteAllShapes();
        }
    }
}
