﻿using log4net;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text.RegularExpressions;
using System.Threading;

namespace LolStatistics.WebServiceConsumers
{
    public class WebServiceConsumer<T> where T : class
    {
        private static readonly ILog logger = Logger.GetLogger(typeof(WebServiceConsumer<T>));

        private string WebServiceUri;

        protected string baseUri = ConfigurationManager.AppSettings["BaseApiUrl"];

        private int nbTentatives;

        public WebServiceConsumer(string webUri)
        {
            WebServiceUri = webUri;
            nbTentatives = 0;
        }

        public T Consume(Dictionary<string, string> uriParameters)
        {
            string url = string.Concat(baseUri, ReplaceParameters(WebServiceUri, uriParameters), "?api_key=", ConfigurationManager.AppSettings["ApiKey"]);
            logger.Info(string.Concat("Appel au WebService ", url));
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
                    T castResponse = jsonSerializer.ReadObject(response.GetResponseStream()) as T;
                    nbTentatives = 0;
                    return castResponse;
                }
            }
            catch (WebException we)
            {
                if (nbTentatives >= 10)
                {
                    logger.Error("Nombre max de tentatives atteint. Mise à jour annulée.");
                    return null;
                }
                logger.Warn(string.Format("Erreur {0} lors de l'appel au webservice : {1}", we.Status, we.Message));
                logger.Info("Temporisation 10 secondes avant nouvel appel");
                nbTentatives++;
                Thread.Sleep(10000);
                return Consume(uriParameters);
            }
        }

        private string ReplaceParameters(string baseUri, Dictionary<string, string> values)
        {
            string finalUri = baseUri;
            if (values != null)
            {
                string paramPattern = @"({[A-z]*})";
                MatchCollection matches = Regex.Matches(baseUri, paramPattern);
                foreach (Match match in matches)
                {
                    string arg = match.Groups[1].Value;
                    finalUri = finalUri.Replace(arg, values[arg.Replace("{", string.Empty).Replace("}", string.Empty)]);
                }
            }
            return finalUri;
        }
    }
}