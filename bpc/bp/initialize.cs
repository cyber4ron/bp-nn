using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bpc
{
    public abstract class Intializer
    {
        public List<Connection> Connections;

        public abstract void SetConnections(List<Connection> lc);

        public abstract void InitializeWeight();
    }

    public class RandomIntializer : Intializer
    {
        public Random rand;

        public RandomIntializer()
        {
            rand = new Random();
        }

        public override void SetConnections(List<Connection> lc)
        {
            Connections = lc;
        }

        public override void InitializeWeight()
        {
            foreach (Connection c in Connections)
            {
                c.Weight = 2 * rand.NextDouble() - 1;
            }
        }
    }

    public class IntializerDic
    {
        Dictionary<string, Type> Dic;

        public IntializerDic()
        {
            Dic = new Dictionary<string, Type>();
            Dic.Add("RandomIntializer", typeof(RandomIntializer));
        }

        public Intializer GetIntializer(string type)
        {
            Type t = Dic[type];
            return (Intializer)Activator.CreateInstance(t);
        }
    }
}
