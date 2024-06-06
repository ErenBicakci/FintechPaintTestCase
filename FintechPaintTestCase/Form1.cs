using FintechCase;

namespace FintechPaintTestCase
{
    public partial class Form1 : Form
    {

        private MenuOperations menuOperations;
        private DrawOperations drawOperations;
        public Form1()
        {
            InitializeComponent();
            List<PictureBox> shapePictureBoxs = this.shapeGroupBox.Controls.OfType<PictureBox>().ToList();
            List<PictureBox> colorPictureBoxs = this.colorGroupBox.Controls.OfType<PictureBox>().ToList();
            menuOperations = new MenuOperations(shapePictureBoxs, colorPictureBoxs);
            drawOperations = new DrawOperations(panel1,menuOperations);
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
        }

        private void clickColorPB(object sender, EventArgs e)
        {
            menuOperations.selectColor(((System.Windows.Forms.PictureBox)sender).Name);
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
    }
}
