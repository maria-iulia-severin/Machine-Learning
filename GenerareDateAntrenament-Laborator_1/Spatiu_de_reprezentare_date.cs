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
        public Spatiu_de_reprezentare_date()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            //am desenat axele x0y
            Graphics gObject = CreateGraphics();
            Brush black = new SolidBrush(Color.Black);
            Brush white = new SolidBrush(Color.White);
            Pen whitePen = new Pen(white, 2);

            gObject.FillRectangle(black, 0, 0, 500, 500);
            gObject.DrawRectangle(whitePen, 30, 30, 300, 300);
            gObject.DrawLine(whitePen,180,30,180,330);
            gObject.DrawLine(whitePen, 30, 180, 330, 180);
        }

        //random.NextDouble returns a double between 0 and 1. Multipling that by 
        //the range the number should be into and add that to the base (minimum)
        private double RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.NextDouble() * (min - max) + min;
        }







    }
}
