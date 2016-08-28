using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bpc
{
    public class Connection
    {
        //public List<double> Weights;
        public double PreDeltaWeight;
        public double PreWeight;
        public double Weight;
        public int l, i, j;

        public Connection()
        {
            //Weights = new List<double>();
        }

        public Connection(int a, int b, int c)
        {
            //Weights = new List<double>();
            l = a;
            i = b;
            j = c;
        }
    }
}
