using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeans_Laborator_2
{
    class Point
    {
        private int x, y;
        private int xForm, yForm;
        public Color color;
        public int zonaCentroid;

        public Point(int x, int y, Color color, int zonaCentroid = 0)
        {
            this.x = x;
            this.y = y;
            this.xForm = 300 + x;
            this.yForm = 300 - y;
            this.color = color;
            this.zonaCentroid = zonaCentroid;
        }

        public int getX()
        {
            return this.x;
        }

        public int getY()
        {
            return this.y;
        }

        public void setX(int x)
        {
            this.x = x;
            this.xForm = Convert.ToInt16(300 + x);
        }

        public void setY(int y)
        {
            this.y = y;
            this.yForm = Convert.ToInt16(300 - y);
        }

        public int getXForm()
        {
            return this.xForm;
        }

        public int getYForm()
        {
            return this.yForm;
        }
    }
}
