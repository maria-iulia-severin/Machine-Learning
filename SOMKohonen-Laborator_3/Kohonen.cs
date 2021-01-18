using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOMKohonen_Laborator_3
{
    class Kohonen
    {
        private int n; //numarul de linii si coloane
        private Neuron[,] _neuroni;
        private List<Point> _points; //lista cu toate punctele 
        private int N; //numarul de epoci in care imi propun ca algoritmul meu sa invete
        public Kohonen() { }
        public Neuron[,] neuroni { get; set; }

        public Kohonen(int n, Neuron[,] neuroni, List<Point> points, int N = 10)
        {
            this.n = n;
            _neuroni = neuroni;
            _points = points;
            this.N = N;
        }

        public double Alpha(int t)
        {
            return 0.6 * Math.Pow(Math.E, (-1) * (double)t / N);
        }

        public double Vecinatate(int t)
        {

            return 6.1 * Math.Pow(Math.E, (-1) * (double)t / N);
        }
        public void ActualizareNeuron(Neuron neuron, Point point, int t)
        {
            neuron.Pondere.x = neuron.Pondere.x + Alpha(t) * (point.x - neuron.Pondere.x);
            neuron.Pondere.y = neuron.Pondere.y + Alpha(t) * (point.y - neuron.Pondere.y);
        }
        private double[,] DistantaManhattan(Point data)
        {
            double[,] distanta = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    double distantaX = data.x - _neuroni[i, j].Pondere.x;
                    double distantaY = data.y - _neuroni[i, j].Pondere.y;
                    distanta[i, j] = Math.Abs(distantaX + distantaY);
                }
            }

            return distanta;
        }
        public double[,] DistantaEuclidiana(Point data)
        {
            double[,] distanta = new double[n, n];
            //calculez distanta euclidiana dintre un punct si toti neuronii
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    double distantaX = Math.Pow((data.x - _neuroni[i, j].Pondere.x), 2);
                    double distantaY = Math.Pow((data.y - _neuroni[i, j].Pondere.y), 2);
                    distanta[i, j] = Math.Sqrt(distantaX + distantaY);
                }
            }
            return distanta;
        }

        public KeyValuePair<int, int> NeuronInvingator(Point data)
        {
            int row = 0;
            int col = 0;

            double min = double.MaxValue;

            //calculez distanta dintre punct si toti neuronii(ponderea fiecarui neuron)
            double[,] distance = DistantaEuclidiana(data);
            //double[,] distance = DistantaManhattan(data);
            
            //distanta minima dintre un punct si un neuron => neuron invingator
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (distance[i, j] < min)
                    {
                        min = distance[i, j];
                        row = i;
                        col = j;
                    }
                }
            }

            return new KeyValuePair<int, int>(row, col);
        }

        public void Learn(int t)
        {
            //iau pe rand cate un punct din fisier
            for (int i = 0; i < _points.Count(); i++)
            {
                //calculez cel mai apropiat neuron si actualizez neuronul invingator 
                var neuronInvingator = NeuronInvingator(_points[i]);

                //actualizam si toti neuronii care sunt vecini cu neuronul invingator
                //La toţi neuroni care sunt vecini(la pasul respectiv) cu neuronul „învingător” se recalculează ponderea
                int vecin = (int)Vecinatate(t);

                for (int row = neuronInvingator.Key - vecin; row <= neuronInvingator.Key + vecin; row++)
                {
                    for (int col = neuronInvingator.Value - vecin; col <= neuronInvingator.Value + vecin; col++)
                    {
                        if ((row >= 0 && row < n) && (col >= 0 && col < n))
                        {
                            ActualizareNeuron(_neuroni[row, col], _points[i], t);
                        }
                    }
                }
            }
            neuroni = (Neuron[,])_neuroni.Clone();

            double afisareVecin = Vecinatate(t);
            Console.WriteLine("Vecinatate: "+ afisareVecin);

            double afisareAlpha = Alpha(t);
            Console.WriteLine("alpha(t): "+ afisareAlpha);
        }
    }
}
