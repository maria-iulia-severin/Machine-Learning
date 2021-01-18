using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReteauaKohonen
{
    class Neuron
    {
        public Point Weight { get; set; }

        public Neuron()
        {
            Weight = new Point();
        }

        public Neuron(Point weight)
        {
            Weight = weight;
        }
    }
}
