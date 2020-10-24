using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerareDateAntrenament_Laborator_1
{
    public partial class Spatiu_de_reprezentare_date : Form
    {
        private System.IO.StreamWriter file;
        Random random = new Random();
        private double x;
        private double y;
        //zone 1 - red
        private double mx1 = 180;
        private double my1 = 220;
        private double sigmax1 = 10;
        private double sigmay1 = 10;
        //zone 2 - purple
        private double mx2 = -110;
        private double my2 = 110;
        private double sigmax2 = 15;
        private double sigmay2 = 10;
        //zone 3 - yellow
        private double mx3 = 210;
        private double my3 = -150;
        private double sigmax3 = 5;
        private double sigmay3 = 10;
        //initialize zone between [0,3] 
        private double zone;
        //maximum points
        private int points = 2;


        public Spatiu_de_reprezentare_date()
        {
            file = new System.IO.StreamWriter("coordinates.txt");
            InitializeComponent();
            Zone();
        }

        //am desenat axele x0y
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics gObject = CreateGraphics();
            Brush black = new SolidBrush(Color.Black);
            Brush white = new SolidBrush(Color.White);
            Pen whitePen = new Pen(white, 2);

           // gObject.FillRectangle(black, 0, 0, 500, 500);
            gObject.DrawRectangle(whitePen, 30, 30, 300, 300);
            gObject.DrawLine(whitePen,180,30,180,330);
            gObject.DrawLine(whitePen, 30, 180, 330, 180);
            gObject.Dispose();
          
        }
        private void Zone()
        {
            float prag;
            double G;

            for (int i = 0; i < points; i++)
            {
                zone = random.Next(0, 3);
                do
                {
                    x = RandomNumber();
                    //random.Next() - returns a positive random integer that is less than the specified maximum.
                    prag = (float)(random.Next(10000) / 10000);
                    if (zone == 0)
                    {
                        G = GaussFunction(x, mx1, sigmax1);
                    }
                    else if (zone == 1)
                    {
                        G = GaussFunction(x, mx2, sigmax2);
                    }
                    else
                    {
                        G = GaussFunction(x, mx3, sigmax3);
                    }
                } while (G < prag);

                do
                {
                    y = RandomNumber();
                    //random.Next() - returns a positive random integer that is less than the specified maximum.
                    prag = (float)(random.Next(10000) / 10000);
                    if (zone == 0)
                    {
                        G = GaussFunction(y, my1, sigmay1);
                    }
                    else if (zone == 1)
                    {
                        G = GaussFunction(y, my2, sigmay2);
                    }
                    else
                    {
                        G = GaussFunction(y, my3, sigmay3);
                    }
                } while (G < prag);

                draw(x, y);
                file.WriteLine(x + " " + y + " " + zone);
            }

        }

        public void draw(double x, double y)
        {
            Graphics gObject = CreateGraphics();

            if (zone == 0)
            {
                gObject.FillEllipse(new SolidBrush(Color.Red), (float)x, (float)y, 2.0f, 2.0f);
            }
            else if (zone==1)
            {
                gObject.FillEllipse(new SolidBrush(Color.BlueViolet), (float)x, (float)y, 2.0f, 2.0f);
            }
            else
            {
                gObject.FillEllipse(new SolidBrush(Color.YellowGreen), (float)x, (float)y, 2.0f, 2.0f);
            }
        }

        //random.NextDouble returns a double between 0 and 1. Multipling that by 
        //the range the number should be into and add that to the base (minimum)
        private double RandomNumber()
        {
            int min = -300;
            int max = 300;
            // return random.NextDouble() * (min - max) + min;
            return random.Next(min, max);
        }

        private double GaussFunction(double x, double m, double sigma)
        {
            double n = Math.Pow(m - x, 2);
            return Math.Exp(-n / (2 * Math.Pow(sigma, 2)));
        }
    }
}
