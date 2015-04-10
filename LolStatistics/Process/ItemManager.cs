using log4net;
using LolStatistics.Log;
using LolStatistics.Model.Static;
using LolStatistics.WebServiceConsumers;
using System.Configuration;

namespace LolStatistics.Process
{
    public class ItemManager : IManager
    {
        private readonly ILog logger = Logger.GetLogger(typeof(ItemManager));

        private WebServiceConsumer<ListOfItems> itemWebServiceConsumer;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public ItemManager()
        {
            itemWebServiceConsumer = new WebServiceConsumer<ListOfItems>(ConfigurationManager.AppSettings["GlobalApiUrl"], ConfigurationManager.AppSettings["GlobalApiUrl"]);
        }

        /// <summary>
        /// Fonction principale
        /// </summary>
        public void Execute()
        {
            logger.Info("Démarrage du traitement des items");
            // Récupération des items
            ListOfItems items = itemWebServiceConsumer.Consume();

            // Insertion en base
            foreach (Item item in items.Items)
            {
            }
            logger.Info("Fin du traitement des items");
        }
    }
}
