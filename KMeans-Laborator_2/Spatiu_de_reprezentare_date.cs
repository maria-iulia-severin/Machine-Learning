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
        private int k, newX, newY;
        private List<Point> points = new List<Point>();
        private List<Centroid> centroizi = new List<Centroid>();
        private List<Color> oldColor = new List<Color>();
        private Color newColor;
        private Color[] colors = new Color[] { Color.Magenta, Color.LightBlue, Color.LightCoral, Color.LightGreen, Color.Orange, Color.Orchid, Color.Olive, Color.Pink, Color.Purple, Color.PowderBlue };
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
           // GenerareCentroizi();
            DrawCentroizi();
            DrawPoints();
        }

        //generez centroizii
        private void GenerareCentroizi()
        {
            // k = random.Next(2, 10);
            k = 5;
            for (int i = 0; i < k; i++)
            {
                newX = RandomNumber();
                newY = RandomNumber();

                //cat timp noua culoarea nu a mai fost folosita, alege o noua culoare
                do
                {
                    newColor = colors.ElementAt(random.Next(1, 10));
                }
                while (oldColor.Contains(newColor));
                oldColor.Add(newColor);
                centroizi.Add(new Centroid(newX, newY, newColor, i + 1));

            }
            Console.WriteLine(k);
        }
        private void DrawCentroizi()
        {
            Graphics gObject = CreateGraphics();

            foreach (Centroid c in centroizi)
            {
                int xCentroid = 300 + c.getX();
                int yCentroid = 300 - c.getY();

                //  int xCentroid = panelWindow.Width - panelWindow.Width / 2 + c.getX();
                // int yCentroid = panelWindow.Height - panelWindow.Height / 2 - c.getY();
                if ((xCentroid < 600 && xCentroid > 40) && (yCentroid < 500 && yCentroid > 40))
                {
                    
                    gObject.FillEllipse(new SolidBrush(c.color), new Rectangle(xCentroid - 5, yCentroid - 5, 10, 10));
                   
                }
             //   Console.WriteLine(xCentroid + " " + yCentroid);
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






        private int RandomNumber()
        {
            int min = -300;
            int max = 300;
            return random.Next(min, max);
        }





    }
}
