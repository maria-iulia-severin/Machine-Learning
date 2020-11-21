using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private double mx1 = 180; //480
        private double my1 = 220; //80
        private double sigmax1 = 10;
        private double sigmay1 = 10;
        //zone 2 - purple
        private double mx2 = -110; //190
        private double my2 = 110; //190
        private double sigmax2 = 25;
        private double sigmay2 = 10;
        //zone 3 - yellow
        private double mx3 = 210; //510
        private double my3 = -150; //450
        private double sigmax3 = 5;
        private double sigmay3 = 10;
        //initialize zone
        private double zone;
        //maximum points
        private int points = 10000;

        public Spatiu_de_reprezentare_date()
        {
            file = new StreamWriter("coordinates.txt");
            InitializeComponent();
        }
        
        //am desenat axele x0y
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics gObject = CreateGraphics();
            Brush black = new SolidBrush(Color.Black);
            Brush white = new SolidBrush(Color.White);
            Pen whitePen = new Pen(white, 2);
            gObject.FillRectangle(black, 0, 0, 640, 540);
            gObject.DrawRectangle(whitePen, 20, 20, 600, 500);
            gObject.DrawLine(whitePen,320,20,320,520);
            gObject.DrawLine(whitePen, 20, 270, 620, 270);
            gObject.Dispose();
            Zone();
        }
        private void Zone()
        {
            double pragX;
            double GX;
            double pragY;
            double GY;

            for (int i = 0; i < points; i++)
            {
                zone = random.Next(0, 3);
                do
                {
                    x = RandomNumber();
                    //random.Next() - returns a positive random integer that is less than the specified maximum.
                    pragX = (double)(random.Next(1000) / 1000.0);
                    if (zone == 0)
                    {
                        GX = GaussFunction(x, mx1, sigmax1);
                    }
                    else if (zone == 1)
                    {
                        GX = GaussFunction(x, mx2, sigmax2);
                    }
                    else
                    {
                        GX = GaussFunction(x, mx3, sigmax3);
                    }
                } while (GX < pragX);

                do
                {
                    y = RandomNumber();
                    //random.Next() - returns a positive random integer that is less than the specified maximum.
                    pragY = (double)(random.Next(1000) / 1000.0);
                    if (zone == 0)
                    {
                        GY = GaussFunction(y, my1, sigmay1);
                       
                    }
                    else if (zone == 1)
                    {
                        GY = GaussFunction(y, my2, sigmay2);
                     
                    }
                    else
                    {
                        GY = GaussFunction(y, my3, sigmay3);
                      
                    }
                } while (GY < pragY);

                Console.Write("GX:"+GX+" pragX:"+pragX+ "GY:" + GY + " pragY:" + pragY + " x:" +x +" y:" + y+"   "+ "\t");

                Draw(x+300,300-y);

                file.WriteLine("x="+ x +" y="+ y +" zona=" + zone);
            }
        }

        private void Draw(double x, double y)
        {
            Graphics gObject = CreateGraphics();
            Console.WriteLine("x:"+x+" y:"+y+" zona:"+zone);
            if (zone == 0)
            {
                gObject.FillEllipse(new SolidBrush(Color.Red), (float)x, (float)y, 2.0F, 2.0F);
            }
            else if (zone==1)
            {
                gObject.FillEllipse(new SolidBrush(Color.BlueViolet), (float)x, (float)y, 2.0F, 2.0F);
            }
            else
            {
                gObject.FillEllipse(new SolidBrush(Color.YellowGreen), (float)x, (float)y, 2.0F, 2.0F);
            }

            gObject.Dispose();
        }
        //random.NextDouble returns a double between 0 and 1. Multipling that by 
        //the range the number should be into and add that to the base (minimum)
        private double RandomNumber()
        {
            int min = -300;
            int max = 300;
            return random.Next(min, max);
        }

        private double GaussFunction(double x, double m, double sigma)
        {
            double n = Math.Pow(m - x, 2);
            return Math.Exp(-n / (2 * Math.Pow(sigma, 2)));
        }
    }
}
