﻿using System;
using log4net;
using LolStatistics.Log;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace LolStatistics.WebServiceConsumers
{
    /// <summary>
    /// Classe générique de consommation de web service
    /// </summary>
    /// <typeparam name="T">Le type de données renvoyées par le web service</typeparam>
    public class WebServiceConsumer<T> where T : class
    {
        private static readonly ILog logger = Logger.GetLogger(typeof(WebServiceConsumer<T>));

        private readonly string WebServiceUri;

        private string BaseUri;

        private static DateTime LastCall { get; set; }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        /// <param name="baseUri">La base de l'url à appeler</param>
        /// <param name="webUri">Le web service à appeler</param>
        public WebServiceConsumer(string baseUri, string webUri)
        {
            if (baseUri == null)
            {
                throw new ArgumentException("baseUri");
            }
            if (webUri == null)
            {
                throw new ArgumentException("webUri");
            }

            BaseUri = baseUri;
            WebServiceUri = webUri;
            LastCall = DateTime.Now;
        }

        /// <summary>
        /// Récupération d'un objet à partir d'un webservice
        /// </summary>
        /// <param name="uriParameters">Les paramètres du web service</param>
        /// <param name="nbTentatives">Le nombre actuel de tentatives</param>
        /// <returns>L'objet retourné mappé</returns>
        public T Consume(Dictionary<string, string> uriParameters = null, int nbTentatives = 0)
        {
            if (ConfigurationManager.AppSettings["ApiKey"] == null)
            {
                throw new ArgumentException("ApiKey");
            }
            // Création de l'url à appeler
            string url = string.Concat(BaseUri, ReplaceParameters(WebServiceUri, uriParameters), WebServiceUri.Contains("?") ? "&" : "?", "api_key=", ConfigurationManager.AppSettings["ApiKey"]);
            logger.Info(string.Concat("Appel au WebService ", url));
            try
            {
                while ((DateTime.Now - LastCall).Seconds < 1)
                {

                }
                // Création de la requête
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

                // Appel au web service
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Lecture de la réponse et Désérialisation
                    Stream s = response.GetResponseStream();
                    using (StreamReader sr = new StreamReader(s, Encoding.UTF8))
                    {
                        T castResponse = JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
                        LastCall = DateTime.Now;
                        return castResponse;
                    }
                }
            }
            catch (WebException we)
            {
                switch (we.Status)
                {
                    case WebExceptionStatus.ProtocolError:
                        switch ((int)((HttpWebResponse)we.Response).StatusCode)
                        {
                            case 429:
                                // En cas d'erreur, on temporise avant de réessayer
                                // Jusqu'à un certain nombre de tentatives
                                if (nbTentatives >= 10)
                                {
                                    logger.Error("Nombre max de tentatives atteint. Mise à jour annulée.");
                                    return null;
                                }
                                logger.Info("Temporisation 10 secondes avant nouvel appel");
                                nbTentatives++;
                                Thread.Sleep(1000);
                                return Consume(uriParameters, nbTentatives + 1);
                            default:
                                logger.Error(string.Format("Erreur {0} lors de l'appel au webservice : {1}", we.Status, we.Message));
                                return null;
                        }
                    default:
                        logger.Error(string.Format("Erreur {0} lors de l'appel au webservice : {1}", we.Status, we.Message));
                        return null;
                }
            }
        }

        /// <summary>
        /// Modifie une uri pour mettre des valeurs à la place des paramètres
        /// </summary>
        /// <param name="baseUri">L'uri à modifier</param>
        /// <param name="values">Les paramètres à ajouter</param>
        /// <returns></returns>
        private string ReplaceParameters(string baseUri, Dictionary<string, string> values)
        {
            string finalUri = baseUri;
            if (values != null)
            {
                string paramPattern = @"({[A-z]*})";

                // Récupération de tous les paramètres présents dans l'uri
                MatchCollection matches = Regex.Matches(baseUri, paramPattern);

                // Remplacement par les valeurs fournies
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
