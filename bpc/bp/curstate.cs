using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bpc;

namespace bpc
{
    public class CurState
    {
        public List<List<double>> Outputs;
        public List<List<double>> OutputsG;
        public int IterateTimes;
        public double AbsEpsilon;
        public double RelEpsilon;
        public double AbsEpsilonG;
        public double RelEpsilonG;
        public List<List<List<double>>> Weights;

        public CurState()
        {
            Outputs = new List<List<double>>();
            OutputsG = new List<List<double>>();
            Weights = new List<List<List<double>>>();
 
        }

        //public CurState(List<Connection> conns, int l,int i)
        //{
        //    Outputs = new List<List<double>>();
        //    BackConn = new List<Connection>();
        //    ForeConn = new List<Connection>();

        //    List<Connection> bc = conns.Where(x => (x.l == l - 1 && x.j == i)).ToList();
        //    List<Connection> fc = conns.Where(x => (x.l == l && x.i == i)).ToList();

        //    Connection ct;
        //    foreach (Connection c in bc)
        //    {
        //        ct = new Connection();

        //        foreach (double d in c.Weights)
        //        {
        //            ct.Weights.Add(d);
        //        }

        //        BackConn.Add(ct);
        //    }

        //    foreach (Connection c in fc)
        //    {
        //        ct = new Connection();

        //        foreach (double d in c.Weights)
        //        {
        //            ct.Weights.Add(d);
        //        }

        //        ForeConn.Add(ct);
        //    }
        //}
    }
}
