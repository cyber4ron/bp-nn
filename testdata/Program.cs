using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace testdata
{
    class Program
    {
        static void Main(string[] args)
        {
            //StreamWriter sw = new StreamWriter("../../../BPNN/test60.txt");
            //double step = 0.1;
            //sw.WriteLine(1);
            //sw.WriteLine(1);
            //for (double i = -Math.PI; i < Math.PI; i += step)
            //{
            //    sw.WriteLine("{0},{1}", i, Math.Sin(i));
            //}
            //sw.Close();
            //sw = new StreamWriter("../../../BPNN/test30.txt");
            //step = 0.2;
            //sw.WriteLine(1);
            //sw.WriteLine(1);
            //for (double i = -Math.PI; i < Math.PI; i += step)
            //{
            //    sw.WriteLine("{0},{1}", i, Math.Sin(i));
            //}
            //sw.Close();
            //sw = new StreamWriter("../../../BPNN/test20.txt");
            //step = 0.314;
            //sw.WriteLine(1);
            //sw.WriteLine(1);
            //for (double i = -Math.PI; i < Math.PI; i += step)
            //{
            //    sw.WriteLine("{0},{1}", i, Math.Sin(i));
            //}
            //sw.Close();

            StreamWriter sw = new StreamWriter("../../../testdata/sin10.txt");
            double step = 0.628;
            sw.WriteLine(1);
            sw.WriteLine(1);
            for (double i = -Math.PI; i < Math.PI; i += step)
            {
                sw.WriteLine("{0},{1}", i, Math.Sin(i));
            }
            sw.Close();


            //StreamWriter sw = new StreamWriter("../../../testdata/sin10.txt");
            //double step = 0.1;
            //sw.WriteLine(1);
            //sw.WriteLine(1);
            //for (double x = -1; x <= 1.5; x += step)
            //{
            //    sw.WriteLine("{0},{1}", x, 5 + 2 * Math.Exp(1 - x * x) * Math.Cos(2 * Math.PI * x));
            //}
            //sw.Close();



        }
    }
}
