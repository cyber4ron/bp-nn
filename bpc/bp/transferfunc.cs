using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bpc
{
    public abstract class TransferFunction
    {
        public List<double> InputMax, InputMin, OutputMax, OutputMin;

        public double Max, Min;

        public TransferFunction()
        {
            InputMax = new List<double>();
            InputMin = new List<double>();
            OutputMax = new List<double>();
            OutputMin = new List<double>();
        }

        public abstract string FunctionName();

        public abstract double TransferFunc(double u);

        public abstract double TransferFuncDerivatived(double u);

        public abstract void Normalize(List<List<double>> Inputs, List<List<double>> Outputs, out List<List<double>> NormalizedInputs, out List<List<double>> NormalizedOutputs);

        public abstract List<double> Normalize(List<double> ld);

        public abstract List<double> Denormalize(List<double> ld);
    }

    public class Sigmoid : TransferFunction
    {
        public Sigmoid()
            : base()
        {

        }

        public override string FunctionName()
        {
            return "Sigmoid";
        }

        public override double TransferFunc(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }

        public override double TransferFuncDerivatived(double x)
        {
            double f = TransferFunc(x);
            return f * (1 - f);
        }

        public override List<double> Normalize(List<double> ld)
        {
            return ld.Select(x => ((x - InputMin[ld.IndexOf(x)]) / (InputMax[ld.IndexOf(x)] - InputMin[ld.IndexOf(x)])) * 2 - 1).ToList();
        }

        public override List<double> Denormalize(List<double> ld)
        {
            return ld.Select(x => OutputMin[ld.IndexOf(x)] + x * (OutputMax[ld.IndexOf(x)] - OutputMin[ld.IndexOf(x)])).ToList();
        }

        public override void Normalize(List<List<double>> Inputs, List<List<double>> Outputs, out List<List<double>> NormalizedInputs, out List<List<double>> NormalizedOutputs)
        {
            NormalizedInputs = new List<List<double>>();
            NormalizedOutputs = new List<List<double>>();

            for (int i = 0; i < Inputs.Count; i++)
            {
                NormalizedInputs.Add(new List<double>());
            }

            for (int i = 0; i < Outputs.Count; i++)
            {
                NormalizedOutputs.Add(new List<double>());
            }

            for (int i = 0; i < Inputs[0].Count; i++)
            {
                Max = Inputs.Select(x => x.Skip(i).Take(1).ToList()[0]).Max();
                Min = Inputs.Select(x => x.Skip(i).Take(1).ToList()[0]).Min();

                List<double> ld = Inputs.Select(x => x.Skip(i).Take(1).ToList()[0]).Select(y => ((y - Min) / (Max - Min)) * 2 - 1).ToList();

                InputMin.Add(Min);
                InputMax.Add(Max);

                for (int j = 0; j < Inputs.Count; j++)
                {
                    NormalizedInputs[j].Add(ld[j]);
                }
            }

            for (int i = 0; i < Outputs[0].Count; i++)
            {
                Max = Outputs.Select(x => x.Skip(i).Take(1).ToList()[0]).Max();
                Min = Outputs.Select(x => x.Skip(i).Take(1).ToList()[0]).Min();

                List<double> ld = Outputs.Select(x => x.Skip(i).Take(1).ToList()[0]).Select(y => ((y - Min) / (Max - Min))).ToList();

                OutputMin.Add(Min);
                OutputMax.Add(Max);

                for (int j = 0; j < Outputs.Count; j++)
                {
                    NormalizedOutputs[j].Add(ld[j]);
                }
            }

        }

        //输入数据max-min!=0
        //public override void Normalize(List<List<double>> Inputs, List<List<double>> Outputs, out List<List<double>> NormalizedInputs, out List<List<double>> NormalizedOutputs)
        //{
        //    NormalizedInputs = new List<List<double>>();
        //    NormalizedOutputs = new List<List<double>>();

        //    InputMax = Double.MinValue;
        //    InputMin = Double.MaxValue;
        //    foreach (List<double> ld in Inputs)
        //    {
        //        if (ld.Max() > InputMax) InputMax = ld.Max();
        //        if (ld.Min() < InputMin) InputMin = ld.Min();
        //    }
        //    for (int i = 0; i < Inputs.Count; i++)
        //    {
        //        NormalizedInputs.Add(Inputs[i].Select(x => ((x - InputMin) / (InputMax - InputMin)) * 2 - 1).ToList());//[-1, 1]
        //    }

        //    OutputMax = Double.MinValue;
        //    OutputMin = Double.MaxValue;
        //    foreach (List<double> ld in Outputs)
        //    {
        //        if (ld.Max() > OutputMax) OutputMax = ld.Max();
        //        if (ld.Min() < OutputMin) OutputMin = ld.Min();
        //    }
        //    for (int i = 0; i < Outputs.Count; i++)
        //    {
        //        NormalizedOutputs.Add(Outputs[i].Select(x => (x - OutputMin) / (OutputMax - OutputMin)).ToList());//[0, 1]
        //    }
        //}
    }

    public class Tanh : TransferFunction
    {
        public Tanh()
            : base()
        {

        }

        public override string FunctionName()
        {
            return "Tanh";
        }

        public override double TransferFunc(double x)
        {
            return Math.Tanh(x);
        }

        public override double TransferFuncDerivatived(double x)
        {
            double f = Math.Tanh(x);
            return 1 - f * f;
        }

        public override List<double> Normalize(List<double> ld)
        {
            return ld.Select(x => ((x - InputMin[ld.IndexOf(x)]) / (InputMax[ld.IndexOf(x)] - InputMin[ld.IndexOf(x)])) * 2 - 1).ToList();
        }

        public override List<double> Denormalize(List<double> ld)
        {
            return ld.Select(x => OutputMin[ld.IndexOf(x)] + x * (OutputMax[ld.IndexOf(x)] - OutputMin[ld.IndexOf(x)])).ToList();
        }

        public override void Normalize(List<List<double>> Inputs, List<List<double>> Outputs, out List<List<double>> NormalizedInputs, out List<List<double>> NormalizedOutputs)
        {
            NormalizedInputs = new List<List<double>>();
            NormalizedOutputs = new List<List<double>>();

            for (int i = 0; i < Inputs.Count; i++)
            {
                NormalizedInputs.Add(new List<double>());
            }

            for (int i = 0; i < Outputs.Count; i++)
            {
                NormalizedOutputs.Add(new List<double>());
            }

            for (int i = 0; i < Inputs[0].Count; i++)
            {
                Max = Inputs.Select(x => x.Skip(i).Take(1).ToList()[0]).Max();
                Min = Inputs.Select(x => x.Skip(i).Take(1).ToList()[0]).Min();

                List<double> ld = Inputs.Select(x => x.Skip(i).Take(1).ToList()[0]).Select(y => ((y - Min) / (Max - Min)) * 2 - 1).ToList();

                InputMin.Add(Min);
                InputMax.Add(Max);

                for (int j = 0; j < Inputs.Count; j++)
                {
                    NormalizedInputs[j].Add(ld[j]);
                }
            }

            for (int i = 0; i < Outputs[0].Count; i++)
            {
                Max = Outputs.Select(x => x.Skip(i).Take(1).ToList()[0]).Max();
                Min = Outputs.Select(x => x.Skip(i).Take(1).ToList()[0]).Min();

                List<double> ld = Outputs.Select(x => x.Skip(i).Take(1).ToList()[0]).Select(y => ((y - Min) / (Max - Min))).ToList();

                OutputMin.Add(Min);
                OutputMax.Add(Max);

                for (int j = 0; j < Outputs.Count; j++)
                {
                    NormalizedOutputs[j].Add(ld[j]);
                }
            }

        }
    }

    public class TransferFunctionDic
    {
        Dictionary<string, Type> Dic;

        public TransferFunctionDic()
        {
            Dic = new Dictionary<string, Type>();
            Dic.Add("Sigmoid", typeof(Sigmoid));
            Dic.Add("Tanh", typeof(Tanh));
        }

        public TransferFunction GetTransferFunction(string type)
        {
            Type t = Dic[type];
            return (TransferFunction)Activator.CreateInstance(t);
        }
    }
}
