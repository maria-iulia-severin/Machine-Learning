using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KMeans_Laborator_2
{
    public partial class Spatiu_de_reprezentare_date : Form
    {
        public Spatiu_de_reprezentare_date()
        {
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
            gObject.DrawLine(whitePen, 320, 20, 320, 520);
            gObject.DrawLine(whitePen, 20, 270, 620, 270);
            gObject.Dispose();
           // Zone();
        }








    }
}
