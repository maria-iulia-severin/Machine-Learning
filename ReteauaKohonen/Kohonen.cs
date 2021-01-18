using System;
using System.Collections.Generic;
using System.Linq;

namespace ReteauaKohonen
{
    class Kohonen
    {
        private int n;
        private Neuron[,] _neurons;
        private List<Point> _dataSet;

        private int N;

        public Kohonen() { }

        public Neuron[,] Neurons { get; set; }

        public Kohonen(int n, Neuron[,] neurons, List<Point> dataSet, int N = 10)
        {
            this.n = n;
            _neurons = neurons;
            _dataSet = dataSet;
            this.N = N;
        }

        public void UpdateWeight(Neuron neuron, Point point, int t)
        {
            neuron.Weight.x = neuron.Weight.x + LearningRate(t) * (point.x - neuron.Weight.x);
            neuron.Weight.y = neuron.Weight.y + LearningRate(t) * (point.y - neuron.Weight.y);
        }

        public double LearningRate(int t)
        {
            return 0.7 * Math.Pow(Math.E, (-1) * (double)t / N);
            //return 0.7 * Math.Exp((-1) * t / N);
        }

        public double Neighbours(int t)
        {
            return 7 * Math.Pow(Math.E, (-1) * (double)t / N);
            //return 7 * Math.Exp((-1) * t / N);
        }

        public double[,] Distance(Point data)
        {
            double[,] distance = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    double distanceX = Math.Pow((data.x - _neurons[i, j].Weight.x), 2);
                    double distanceY = Math.Pow((data.y - _neurons[i, j].Weight.y), 2);
                    distance[i, j] = Math.Sqrt(distanceX + distanceY);
                }
            }

            return distance;
        }

        public KeyValuePair<int, int> GetWinnerPosition(Point data)
        {
            int row = 0;
            int col = 0;

            double min = double.MaxValue;

            double[,] distance = Distance(data);

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
            for (int i = 0; i < _dataSet.Count(); i++)
            {
                var winnerPosition = GetWinnerPosition(_dataSet[i]);

                int neighbor = (int)Neighbours(t);

                for (int row = winnerPosition.Key - neighbor; row <= winnerPosition.Key + neighbor; row++)
                {
                    for (int col = winnerPosition.Value - neighbor; col <= winnerPosition.Value + neighbor; col++)
                    {
                        if ((row >= 0 && row < n) && (col >= 0 && col < n))
                        {
                            UpdateWeight(_neurons[row, col], _dataSet[i], t);
                        }
                    }
                }
            }
            Neurons = (Neuron[,])_neurons.Clone();

            double neight = Neighbours(t);
            Console.WriteLine("Vecinatate{0},{1}", t, neight);

            double rateLearn = LearningRate(t);
            Console.WriteLine("{0},{1}", t, rateLearn);
        }
    }
}
