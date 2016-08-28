using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bpc
{
    public interface ILRModify
    {
        double LearningRateModify(double lr, double times, double error);
    }

    public class DefaultLRModify : ILRModify
    {
        public double LearningRateModify(double lr, double times, double error)
        {
            return lr;
        }
    }

    public class LRModify : ILRModify
    {
        public double LearningRateModify(double lr, double times, double error)
        {
            return lr * Math.Exp(-error / times);
        }
    }

    public interface IMFModify
    {
        double MomentunFactorModify(double mf, double times, double error);
    }

    public class DefaultMFModify : IMFModify
    {
        public double MomentunFactorModify(double mf, double times, double error)
        {
            return mf;
        }
    }

    public class ModifyMethodDic
    {
        public Dictionary<string, Type> LRDic;
        public Dictionary<string, Type> MFDic;

        public ModifyMethodDic()
        {
            LRDic = new Dictionary<string, Type>();
            LRDic.Add("Default", typeof(DefaultLRModify));
            LRDic.Add("LRModify", typeof(LRModify));

            MFDic = new Dictionary<string, Type>();
            MFDic.Add("Default", typeof(DefaultMFModify));
        }

        public ILRModify GetLRModify(string type)
        {
            Type t = LRDic[type];
            return (ILRModify)Activator.CreateInstance(t);
        }

        public IMFModify GetMFModify(string type)
        {
            Type t = MFDic[type];
            return (IMFModify)Activator.CreateInstance(t);
        }
    }

    public class ModifyMethod
    {
        public ILRModify LRM;
        public IMFModify MFM;

        public ModifyMethod(string lrt, string mft)
        {
            LRM = (new ModifyMethodDic()).GetLRModify(lrt);
            MFM = (new ModifyMethodDic()).GetMFModify(mft);
        }
    }
}
