using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bpc
{
    public class Network
    {
        #region Vars
        public List<Layer> Layers; 
        public List<Connection> Connections;
        
        public TransferFunction TransFunc;
        public ErrorFunction ErrFunc;
        public Intializer Init;
        public TrainMethod BPMethod;
        public string TrainMethod;

        public double LearningRate;
        public double MomentumFactor;
        public int IterateTimes;
        public double MaxEpsilon;
        public double AbsoluteEpsilon;

        public double SumError;
        public double SumOutput;
        public double RelativeEpsilon;
        
        //training data
        public List<List<double>> Inputs;
        public List<List<double>> Outputs;
        public List<List<double>> NormalizedInputs;
        public List<List<double>> NormalizedOutputs;
        #endregion

        public Network()
        {
            Connections = new List<Connection>();
        }
    }

    public class BPNetwork : Network
    {
        public BPNetwork(List<int> nc, List<List<double>> inputs, List<List<double>> outputs, 
            TransferFunction tf, ErrorFunction ef, Intializer it, ModifyMethod mm, string tm,
            double lr, double mf, double me)//2,3,2
        {
            Inputs = inputs;
            Outputs = outputs;

            //create layers
            Layers = new List<Layer>();
            Layers.Add(new InputLayer(nc[0]));
            for (int i = 1; i < nc.Count - 1; i++)
            {
                Layers.Add(new HiddenLayer(nc[i]));
            }
            Layers.Add(new OutputLayer(nc[nc.Count - 1]));

            //create connections;
            for (int i = 0; i < nc.Count - 1; i++)
            {
                for (int j = 0; j < nc[i]; j++)
                {
                    for (int k = 0; k < nc[i + 1]; k++)
                    {
                        Connections.Add(new Connection(i, j, k));
                    }
                }
            }

            //create units and assign connection to each unit;
            for (int i = 0; i < Layers.Count; i++)
            {
                for (int j = 0; j < Layers[i].UnitCount; j++)
                {
                    Layers[i].AddUnit(Layers, Connections, i, j, tf, ef, mm, lr, mf);
                }
            }

            TransFunc = tf;
            ErrFunc = ef;
            Init = it;
            MaxEpsilon = me;
            IterateTimes = 0;
            TrainMethod = tm;
            BPMethod = new TrainMethod(this, tm);

            Normalize();
            InitializeWeights();
        }

        public void Normalize()
        {
            TransFunc.Normalize(Inputs, Outputs, out NormalizedInputs, out NormalizedOutputs);
        }

        public void InitializeWeights()
        {
            Init.SetConnections(Connections);
            Init.InitializeWeight();
        }

        public void GetEpsilon()
        {
            AbsoluteEpsilon += Layers[Layers.Count - 1].Units.Sum(x => Math.Abs(x.TargetOutput - x.Output));

            SumOutput += Layers[Layers.Count - 1].Units.Sum(x => Math.Abs(x.Output));
        }

        public void Forward(int k)
        {
            for (int i = 0; i < Layers[0].UnitCount; i++)
            {
                Layers[0].Units[i].SetInput(NormalizedInputs[k][i]);
            }

            for (int i = 0; i < Layers.Count; i++)
            {
                for (int j = 0; j < Layers[i].UnitCount; j++)
                {
                    Layers[i].Units[j].GetOutput();
                }
            }

            for (int i = 0; i < Layers[Layers.Count - 1].UnitCount; i++)
            {
                Layers[Layers.Count - 1].Units[i].SetTargetOutput(NormalizedOutputs[k][i]);
            }

            GetEpsilon();
        }

        public void Backward()
        {
            for (int i = Layers.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < Layers[i].UnitCount; j++)
                {
                    Layers[i].Units[j].CalcError();
                }
            }

            for (int i = Layers.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < Layers[i].UnitCount; j++)
                {
                    Layers[i].Units[j].AdjustWeight(IterateTimes);
                }
            }
        }

        public void BackPropagation()
        {
            for (int k = 0; k < NormalizedInputs.Count; k++)
            {
                Forward(k);

                Backward();
            }

            RelativeEpsilon = AbsoluteEpsilon / SumOutput;
            AbsoluteEpsilon /= NormalizedInputs.Count;
        }

        public void Train()
        {
            IterateTimes = 0;
            while (true)
            {
                IterateTimes++;
                AbsoluteEpsilon = 0;
                RelativeEpsilon = 0;

                BPMethod.MethodInvoke();

                Console.WriteLine("{0},  {1},  {2}", IterateTimes, AbsoluteEpsilon, RelativeEpsilon);

                if (RelativeEpsilon < MaxEpsilon) break;

                
            }
        }

        public List<double> CalculateOutput(List<double> inp)
        {
            List<double> inputs = TransFunc.Normalize(inp);

            for (int i = 0; i < Layers[0].UnitCount; i++)
            {
                Layers[0].Units[i].SetInput(inputs[i]);
            }

            for (int i = 0; i < Layers.Count; i++)
            {
                for (int j = 0; j < Layers[i].UnitCount; j++)
                {
                    Layers[i].Units[j].GetOutput();
                }
            }

            List<double> ld = new List<double>();
            for (int i = 0; i < Layers[Layers.Count - 1].UnitCount; i++)
            {
                ld.Add(Layers[Layers.Count - 1].Units[i].Output);
            }

            return TransFunc.Denormalize(ld);
        }
    }
}