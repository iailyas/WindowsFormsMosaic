using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsApp1.Resorces
{
    public class Brush: IDisposable
    {
        private Pen pen = new Pen(Color.Black,2);
        private List <HatchBrush> brushes;
        private Random random;
        private List <Color> colors;
        private Rectangle rectangle=Screen.PrimaryScreen.Bounds;
        private int size;

        public Brush()
        {
            this.brushes = new List<HatchBrush>();
            this.random = new Random();
            this.colors = new List<Color>();
      
        }

        public void GenerateMosaic(Graphics graphics,int size) 
        {
            
           
            foreach (Color c in colors)
            {
              brushes.Add(new HatchBrush(HatchStyle.LargeGrid,c, c));
            }
            for (int i = 0; i <=rectangle.Width; i+=size*20)
            {
                for (int j = 0; j <=rectangle.Height; j+=size*20)
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

        public void Dispose()
        {
            pen.Dispose();
            
        }
    }
}
