using System.Configuration;
using LolStatistics.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LolStatistics.DataAccess.Cache
{
    public static class LolCache
    {
        public static HashSet<long> RegisteredGames { get; set; }

        public static HashSet<Tuple<long, long>> RegisteredStats { get; set; }

        public static bool UseCache { get; set; }

        private static RankedGameRepository rankedGameRepository = new RankedGameRepository();

        /// <summary>
        /// Initialisation du cache
        /// </summary>
        public static void Init()
        {
            UseCache = bool.Parse(ConfigurationManager.AppSettings["UseLolCache"]);
            // Les games sont déjà uniques en base par construction de la table
            RegisteredGames = new HashSet<long>(rankedGameRepository.GetAllGames().Select(g => g.MatchId));

            // Idem
            RegisteredStats = new HashSet<Tuple<long, long>>(rankedGameRepository.GetAllParticipants().Select(m => new Tuple<long, long>(m.MatchId, m.ParticipantId)));
        }
    }
}
