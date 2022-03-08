
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsApp1.Resorces
{
    public class Brush
    {
        List <HatchBrush> brushes;
        Random random;
        List <Color> colors;
        Rectangle rectangle=Screen.PrimaryScreen.Bounds;
        int size;

        public Brush()
        {
            this.brushes = new List<HatchBrush>();
            this.random = new Random();
            this.colors = new List<Color>();
      
        }

        public void GenerateMosaic(Graphics graphics,int size) 
        {
            int x=rectangle.Width;
            int y= rectangle.Height;
            Pen pen = new Pen(Color.Black,2);
           // Brush brush = new TextureBrush(brushes);
            foreach (Color c in colors)
            {
              brushes.Add(new HatchBrush(HatchStyle.LargeGrid,c, c));
            }
            //graphics.FillRectangle(brushes[random.Next(0, 3)], new Rectangle(0, 0, 200, 200));
            //graphics.FillRectangle(brushes[random.Next(0, 3)], new Rectangle(0, 0, 400, 200));
            for (int i = 0; i <= x; i+=size*20)
            {
                for (int j = 0; j <= y; j+=size*20)
                {

                    DrawRectangle(graphics, pen, random.Next(0, 4), i, j,size*20,size*20);
                   
                }
            }


        }
        public void DrawRectangle(Graphics graphics,Pen pen,int random,int x,int y,int width, int height) 
        { 
            graphics.FillRectangle(brushes[random],new Rectangle(x,y,width,height));
            graphics.DrawRectangle(pen, new Rectangle(x,y,width,height));
        }
        public void SetColor(Color color)
        {
            colors.Add(color);
        }
        public void SetSize(int size)
        {
            this.size=size;
        }
        public int GetSize()
        {
            return size;
        }

    }
}
