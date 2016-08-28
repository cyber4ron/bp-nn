using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bpc
{
    public abstract class Unit
    {
        public int LayerNo, UnitNo;//0-based;
        public double Input, Output, TargetOutput;
        public double Bias;
        public TransferFunction Func;
        public ErrorFunction ErrFunc;
        public List<Connection> BackwardConnections;
        public List<Connection> ForewardConnections;
        public Layer BackwardLayer;
        public Layer ForewardLayer;
        public double Error;
        public double ErrorSum;
        public double LearningRate;
        public double MomentumFactor;
        public ModifyMethod Method;

        public Unit()
        {
            BackwardConnections = new List<Connection>();
            ForewardConnections = new List<Connection>();
        }

        public virtual void SetInput(double u) { }
        public virtual void SetTargetOutput(double to) { }
        public virtual void SetTargetOutputSum(double to) { }
        public abstract void CalcError();
        public abstract double CalcErrorSum();
        public abstract double GetOutput();
        public abstract void AdjustWeight(int times);
    }

    public class InputUnit : Unit
    {
        public InputUnit(List<Layer> ll, List<Connection> lc, int ln, int un, TransferFunction tf, ModifyMethod mm, double lr, double mf)
        {
            LayerNo = ln;
            UnitNo = un;
            AddConnections(lc, ln, un);
            AddLayers(ll, ln);
            Func = tf;
            Method = mm;
            Bias = 0;
        }

        public void AddConnections(List<Connection> lc, int ln, int un)
        {
            foreach (Connection c in lc)
            {
                if (c.l == ln && c.i == un) ForewardConnections.Add(c);
            }
        }

        public void AddLayers(List<Layer> ll, int ln)
        {
            ForewardLayer = ll[ln + 1];
        }

        public override void SetInput(double u)
        {
            Input = u;
        }

        public override double GetOutput()
        {
            Output = Input;
            return Output;
        }

        public override void CalcError() { }

        public override double CalcErrorSum() { return 0; }

        public override void AdjustWeight(int times) { }
    }

    public class HiddenUnit : Unit
    {
        public HiddenUnit(List<Layer> ll, List<Connection> lc, int ln, int un, TransferFunction tf, ErrorFunction ef, ModifyMethod mm, double lr, double mf)
        {
            LayerNo = ln;
            UnitNo = un;
            AddConnections(lc, ln, un);
            AddLayers(ll, ln);
            Func = tf;
            ErrFunc = ef;
            LearningRate = lr;
            MomentumFactor = mf;
            Method = mm;
            Bias = (new Random()).NextDouble() * 2 - 1;
        }

        public void AddConnections(List<Connection> lc, int ln, int un)
        {
            foreach (Connection c in lc)
            {
                if (c.l == ln && c.i == un) ForewardConnections.Add(c);
            }
            foreach (Connection c in lc)
            {
                if (c.l == ln - 1 && c.j == un) BackwardConnections.Add(c);
            }
        }

        public void AddLayers(List<Layer> ll, int ln)
        {
            BackwardLayer = ll[ln - 1];
            ForewardLayer = ll[ln + 1];
        }

        public double PDEV()
        {
            double res = 0;
            for (int i = 0; i < ForewardLayer.UnitCount; i++)
            {
                res += ForewardLayer.Units[i].Error * ForewardConnections[i].Weight;
            }
            return res;
        }

        public double PDVU()
        {
            return Func.TransferFuncDerivatived(Input);
        }

        public double PDUW(int i)
        {
            return BackwardLayer.Units[i].Output;
        }

        public double SetInput()
        {
            Input = 0;
            for (int i = 0; i < BackwardLayer.UnitCount; i++)
            {
                Input += BackwardConnections[i].Weight * BackwardLayer.Units[i].Output;
            }
            Input += Bias;
            return Input;
        }

        public override double GetOutput()
        {
            Output = Func.TransferFunc(SetInput());
            return Output;
        }

        public override void CalcError()
        {
            Error = PDVU() * PDEV();
        }

        public override double CalcErrorSum() { return 0; }

        public override void AdjustWeight(int times)
        {
            for (int i = 0; i < BackwardConnections.Count; i++)
            {
                BackwardConnections[i].PreDeltaWeight =
                   Method.LRM.LearningRateModify(LearningRate, times, Error) * PDUW(i) * Error +
                   Method.MFM.MomentunFactorModify(MomentumFactor, times, Error) * BackwardConnections[i].PreDeltaWeight;

                BackwardConnections[i].Weight += BackwardConnections[i].PreDeltaWeight;

                //BackwardConnections[i].Weights.Add(BackwardConnections[i].Weight);
            }
            Bias += Error;
        }
    }

    public class OutputUnit : Unit
    {
        public OutputUnit(List<Layer> ll, List<Connection> lc, int ln, int un, TransferFunction tf, ErrorFunction ef, ModifyMethod mm, double lr, double mf)
        {
            LayerNo = ln;
            UnitNo = un;
            AddConnections(lc, ln, un);
            AddLayers(ll, ln);
            Func = tf;
            ErrFunc = ef;
            LearningRate = lr;
            MomentumFactor = mf;
            Method = mm;
            Bias = (new Random()).NextDouble() * 2 - 1;
            Error = 0;
        }

        public void AddConnections(List<Connection> lc, int ln, int un)
        {
            foreach (Connection c in lc)
            {
                if (c.l == ln - 1 && c.j == un) BackwardConnections.Add(c);
            }
        }

        public void AddLayers(List<Layer> ll, int ln)
        {
            BackwardLayer = ll[ln - 1];
        }

        public double PDEV()
        {
            return ErrFunc.ErrorFuncDerivatived(TargetOutput, Output);
        }

        public double PDVU()
        {
            return Func.TransferFuncDerivatived(Input);
        }

        public double PDUW(int i)
        {
            return BackwardLayer.Units[i].Output;
        }

        public double SetInput()
        {
            Input = 0;
            for (int i = 0; i < BackwardLayer.UnitCount; i++)
            {
                Input += BackwardConnections[i].Weight * BackwardLayer.Units[i].Output;
            }
            Input += Bias;
            return Input;
        }

        public override double GetOutput()
        {
            Output = Func.TransferFunc(SetInput());
            return Output;
        }

        public override void SetTargetOutput(double to)
        {
            TargetOutput = to;
        }

        public override void SetTargetOutputSum(double to)
        {
            TargetOutput = to;

            Error += CalcErrorSum();
        }

        public override void CalcError()
        {
            Error = -PDVU() * PDEV();
        }

        public override double CalcErrorSum()
        {
            return -PDVU() * PDEV();
        }

        public override void AdjustWeight(int times)
        {
            for (int i = 0; i < BackwardConnections.Count; i++)
            {
                BackwardConnections[i].PreDeltaWeight =
                   Method.LRM.LearningRateModify(LearningRate, times, Error) * PDUW(i) * Error +
                   Method.MFM.MomentunFactorModify(MomentumFactor, times, Error) * BackwardConnections[i].PreDeltaWeight;

                BackwardConnections[i].Weight += BackwardConnections[i].PreDeltaWeight;

                //BackwardConnections[i].Weights.Add(BackwardConnections[i].Weight);
            }

            Bias += Error;
        }
    }
}
