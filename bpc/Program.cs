using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace bpc
{
    class Program
    {
        BPNetwork bp;
        LoadData ld;

        static void Main(string[] args)
        {
            Program pg = new Program();

            (pg.ld = new LoadData()).ReadData("../../sin10.txt", "");

            pg.bp = new BPNetwork(new List<int>() { 1, 10, 1 }, pg.ld.Inputs, pg.ld.Outputs,
                (new TransferFunctionDic()).GetTransferFunction("Sigmoid"),
                (new ErrorFunctionDic()).GetErrorFunction("SquaredError"),
                (new IntializerDic()).GetIntializer("RandomIntializer"),
                new ModifyMethod("DefaultLRModify", "DefaultMFModify"), "Single", 1, 0.5, 0.01);

            pg.bp.Train();

            foreach (List<double> ld in pg.ld.Inputs)
            {
                Console.WriteLine("{0}, {1}", ld[0], pg.bp.CalculateOutput(ld)[0]);
            }

            Console.ReadKey();
        }
    }
}
