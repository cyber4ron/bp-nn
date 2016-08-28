using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using bpc;

namespace bp
{
    public partial class Form1 : Form
    {
        #region Vars
        delegate void UpdateUIDynamic(CurState s);
        delegate void UpdateUI();

        LoadData Loader;
        BPNetwork BP;
        public CurState State;

        string TrainingFilePath, GeneralizingFilePath;
        string Info;

        public List<List<Point>> Points;
        List<double> Epsilons;
        Dictionary<string, string> Dic;

        List<int> Constructure;
        public string TransferFunction;
        public string ErrorFunction;
        public string Intializer;
        public string LRModify;
        public string MFModify;
        public string TrainMethod;
        public double LearningRate;
        public double MomentumFactor;
        public double MaxEpsilon;

        bool Continue, Stop;
        #endregion

        public void ChartAppearance(Chart chart)
        {
            chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
        }

        public void CalculatePoints(List<int> nc)
        {
            Points.Clear();
            int w = network1.Width;
            int h = network1.Height;

            int vmargin, hmargin;

            vmargin = h / 10;
            hmargin = w / 10;

            int hinterval = (int)(w * 0.8 / (nc.Count - 1));

            List<int> vinterval = new List<int>();

            for (int i = 0; i < nc.Count; i++)
            {
                if (nc[i] == 1) vinterval.Add((int)(h * 0.8));
                else vinterval.Add((int)(h * 0.8 / nc[i] - 1));
            }

            List<Point> lp;
            for (int i = 0; i < nc.Count; i++)
            {
                lp = new List<Point>();
                for (int j = 0; j < nc[i]; j++)
                {
                    lp.Add(new Point(hmargin + hinterval * i, vmargin + vinterval[i] * j));
                }
                Points.Add(lp);
            }
        }

        public Form1()
        {
            InitializeComponent();

            network1.Form = this;

            comboBox1.Items.Add("Default(Sigmoid)");
            comboBox1.Items.Add("Tanh");
            comboBox1.SelectedItem = comboBox1.Items[0];
            comboBox2.Items.Add("Default(SquaredError)");
            comboBox2.SelectedItem = comboBox2.Items[0];
            comboBox3.Items.Add("Default(RandomIntializer)");
            comboBox3.SelectedItem = comboBox3.Items[0];
            comboBox4.Items.Add("Default"); 
            comboBox4.Items.Add("Modified1");
            comboBox4.SelectedItem = comboBox4.Items[0];
            comboBox5.Items.Add("Default");
            comboBox5.SelectedItem = comboBox5.Items[0];
            comboBox6.Items.Add("Default(Each)");
            comboBox6.Items.Add("All");
            comboBox6.SelectedItem = comboBox6.Items[0];

            Dic = new Dictionary<string, string>();
            Dic.Add("Default(Sigmoid)", "Sigmoid");
            Dic.Add("Tanh", "Tanh");
            Dic.Add("Default(SquaredError)", "SquaredError");
            Dic.Add("Default(RandomIntializer)", "RandomIntializer");
            Dic.Add("Default", "Default");
            Dic.Add("Modified1", "LRModify");
            Dic.Add("Default(Each)", "Each");
            Dic.Add("All", "All");

            textBox1.Text = "4, 10, 1";
            textBox2.Text = "0.8";
            textBox3.Text = "0.5";
            textBox4.Text = "1";
            label11.Text = "";
            TrainingFilePath = @"..\..\TrainintData.txt";
            GeneralizingFilePath = @"..\..\Generalization.txt";

            Init();
        }

        public void Init()
        {
            Loader = new LoadData();
            Epsilons = new List<double>();
            Constructure = new List<int>();
            Points = new List<List<Point>>();

            Continue = true;
            Stop = false;
            BtnPause.Enabled = true;
            BtnResume.Enabled = false;
        }

        public void LoadFile(string path1,string path2)
        {
            Loader.ReadData(path1, path2);

            Info = String.Format("{0} inputs, {1} ouputs, {2} items, iterate times = ", Loader.InputsCount, Loader.OutputsCount, Loader.Inputs.Count);
            label11.Text = Info + "0";
        }

        public void UpdateNetwork()
        {
            CalculatePoints(Constructure);
            network1.Invalidate();
        }

        public void UpdateTargetOutput()
        {
            foreach (List<double> ld in Loader.Outputs)
            {
            }

            foreach (List<double> ld in Loader.OutputsG)
            {
            }

        }

        public void UpdateOutput(CurState cs)
        {
        }

        public void UpdateIterateTimes(CurState cs)
        {
            label11.Text = Info + cs.IterateTimes.ToString();
        }

        public void UpdateEpsilon(CurState cs)
        {
        }

        public void UpdateData()
        {
            State = new CurState();

            foreach (List<double> ld in Loader.Inputs)
            {
                State.Outputs.Add(BP.CalculateOutput(ld));
            }

            foreach (List<double> ld in Loader.InputsG)
            {
                State.OutputsG.Add(BP.CalculateOutput(ld));
            }

            State.AbsEpsilon = BP.AbsoluteEpsilon;
            State.RelEpsilon = BP.RelativeEpsilon;
            State.IterateTimes = BP.IterateTimes;

            State.AbsEpsilonG = 0;
            for (int i = 0; i < State.OutputsG.Count; i++)
            {
                for (int j = 0; j < State.OutputsG[i].Count; j++)
                {
                    State.AbsEpsilonG += Math.Abs(State.OutputsG[i][j] - Loader.OutputsG[i][j]);
                }
            }

            State.AbsEpsilonG /= State.OutputsG.Count;
            State.RelEpsilonG = Math.Abs(State.AbsEpsilonG / Loader.OutputsG.Sum(x => x.Sum())) / State.OutputsG.Count;

            Epsilons.Add(BP.RelativeEpsilon);

            List<List<double>> lld;
            for (int k = 0; k < Constructure.Count - 1; k++)
            {
                lld = new List<List<double>>();
                for (int i = 0; i < Constructure[k]; i++)
                {
                    lld.Add(new List<double>());
                }
                State.Weights.Add(lld);
            }

            for (int k = 0; k < BP.Connections.Count; k++)
            {
                State.Weights[BP.Connections[k].l][BP.Connections[k].i].Add(BP.Connections[k].Weight);
            }
        }

        public void BPTrain()
        {
            this.BeginInvoke(new UpdateUI(UpdateTargetOutput), null);

            BP = new BPNetwork(Constructure, Loader.Inputs, Loader.Outputs,
                (new TransferFunctionDic()).GetTransferFunction(TransferFunction),
                (new ErrorFunctionDic()).GetErrorFunction(ErrorFunction),
                (new IntializerDic()).GetIntializer(Intializer),
                new ModifyMethod(LRModify, MFModify), TrainMethod, LearningRate, MomentumFactor, MaxEpsilon);


            BP.IterateTimes = 0;
            while (true)
            {
                while (!Continue)
                {
                    Thread.Sleep(new TimeSpan(100));
                }

                if (Stop)
                {
                    this.BeginInvoke(new MethodInvoker(Init));
                    break;
                }

                BP.IterateTimes++;
                BP.AbsoluteEpsilon = 0;
                BP.RelativeEpsilon = 0;

                BP.BPMethod.MethodInvoke();

                if (BP.IterateTimes % 100 == 0)
                {
                    UpdateData();
                    this.BeginInvoke(new UpdateUI(UpdateNetwork));
                    this.BeginInvoke(new UpdateUIDynamic(UpdateIterateTimes), State);
                    this.BeginInvoke(new UpdateUIDynamic(UpdateEpsilon), State);
                    this.BeginInvoke(new UpdateUIDynamic(UpdateOutput), State);
                }

                if (BP.RelativeEpsilon < BP.MaxEpsilon) break;
            }
        }

        private void BtnTrain_Click(object sender, EventArgs e)
        {
            Init();

            LoadFile(TrainingFilePath, GeneralizingFilePath);

            Constructure = textBox1.Text.ToString().Split(',').Select(x => Int32.Parse(x)).ToList();
            TransferFunction = Dic[comboBox1.SelectedItem.ToString()];
            ErrorFunction = Dic[comboBox2.SelectedItem.ToString()];
            Intializer = Dic[comboBox3.SelectedItem.ToString()];
            LRModify = Dic[comboBox4.SelectedItem.ToString()];
            MFModify = Dic[comboBox5.SelectedItem.ToString()];
            TrainMethod = Dic[comboBox6.SelectedItem.ToString()];
            LearningRate = Double.Parse(textBox2.Text.ToString());
            MomentumFactor = Double.Parse(textBox3.Text.ToString());
            MaxEpsilon = Double.Parse(textBox4.Text.ToString()) / 100;

            MethodInvoker mi = new MethodInvoker(BPTrain);
            mi.BeginInvoke(null, null);
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            Continue = false;
            BtnPause.Enabled = false;
            BtnResume.Enabled = true;
        }

        private void BtnResume_Click(object sender, EventArgs e)
        {
            Continue = true;
            BtnPause.Enabled = true;
            BtnResume.Enabled = false;
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            Stop = true;
        }

        private void openTrainingDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            TrainingFilePath = openFileDialog1.FileName;
        }

        private void openGeneralizingDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            GeneralizingFilePath = openFileDialog1.FileName;
        }

    }
}
