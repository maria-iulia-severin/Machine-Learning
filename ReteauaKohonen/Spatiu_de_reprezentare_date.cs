using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ReteauaKohonen
{
    public partial class Spatiu_de_reprezentare_date : Form
    {
        private List<Point> points = new List<Point>();
        StreamReader file = new StreamReader("coordinates.txt");
        private int N = 10;
        private double limit = 0.01;
        public Graphics g = null;
        private static int n = 10;
        private Neuron[,] neurons = new Neuron[n, n];
        private ReteauaKohonen.Kohonen kohonen;
        int t = 0;

        //private ReteauaKohonen.Kohonen kohonen;
        public Spatiu_de_reprezentare_date()
        {
            InitializeComponent();
            InitNeurons();
            ReadPoints();
            DrawGrid();
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

            DrawGrid();
            DrawPoints();
        }
        private void ReadPoints()
        {
            string line = String.Empty;
            string[] values;
            while ((line = file.ReadLine()) != null)
            {
                values = line.Split(' ');
               //points.Add(new Point(Convert.ToDouble(values[0]), Convert.ToDouble(values[1]), Color.White));
                points.Add(new ReteauaKohonen.Point
                {
                    x = Convert.ToDouble(values[0]),
                    y = Convert.ToDouble(values[1]),
                    color = Color.White
                });
            }
            file.Close();
            kohonen = new ReteauaKohonen.Kohonen(n, neurons, points, N);
        }

        private void DrawPoints()
        {
            Graphics gObject = CreateGraphics();

            foreach (Point p in points)
            {
                float radius = 3.6f;
                double xPoint = 300 + p.x - radius / 2;
                double yPoint = 300 - p.y - radius / 2;

                if ((xPoint < 600 && xPoint > 0) && (yPoint < 500 && yPoint > 0))
                {
                    
                   // gObject.FillEllipse(new SolidBrush(p.color), new Rectangle((xPoint-2, yPoint-2, 2, 2));
                   gObject.FillEllipse(new SolidBrush(p.color), (float)xPoint, (float)yPoint, radius, radius);
                }
            }
            gObject.Dispose();
        }

        private void InitNeurons()
        {
            double xSpace = 600 / (n + 1);
            double ySpace = 600 / (n + 1);
            float radius = 3.6f;

            double x = xSpace;
            for (int i = 0; i < n; i++)
            {
                double y = ySpace;
                for (int j = 0; j < n; j++)
                {
                    ReteauaKohonen.Point point = new ReteauaKohonen.Point();
                    point.x = (int)(x - 600 / 2 + radius / 2);
                    point.y = (int)(600 / 2 - radius / 2 - y);
                    neurons[i, j] = new Neuron(point);
                    y += ySpace;
                }
                x += xSpace;
            }

        }
        private void DrawLine(double x1, double y1, double x2, double y2, Color c)
        {
            g = CreateGraphics();
            double screenX1 = x1 + 640 / 2;
            double screenY1 = 545 / 2 - y1;

            double screenX2 = x2 + 640 / 2;
            double screenY2 = 545 / 2 - y2;

            g.DrawLine(new Pen(c), (float)screenX1, (float)screenY1, (float)screenX2, (float)screenY2);
        }
        private void DrawGrid()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    ReteauaKohonen.Point point1;
                    ReteauaKohonen.Point point2;
                    if (i > 0)
                    {
                        point1 = neurons[i - 1, j].Weight;
                        point2 = neurons[i, j].Weight;
                        DrawLine(point1.x, point1.y, point2.x, point2.y, Color.Red);
                    }
                    if (i < n - 1)
                    {
                        point1 = neurons[i, j].Weight;
                        point2 = neurons[i + 1, j].Weight;
                        DrawLine(point1.x, point1.y, point2.x, point2.y, Color.Red);
                    }
                    if (j > 0)
                    {

                        point1 = neurons[i, j - 1].Weight;
                        point2 = neurons[i, j].Weight;
                        DrawLine(point1.x, point1.y, point2.x, point2.y, Color.Red);
                    }
                    if (j < n - 1)
                    {
                        point1 = neurons[i, j + 1].Weight;
                        point2 = neurons[i, j].Weight;
                        DrawLine(point1.x, point1.y, point2.x, point2.y, Color.Red);
                    }

                }
            }
        }
        private void UpdatePanel()
        {

            /* if (Form.Control.InvokeRequired)
                 Invoke(new Action(() => Refresh()));
             else
                 Refresh();*/
            foreach (var item in points)
            {
                DrawPoints();
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    ReteauaKohonen.Point point1;
                    ReteauaKohonen.Point point2;
                    if (i > 0)
                    {
                        point1 = kohonen.Neurons[i - 1, j].Weight;
                        point2 = kohonen.Neurons[i, j].Weight;
                        DrawLine(point1.x, point1.y, point2.x, point2.y, Color.Red);
                    }
                    if (i < n - 1)
                    {
                        point1 = kohonen.Neurons[i, j].Weight;
                        point2 = kohonen.Neurons[i + 1, j].Weight;
                        DrawLine(point1.x, point1.y, point2.x, point2.y, Color.Red);
                    }
                    if (j > 0)
                    {

                        point1 = kohonen.Neurons[i, j - 1].Weight;
                        point2 = kohonen.Neurons[i, j].Weight;
                        DrawLine(point1.x, point1.y, point2.x, point2.y, Color.Red);
                    }
                    if (j < n - 1)
                    {
                        point1 = kohonen.Neurons[i, j + 1].Weight;
                        point2 = kohonen.Neurons[i, j].Weight;
                        DrawLine(point1.x, point1.y, point2.x, point2.y, Color.Red);
                    }

                }
            }
            //Thread.Sleep(5);
        }
        private void Spatiu_de_reprezentare_date_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(Run));
            thread.Start();
        }
        private void Run()
        {
            while (kohonen.LearningRate(t) > limit)
            {
                kohonen.Learn(t);
                UpdatePanel();
                t++;

                labelEra.Invoke(new Action(() => labelEra.Text = "Era:" + t));
            }
        }
    }
}
