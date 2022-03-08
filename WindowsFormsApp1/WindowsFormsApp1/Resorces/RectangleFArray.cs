using System.Drawing;

namespace WindowsFormsApp1.Resorces
{
    public class RectangleArray
    {
            int index = 0;
            Rectangle[] rectangleArray;

            public RectangleArray(int size)
            {
                if (size <= 0) size = 2;
                this.rectangleArray = new Rectangle[size];
            }
            public void SetRectangle(int x, int y,int width, int height)
            {
                if (index >= rectangleArray.Length)
                {
                    index = 0;
                }
                else
                {
                    rectangleArray[index] = new Rectangle(x, y,width,height);
                    index += 1;
                }
            }
            public void ResetRectangles()
            {
                index = 0;
            }
            public int GetRectanglesCount()
            {
                return index;
            }
            public Rectangle[] GetRectangleArray()
            {
                return rectangleArray;
            }
    }
}
