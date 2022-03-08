using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WindowsFormsApp1.Resorces;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        bool MouseKey = false;
        PointArray pointArray=new PointArray(2);
        RectangleArray rectangleF = new RectangleArray(1);
        Bitmap bitmap;
        Graphics graphics;
        Pen pen = new Pen(Color.Black,3f);
        HatchBrush hBrush = new HatchBrush(HatchStyle.LargeGrid, Color.Black);
        Resorces.Brush brush=new Resorces.Brush();
        
        
        private void SetSize() 
        {

            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
            bitmap = new Bitmap(rectangle.Width,rectangle.Height);
            graphics = Graphics.FromImage(bitmap);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        public Form1()
        {

            InitializeComponent();
            SetSize();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPG(*.JPG)|*.jpg";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                if (pictureBox1.Image == null)
                {
                    pictureBox1.Image.Save(saveFileDialog1.FileName);   
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            graphics.Clear(pictureBox1.BackColor);
            pictureBox1.Image = bitmap;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseKey = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseKey = false;
            pointArray.ResetPoints();
            rectangleF.ResetRectangles();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!MouseKey) 
            { 
                return;
            }
            
        
            pointArray.SetPoint(e.X, e.Y);

            if (pointArray.GetPointsCount() >= 2)
            {
                graphics.DrawLines(pen, pointArray.GetPoints());
                pointArray.SetPoint(e.X, e.Y);
                pictureBox1.Image = bitmap;
            }

            pointArray.SetPoint(e.X, e.Y);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            pen.Color = ((Button)sender).BackColor;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            
            if (colorDialog1.ShowDialog()== DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
                ((Button)sender).BackColor = pen.Color;
            }
        }
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = trackBar1.Value;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            brush.SetSize(2);
            brush.GenerateMosaic(graphics, 2);
            pictureBox1.Image = bitmap;
        }
        private void button17_Click(object sender, EventArgs e)
        {
            brush.SetSize(4);
            brush.GenerateMosaic(graphics, 4);
            pictureBox1.Image = bitmap;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            brush.SetSize(8);
            brush.GenerateMosaic(graphics, 8);
            pictureBox1.Image = bitmap;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (colorDialog4.ShowDialog() == DialogResult.OK)
            {
                brush.SetColor(colorDialog4.Color);
                ((Button)sender).ForeColor = colorDialog4.Color;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (colorDialog5.ShowDialog() == DialogResult.OK)
            {
                brush.SetColor(colorDialog5.Color);
                ((Button)sender).BackColor = colorDialog5.Color;
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
                ((Button)sender).BackColor = pen.Color;
            }
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                brush.SetColor(colorDialog2.Color);
                ((Button)sender).BackColor = colorDialog2.Color;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (colorDialog3.ShowDialog() == DialogResult.OK)
            {
                brush.SetColor(colorDialog3.Color);
                ((Button)sender).BackColor = colorDialog3.Color;
            }
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            if (colorDialog4.ShowDialog() == DialogResult.OK)
            {
                brush.SetColor(colorDialog4.Color);
                ((Button)sender).BackColor = colorDialog4.Color;
            }
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            if (colorDialog5.ShowDialog() == DialogResult.OK)
            {
                brush.SetColor(colorDialog5.Color);
                ((Button)sender).BackColor = colorDialog5.Color;
            }
        }
    }
}
