using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bpc
{
    public abstract class Layer
    {
        public List<Unit> Units;
        public int UnitCount;

        public Layer(int c)
        {
            Units = new List<Unit>();
            UnitCount = c;
        }

        public abstract void AddUnit(List<Layer> ll, List<Connection> lc, int ln, int un, TransferFunction tf, ErrorFunction ef, ModifyMethod mm, double lr, double mf);
    }

    public class InputLayer : Layer
    {
        public InputLayer(int c)
            : base(c)
        {

        }

        public override void AddUnit(List<Layer> ll, List<Connection> lc, int ln, int un, TransferFunction tf, ErrorFunction ef, ModifyMethod mm, double lr, double mf)
        {
            InputUnit iu = new InputUnit(ll, lc, ln, un, tf, mm, lr, mf);
            Units.Add(iu);
        }
    }

    public class HiddenLayer : Layer
    {
        public HiddenLayer(int c)
            : base(c)
        {

        }
        public override void AddUnit(List<Layer> ll, List<Connection> lc, int ln, int un, TransferFunction tf, ErrorFunction ef, ModifyMethod mm, double lr, double mf)
        {
            HiddenUnit hu = new HiddenUnit(ll, lc, ln, un, tf, ef, mm, lr, mf);
            Units.Add(hu);
        }
    }

    public class OutputLayer : Layer
    {
        public OutputLayer(int c)
            : base(c)
        {

        }
        public override void AddUnit(List<Layer> ll, List<Connection> lc, int ln, int un, TransferFunction tf, ErrorFunction ef, ModifyMethod mm, double lr, double mf)
        {
            OutputUnit ou = new OutputUnit(ll, lc, ln, un, tf, ef, mm, lr, mf);
            Units.Add(ou);
        }
    }
}
