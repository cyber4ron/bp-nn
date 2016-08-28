using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bpc
{
    public class TrainMethod
    {
        public delegate void Method();
        public string MethodName;

        Dictionary<string, Method> Dic;

        public TrainMethod(BPNetwork bpn,string mn)
        {
            MethodName = mn;
            Dic=new Dictionary<string,Method>();
            Dic.Add("Each", bpn.BackPropagation);            
            Dic.Add("All", bpn.BackPropagationSum);
        }

        public void MethodInvoke()
        {
            Dic[MethodName].Invoke();
        }
    }
}