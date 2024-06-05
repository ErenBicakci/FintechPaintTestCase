using FintechCase;

namespace FintechPaintTestCase
{
    public partial class Form1 : Form
    {

        private MenuOperations menuOperations;
        public Form1()
        {
            InitializeComponent();
            List<PictureBox> shapePictureBoxs = this.shapeGroupBox.Controls.OfType<PictureBox>().ToList();
            List<PictureBox> colorPictureBoxs = this.colorGroupBox.Controls.OfType<PictureBox>().ToList();
            menuOperations = new MenuOperations(shapePictureBoxs, colorPictureBoxs);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
    }
}
