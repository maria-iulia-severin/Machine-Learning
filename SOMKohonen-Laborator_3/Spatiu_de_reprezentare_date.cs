using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SOMKohonen_Laborator_3.Properties;

namespace SOMKohonen_Laborator_3
{
    public partial class Spatiu_de_reprezentare_date : Form
    {
        private List<Point> points = new List<Point>();
        StreamReader file = new StreamReader("coordinates.txt");
        private static int n = 10; //numarul de linii si coloane
        private Neuron[,] neuroni = new Neuron[n, n];
        Graphics gObject = null;
        //patrat alb
        private const int MAX_X = 600;
        private const int MAX_Y = 500;

        private double limit = 0.01;
        private int N = 10;
        int t = 0;
        private Kohonen kohonen;
        public Spatiu_de_reprezentare_date()
        {
            InitializeComponent();
          /*  ReadPoints();*/
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
        }
        private void ReadPoints()
        {
            string line = String.Empty;
            string[] values;
            while ((line = file.ReadLine()) != null)
            {
                values = line.Split(' ');
                double X = Convert.ToDouble(values[0]);
                double Y = Convert.ToDouble(values[1]);
                DrawPoint(X, Y, Color.White);
                points.Add(new Point
                {
                    x = Convert.ToDouble(values[0]),
                    y = Convert.ToDouble(values[1]),
                    color = Color.White
                });
            }
            file.Close();
            kohonen = new Kohonen(n, neuroni, points, N);
        }

        private void DrawPoint(double x, double y, Color c)
        {
            gObject = CreateGraphics();
            double xPoint = 300 + x;
            double yPoint = 250 - y;
            if ((xPoint < 600 && xPoint > 0) && (yPoint < 500 && yPoint > 0))
            {
                gObject.FillEllipse(new SolidBrush(c), new Rectangle(Convert.ToInt32(xPoint) - 2, Convert.ToInt32(yPoint) - 2, 2, 2));
            }
        }
        private Point ModificareCoordonate(double xEcran, double yEcran, float radius = 3.6f)
        {
            //modific din coordonate ecran in coordonate carteziene
            Point point = new Point();
            point.x = (int)(xEcran - MAX_X / 2 + radius / 2);
            point.y = (int)(MAX_Y / 2 - radius / 2 - yEcran);
            return point;
        }
        private void InitializareNeuroni()
        {
            //640, 540 - patratul negru width, height
            double xSpace = 640 / (n + 1);
            double ySpace = 540 / (n + 1);

            double x = xSpace;
            for (int i = 0; i < n; i++)
            {
               double y = ySpace;
                for (int j = 0; j < n; j++)
                {
                    Point point = ModificareCoordonate(x, y);
                    neuroni[i, j] = new Neuron(point);
                    y += ySpace;
                }
                x += xSpace;
            }
        }
        private void DrawLines(double x1, double y1, double x2, double y2, Color c)
        {
            gObject = CreateGraphics();
            //transform in coord ecran 640 - patrat negru width 
            double x1Ecran = x1 + MAX_X / 2;
            double y1Ecran = MAX_Y / 2 - y1;

            double x2Ecran = x2 + MAX_X / 2;
            double y2Ecran = MAX_Y / 2 - y2;

            gObject.DrawLine(new Pen(c), (float)x1Ecran, (float)y1Ecran, (float)x2Ecran, (float)y2Ecran);
        }
        private void DrawGrid()
        {
            //i = rand, j = coloana
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Point point1;
                    Point point2;
                    if (i < n - 1)
                    {
                        point1 = neuroni[i, j].Pondere;
                        point2 = neuroni[i + 1, j].Pondere;
                        DrawLines(point1.x, point1.y, point2.x, point2.y, Color.Red);
                    }
                    if (j < n - 1)
                    {
                        point1 = neuroni[i, j + 1].Pondere;
                        point2 = neuroni[i, j].Pondere;
                        DrawLines(point1.x, point1.y, point2.x, point2.y, Color.Red);
                    }

                }
            }
        }
        private void UpdatePanel()
        {
            if (panel1.InvokeRequired)
                panel1.Invoke(new Action(() => panel1.Refresh()));
            else
               panel1.Refresh();

            //draw points
            foreach (Point p in points)
            {
                DrawPoint(p.x, p.y, Color.White);
            }
           

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Point point1;
                    Point point2;
                    if (i < n - 1)
                    {
                        point1 = neuroni[i, j].Pondere;
                        point2 = neuroni[i + 1, j].Pondere;
                        DrawLines(point1.x, point1.y, point2.x, point2.y, Color.Red);
                    }
                    if (j < n - 1)
                    {
                        point1 = neuroni[i, j + 1].Pondere;
                        point2 = neuroni[i, j].Pondere;
                        DrawLines(point1.x, point1.y, point2.x, point2.y, Color.Red);
                    }
                }
            }
        }
        private void Spatiu_de_reprezentare_date_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(Run));
            thread.Start();
        }
        private void Run()
        {
            while (kohonen.Alpha(t) > limit)
            {
                kohonen.Learn(t);
                UpdatePanel();
                t++;
                Console.WriteLine("Era "+ t);
            }
        }

        private void DrawAxis()
        {
            Graphics gObject = CreateGraphics();
            Brush black = new SolidBrush(Color.Black);
            Brush white = new SolidBrush(Color.White);
            Pen whitePen = new Pen(white, 2);
            gObject.FillRectangle(black, 0, 0, 640, 540); //patrat negru
           // gObject.DrawRectangle(whitePen, 20, 20, 600, 500); //patrat alb
            gObject.DrawLine(whitePen, 320, 20, 320, 520);
            gObject.DrawLine(whitePen, 20, 270, 620, 270);
            gObject.Dispose();
        }
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            DrawAxis();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            ReadPoints();
            InitializareNeuroni();
            DrawGrid();
        }
    }
}
