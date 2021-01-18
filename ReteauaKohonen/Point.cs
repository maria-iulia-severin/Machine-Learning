using System;
using System.Drawing;

namespace ReteauaKohonen
{
    class Point
    {
        public double x { get; set; }
        public double y { get; set; }
       // public double xForm, yForm;
        public Color color { get; set; }

        /*     public Point(double x, double y, Color color)
             {
                 this.x = x;
                 this.y = y;
                 this.xForm = 300 + x;
                 this.yForm = 300 - y;
                 this.color = color;
             }*/

        /*   public Point()
           {
           }

           public double getX()
           {
               return this.x;
           }

           public double getY()
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

           public double getXForm()
           {
               return this.xForm;
           }

           public double getYForm()
           {
               return this.yForm;
           }*/
    }
}