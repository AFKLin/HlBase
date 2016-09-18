using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Core.Infrastructure
{
    public class Singleton<T> :Singleton
    {
        static T _instance;
        public static T Instance
        {
            get
            {
                return _instance;
            }
            set
            {
                AllSingletonInstance[typeof(T)] = value;
                _instance = value;
            }
        }
    }


    public class Singleton
    {
        static readonly IDictionary<Type, object> _allSingletonInstance;
        static Singleton()
        {
            _allSingletonInstance = new Dictionary<Type, object>();
        }

        public static IDictionary<Type,object> AllSingletonInstance { get; set; }
    }
}
