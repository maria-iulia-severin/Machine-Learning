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

namespace KMeans_Laborator_2
{
    public partial class Spatiu_de_reprezentare_date : Form
    {

        Random random = new Random();
        private int k, newX, newY, epoca=0;
        private List<Point> points = new List<Point>();
        private List<Centroid> centroizi = new List<Centroid>();
        private List<Centroid> centroiziDesenati = new List<Centroid>();
        private List<Color> oldColor = new List<Color>();
        private Color newColor;
        private Color[] colors = new Color[] { Color.Magenta, Color.LightBlue, Color.LightCoral, Color.LightGreen, Color.Orange, Color.Orchid, Color.Olive, Color.Pink, Color.Purple, Color.Cyan };
        StreamReader file = new StreamReader("coordinates.txt");
        public Spatiu_de_reprezentare_date()
        {
            InitializeComponent();
            ReadPoints();
            GenerareCentroizi();
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
            gObject.DrawLine(whitePen, 320, 20, 320, 520);
            gObject.DrawLine(whitePen, 20, 270, 620, 270);
            gObject.Dispose();

            //ReadPoints();
            //GenerareCentroizi();
            DrawCentroizi();
            DrawPoints();
        }

        //generez centroizii
        private void GenerareCentroizi()
        {
            //3 centroizi
            //124 - 53
            //217 - 61
            //244 52

            //5 centroizi
            //16 214
            //- 149 195
            // - 240 160
            //220 132
            //97 - 40

            //centroizi fixi
            //centroizi.Add(new Centroid(16, 214, Color.Red, 1));
            //centroizi.Add(new Centroid(-149, 195, Color.Yellow, 2));
            //centroizi.Add(new Centroid(-240, 160, Color.Blue, 3));
            //centroizi.Add(new Centroid(220, 132, Color.Green, 4));
            //centroizi.Add(new Centroid(97, -40, Color.Pink, 4));

            //generare centroizi random
            k = random.Next(2, 10);
            //k = 7;
            for (int i = 0; i < k; i++)
            {
                newX = RandomNumber();
                newY = RandomNumber();
                int changedX = newX + 300;
                int changedY = 300 - newY;
                //   cat timp noua culoarea nu a mai fost folosita, alege o noua culoare
                do
                {
                    newColor = colors.ElementAt(random.Next(1, 10));
                }
                while (oldColor.Contains(newColor));
                oldColor.Add(newColor);

                if ((changedX < 600 && changedX > 40) && (changedY < 500 && changedY > 40))
                {
                    centroizi.Add(new Centroid(newX, newY, newColor, i + 1));
                    Console.WriteLine(newX + " " + newY);
                }
            }
        }
        private void DrawCentroizi()
        {
            Graphics gObject = CreateGraphics();

            foreach (Centroid c in centroizi)
            {
                int xCentroid = 300 + c.getX();
                int yCentroid = 300 - c.getY();
                Color cul = c.color;
                Brush white = new SolidBrush(Color.Black);
                gObject.FillEllipse(white, new Rectangle(xCentroid - 5, yCentroid - 5, 12, 12));
                gObject.FillEllipse(new SolidBrush(c.color), new Rectangle(xCentroid - 5, yCentroid - 5, 10, 10));
            }
            gObject.Dispose();

        }
        private void DeleteOldCentroizi()
        {
            Graphics gObject = CreateGraphics();

            foreach (Centroid c in centroizi)
            {
                int xCentroid = 300 + c.getX();
                int yCentroid = 300 - c.getY();
                if ((xCentroid < 600 && xCentroid > 40) && (yCentroid < 500 && yCentroid > 40))
                {
                    gObject.FillEllipse(new SolidBrush(Color.Black), new Rectangle(xCentroid - 5, yCentroid - 5, 10, 10));
                }
            }
            gObject.Dispose();
        }

        private void ReadPoints()
        {
            string line = String.Empty;
            string[] values;
            while ((line = file.ReadLine()) != null)
            {
                values = line.Split(' ');
                points.Add(new Point(Convert.ToInt16(values[0]), Convert.ToInt16(values[1]), Color.White));
            }
            file.Close();
        }

        private void DrawPoints()
        {
            Graphics gObject = CreateGraphics();

            foreach (Point p in points)
            {
                int xPoint = 300 + p.getX();
                int yPoint = 300 - p.getY();
                if ((xPoint < 600 && xPoint > 0) && (yPoint < 500 && yPoint > 0))
                {
                    gObject.FillEllipse(new SolidBrush(p.color), new Rectangle(xPoint - 2, yPoint - 2, 2, 2));
                }
            }
            gObject.Dispose();

        }

        private double Similaritate()
        {
            double distanta = 0;
            foreach (Point point in points)
            {
                //atribuim o valoare foarte mare pt. distanta minima
                double distantaMin = double.MaxValue;
                //double distantaMin= 1000;
                foreach (Centroid centroid in centroizi)
                {
                   double similaritate = DistantaEuclidiana(point, centroid);
                   //double similaritate = DistantaManhattan(point, centroid);

                    if (similaritate < distantaMin)
                    {
                        distantaMin = similaritate;
                        point.zonaCentroid = centroid.zonaCentroid;
                        point.color = centroid.color;
                    }
                }
                distanta += distantaMin;
            }
            return distanta;

        }
        private void CentruDeGreutate()
        {
            int mediaX = 0, mediaY = 0;
            int sumaX = 0, sumaY = 0;
            int totalPuncte = 0;

            foreach (Centroid centroid in centroizi)
            {
                foreach (Point point in points)
                {
                    if (point.zonaCentroid == centroid.zonaCentroid)
                    {
                        sumaX += point.getX();
                        sumaY += point.getY();
                        totalPuncte++;
                    }
                }

                if (totalPuncte != 0)
                {
                    //se calculeaza media tuturor punctelor din cluster pentru centru de greutate 
                    mediaX = sumaX / totalPuncte;
                    mediaY = sumaY / totalPuncte;
                }

                centroid.setX(mediaX);
                centroid.setY(mediaY);
            }
        }



        private void Spatiu_de_reprezentare_date_Click(object sender, EventArgs e)
        {
            double cost = 0;
            DeleteOldCentroizi();
            cost = Similaritate();
            CentruDeGreutate();
            DrawCentroizi();
            DrawPoints();
            epoca++;

            Console.WriteLine("Nr. epoci:" +" "+ epoca);
            Console.WriteLine("Cost:" + " " + cost);
        }

        private double DistantaEuclidiana(Point p, Centroid c)
        {
            double distanceX = p.getX() - c.getX();
            double distanceY = p.getY() - c.getY();
            return Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2));
        }
        private double DistantaManhattan(Point p, Centroid c)
        {
            double distanceX = p.getX() - c.getX();
            double distanceY = p.getY() - c.getY();
            return Math.Abs((distanceX + distanceY));
        }
        private int RandomNumber()
        {
            int min = -300;
            int max = 300;
            return random.Next(min, max);
        }

    }
}
