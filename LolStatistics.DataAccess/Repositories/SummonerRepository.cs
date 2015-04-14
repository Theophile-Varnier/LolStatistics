using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LolStatistics.DataAccess.Dao;
using LolStatistics.Model.App;
using MySql.Data.MySqlClient;

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
            DbConnection conn = new MySqlConnection();
            return summonerDao.Get(conn);
        }
    }
}
