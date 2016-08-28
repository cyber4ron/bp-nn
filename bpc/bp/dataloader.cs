using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace bpc
{
    public class LoadData
    {
        public List<List<double>> Inputs;
        public List<List<double>> Outputs;

        public List<List<double>> InputsG;
        public List<List<double>> OutputsG;

        public int InputsCount, OutputsCount;

        public void ReadData(string path1, string path2)
        {
            StreamReader sr = new StreamReader(path1);
            string s;

            s = sr.ReadLine();
            InputsCount = Convert.ToInt32(s);
            s = sr.ReadLine();
            OutputsCount = Convert.ToInt32(s);

            Inputs = new List<List<double>>();
            Outputs = new List<List<double>>();
            while ((s = sr.ReadLine()) != null)
            {
                string[] sa = s.Split(new char[] { ',' });
                Inputs.Add(sa.Select(x => Convert.ToDouble(x)).Take(InputsCount).ToList());
                Outputs.Add(sa.Select(x => Convert.ToDouble(x)).Skip(InputsCount).Take(OutputsCount).ToList());
            }
            sr.Close();

            sr = new StreamReader(path2);

            InputsG = new List<List<double>>();
            OutputsG = new List<List<double>>();

            while ((s = sr.ReadLine()) != null)
            {
                string[] sa = s.Split(new char[] { ',' });
                InputsG.Add(sa.Select(x => Convert.ToDouble(x)).Take(InputsCount).ToList());
                OutputsG.Add(sa.Select(x => Convert.ToDouble(x)).Skip(InputsCount).Take(OutputsCount).ToList());
            }
            sr.Close();
        }
    }
}
