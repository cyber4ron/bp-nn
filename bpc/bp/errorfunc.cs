using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bpc
{
    public abstract class ErrorFunction
    {
        public abstract double ErrorFunc(double target, double x);

        public abstract double ErrorFuncDerivatived(double target, double x);
    }

    public class SquaredError : ErrorFunction
    {
        public override double ErrorFunc(double target, double x)
        {
            return (target - x) * (target - x) / 2;
        }

        public override double ErrorFuncDerivatived(double target, double x)
        {
            return -(target - x);
        }
    }

    public class ErrorFunctionDic
    {
        Dictionary<string, Type> Dic;

        public ErrorFunctionDic()
        {
            Dic = new Dictionary<string, Type>();
            Dic.Add("SquaredError", typeof(SquaredError));
        }

        public ErrorFunction GetErrorFunction(string type)
        {
            Type t = Dic[type];
            return (ErrorFunction)Activator.CreateInstance(t);
        }
    }
}
