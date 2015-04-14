using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LolStatistics.DataAccess.Dao;
using LolStatistics.Model.Static;
using MySql.Data.MySqlClient;

namespace LolStatistics.DataAccess.Repositories
{
    public class ChampionRepository: IRepository<Champion>
    {
        ChampionDao championDao = new ChampionDao();

        public void Insert(Champion t)
        {
            DbConnection conn = new MySqlConnection();
            DbTransaction tran = null;
            championDao.Insert(t, conn, tran);
        }

        public Champion GetById(string id)
        {
            DbConnection conn = new MySqlConnection();
            return championDao.GetById(id, conn);
        }

        public List<Champion> GetAllChampions()
        {
            DbConnection conn = new MySqlConnection();
            return championDao.GetAllChampions(conn);
        }
    }
}
