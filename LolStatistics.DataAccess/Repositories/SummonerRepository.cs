using LolStatistics.DataAccess.Dao;
using LolStatistics.DataAccess.Extensions;
using LolStatistics.Model.App;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace LolStatistics.DataAccess.Repositories
{
    public class SummonerRepository: IRepository<Summoner>
    {
        private SummonerDao summonerDao = new SummonerDao();

        public void Insert(Summoner t)
        {
            throw new NotImplementedException();
        }

        public Summoner GetById(string id)
        {
            throw new NotImplementedException();
        }

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
