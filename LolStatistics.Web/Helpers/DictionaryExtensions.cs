using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LolStatistics.WebServiceConsumers;

namespace LolStatistics.Web.Helpers
{
    public static class DictionaryExtensions
    {
        public static T2 GetOrDefault<T1, T2>(this Dictionary<T1, T2> dico, T1 key)
        {
            return dico.ContainsKey(key) ? dico[key] : default(T2);
        }

        public static T2 GetOrRetrieve<T1, T2, TWeb>(this Dictionary<T1, T2> dico, T1 key, WebServiceConsumer<TWeb> webServiceConsumer, Dictionary<string, string> parameters, Func<TWeb, T2> GetResult ) where TWeb : class
        {
            // On regarde si l'information est déjà présente
            if (dico.ContainsKey(key))
            {
                return dico[key];
            }
            // sinon on va la chercher via un web service
            T2 res = GetResult(webServiceConsumer.Consume(parameters));
            dico.Add(key, res);
            return res;
        }
    }
}