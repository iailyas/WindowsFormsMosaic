using System;
using System.Drawing;

namespace WindowsFormsApp1.Resorces
{
    public class PointArray
    {
        int index = 0;
        Point[] points;

        public PointArray(int size)
        {
            if (size <= 0) size = 2;
            this.points = new Point[size];
        }
        public void SetPoint(int x, int y)
        {
            if (index >= points.Length)
            {
                index = 0;
            }
            else
            {
                points[index] = new Point(x, y);
                index += 1;
            }
        }
        public void ResetPoints()
        {
            index = 0;
        }
        public int GetPointsCount()
        {
            return index;
        }
        public Point[] GetPoints()
        {
            return points;
        }
    }
}