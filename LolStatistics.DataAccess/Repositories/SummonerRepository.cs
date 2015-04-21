using LolStatistics.DataAccess.Dao;
using LolStatistics.DataAccess.Extensions;
using LolStatistics.Model.App;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace LolStatistics.DataAccess.Repositories
{
    /// <summary>
    /// Respository associé aux invocateurs
    /// </summary>
    public class SummonerRepository: IRepository<Summoner>
    {
        private readonly SummonerDao summonerDao = new SummonerDao();

        /// <summary>
        /// Insert un invocateur en base
        /// </summary>
        /// <param name="t"></param>
        public void Insert(Summoner t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Récupère un invocateur par son id
        /// </summary>
        /// <param name="id">l'id de l'invocateur à récupérer</param>
        /// <returns></returns>
        public Summoner GetById(long id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Récupère la liste des invocateurs enregistrés
        /// </summary>
        /// <returns></returns>
        public IList<Summoner> Get()
        {
            using (DbConnection conn = Command.GetConnexion())
            {
                try
                {
                    conn.Open();
                    return summonerDao.Get(conn);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
