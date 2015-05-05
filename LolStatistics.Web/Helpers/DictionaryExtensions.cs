using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LolStatistics.Web.Helpers
{
    public static class DictionaryExtensions
    {
        public static T2 GetOrDefault<T1, T2>(this Dictionary<T1, T2> dico, T1 key)
        {
            return dico.ContainsKey(key) ? dico[key] : default(T2);
        }
    }
}